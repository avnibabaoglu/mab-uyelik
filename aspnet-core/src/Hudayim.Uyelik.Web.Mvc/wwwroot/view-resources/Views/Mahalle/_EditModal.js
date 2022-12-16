(function ($) {
	var _mahalleService = abp.services.app.mahalle,
		l = abp.localization.getSource('Uyelik'),
		_$modal = $('#MahalleEditModal'),
		_$form = _$modal.find('form');

	function save() {
		if (!_$form.valid()) {
			return;
		}
		var mahalle = _$form.serializeFormToObject();

		abp.ui.setBusy(_$form);
		_mahalleService.update(mahalle).done(function () {
			_$modal.modal('hide');
			abp.notify.info(l('SavedSuccessfully'));
			abp.event.trigger('mahalle.edited', mahalle);
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

	_$form.find('#ulkeId').on('change', function (e) {
		var selectedIndex = _$form.find('#ulkeId').val();
		if (selectedIndex != undefined && selectedIndex != '') {
			var postData = { ulkeId: selectedIndex };
			var $ValueList = _$form.find('#ilId');

			$.ajax({
				type: "POST",
				url: '/Mahalle/GetIller',
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
					abp.notify.info("Seçilen ülkeye bağlı il bilgisi bulunamadı.");
				}
			}).fail(function (jqXHR) {
				abp.notify.error("İl bilgisi getirilirken hata oluştu..");
			});
		}
	});

	_$form.find('#ilId').on('change', function (e) {
		var selectedIndex = _$form.find('#ilId').val();
		if (selectedIndex != undefined && selectedIndex != '') {
			var postData = { ilId: selectedIndex };
			var $ValueList = _$form.find('#ilceId');

			$.ajax({
				type: "POST",
				url: '/Mahalle/GetIlceler',
				data: postData,
				dataType: "json",
				traditional: true
			}).done(function (result) {
				if (result.result.length > 0) {
					$ValueList.append('<option value="">Seçiniz</option>');
					$.each(result.result, function (i, o) {
						$ValueList.append('<option value=' + o.value + '>' + o.text + '</option>')
					});
				} else {
					abp.notify.info("Seçilen ile bağlı ilçe bilgisi bulunamadı.");
				}
			}).fail(function (jqXHR) {
				abp.notify.error("İlçe bilgisi getirilirken hata oluştu..");
			});
		}
	});

	function IlListesiTemizleme() {
		var $ValueListCity = $('#ilId');
		$ValueListCity.find('option').remove().end();
	}

	function IlceListesiTemizleme() {
		var $ValueListCounty = $('#ilceId');
		$ValueListCounty.find('option').remove().end();
	}

	function MahalleListesiTemizleme() {
		var $ValueListDistrict = $('#mahalleId');
		$ValueListDistrict.find('option').remove().end();
	}
})(jQuery);
