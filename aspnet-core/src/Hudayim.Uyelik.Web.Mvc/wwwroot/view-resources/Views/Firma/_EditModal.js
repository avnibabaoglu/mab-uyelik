(function ($) {
	var _firmaService = abp.services.app.firma,
		l = abp.localization.getSource('Uyelik'),
		_$modal = $('#FirmaEditModal'),
		_$form = _$modal.find('form');

	function save() {
		if (!_$form.valid()) {
			return;
		}

		var firma= _$form.serializeFormToObject();

		var resultFileUpload;
		var file = _$form[0].fileUpload.files[0];
		if (file != undefined && file != null) {
			var formData = new FormData();
			formData.append("dosya", file);
			formData.append("firmaAdi", ReplaceSlugify(firma.Ad));

			abp.ajax({
				type: "POST",
				url: '/Firma/FileUpload',
				data: formData,
				processData: false,
				contentType: false,
				traditional: true,
				async: false,
			}).done(function (result) {
				if (result.success == true) {
					if (result.data != null) {
						resultFileUpload = result.data;
					} else {
						abp.notify.error("Ek yükleme işlemi başarısız. Lütfen tekrar deneyiniz.");
					}
				} else {
					abp.notify.error(result.message);
				}
			}).fail(function (jqXHR) {
				abp.notify.error("Ek yükleme işlemi başarısız. Lütfen tekrar deneyiniz..");
			});
		}

		if (resultFileUpload != undefined && resultFileUpload != null) {
			firma.ResimYolu = resultFileUpload.item1;
			firma.ResimAdi = resultFileUpload.item2;
		}

		abp.ui.setBusy(_$form);
		_firmaService.update(firma).done(function () {
			_$modal.modal('hide');
			abp.notify.info(l('SavedSuccessfully'));
			abp.event.trigger('firma.edited', firma);
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

	$('.delete-firma-photo').on('click', function (e) {
		var firmaId = $(this).attr("data-firma-id");

		if (firmaId != undefined && firmaId != '') {
			var postData = { id: firmaId };

			$.ajax({
				type: "POST",
				url: '/Firma/FileDelete',
				data: postData,
				dataType: "json",
				traditional: true
			}).done(function (result) {
				if (result.success == true) {
					if (result.data != null) {
						abp.notify.error("Ek silme işlemi başarılı..");
					} else {
						abp.notify.error(result.message);
					}
				} else {
					abp.notify.error(result.message);
				}
				window.location.href = '/Firma/Index';

			}).fail(function (jqXHR) {
				abp.notify.error("Ek silme işlemi başarısız. Lütfen tekrar deneyiniz..");
			});
		}
	});

	function ReplaceSlugify(value) {
		var retval;
		retval = value.replace(/[\. , ':-]+/g, "-").toLowerCase()
			.replace(/Ğ/g, "g")
			.replace(/Ü/g, "u")
			.replace(/Ş/g, "s")
			.replace(/I/g, "i")
			.replace(/İ/g, "i")
			.replace(/Ö/g, "o")
			.replace(/Ç/g, "c")
			.replace(/ğ/g, "g")
			.replace(/ü/g, "u")
			.replace(/ş/g, "s")
			.replace(/ı/g, "i")
			.replace(/ö/g, "o")
			.replace(/ç/g, "c");
		return retval;
	}
})(jQuery);
