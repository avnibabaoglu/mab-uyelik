(function ($) {
	var _servis = abp.services.app.user,
		l = abp.localization.getSource('Uyelik'),
		_$card = $('#UserEditCard'),
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
			placeholder: 'Meslekleri arayarak seçiniz',
			minimumInputLength: 2,
			allowClear: true,
			ajax: {
				delay: 500,
				url: function () {
					return '/Users/GetMeslekler';
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

	_$form.find('#ulkeId').on('change', function (e) {
		var selectedIndex = _$form.find('#ulkeId').val();
		if (selectedIndex != undefined && selectedIndex != '') {
			var postData = { ulkeId: selectedIndex };
			var $ValueList = _$form.find('#ilId');

			$.ajax({
				type: "POST",
				url: '/Users/GetIller',
				data: postData,
				dataType: "json",
				traditional: true
			}).done(function (result) {
				if (result.result.length > 0) {
					$ValueList.find('option').remove().end();
					$ValueList.append('<option="">Seçiniz</option>');
					$.each(result.result, function (i, o) {
						$ValueList.append('<option value=' + o.value + '>' + o.text + '</option>')
					});
				} else {
					abp.notify.info("Seçilen ülkeye bağlı il bilgisi bulunamadı.");
				}

				IlceListesiTemizleme();
				MahalleListesiTemizleme();
			}).fail(function (jqXHR) {
				abp.notify.error("İl bilgisi getirilirken hata oluştu..");
			});
		} else {
			IlListesiTemizleme();
			IlceListesiTemizleme();
			MahalleListesiTemizleme();
		}
	});

	_$form.find('#ilId').on('change', function (e) {
		var selectedIndex = _$form.find('#ilId').val();
		if (selectedIndex != undefined && selectedIndex != '') {
			var postData = { ilId: selectedIndex };
			var $ValueList = _$form.find('#ilceId');

			$.ajax({
				type: "POST",
				url: '/Users/GetIlceler',
				data: postData,
				dataType: "json",
				traditional: true
			}).done(function (result) {
				if (result.result.length > 0) {
					$ValueList.find('option').remove().end();
					$ValueList.append('<option="">Seçiniz</option>');
					$.each(result.result, function (i, o) {
						$ValueList.append('<option value=' + o.value + '>' + o.text + '</option>')
					});
				} else {
					abp.notify.info("Seçilen ile bağlı ilçe bilgisi bulunamadı.");
				}
				MahalleListesiTemizleme();
			}).fail(function (jqXHR) {
				abp.notify.error("İlçe bilgisi getirilirken hata oluştu..");
			});
		} else {
			IlceListesiTemizleme();
			MahalleListesiTemizleme();
		}
	});

	_$form.find('#ilceId').on('change', function (e) {
		var selectedIndex = _$form.find('#ilceId').val();
		if (selectedIndex != undefined && selectedIndex != '') {
			var postData = { ilceId: selectedIndex };
			var $ValueList = _$form.find('#mahalleId');

			$.ajax({
				type: "POST",
				url: '/Users/GetMahalleler',
				data: postData,
				dataType: "json",
				traditional: true
			}).done(function (result) {
				if (result.result.length > 0) {
					$ValueList.find('option').remove().end();
					$ValueList.append('<option="">Seçiniz</option>');
					$.each(result.result, function (i, o) {
						$ValueList.append('<option value=' + o.value + '>' + o.text + '</option>')
					});
				} else {
					abp.notify.info("Seçilen ilçeye bağlı mahalle bilgisi bulunamadı.");
				}
			}).fail(function (jqXHR) {
				abp.notify.error("Mahalle bilgisi getirilirken hata oluştu..");
			});
		} else {
			MahalleListesiTemizleme();
		}
	});

	_$form.find('#universiteId').on('change', function (e) {
		var selectedIndex = _$form.find('#universiteId').val();
		if (selectedIndex != undefined && selectedIndex != '') {
			var postData = { universiteId: selectedIndex };
			var $ValueList = _$form.find('#fakulteId');

			$.ajax({
				type: "POST",
				url: '/Users/GetUniversiteFakulteler',
				data: postData,
				dataType: "json",
				traditional: true
			}).done(function (result) {
				if (result.result.length > 0) {
					$ValueList.find('option').remove().end();
					$ValueList.append('<option="">Seçiniz</option>');
					$.each(result.result, function (i, o) {
						$ValueList.append('<option value=' + o.value + '>' + o.text + '</option>')
					});
				} else {
					abp.notify.info("Seçilen üniversiteye bağlı fakülte bilgisi bulunamadı.");
				}
				BolumListesiTemizleme();
			}).fail(function (jqXHR) {
				abp.notify.error("Fakülte bilgisi getirilirken hata oluştu..");
			});
		} else {
			FakulteListesiTemizleme();
			BolumListesiTemizleme();
		}
	});

	_$form.find('#fakulteId').on('change', function (e) {
		var selectedIndex = _$form.find('#fakulteId').val();
		if (selectedIndex != undefined && selectedIndex != '') {
			var postData = { fakulteId: selectedIndex };
			var $ValueList = _$form.find('#bolumId');

			$.ajax({
				type: "POST",
				url: '/Users/GetUniversiteBolumler',
				data: postData,
				dataType: "json",
				traditional: true
			}).done(function (result) {
				if (result.result.length > 0) {
					$ValueList.find('option').remove().end();
					$ValueList.append('<option="">Seçiniz</option>');
					$.each(result.result, function (i, o) {
						$ValueList.append('<option value=' + o.value + '>' + o.text + '</option>')
					});
				} else {
					abp.notify.info("Seçilen fakülteye bağlı bölüm bilgisi bulunamadı.");
				}
			}).fail(function (jqXHR) {
				abp.notify.error("Bölüm bilgisi getirilirken hata oluştu..");
			});
		} else {
			BolumListesiTemizleme();
		}
	});

	function IlListesiTemizleme() {
		var $ValueListCity = $('#ilId');
		$ValueListCity.find('option').remove().end();
		$ValueListCity.append('<option="">Seçiniz</option>');
	}

	function IlceListesiTemizleme() {
		var $ValueListCounty = $('#ilceId');
		$ValueListCounty.find('option').remove().end();
		$ValueListCounty.append('<option="">Seçiniz</option>');
	}

	function MahalleListesiTemizleme() {
		var $ValueListDistrict = $('#mahalleId');
		$ValueListDistrict.find('option').remove().end();
		$ValueListDistrict.append('<option="">Seçiniz</option>');
	}

	function FakulteListesiTemizleme() {
		var $ValueList = $('#fakulteId');
		$ValueList.find('option').remove().end();
		$ValueList.append('<option="">Seçiniz</option>');
	}

	function BolumListesiTemizleme() {
		var $ValueList = $('#bolumId');
		$ValueList.find('option').remove().end();
		$ValueList.append('<option="">Seçiniz</option>');
	}

	_$form.find('.save-button').on('click', (e) => {
		e.preventDefault();

		if (!_$form.valid()) {
			return;
		}

		abp.ui.setBusy(_$card);
		debugger;
		var user = _$form.serializeFormToObject();

		user.kategoriIds = [];
		var _$kategoriIds = $('#kategoriId').val();
		if (_$kategoriIds) {
			$.each(_$kategoriIds, function (index, value) {
				user.kategoriIds.push(value.toString());
			});
		}

		user.roleNames = [];
		var _$roleCheckboxes = _$form[0].querySelectorAll("input[name='role']:checked");
		if (_$roleCheckboxes) {
			for (var roleIndex = 0; roleIndex < _$roleCheckboxes.length; roleIndex++) {
				var _$roleCheckbox = $(_$roleCheckboxes[roleIndex]);
				user.roleNames.push(_$roleCheckbox.val());
			}
		}

		var resultFileUpload;
		var file = $('#fileUpload')[0].files[0];
		if (file != undefined && file != null) {
			var formData = new FormData();
			formData.append("dosya", file);
			formData.append("userName", user.UserName);

			abp.ajax({
				type: "POST",
				url: '/Users/FileUpload',
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
			user.ProfilFotografYolu = resultFileUpload.item1;
			user.ProfilFotografAdi = resultFileUpload.item2;
		}
		_servis.update(user).done(function () {
			_$form[0].reset();
			abp.notify.info(l('SavedSuccessfully'));
			window.location.href = '/Users/Index';
		}).always(function () {
			abp.ui.clearBusy(_$card);
		});
	});

	$('.delete-user-photo').on('click', function (e) {
		var userId = $(this).attr("data-user-id");

		if (userId != undefined && userId != '') {
			var postData = { id: userId };

			$.ajax({
				type: "POST",
				url: '/Users/FileDelete',
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
				window.location.href = '/Users/Edit/' + userId;

			}).fail(function (jqXHR) {
				abp.notify.error("Ek silme işlemi başarısız. Lütfen tekrar deneyiniz..");
			});
		}
	});

})(jQuery);
