using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using Hudayim.Uyelik.Authorization;

namespace Hudayim.Uyelik.Web.Startup
{
	public class UyelikNavigationProvider : NavigationProvider
	{
		public override void SetNavigation(INavigationProviderContext context)
		{
			context.Manager.MainMenu
				.AddItem(
					new MenuItemDefinition(
						PageNames.Home,
						L("HomePage"),
						url: "",
						icon: "fas fa-home",
						requiresAuthentication: true,
						order: 1
					)
				).AddItem(
					new MenuItemDefinition(
						PageNames.Tenants,
						L("Tenants"),
						url: "Tenants",
						icon: "fas fa-building",
						order: 2,
						permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Tenants)
					)
				).AddItem(
					new MenuItemDefinition(
						PageNames.Users,
						L("Users"),
						url: "Users",
						icon: "fas fa-users",
						order: 3,
						permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Users)
					)
				).AddItem(
					new MenuItemDefinition(
						PageNames.Roles,
						L("Roles"),
						url: "Roles",
						icon: "fas fa-theater-masks",
						order: 4,
						permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Roles)
					)
				)
				.AddItem(
					new MenuItemDefinition(
						PageNames.Kategori,
						L("CategoryManager"),
						url: "Kategori",
						icon: "fas fa-list-alt",
						order: 5,
						permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Kategori)
					)
				)
				.AddItem(
					new MenuItemDefinition(
						PageNames.Birim,
						L("UnitManager"),
						url: "Birim",
						icon: "fas fa-puzzle-piece",
						order: 6,
						permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Birim)
					)
				).AddItem(
					new MenuItemDefinition(
						PageNames.Donem,
						L("PeriodManager"),
						url: "Donem",
						icon: "far fa-calendar-alt",
						order: 7,
						permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Donem)
					)
				).AddItem(
					new MenuItemDefinition(
						PageNames.Meslek,
						L("ProfessionManager"),
						url: "Meslek",
						icon: "fas fa-user-tie",
						order: 8,
						permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Meslek)
					)
				).AddItem(
					new MenuItemDefinition(
						PageNames.Gelir,
						L("IncomeManager"),
						url: "Gelir",
						icon: "fas fa-money-bill-wave",
						order: 9,
						permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Gelir)
					)
				).AddItem(
					new MenuItemDefinition(
						PageNames.Firma,
						L("CompanyManager"),
						url: "Firma",
						icon: "fas fas fa-building",
						order: 10,
						permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Firma)
					)
				).AddItem(
					new MenuItemDefinition(
						PageNames.Kampanya,
						L("CampaignManager"),
						url: "Kampanya/IndexAdmin",
						icon: "fas fa-percent",
						order: 11,
						permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Kampanya)
					)
				).AddItem(
					new MenuItemDefinition(
						PageNames.KampanyaGoruntule,
						L("Campaigns"),
						url: "Kampanya",
						icon: "fas fa-percent",
						order: 12,
						permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Uye)
					)
				).AddItem(
					new MenuItemDefinition(
						PageNames.Adres,
						L("AddressManager"),
						url: "Adres",
						icon: "fas fa-address-card",
						order: 13,
						permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Adres)
					).AddItem(
					new MenuItemDefinition(
						PageNames.Ulke,
						L("CountryManager"),
						url: "Ulke",
						icon: "far fa-flag",
						order: 1
					)).AddItem(
					new MenuItemDefinition(
						PageNames.Il,
						L("CityManager"),
						url: "Il",
						icon: "fas fa-city",
						order: 2
					)).AddItem(
					new MenuItemDefinition(
						PageNames.Ilce,
						L("CountyManager"),
						url: "Ilce",
						icon: "fas fa-flag",
						order: 3
					)).AddItem(
					new MenuItemDefinition(
						PageNames.Mahalle,
						L("DistrictManager"),
						url: "Mahalle",
						icon: "fas fa-house-damage",
						order: 4
					))
				).AddItem(
					new MenuItemDefinition(
						PageNames.Egitim,
						L("EducationManager"),
						url: "Egitim",
						icon: "fas fa-school",
						order: 14,
						permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Egitim)
					).AddItem(
					new MenuItemDefinition(
						PageNames.Universite,
						L("UniversityManager"),
						url: "Universite",
						icon: "fas fa-university",
						order: 1
					)).AddItem(
					new MenuItemDefinition(
						PageNames.Fakulte,
						L("FaculityManager"),
						url: "Fakulte",
						icon: "fas fa-university",
						order: 2
					)).AddItem(
					new MenuItemDefinition(
						PageNames.Bolum,
						L("DepartmentManager"),
						url: "Bolum",
						icon: "fas fa-university",
						order: 3
					))
				);
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, UyelikConsts.LocalizationSourceName);
		}
	}
}
