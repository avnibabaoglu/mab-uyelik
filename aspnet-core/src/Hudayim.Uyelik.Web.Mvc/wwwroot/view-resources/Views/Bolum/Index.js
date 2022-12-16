(function ($) {
	var _bolumService = abp.services.app.bolum,
		l = abp.localization.getSource('Uyelik'),
		_$modal = $('#BolumCreateModal'),
		_$form = _$modal.find('form'),
		_$table = $('#BolumTable');

	var _$bolumTable = _$table.DataTable({
		paging: true,
		serverSide: true,
		ajax: function (data, callback, settings) {
			var filter = $('#BolumSearchForm').serializeFormToObject(true);
			filter.maxResultCount = data.length;
			filter.skipCount = data.start;

			abp.ui.setBusy(_$table);
			_bolumService.getAll(filter).done(function (result) {
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
				action: () => _$bolumTable.draw(false)
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
				data: 'ad',
				sortable: false
			},
			{
				targets: 2,
				data: 'siraNo',
				sortable: false
			},
			{
				targets: 3,
				data: 'universiteAdi',
				sortable: false
			},
			{
				targets: 4,
				data: 'fakulteAdi',
				sortable: false
			},
			{
				targets: 5,
				data: 'aktifMi',
				sortable: false,
				render: data => `<input type="checkbox" disabled ${data ? 'checked' : ''}>`
			},
			{
				targets: 6,
				data: null,
				sortable: false,
				autoWidth: false,
				defaultContent: '',
				render: (data, type, row, meta) => {
					return [
						`   <button type="button" class="btn btn-sm bg-secondary edit-bolum" data-bolum-id="${row.id}" data-toggle="modal" data-target="#BolumEditModal">`,
						`       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
						'   </button>',
						`   <button type="button" class="btn btn-sm bg-danger delete-bolum" data-bolum-id="${row.id}" data-bolum-name="${row.ad}">`,
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
		var bolum = _$form.serializeFormToObject();

		abp.ui.setBusy(_$modal);
		_bolumService.create(bolum).done(function () {
			_$modal.modal('hide');
			_$form[0].reset();
			abp.notify.info(l('SavedSuccessfully'));
			_$bolumTable.ajax.reload();
		}).always(function () {
			abp.ui.clearBusy(_$modal);
		});
	});

	$(document).on('click', '.delete-bolum', function () {
		var bolumId = $(this).attr("data-bolum-id");
		var bolumName = $(this).attr('data-bolum-name');

		deleteBolum(bolumId, bolumName);
	});

	function deleteBolum(bolumId, bolumName) {
		abp.message.confirm(
			abp.utils.formatString(
				l('AreYouSureWantToDelete'),
				bolumName),
			null,
			(isConfirmed) => {
				if (isConfirmed) {
					_bolumService.delete({
						id: bolumId
					}).done(() => {
						abp.notify.info(l('SuccessfullyDeleted'));
						_$bolumTable.ajax.reload();
					});
				}
			}
		);
	}

	$(document).on('click', '.edit-bolum', function (e) {
		var bolumId = $(this).attr("data-bolum-id");

		e.preventDefault();
		abp.ajax({
			url: abp.appPath + 'Bolum/EditModal?bolumId=' + bolumId,
			type: 'POST',
			dataType: 'html',
			success: function (content) {
				$('#BolumEditModal div.modal-content').html(content);
			},
			error: function (e) { }
		});
	});

	abp.event.on('bolum.edited', (data) => {
		_$bolumTable.ajax.reload();
	});

	_$modal.on('shown.bs.modal', () => {
		_$modal.find('input:not([type=hidden]):first').focus();
	}).on('hidden.bs.modal', () => {
		_$form.clearForm();
	});

	$('.btn-search').on('click', (e) => {
		_$bolumTable.ajax.reload();
	});

	$('.txt-search').on('keypress', (e) => {
		if (e.which == 13) {
			_$bolumTable.ajax.reload();
			return false;
		}
	});

	_$form.find('#universiteId').on('change', function (e) {
		var selectedIndex = _$form.find('#universiteId').val();
		if (selectedIndex != undefined && selectedIndex != '') {
			var postData = { universiteId: selectedIndex };
			var $ValueList = _$form.find('#fakulteId');

			$.ajax({
				type: "POST",
				url: '/Bolum/GetFakulteler',
				data: postData,
				dataType: "json",
				traditional: true
			}).done(function (result) {
				if (result.result.length > 0) {
					$ValueList.find('option').remove().end();
					$ValueList.append('<option value="">Seçiniz</option>');
					$.each(result.result, function (i, o) {
						$ValueList.append('<option value=' + o.value + '>' + o.text + '</option>')
					});
				} else {
					abp.notify.info("Seçilen üniversiteye bağlı fakülte bilgisi bulunamadı.");
				}
			}).fail(function (jqXHR) {
				abp.notify.error("Fakülte bilgisi getirilirken hata oluştu..");
			});
		}
	});

	function FakulteListesiTemizleme() {
		var $ValueListCity = $('#fakulteId');
		$ValueListCity.find('option').remove().end();
	}

})(jQuery);