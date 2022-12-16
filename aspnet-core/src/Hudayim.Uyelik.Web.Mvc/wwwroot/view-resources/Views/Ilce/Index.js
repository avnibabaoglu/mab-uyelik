(function ($) {
	var _ilceService = abp.services.app.ilce,
		l = abp.localization.getSource('Uyelik'),
		_$modal = $('#IlceCreateModal'),
		_$form = _$modal.find('form'),
		_$table = $('#IlceTable');

	var _$ilceTable = _$table.DataTable({
		paging: true,
		serverSide: true,
		ajax: function (data, callback, settings) {
			var filter = $('#IlceSearchForm').serializeFormToObject(true);
			filter.maxResultCount = data.length;
			filter.skipCount = data.start;

			abp.ui.setBusy(_$table);
			_ilceService.getAll(filter).done(function (result) {
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
				action: () => _$ilceTable.draw(false)
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
				data: 'ulkeAdi',
				sortable: false
			},
			{
				targets: 4,
				data: 'ilAdi',
				sortable: false
			},
			{
				targets: 5,
				data: null,
				sortable: false,
				autoWidth: false,
				defaultContent: '',
				render: (data, type, row, meta) => {
					return [
						`   <button type="button" class="btn btn-sm bg-secondary edit-ilce" data-ilce-id="${row.id}" data-toggle="modal" data-target="#IlceEditModal">`,
						`       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
						'   </button>',
						`   <button type="button" class="btn btn-sm bg-danger delete-ilce" data-ilce-id="${row.id}" data-ilce-name="${row.ad}">`,
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
		var ilce = _$form.serializeFormToObject();

		abp.ui.setBusy(_$modal);
		_ilceService.create(ilce).done(function () {
			_$modal.modal('hide');
			_$form[0].reset();
			abp.notify.info(l('SavedSuccessfully'));
			_$ilceTable.ajax.reload();
		}).always(function () {
			abp.ui.clearBusy(_$modal);
		});
	});

	$(document).on('click', '.delete-ilce', function () {
		var ilceId = $(this).attr("data-ilce-id");
		var ilceName = $(this).attr('data-ilce-name');

		deleteIlce(ilceId, ilceName);
	});

	function deleteIlce(ilceId, ilceName) {
		abp.message.confirm(
			abp.utils.formatString(
				l('AreYouSureWantToDelete'),
				ilceName),
			null,
			(isConfirmed) => {
				if (isConfirmed) {
					_ilceService.delete({
						id: ilceId
					}).done(() => {
						abp.notify.info(l('SuccessfullyDeleted'));
						_$ilceTable.ajax.reload();
					});
				}
			}
		);
	}

	$(document).on('click', '.edit-ilce', function (e) {
		var ilceId = $(this).attr("data-ilce-id");

		e.preventDefault();
		abp.ajax({
			url: abp.appPath + 'Ilce/EditModal?ilceId=' + ilceId,
			type: 'POST',
			dataType: 'html',
			success: function (content) {
				$('#IlceEditModal div.modal-content').html(content);
			},
			error: function (e) { }
		});
	});

	abp.event.on('ilce.edited', (data) => {
		_$ilceTable.ajax.reload();
	});

	_$modal.on('shown.bs.modal', () => {
		_$modal.find('input:not([type=hidden]):first').focus();
	}).on('hidden.bs.modal', () => {
		_$form.clearForm();
	});

	$('.btn-search').on('click', (e) => {
		_$ilceTable.ajax.reload();
	});

	$('.txt-search').on('keypress', (e) => {
		if (e.which == 13) {
			_$ilceTable.ajax.reload();
			return false;
		}
	});

	_$form.find('#ulkeId').on('change', function (e) {
		var selectedIndex = _$form.find('#ulkeId').val();
		if (selectedIndex != undefined && selectedIndex != '') {
			var postData = { ulkeId: selectedIndex };
			var $ValueList = _$form.find('#ilId');

			$.ajax({
				type: "POST",
				url: '/Ilce/GetIller',
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
					abp.notify.info("Seçilen ülkeye bağlı il bilgisi bulunamadı.");
				}
			}).fail(function (jqXHR) {
				abp.notify.error("İl bilgisi getirilirken hata oluştu..");
			});
		}
	});

	function IlListesiTemizleme() {
		var $ValueListCity = $('#ilId');
		$ValueListCity.find('option').remove().end();
	}

})(jQuery);