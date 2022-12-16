(function ($) {
	var _universiteService = abp.services.app.universite,
		l = abp.localization.getSource('Uyelik'),
		_$modal = $('#UniversiteCreateModal'),
		_$form = _$modal.find('form'),
		_$table = $('#UniversiteTable');

	var _$universiteTable = _$table.DataTable({
		paging: true,
		serverSide: true,
		ajax: function (data, callback, settings) {
			var filter = $('#UniversiteSearchForm').serializeFormToObject(true);
			filter.maxResultCount = data.length;
			filter.skipCount = data.start;

			abp.ui.setBusy(_$table);
			_universiteService.getAll(filter).done(function (result) {
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
				action: () => _$universiteTable.draw(false)
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
				data: null,
				sortable: false,
				autoWidth: false,
				defaultContent: '',
				render: (data, type, row, meta) => {
					return [
						`   <button type="button" class="btn btn-sm bg-secondary edit-universite" data-universite-id="${row.id}" data-toggle="modal" data-target="#UniversiteEditModal">`,
						`       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
						'   </button>',
						`   <button type="button" class="btn btn-sm bg-danger delete-universite" data-universite-id="${row.id}" data-universite-name="${row.ad}">`,
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
		var universite = _$form.serializeFormToObject();

		abp.ui.setBusy(_$modal);
		_universiteService.create(universite).done(function () {
			_$modal.modal('hide');
			_$form[0].reset();
			abp.notify.info(l('SavedSuccessfully'));
			_$universiteTable.ajax.reload();
		}).always(function () {
			abp.ui.clearBusy(_$modal);
		});
	});

	$(document).on('click', '.delete-universite', function () {
		var universiteId = $(this).attr("data-universite-id");
		var universiteName = $(this).attr('data-universite-name');

		deleteUniversite(universiteId, universiteName);
	});

	function deleteUniversite(universiteId, universiteName) {
		abp.message.confirm(
			abp.utils.formatString(
				l('AreYouSureWantToDelete'),
				universiteName),
			null,
			(isConfirmed) => {
				if (isConfirmed) {
					_universiteService.delete({
						id: universiteId
					}).done(() => {
						abp.notify.info(l('SuccessfullyDeleted'));
						_$universiteTable.ajax.reload();
					});
				}
			}
		);
	}

	$(document).on('click', '.edit-universite', function (e) {
		var universiteId = $(this).attr("data-universite-id");

		e.preventDefault();
		abp.ajax({
			url: abp.appPath + 'Universite/EditModal?universiteId=' + universiteId,
			type: 'POST',
			dataType: 'html',
			success: function (content) {
				$('#UniversiteEditModal div.modal-content').html(content);
			},
			error: function (e) { }
		});
	});

	abp.event.on('universite.edited', (data) => {
		_$universiteTable.ajax.reload();
	});

	_$modal.on('shown.bs.modal', () => {
		_$modal.find('input:not([type=hidden]):first').focus();
	}).on('hidden.bs.modal', () => {
		_$form.clearForm();
	});

	$('.btn-search').on('click', (e) => {
		_$universiteTable.ajax.reload();
	});

	$('.txt-search').on('keypress', (e) => {
		if (e.which == 13) {
			_$universiteTable.ajax.reload();
			return false;
		}
	});
})(jQuery);