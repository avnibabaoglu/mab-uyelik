(function ($) {
	var _ilService = abp.services.app.il,
		l = abp.localization.getSource('Uyelik'),
		_$modal = $('#IlCreateModal'),
		_$form = _$modal.find('form'),
		_$table = $('#IlTable');

	var _$ilTable = _$table.DataTable({
		paging: true,
		serverSide: true,
		ajax: function (data, callback, settings) {
			var filter = $('#IlSearchForm').serializeFormToObject(true);
			filter.maxResultCount = data.length;
			filter.skipCount = data.start;

			abp.ui.setBusy(_$table);
			_ilService.getAll(filter).done(function (result) {
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
				action: () => _$ilTable.draw(false)
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
				data: 'plakaKodu',
				sortable: false
			},
			{
				targets: 4,
				data: 'ulkeAdi',
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
						`   <button type="button" class="btn btn-sm bg-secondary edit-il" data-il-id="${row.id}" data-toggle="modal" data-target="#IlEditModal">`,
						`       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
						'   </button>',
						`   <button type="button" class="btn btn-sm bg-danger delete-il" data-il-id="${row.id}" data-il-name="${row.ad}">`,
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
		var il = _$form.serializeFormToObject();

		abp.ui.setBusy(_$modal);
		_ilService.create(il).done(function () {
			_$modal.modal('hide');
			_$form[0].reset();
			abp.notify.info(l('SavedSuccessfully'));
			_$ilTable.ajax.reload();
		}).always(function () {
			abp.ui.clearBusy(_$modal);
		});
	});

	$(document).on('click', '.delete-il', function () {
		var ilId = $(this).attr("data-il-id");
		var ilName = $(this).attr('data-il-name');

		deleteIl(ilId, ilName);
	});

	function deleteIl(ilId, ilName) {
		abp.message.confirm(
			abp.utils.formatString(
				l('AreYouSureWantToDelete'),
				ilName),
			null,
			(isConfirmed) => {
				if (isConfirmed) {
					_ilService.delete({
						id: ilId
					}).done(() => {
						abp.notify.info(l('SuccessfullyDeleted'));
						_$ilTable.ajax.reload();
					});
				}
			}
		);
	}

	$(document).on('click', '.edit-il', function (e) {
		var ilId = $(this).attr("data-il-id");

		e.preventDefault();
		abp.ajax({
			url: abp.appPath + 'Il/EditModal?ilId=' + ilId,
			type: 'POST',
			dataType: 'html',
			success: function (content) {
				$('#IlEditModal div.modal-content').html(content);
			},
			error: function (e) { }
		});
	});

	abp.event.on('il.edited', (data) => {
		_$ilTable.ajax.reload();
	});

	_$modal.on('shown.bs.modal', () => {
		_$modal.find('input:not([type=hidden]):first').focus();
	}).on('hidden.bs.modal', () => {
		_$form.clearForm();
	});

	$('.btn-search').on('click', (e) => {
		_$ilTable.ajax.reload();
	});

	$('.txt-search').on('keypress', (e) => {
		if (e.which == 13) {
			_$ilTable.ajax.reload();
			return false;
		}
	});
})(jQuery);