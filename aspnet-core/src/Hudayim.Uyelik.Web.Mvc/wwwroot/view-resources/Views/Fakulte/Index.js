(function ($) {
	var _fakulteService = abp.services.app.fakulte,
		l = abp.localization.getSource('Uyelik'),
		_$modal = $('#FakulteCreateModal'),
		_$form = _$modal.find('form'),
		_$table = $('#FakulteTable');

	var _$fakulteTable = _$table.DataTable({
		paging: true,
		serverSide: true,
		ajax: function (data, callback, settings) {
			var filter = $('#FakulteSearchForm').serializeFormToObject(true);
			filter.maxResultCount = data.length;
			filter.skipCount = data.start;

			abp.ui.setBusy(_$table);
			_fakulteService.getAll(filter).done(function (result) {
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
				action: () => _$fakulteTable.draw(false)
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
				data: 'aktifMi',
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
						`   <button type="button" class="btn btn-sm bg-secondary edit-fakulte" data-fakulte-id="${row.id}" data-toggle="modal" data-target="#FakulteEditModal">`,
						`       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
						'   </button>',
						`   <button type="button" class="btn btn-sm bg-danger delete-fakulte" data-fakulte-id="${row.id}" data-fakulte-name="${row.ad}">`,
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
		var fakulte = _$form.serializeFormToObject();

		abp.ui.setBusy(_$modal);
		_fakulteService.create(fakulte).done(function () {
			_$modal.modal('hide');
			_$form[0].reset();
			abp.notify.info(l('SavedSuccessfully'));
			_$fakulteTable.ajax.reload();
		}).always(function () {
			abp.ui.clearBusy(_$modal);
		});
	});

	$(document).on('click', '.delete-fakulte', function () {
		var fakulteId = $(this).attr("data-fakulte-id");
		var fakulteName = $(this).attr('data-fakulte-name');

		deleteFakulte(fakulteId, fakulteName);
	});

	function deleteFakulte(fakulteId, fakulteName) {
		abp.message.confirm(
			abp.utils.formatString(
				l('AreYouSureWantToDelete'),
				fakulteName),
			null,
			(isConfirmed) => {
				if (isConfirmed) {
					_fakulteService.delete({
						id: fakulteId
					}).done(() => {
						abp.notify.info(l('SuccessfullyDeleted'));
						_$fakulteTable.ajax.reload();
					});
				}
			}
		);
	}

	$(document).on('click', '.edit-fakulte', function (e) {
		var fakulteId = $(this).attr("data-fakulte-id");

		e.preventDefault();
		abp.ajax({
			url: abp.appPath + 'Fakulte/EditModal?fakulteId=' + fakulteId,
			type: 'POST',
			dataType: 'html',
			success: function (content) {
				$('#FakulteEditModal div.modal-content').html(content);
			},
			error: function (e) { }
		});
	});

	abp.event.on('fakulte.edited', (data) => {
		_$fakulteTable.ajax.reload();
	});

	_$modal.on('shown.bs.modal', () => {
		_$modal.find('input:not([type=hidden]):first').focus();
	}).on('hidden.bs.modal', () => {
		_$form.clearForm();
	});

	$('.btn-search').on('click', (e) => {
		_$fakulteTable.ajax.reload();
	});

	$('.txt-search').on('keypress', (e) => {
		if (e.which == 13) {
			_$fakulteTable.ajax.reload();
			return false;
		}
	});
})(jQuery);