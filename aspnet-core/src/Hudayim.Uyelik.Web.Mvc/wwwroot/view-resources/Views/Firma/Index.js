(function ($) {
	var _firmaService = abp.services.app.firma,
		l = abp.localization.getSource('Uyelik'),
		_$modal = $('#FirmaCreateModal'),
		_$form = _$modal.find('form'),
		_$table = $('#FirmaTable');

	var _$firmaTable = _$table.DataTable({
		paging: true,
		serverSide: true,
		ajax: function (data, callback, settings) {
			var filter = $('FirmaSearchForm').serializeFormToObject(true);
			filter.maxResultCount = data.length;
			filter.skipCount = data.start;

			abp.ui.setBusy(_$table);
			_firmaService.getAll(filter).done(function (result) {
				callback({
					recordsTotal: result.totalCount,
					recordsFiltered: result.totalCount,
					data: result.items
				});
			}).always(function () {
				abp.ui.clearBusy(_$table);
			});
		},
		buttons: [
			{
				name: 'refresh',
				text: '<i class="fas fa-redo-alt"></i>',
				action: () => _$firmaTable.draw(false)
			}
		],
		responsive: {
			details: {
				type: 'column'
			}
		},
		columnDefs: [
			{
				targets: 0,
				className: 'control',
				defaultContent: '',
			},
			{
				targets: 1,
				data: 'resimTamYolu',
				sortable: false
			},
			{
				targets: 1,
				data: 'resimTamYolu',
				sortable: false,
				render: function (data) {
					if (data != undefined && data != null && data != '') {
						return label = '<img class="img-bordered img-thumbnail img-responsive" width="100px" src="' + data + '" />';
					} else {
						return label = '<div class="text-center"><i class="far fa-building fa-4x"></i></div>';
					}
				}
			},
			{
				targets: 2,
				data: 'ad',
				sortable: false
			},
			{
				targets: 3,
				data: 'webAdresi',
				sortable: false
			},
			{
				targets: 4,
				data: 'mail',
				sortable: false
			},
			{
				targets: 5,
				data: 'telefon',
				sortable: false
			},
			{
				targets: 6,
				data: 'adres',
				sortable: false
			},
			{
				targets: 7,
				data: 'siraNo',
				sortable: false
			},
			{
				targets: 8,
				data: 'ilAdi',
				sortable: false
			},
			{
				targets: 9,
				data: 'kategoriAdi',
				sortable: false
			},
			{
				targets: 10,
				data: null,
				sortable: false,
				autoWidth: false,
				defaultContent: '',
				render: (data, type, row, meta) => {
					return [
						`   <button type="button" class="btn btn-sm bg-secondary edit-firma" data-firma-id="${row.id}" data-toggle="modal" data-target="#FirmaEditModal">`,
						`       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
						'   </button>',
						`   <button type="button" class="btn btn-sm bg-danger delete-firma" data-firma-id="${row.id}" data-firma-name="${row.ad}">`,
						`       <i class="fas fa-trash"></i> ${l('Delete')}`,
						'   </button>'
					].join('');
				}
			}
		]
	});

	_$form.find('.save-button').on('click', (e) => {
		e.preventDefault();

		if (!_$form.valid()) {
			return;
		}
		var firma = _$form.serializeFormToObject();

		var resultFileUpload;
		var file = _$form[0].fileUpload.files[0];
		if (file != undefined && file != null) {
			var formData = new FormData();
			formData.append("dosya", file);
			formData.append("firmaAdi", ReplaceSlugify(firma.Ad));

			abp.ajax({
				type: "POST",
				url: '/Firma/FileUpload',
				data: formData,
				processData: false,
				contentType: false,
				traditional: true,
				async: false,
			}).done(function (result) {
				debugger;
				if (result.success == true) {
					if (result.data != null) {
						resultFileUpload = result.data;
					} else {
						abp.notify.error("Ek yükleme işlemi başarısız. Lütfen tekrar deneyiniz.");
					}
				} else {
					abp.notify.error(result.message);
				}
			}).fail(function (jqXHR) {
				abp.notify.error("Ek kaydetme işlemi başarısız. Lütfen tekrar deneyiniz..");
			});
		}
		debugger;
		if (resultFileUpload != undefined && resultFileUpload != null) {
			firma.ResimYolu = resultFileUpload.item1;
			firma.ResimAdi = resultFileUpload.item2;
		}

		abp.ui.setBusy(_$modal);
		_firmaService.create(firma).done(function () {
			_$modal.modal('hide');
			_$form[0].reset();
			abp.notify.info(l('SavedSuccessfully'));
			_$firmaTable.ajax.reload();
		}).always(function () {
			abp.ui.clearBusy(_$modal);
		});
	});

	$(document).on('click', '.delete-firma', function () {
		var firmaId = $(this).attr("data-firma-id");
		var firmaName = $(this).attr('data-firma-name');

		deleteFirma(firmaId, firmaName);
	});

	function deleteFirma(firmaId, firmaName) {
		abp.message.confirm(
			abp.utils.formatString(
				l('AreYouSureWantToDelete'),
				firmaName),
			null,
			(isConfirmed) => {
				if (isConfirmed) {
					_firmaService.delete({
						id: firmaId
					}).done(() => {
						abp.notify.info(l('SuccessfullyDeleted'));
						_$firmaTable.ajax.reload();
					});
				}
			}
		);
	}

	$(document).on('click', '.edit-firma', function (e) {
		var firmaId = $(this).attr("data-firma-id");

		e.preventDefault();
		abp.ajax({
			url: abp.appPath + 'Firma/EditModal?firmaId=' + firmaId,
			type: 'POST',
			dataType: 'html',
			success: function (content) {
				$('#FirmaEditModal div.modal-content').html(content);
			},
			error: function (e) { }
		});
	});

	abp.event.on('firma.edited', (data) => {
		_$firmaTable.ajax.reload();
	});

	_$modal.on('shown.bs.modal', () => {
		_$modal.find('input:not([type=hidden]):first').focus();
	}).on('hidden.bs.modal', () => {
		_$form.clearForm();
	});

	$('.btn-search').on('click', (e) => {
		_$firmaTable.ajax.reload();
	});

	$('.txt-search').on('keypress', (e) => {
		if (e.which == 13) {
			_$firmaTable.ajax.reload();
			return false;
		}
	});

	function ReplaceSlugify(value) {
		var retval;
		retval = value.replace(/[\. , ':-]+/g, "-").toLowerCase()
			.replace(/Ğ/g, "g")
			.replace(/Ü/g, "u")
			.replace(/Ş/g, "s")
			.replace(/I/g, "i")
			.replace(/İ/g, "i")
			.replace(/Ö/g, "o")
			.replace(/Ç/g, "c")
			.replace(/ğ/g, "g")
			.replace(/ü/g, "u")
			.replace(/ş/g, "s")
			.replace(/ı/g, "i")
			.replace(/ö/g, "o")
			.replace(/ç/g, "c");
		return retval;
	}
})(jQuery);