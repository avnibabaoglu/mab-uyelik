(function ($) {
	var _kategoriService = abp.services.app.kategori,
		l = abp.localization.getSource('Uyelik'),
		_$modal = $('#KategoriCreateModal'),
		_$form = _$modal.find('form'),
		_$table = $('#KategoriTable');

	var _$kategoriTable = _$table.DataTable({
		paging: true,
		serverSide: true,
		ajax: function (data, callback, settings) {
			var filter = $('#KategoriSearchForm').serializeFormToObject(true);
			filter.maxResultCount = data.length;
			filter.skipCount = data.start;

			abp.ui.setBusy(_$table);
			_kategoriService.getAll(filter).done(function (result) {
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
				action: () => _$kategoriTable.draw(false)
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
				data: 'kategoriTuruAdi',
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
						`   <button type="button" class="btn btn-sm bg-secondary edit-kategori" data-kategori-id="${row.id}" data-toggle="modal" data-target="#KategoriEditModal">`,
						`       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
						'   </button>',
						`   <button type="button" class="btn btn-sm bg-danger delete-kategori" data-kategori-id="${row.id}" data-kategori-name="${row.ad}">`,
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
		var kategori = _$form.serializeFormToObject();

		abp.ui.setBusy(_$modal);
		_kategoriService.create(kategori).done(function () {
			_$modal.modal('hide');
			_$form[0].reset();
			abp.notify.info(l('SavedSuccessfully'));
			_$kategoriTable.ajax.reload();
		}).always(function () {
			abp.ui.clearBusy(_$modal);
		});
	});

	$(document).on('click', '.delete-kategori', function () {
		var kategoriId = $(this).attr("data-kategori-id");
		var kategoriName = $(this).attr('data-kategori-name');

		deleteKategori(kategoriId, kategoriName);
	});

	function deleteKategori(kategoriId, kategoriName) {
		abp.message.confirm(
			abp.utils.formatString(
				l('AreYouSureWantToDelete'),
				kategoriName),
			null,
			(isConfirmed) => {
				if (isConfirmed) {
					_kategoriService.delete({
						id: kategoriId
					}).done(() => {
						abp.notify.info(l('SuccessfullyDeleted'));
						_$kategoriTable.ajax.reload();
					});
				}
			}
		);
	}

	$(document).on('click', '.edit-kategori', function (e) {
		var kategoriId = $(this).attr("data-kategori-id");

		e.preventDefault();
		abp.ajax({
			url: abp.appPath + 'Kategori/EditModal?kategoriId=' + kategoriId,
			type: 'POST',
			dataType: 'html',
			success: function (content) {
				$('#KategoriEditModal div.modal-content').html(content);
			},
			error: function (e) { }
		});
	});

	abp.event.on('kategori.edited', (data) => {
		_$kategoriTable.ajax.reload();
	});

	_$modal.on('shown.bs.modal', () => {
		_$modal.find('input:not([type=hidden]):first').focus();
	}).on('hidden.bs.modal', () => {
		_$form.clearForm();
	});

	$('.btn-search').on('click', (e) => {
		_$kategoriTable.ajax.reload();
	});

	$('.txt-search').on('keypress', (e) => {
		if (e.which == 13) {
			_$kategoriTable.ajax.reload();
			return false;
		}
	});
})(jQuery);
