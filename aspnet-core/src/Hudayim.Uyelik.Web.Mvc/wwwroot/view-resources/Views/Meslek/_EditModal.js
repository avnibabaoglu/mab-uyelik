(function ($) {
	var _meslekService = abp.services.app.meslek,
		l = abp.localization.getSource('Uyelik'),
		_$modal = $('#MeslekEditModal'),
		_$form = _$modal.find('form');

	function save() {
		if (!_$form.valid()) {
			return;
		}

		var meslek = _$form.serializeFormToObject();

		abp.ui.setBusy(_$form);
		_meslekService.update(meslek).done(function () {
			_$modal.modal('hide');
			abp.notify.info(l('SavedSuccessfully'));
			abp.event.trigger('meslek.edited', meslek);
		}).always(function () {
			abp.ui.clearBusy(_$form);
		});
	}

	_$form.closest('div.modal-content').find(".save-button").click(function (e) {
		e.preventDefault();
		save();
	});

	_$form.find('input').on('keypress', function (e) {
		if (e.which === 13) {
			e.preventDefault();
			save();
		}
	});

	_$modal.on('shown.bs.modal', function () {
		_$form.find('input[type=text]:first').focus();
	});
})(jQuery);
