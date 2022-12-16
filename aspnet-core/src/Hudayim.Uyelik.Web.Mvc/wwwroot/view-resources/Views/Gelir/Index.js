(function ($) {
	var _gelirService = abp.services.app.gelir,
		l = abp.localization.getSource('Uyelik'),
		_$table = $('#GelirTable');

	var _$gelirTable = _$table.DataTable({
		paging: true,
		serverSide: true,
		ajax: function (data, callback, settings) {
			var filter = $('#GelirSearchForm').serializeFormToObject(true);
			filter.maxResultCount = data.length;
			filter.skipCount = data.start;

			abp.ui.setBusy(_$table);
			_gelirService.getAll(filter).done(function (result) {
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
				action: () => _$gelirTable.draw(false)
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
				data: 'gelirTuruAdi',
				sortable: false
			},
			{
				targets: 2,
				data: 'donemAdi',
				sortable: false
			},
			{
				targets: 3,
				data: 'userName',
				sortable: false
			},
			{
				targets: 4,
				data: 'ad',
				sortable: false
			},
			{
				targets: 5,
				data: 'tutar',
				sortable: false
			},
			{
				targets: 6,
				data: 'odemeTarihi',
				sortable: false
			},
			{
				targets: 7,
				data: null,
				sortable: false,
				autoWidth: false,
				defaultContent: '',
				render: (data, type, row, meta) => {
					return [
						`   <a type="button" class="btn btn-sm bg-secondary edit-gelir" href="/Gelir/Edit/${row.id}">`,
						`       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
						'   </a>',
						`   <button type="button" class="btn btn-sm bg-danger delete-gelir" data-gelir-id="${row.id}" data-gelir-name="${row.ad}">`,
						`       <i class="fas fa-trash"></i> ${l('Delete')}`,
						'   </button>'
					].join('');
				}
			}
		]
	});

	$(document).on('click', '.delete-gelir', function () {
		var gelirId = $(this).attr("data-gelir-id");
		var gelirName = $(this).attr('data-gelir-name');

		deleteGelir(gelirId, gelirName);
	});

	function deleteGelir(gelirId, gelirName) {
		abp.message.confirm(
			abp.utils.formatString(
				l('AreYouSureWantToDelete'),
				gelirName),
			null,
			(isConfirmed) => {
				if (isConfirmed) {
					_gelirService.delete({
						id: gelirId
					}).done(() => {
						abp.notify.info(l('SuccessfullyDeleted'));
						_$gelirTable.ajax.reload();
					});
				}
			}
		);
	}

	$('.btn-search').on('click', (e) => {
		_$gelirTable.ajax.reload();
	});

	$('.txt-search').on('keypress', (e) => {
		if (e.which == 13) {
			_$gelirTable.ajax.reload();
			return false;
		}
	});
})(jQuery);