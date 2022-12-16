(function ($) {
	var _userService = abp.services.app.user,
		l = abp.localization.getSource('Uyelik'),
		_$table = $('#UsersTable');

	var _$usersTable = _$table.DataTable({
		paging: true,
		serverSide: true,
		ajax: function (data, callback, settings) {
			var filter = $('#UsersSearchForm').serializeFormToObject(true);
			filter.maxResultCount = data.length;
			filter.skipCount = data.start;

			abp.ui.setBusy(_$table);
			_userService.getAll(filter).done(function (result) {
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
				action: () => _$usersTable.draw(false)
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
				data: 'profilFotografTamYolu',
				sortable: false,
				render: function (data) {
					if (data != undefined && data != null && data != '') {
						return label = '<img class="img-bordered img-thumbnail img-responsive" width="100px" src="' + data + '" />';
					} else {
						return label = '<img class="img-bordered img-thumbnail img-responsive" width="100px" src="/img/kullanici.png" />';
					}
				}
			},
			{
				targets: 2,
				data: 'userName',
				sortable: false
			},
			{
				targets: 3,
				data: 'fullName',
				sortable: false
			},
			{
				targets: 4,
				data: 'emailAddress',
				sortable: false
			},
			{
				targets: 5,
				data: 'uyelikBaslangicTarihi',
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
				data: 'uyelikBitisTarihi',
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
				targets: 7,
				data: 'isActive',
				sortable: false,
				render: data => `<input type="checkbox" disabled ${data ? 'checked' : ''}>`
			},
			{
				targets: 8,
				data: null,
				sortable: false,
				autoWidth: false,
				defaultContent: '',
				render: (data, type, row, meta) => {
					return [
						`   <a type="button" class="btn btn-sm bg-secondary edit-user" href="/Users/EditAdmin/${row.id}">`,
						`       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
						'   </a>',
						`   <button type="button" class="btn btn-sm bg-danger delete-user" data-user-id="${row.id}" data-user-name="${row.ad}">`,
						`       <i class="fas fa-trash"></i> ${l('Delete')}`,
						'   </button>'
					].join('');
				}
			}
		]
	});

	$(document).on('click', '.delete-user', function () {
		var userId = $(this).attr("data-user-id");
		var userName = $(this).attr('data-user-name');

		deleteUser(userId, userName);
	});

	function deleteUser(userId, userName) {
		abp.message.confirm(
			abp.utils.formatString(
				l('AreYouSureWantToDelete'),
				userName),
			null,
			(isConfirmed) => {
				if (isConfirmed) {
					_userService.delete({
						id: userId
					}).done(() => {
						abp.notify.info(l('SuccessfullyDeleted'));
						_$usersTable.ajax.reload();
					});
				}
			}
		);
	}

	$('.btn-search').on('click', (e) => {
		_$usersTable.ajax.reload();
	});

	$('.txt-search').on('keypress', (e) => {
		if (e.which == 13) {
			_$usersTable.ajax.reload();
			return false;
		}
	});
})(jQuery);
