(function ($) {
	var _ulkeService = abp.services.app.ulke,
		l = abp.localization.getSource('Uyelik'),
		_$modal = $('#UlkeCreateModal'),
		_$form = _$modal.find('form'),
		_$table = $('#UlkeTable');

	var _$ulkeTable = _$table.DataTable({
		paging: true,
		serverSide: true,
		ajax: function (data, callback, settings) {
			var filter = $('#UlkeSearchForm').serializeFormToObject(true);
			filter.maxResultCount = data.length;
			filter.skipCount = data.start;

			abp.ui.setBusy(_$table);
			_ulkeService.getAll(filter).done(function (result) {
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
				action: () => _$ulkeTable.draw(false)
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
						`   <button type="button" class="btn btn-sm bg-secondary edit-ulke" data-ulke-id="${row.id}" data-toggle="modal" data-target="#UlkeEditModal">`,
						`       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
						'   </button>',
						`   <button type="button" class="btn btn-sm bg-danger delete-ulke" data-ulke-id="${row.id}" data-ulke-name="${row.ad}">`,
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
		var ulke = _$form.serializeFormToObject();

		abp.ui.setBusy(_$modal);
		_ulkeService.create(ulke).done(function () {
			_$modal.modal('hide');
			_$form[0].reset();
			abp.notify.info(l('SavedSuccessfully'));
			_$ulkeTable.ajax.reload();
		}).always(function () {
			abp.ui.clearBusy(_$modal);
		});
	});

	$(document).on('click', '.delete-ulke', function () {
		var ulkeId = $(this).attr("data-ulke-id");
		var ulkeName = $(this).attr('data-ulke-name');

		deleteUlke(ulkeId, ulkeName);
	});

	function deleteUlke(ulkeId, ulkeName) {
		abp.message.confirm(
			abp.utils.formatString(
				l('AreYouSureWantToDelete'),
				ulkeName),
			null,
			(isConfirmed) => {
				if (isConfirmed) {
					_ulkeService.delete({
						id: ulkeId
					}).done(() => {
						abp.notify.info(l('SuccessfullyDeleted'));
						_$ulkeTable.ajax.reload();
					});
				}
			}
		);
	}

	$(document).on('click', '.edit-ulke', function (e) {
		var ulkeId = $(this).attr("data-ulke-id");

		e.preventDefault();
		abp.ajax({
			url: abp.appPath + 'Ulke/EditModal?ulkeId=' + ulkeId,
			type: 'POST',
			dataType: 'html',
			success: function (content) {
				$('#UlkeEditModal div.modal-content').html(content);
			},
			error: function (e) { }
		});
	});

	abp.event.on('ulke.edited', (data) => {
		_$ulkeTable.ajax.reload();
	});

	_$modal.on('shown.bs.modal', () => {
		_$modal.find('input:not([type=hidden]):first').focus();
	}).on('hidden.bs.modal', () => {
		_$form.clearForm();
	});

	$('.btn-search').on('click', (e) => {
		_$ulkeTable.ajax.reload();
	});

	$('.txt-search').on('keypress', (e) => {
		if (e.which == 13) {
			_$ulkeTable.ajax.reload();
			return false;
		}
	});
})(jQuery);