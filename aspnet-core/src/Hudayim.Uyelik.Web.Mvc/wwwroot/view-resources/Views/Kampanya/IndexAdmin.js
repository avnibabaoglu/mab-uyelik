(function ($) {
	var _kampanyaService = abp.services.app.kampanya,
		l = abp.localization.getSource('Uyelik'),
		_$modal = $('#KampanyaCreateModal'),
		_$form = _$modal.find('form'),
		_$table = $('#KampanyaTable');

	var _$kampanyaTable = _$table.DataTable({
		paging: true,
		serverSide: true,
		ajax: function (data, callback, settings) {
			var filter = $('KampanyaSearchForm').serializeFormToObject(true);
			filter.maxResultCount = data.length;
			filter.skipCount = data.start;

			abp.ui.setBusy(_$table);
			_kampanyaService.getAll(filter).done(function (result) {
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
				action: () => _$kampanyaTable.draw(false)
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
				sortable: false,
				render: function (data) {
					if (data != undefined && data != null && data != '') {
						return label = '<img class="img-bordered img-thumbnail img-responsive" width="100px" src="' + data + '" />';
					} else {
						return label = '<div class="text-center"><i class="fas fa-bullhorn fa-4x"></i></div>';
					}
				}
			},
			{
				targets: 2,
				data: 'firmaAdi',
				sortable: false
			},
			{
				targets: 3,
				data: 'ad',
				sortable: false
			},
			{
				targets: 4,
				data: 'baslangicTarihi',
				sortable: false,
				render: function (data) {
					if (data != null && data != undefined) {
						return moment(data).format('DD.MM.YYYY');
					}
					else {
						return "-";
					}
				}
			},
			{
				targets: 5,
				data: 'bitisTarihi',
				sortable: false,
				render: function (data) {
					if (data != null && data != undefined) {
						return moment(data).format('DD.MM.YYYY');
					}
					else {
						return "-";
					}
				}
			},
			{
				targets: 6,
				data: 'siraNo',
				sortable: false
			},
			{
				targets: 7,
				data: 'indirimOrani',
				sortable: false,
				render: function (data) {
					if (data != undefined && data != null && data != '') {
						return label = '<i class= "fas fa-percentage"></i>&nbsp;' + data + '';
					} else {
						return label = '<span>-</span>';
					}
				}
			},
			{
				targets: 8,
				data: 'aciklama',
				sortable: false
			},
			{
				targets: 9,
				data: null,
				sortable: false,
				autoWidth: false,
				defaultContent: '',
				render: (data, type, row, meta) => {
					return [
						`   <button type="button" class="btn btn-sm bg-secondary edit-kampanya" data-kampanya-id="${row.id}" data-toggle="modal" data-target="#KampanyaEditModal">`,
						`       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
						'   </button>',
						`   <button type="button" class="btn btn-sm bg-danger delete-kampanya" data-kampanya-id="${row.id}" data-kampanya-name="${row.ad}">`,
						`       <i class="fas fa-trash"></i> ${l('Delete')}`
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
		var kampanya = _$form.serializeFormToObject();

		debugger;
		var resultFileUpload;
		var file = _$form[0].fileUpload.files[0];
		if (file != undefined && file != null) {
			var formData = new FormData();
			formData.append("dosya", file);
			formData.append("kampanyaAdi", ReplaceSlugify(kampanya.Ad));

			abp.ajax({
				type: "POST",
				url: '/Kampanya/FileUpload',
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
			kampanya.ResimYolu = resultFileUpload.item1;
			kampanya.ResimAdi = resultFileUpload.item2;
		}

		abp.ui.setBusy(_$modal);
		_kampanyaService.create(kampanya).done(function () {
			_$modal.modal('hide');
			_$form[0].reset();
			abp.notify.info(l('SavedSuccessfully'));
			_$kampanyaTable.ajax.reload();
		}).always(function () {
			abp.ui.clearBusy(_$modal);
		});
	});

	$(document).on('click', '.delete-kampanya', function () {
		var kampanyaId = $(this).attr("data-kampanya-id");
		var kampanyaName = $(this).attr('data-kampanya-name');

		deleteKampanya(kampanyaId, kampanyaName);
	});

	function deleteKampanya(kampanyaId, kampanyaName) {
		abp.message.confirm(
			abp.utils.formatString(l('AreYouSureWantToDelete'), kampanyaName),
			null,
			(isConfirmed) => {
				if (isConfirmed) {
					_kampanyaService.delete({
						id: kampanyaId
					}).done(() => {
						abp.notify.info(l('SuccessfullyDeleted'));
						_$kampanyaTable.ajax.reload();
					});
				}
			}
		);
	}

	$(document).on('click', '.edit-kampanya', function (e) {
		var kampanyaId = $(this).attr("data-kampanya-id");

		e.preventDefault();
		abp.ajax({
			url: abp.appPath + 'Kampanya/EditModal?kampanyaId=' + kampanyaId,
			type: 'POST',
			dataType: 'html',
			success: function (content) {
				$('#KampanyaEditModal div.modal-content').html(content);
			},
			error: function (e) { }
		});
	});

	abp.event.on('kampanya.edited', (data) => {
		_$kampanyaTable.ajax.reload();
	});

	_$modal.on('shown.bs.modal', () => {
		_$modal.find('input:not([type=hidden]):first').focus();
	}).on('hidden.bs.modal', () => {
		_$form.clearForm();
	});

	$('.btn-search').on('click', (e) => {
		_$kampanyaTable.ajax.reload();
	});

	$('.txt-search').on('keypress', (e) => {
		if (e.which == 13) {
			_$kampanyaTable.ajax.reload();
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
			.replace(/ç/g, "c")
			.replace(/%+/g, '');

		return retval;
	}
})(jQuery);