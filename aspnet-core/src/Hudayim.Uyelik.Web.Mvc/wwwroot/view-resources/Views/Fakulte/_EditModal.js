(function ($) {
	var _fakulteService = abp.services.app.fakulte,
		l = abp.localization.getSource('Uyelik'),
		_$modal = $('#FakulteEditModal'),
		_$form = _$modal.find('form');

	function save() {
		if (!_$form.valid()) {
			return;
		}

		var fakulte = _$form.serializeFormToObject();

		abp.ui.setBusy(_$form);
		_fakulteService.update(fakulte).done(function () {
			_$modal.modal('hide');
			abp.notify.info(l('SavedSuccessfully'));
			abp.event.trigger('fakulte.edited', fakulte);
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
