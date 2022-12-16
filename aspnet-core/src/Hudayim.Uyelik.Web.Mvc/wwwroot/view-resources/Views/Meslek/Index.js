(function ($) {
	var _meslekService = abp.services.app.meslek,
		l = abp.localization.getSource('Uyelik'),
		_$modal = $('#MeslekCreateModal'),
		_$form = _$modal.find('form'),
		_$table = $('#MeslekTable');

	var _$meslekTable = _$table.DataTable({
		paging: true,
		serverSide: true,
		ajax: function (data, callback, settings) {
			var filter = $('#MeslekSearchForm').serializeFormToObject(true);
			filter.maxResultCount = data.length;
			filter.skipCount = data.start;

			abp.ui.setBusy(_$table);
			_meslekService.getAll(filter).done(function (result) {
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
				action: () => _$meslekTable.draw(false)
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
				data: 'kod',
				sortable: false
			},
			{
				targets: 3,
				data: 'siraNo',
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
						`   <button type="button" class="btn btn-sm bg-secondary edit-meslek" data-meslek-id="${row.id}" data-toggle="modal" data-target="#MeslekEditModal">`,
						`       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
						'   </button>',
						`   <button type="button" class="btn btn-sm bg-danger delete-meslek" data-meslek-id="${row.id}" data-meslek-name="${row.ad}">`,
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
		var meslek = _$form.serializeFormToObject();

		abp.ui.setBusy(_$modal);
		_meslekService.create(meslek).done(function () {
			_$modal.modal('hide');
			_$form[0].reset();
			abp.notify.info(l('SavedSuccessfully'));
			_$meslekTable.ajax.reload();
		}).always(function () {
			abp.ui.clearBusy(_$modal);
		});
	});

	$(document).on('click', '.delete-meslek', function () {
		var meslekId = $(this).attr("data-meslek-id");
		var meslekName = $(this).attr('data-meslek-name');

		deleteMeslek(meslekId, meslekName);
	});

	function deleteMeslek(meslekId, meslekName) {
		abp.message.confirm(
			abp.utils.formatString(
				l('AreYouSureWantToDelete'),
				meslekName),
			null,
			(isConfirmed) => {
				if (isConfirmed) {
					_meslekService.delete({
						id: meslekId
					}).done(() => {
						abp.notify.info(l('SuccessfullyDeleted'));
						_$meslekTable.ajax.reload();
					});
				}
			}
		);
	}

	$(document).on('click', '.edit-meslek', function (e) {
		var meslekId = $(this).attr("data-meslek-id");

		e.preventDefault();
		abp.ajax({
			url: abp.appPath + 'Meslek/EditModal?meslekId=' + meslekId,
			type: 'POST',
			dataType: 'html',
			success: function (content) {
				$('#MeslekEditModal div.modal-content').html(content);
			},
			error: function (e) { }
		});
	});

	abp.event.on('meslek.edited', (data) => {
		_$meslekTable.ajax.reload();
	});

	_$modal.on('shown.bs.modal', () => {
		_$modal.find('input:not([type=hidden]):first').focus();
	}).on('hidden.bs.modal', () => {
		_$form.clearForm();
	});

	$('.btn-search').on('click', (e) => {
		_$meslekTable.ajax.reload();
	});

	$('.txt-search').on('keypress', (e) => {
		if (e.which == 13) {
			_$meslekTable.ajax.reload();
			return false;
		}
	});
})(jQuery);