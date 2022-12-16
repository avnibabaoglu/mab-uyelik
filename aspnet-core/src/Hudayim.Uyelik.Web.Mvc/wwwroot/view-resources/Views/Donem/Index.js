(function ($) {
	var _donemService = abp.services.app.donem,
		l = abp.localization.getSource('Uyelik'),
		_$modal = $('#DonemCreateModal'),
		_$form = _$modal.find('form'),
		_$table = $('#DonemTable');

	var _$donemTable = _$table.DataTable({
		paging: true,
		serverSide: true,
		ajax: function (data, callback, settings) {
			var filter = $('#DonemSearchForm').serializeFormToObject(true);
			filter.maxResultCount = data.length;
			filter.skipCount = data.start;

			abp.ui.setBusy(_$table);
			_donemService.getAll(filter).done(function (result) {
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
				action: () => _$donemTable.draw(false)
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
				data: 'donemTuruAdi',
				sortable: false
			},
			{
				targets: 2,
				data: 'ad',
				sortable: false
			},
			{
				targets: 3,
				data: 'siraNo',
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
				data: 'aktifMi',
				sortable: false,
				render: data => `<input type="checkbox" disabled ${data ? 'checked' : ''}>`
			},
			{
				targets: 7,
				data: null,
				sortable: false,
				autoWidth: false,
				defaultContent: '',
				render: (data, type, row, meta) => {
					return [
						`   <button type="button" class="btn btn-sm bg-secondary edit-donem" data-donem-id="${row.id}" data-toggle="modal" data-target="#DonemEditModal">`,
						`       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
						'   </button>',
						`   <button type="button" class="btn btn-sm bg-danger delete-donem" data-donem-id="${row.id}" data-donem-name="${row.ad}">`,
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
		var donem = _$form.serializeFormToObject();

		abp.ui.setBusy(_$modal);
		_donemService.create(donem).done(function () {
			_$modal.modal('hide');
			_$form[0].reset();
			abp.notify.info(l('SavedSuccessfully'));
			_$donemTable.ajax.reload();
		}).always(function () {
			abp.ui.clearBusy(_$modal);
		});
	});

	$(document).on('click', '.delete-donem', function () {
		var donemId = $(this).attr("data-donem-id");
		var donemName = $(this).attr('data-donem-name');

		deleteDonem(donemId, donemName);
	});

	function deleteDonem(donemId, donemName) {
		abp.message.confirm(
			abp.utils.formatString(
				l('AreYouSureWantToDelete'),
				donemName),
			null,
			(isConfirmed) => {
				if (isConfirmed) {
					_donemService.delete({
						id: donemId
					}).done(() => {
						abp.notify.info(l('SuccessfullyDeleted'));
						_$donemTable.ajax.reload();
					});
				}
			}
		);
	}

	$(document).on('click', '.edit-donem', function (e) {
		debugger;
		var donemId = $(this).attr("data-donem-id");

		e.preventDefault();
		abp.ajax({
			url: abp.appPath + 'Donem/EditModal?donemId=' + donemId,
			type: 'POST',
			dataType: 'html',
			success: function (content) {
				$('#DonemEditModal div.modal-content').html(content);
			},
			error: function (e) { }
		});
	});

	abp.event.on('donem.edited', (data) => {
		_$donemTable.ajax.reload();
	});

	_$modal.on('shown.bs.modal', () => {
		_$modal.find('input:not([type=hidden]):first').focus();
	}).on('hidden.bs.modal', () => {
		_$form.clearForm();
	});

	$('.btn-search').on('click', (e) => {
		_$donemTable.ajax.reload();
	});

	$('.txt-search').on('keypress', (e) => {
		if (e.which == 13) {
			_$donemTable.ajax.reload();
			return false;
		}
	});
})(jQuery);
