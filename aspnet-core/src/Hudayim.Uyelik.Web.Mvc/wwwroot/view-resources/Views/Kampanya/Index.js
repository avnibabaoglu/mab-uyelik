(function ($) {
	var _kampanyaService = abp.services.app.kampanya,
		l = abp.localization.getSource('Uyelik'),
		_$modal = $('#KampanyaCreateModal'),
		_$form = _$modal.find('form');

	_$form.find('.save-button').on('click', (e) => {
		e.preventDefault();

		if (!_$form.valid()) {
			return;
		}
		var kampanya = _$form.serializeFormToObject();

		debugger;
		var resultFileUpload;
		var file = _$form[0].fileUpload.files[0];
		if (file != undefined && file != null) {
			var formData = new FormData();
			formData.append("dosya", file);
			formData.append("kampanyaAdi", ReplaceSlugify(kampanya.Ad));

			abp.ajax({
				type: "POST",
				url: '/Kampanya/FileUpload',
				data: formData,
				processData: false,
				contentType: false,
				traditional: true,
				async: false,
			}).done(function (result) {
				debugger;
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
				abp.notify.error("Ek kaydetme işlemi başarısız. Lütfen tekrar deneyiniz..");
			});
		}
		debugger;
		if (resultFileUpload != undefined && resultFileUpload != null) {
			kampanya.ResimYolu = resultFileUpload.item1;
			kampanya.ResimAdi = resultFileUpload.item2;
		}

		abp.ui.setBusy(_$modal);
		_kampanyaService.create(kampanya).done(function () {
			_$modal.modal('hide');
			_$form[0].reset();
			abp.notify.info(l('SavedSuccessfully'));
			window.location.href = '/Kampanya/Index';
		}).always(function () {
			abp.ui.clearBusy(_$modal);
		});
	});

	$(document).on('click', '.delete-kampanya', function () {
		var kampanyaId = $(this).attr("data-kampanya-id");
		var kampanyaName = $(this).attr('data-kampanya-name');

		deleteKampanya(kampanyaId, kampanyaName);
	});

	function deleteKampanya(kampanyaId, kampanyaName) {
		abp.message.confirm(
			abp.utils.formatString(l('AreYouSureWantToDelete'), kampanyaName),
			null,
			(isConfirmed) => {
				if (isConfirmed) {
					_kampanyaService.delete({
						id: kampanyaId
					}).done(() => {
						abp.notify.info(l('SuccessfullyDeleted'));
						window.location.href = '/Kampanya/Index';
					});
				}
			}
		);
	}

	$(document).on('click', '.edit-kampanya', function (e) {
		var kampanyaId = $(this).attr("data-kampanya-id");

		e.preventDefault();
		abp.ajax({
			url: abp.appPath + 'Kampanya/EditModal?kampanyaId=' + kampanyaId,
			type: 'POST',
			dataType: 'html',
			success: function (content) {
				$('#KampanyaEditModal div.modal-content').html(content);
			},
			error: function (e) { }
		});
	});

	_$modal.on('shown.bs.modal', () => {
		_$modal.find('input:not([type=hidden]):first').focus();
	}).on('hidden.bs.modal', () => {
		_$form.clearForm();
	});

	$('.txt-search').on('keypress', (e) => {
		if (e.which == 13) {
			return false;
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
			.replace(/ç/g, "c")
			.replace(/%+/g, '');

		return retval;
	}

	$('.portfolio-menu ul li').click(function () {
		$('.portfolio-menu ul li').removeClass('active');
		$(this).addClass('active');

		var selector = $(this).attr('data-filter');
		$('.portfolio-item').isotope({
			filter: selector
		});
		return false;
	});
	$(document).ready(function () {
		var popup_btn = $('.popup-btn');
		popup_btn.magnificPopup({
			type: 'image',
			gallery: {
				enabled: true
			}
		});
	});
})(jQuery);