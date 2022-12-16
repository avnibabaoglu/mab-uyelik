(function ($) {
	var _bolumService = abp.services.app.bolum,
		l = abp.localization.getSource('Uyelik'),
		_$modal = $('#BolumEditModal'),
		_$form = _$modal.find('form');

	function save() {
		if (!_$form.valid()) {
			return;
		}
		debugger;
		var bolum = _$form.serializeFormToObject();

		abp.ui.setBusy(_$form);
		_bolumService.update(bolum).done(function () {
			_$modal.modal('hide');
			abp.notify.info(l('SavedSuccessfully'));
			abp.event.trigger('bolum.edited', bolum);
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

	_$form.find('#universiteId').on('change', function (e) {
		var selectedIndex = _$form.find('#universiteId').val();
		if (selectedIndex != undefined && selectedIndex != '') {
			var postData = { universiteId: selectedIndex };
			var $ValueList = _$form.find('#fakulteId');

			$.ajax({
				type: "POST",
				url: '/Bolum/GetFakulteler',
				data: postData,
				dataType: "json",
				traditional: true
			}).done(function (result) {
				if (result.result.length > 0) {
					$ValueList.find('option').remove().end();
					$ValueList.append('<option value="">Seçiniz</option>');
					$.each(result.result, function (i, o) {
						$ValueList.append('<option value=' + o.value + '>' + o.text + '</option>')
					});
				} else {
					abp.notify.info("Seçilen üniversiteye bağlı fakülte bilgisi bulunamadı.");
				}
			}).fail(function (jqXHR) {
				abp.notify.error("Fakülte bilgisi getirilirken hata oluştu..");
			});
		}
	});

	function FakulteListesiTemizleme() {
		var $ValueListCity = $('#fakulteId');
		$ValueListCity.find('option').remove().end();
	}

})(jQuery);
