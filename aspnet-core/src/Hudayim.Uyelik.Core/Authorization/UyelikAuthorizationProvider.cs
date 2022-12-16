using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Hudayim.Uyelik.Authorization
{
	public class UyelikAuthorizationProvider : AuthorizationProvider
	{
		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			context.CreatePermission(PermissionNames.Pages_Users, L("UserManager"));
			context.CreatePermission(PermissionNames.Pages_Roles, L("RoleManager"));
			context.CreatePermission(PermissionNames.Pages_Tenants, L("TenantManager"), multiTenancySides: MultiTenancySides.Host);
			context.CreatePermission(PermissionNames.Pages_Birim, L("UnitManager"));
			context.CreatePermission(PermissionNames.Pages_Donem, L("PeriodManager"));
			context.CreatePermission(PermissionNames.Pages_Firma, L("CompanyManager"));
			context.CreatePermission(PermissionNames.Pages_Kampanya, L("CampaignManager"));
			context.CreatePermission(PermissionNames.Pages_Kategori, L("CategoryManager"));
			context.CreatePermission(PermissionNames.Pages_Adres, L("AddressManager"));
			//context.CreatePermission(PermissionNames.Pages_Ulke, L("CountryManager"));
			//context.CreatePermission(PermissionNames.Pages_Il, L("CityManager"));
			//context.CreatePermission(PermissionNames.Pages_Ilce, L("CountyManager"));
			//context.CreatePermission(PermissionNames.Pages_Mahalle, L("DistrictManager"));
			context.CreatePermission(PermissionNames.Pages_Gelir, L("IncomeManager"));
			context.CreatePermission(PermissionNames.Pages_Meslek, L("ProfessionManager"));
			context.CreatePermission(PermissionNames.Pages_Egitim, L("EducationManager"));
			//context.CreatePermission(PermissionNames.Pages_Universite, L("UniversityManager"));
			//context.CreatePermission(PermissionNames.Pages_Fakulte, L("FaculityManager"));
			//context.CreatePermission(PermissionNames.Pages_Bolum, L("DepartmentManager"));
			context.CreatePermission(PermissionNames.Pages_Uye, L("Member"));
		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, UyelikConsts.LocalizationSourceName);
		}
	}
}
