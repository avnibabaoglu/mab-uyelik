(function ($) {
	var _servis = abp.services.app.gelir,
		l = abp.localization.getSource('Uyelik'),
		_$card = $('#GelirCreateCard'),
		_$form = _$card.find('form');

	$('.select2').select2({
		theme: 'bootstrap4',
		width: '100%'
	}).on('select2:close', select2TabSelect);

	var pageSize = 15;
	$('.multi-select2').select2(
	{
			theme: 'bootstrap4',
			language: 'tr',
			placeholder: 'Kullanıcıyı arayarak seçiniz',
			minimumInputLength: 2,
			allowClear: true,
			ajax: {
				delay: 500,
				url: function () {
					return '/Gelir/GetKullanicilar';
				},
				dataType: 'JSON',
				data: function (params) {
					return {
						pageSize: pageSize,
						pageNum: params.page || 1,
						searchTerm: params.term
					};
				},
				processResults: function (data) {
					return {
						results: $.map(data.result.results, function (item) {
							return {
								text: item.text,
								id: item.id,
							}
						})
					};
				}
			}
		});

	function select2TabSelect(evt) {
		var context = $(evt.target);
		$(document).on('keydown.select2', function (e) {
			if (e.which === 9) { // tab
				var highlighted = context.data('select2').$dropdown.find('.select2-results__option--highlighted');
				if (highlighted) {
					var id = highlighted.data('data').id;
					context.val(id).trigger('change');
				}
			}
		});
		setTimeout(function () { $(document).off('keydown.select2'); }, 1);
	}

	_$form.find('.save-button').on('click', (e) => {
		e.preventDefault();

		if (!_$form.valid()) {
			return;
		}
		var gelir = _$form.serializeFormToObject();

		abp.ui.setBusy(_$card);
		_servis.create(gelir).done(function () {
			_$form[0].reset();
			abp.notify.info(l('SavedSuccessfully'));
			window.location.href = '/Gelir/Index';
		}).always(function () {
			abp.ui.clearBusy(_$card);
		});
	});

})(jQuery);
