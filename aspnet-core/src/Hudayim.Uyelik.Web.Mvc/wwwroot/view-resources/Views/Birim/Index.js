(function ($) {
	var _birimService = abp.services.app.birim,
		l = abp.localization.getSource('Uyelik'),
		_$modal = $('#BirimCreateModal'),
		_$form = _$modal.find('form'),
		_$table = $('#BirimTable');

	var _$birimTable = _$table.DataTable({
		paging: true,
		serverSide: true,
		ajax: function (data, callback, settings) {
			var filter = $('#BirimSearchForm').serializeFormToObject(true);
			filter.maxResultCount = data.length;
			filter.skipCount = data.start;

			abp.ui.setBusy(_$table);
			_birimService.getAll(filter).done(function (result) {
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
				action: () => _$birimTable.draw(false)
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
				data: 'aktifMi',
				sortable: false,
				render: data => `<input type="checkbox" disabled ${data ? 'checked' : ''}>`
			},
			{
				targets: 4,
				data: 'platformMu',
				sortable: false,
				render: data => `<input type="checkbox" disabled ${data ? 'checked' : ''}>`
			},
			{
				targets: 5,
				data: null,
				sortable: false,
				autoWidth: false,
				defaultContent: '',
				render: (data, type, row, meta) => {
					return [
						`   <button type="button" class="btn btn-sm bg-secondary edit-birim" data-birim-id="${row.id}" data-toggle="modal" data-target="#BirimEditModal">`,
						`       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
						'   </button>',
						`   <button type="button" class="btn btn-sm bg-danger delete-birim" data-birim-id="${row.id}" data-birim-name="${row.ad}">`,
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
		var birim = _$form.serializeFormToObject();

		abp.ui.setBusy(_$modal);
		_birimService.create(birim).done(function () {
			_$modal.modal('hide');
			_$form[0].reset();
			abp.notify.info(l('SavedSuccessfully'));
			_$birimTable.ajax.reload();
		}).always(function () {
			abp.ui.clearBusy(_$modal);
		});
	});

	$(document).on('click', '.delete-birim', function () {
		var birimId = $(this).attr("data-birim-id");
		var birimName = $(this).attr('data-birim-name');

		deleteBirim(birimId, birimName);
	});

	function deleteBirim(birimId, birimName) {
		abp.message.confirm(
			abp.utils.formatString(
				l('AreYouSureWantToDelete'),
				birimName),
			null,
			(isConfirmed) => {
				if (isConfirmed) {
					_birimService.delete({
						id: birimId
					}).done(() => {
						abp.notify.info(l('SuccessfullyDeleted'));
						_$birimTable.ajax.reload();
					});
				}
			}
		);
	}

	$(document).on('click', '.edit-birim', function (e) {
		debugger;
		var birimId = $(this).attr("data-birim-id");

		e.preventDefault();
		abp.ajax({
			url: abp.appPath + 'Birim/EditModal?birimId=' + birimId,
			type: 'POST',
			dataType: 'html',
			success: function (content) {
				$('#BirimEditModal div.modal-content').html(content);
			},
			error: function (e) { }
		});
	});

	abp.event.on('birim.edited', (data) => {
		_$birimTable.ajax.reload();
	});

	_$modal.on('shown.bs.modal', () => {
		_$modal.find('input:not([type=hidden]):first').focus();
	}).on('hidden.bs.modal', () => {
		_$form.clearForm();
	});

	$('.btn-search').on('click', (e) => {
		_$birimTable.ajax.reload();
	});

	$('.txt-search').on('keypress', (e) => {
		if (e.which == 13) {
			_$birimTable.ajax.reload();
			return false;
		}
	});
})(jQuery);
