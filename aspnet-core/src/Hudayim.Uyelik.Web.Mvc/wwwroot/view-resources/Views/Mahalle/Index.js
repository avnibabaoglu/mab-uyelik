(function ($) {
	var _mahalleService = abp.services.app.mahalle,
		l = abp.localization.getSource('Uyelik'),
		_$modal = $('#MahalleCreateModal'),
		_$form = _$modal.find('form'),
		_$table = $('#MahalleTable');

	var _$mahalleTable = _$table.DataTable({
		paging: true,
		serverSide: true,
		ajax: function (data, callback, settings) {
			var filter = $('#MahalleSearchForm').serializeFormToObject(true);
			filter.maxResultCount = data.length;
			filter.skipCount = data.start;

			abp.ui.setBusy(_$table);
			_mahalleService.getAll(filter).done(function (result) {
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
				action: () => _$mahalleTable.draw(false)
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
				data: 'ilceAdi',
				sortable: false
			},
			{
				targets: 6,
				data: null,
				sortable: false,
				autoWidth: false,
				defaultContent: '',
				render: (data, type, row, meta) => {
					return [
						`   <button type="button" class="btn btn-sm bg-secondary edit-mahalle" data-mahalle-id="${row.id}" data-toggle="modal" data-target="#MahalleEditModal">`,
						`       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
						'   </button>',
						`   <button type="button" class="btn btn-sm bg-danger delete-mahalle" data-mahalle-id="${row.id}" data-mahalle-name="${row.ad}">`,
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
		var mahalle = _$form.serializeFormToObject();

		abp.ui.setBusy(_$modal);
		_mahalleService.create(mahalle).done(function () {
			_$modal.modal('hide');
			_$form[0].reset();
			abp.notify.info(l('SavedSuccessfully'));
			_$mahalleTable.ajax.reload();
		}).always(function () {
			abp.ui.clearBusy(_$modal);
		});
	});

	$(document).on('click', '.delete-mahalle', function () {
		var mahalleId = $(this).attr("data-mahalle-id");
		var mahalleName = $(this).attr('data-mahalle-name');

		deleteMahalle(mahalleId, mahalleName);
	});

	function deleteMahalle(mahalleId, mahalleName) {
		abp.message.confirm(
			abp.utils.formatString(
				l('AreYouSureWantToDelete'),
				mahalleName),
			null,
			(isConfirmed) => {
				if (isConfirmed) {
					_mahalleService.delete({
						id: mahalleId
					}).done(() => {
						abp.notify.info(l('SuccessfullyDeleted'));
						_$mahalleTable.ajax.reload();
					});
				}
			}
		);
	}

	$(document).on('click', '.edit-mahalle', function (e) {
		var mahalleId = $(this).attr("data-mahalle-id");

		e.preventDefault();
		abp.ajax({
			url: abp.appPath + 'Mahalle/EditModal?mahalleId=' + mahalleId,
			type: 'POST',
			dataType: 'html',
			success: function (content) {
				$('#MahalleEditModal div.modal-content').html(content);
			},
			error: function (e) { }
		});
	});

	abp.event.on('mahalle.edited', (data) => {
		_$mahalleTable.ajax.reload();
	});

	_$modal.on('shown.bs.modal', () => {
		_$modal.find('input:not([type=hidden]):first').focus();
	}).on('hidden.bs.modal', () => {
		_$form.clearForm();
	});

	$('.btn-search').on('click', (e) => {
		_$mahalleTable.ajax.reload();
	});

	$('.txt-search').on('keypress', (e) => {
		if (e.which == 13) {
			_$mahalleTable.ajax.reload();
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
				url: '/Mahalle/GetIller',
				data: postData,
				dataType: "json",
				traditional: true
			}).done(function (result) {
				if (result.result.length > 0) {
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

	_$form.find('#ilId').on('change', function (e) {
		var selectedIndex = _$form.find('#ilId').val();
		if (selectedIndex != undefined && selectedIndex != '') {
			var postData = { ilId: selectedIndex };
			var $ValueList = _$form.find('#ilceId');

			$.ajax({
				type: "POST",
				url: '/Mahalle/GetIlceler',
				data: postData,
				dataType: "json",
				traditional: true
			}).done(function (result) {
				$ValueList.find('option').remove().end();
				$ValueList.append('<option value="">Seçiniz</option>');
				if (result.result.length > 0) {
					$.each(result.result, function (i, o) {
						$ValueList.append('<option value=' + o.value + '>' + o.text + '</option>')
					});
				} else {
					abp.notify.info("Seçilen ile bağlı ilçe bilgisi bulunamadı.");
				}
			}).fail(function (jqXHR) {
				abp.notify.error("İlçe bilgisi getirilirken hata oluştu..");
			});
		}
	});

	function IlListesiTemizleme() {
		var $ValueListCity = $('#ilId');
		$ValueListCity.find('option').remove().end();
	}

	function IlceListesiTemizleme() {
		var $ValueListCounty = $('#ilceId');
		$ValueListCounty.find('option').remove().end();
	}

	function MahalleListesiTemizleme() {
		var $ValueListDistrict = $('#mahalleId');
		$ValueListDistrict.find('option').remove().end();
	}

})(jQuery);