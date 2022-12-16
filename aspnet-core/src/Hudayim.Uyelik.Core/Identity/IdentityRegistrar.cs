using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Hudayim.Uyelik.Authorization;
using Hudayim.Uyelik.Authorization.Roles;
using Hudayim.Uyelik.Authorization.Users;
using Hudayim.Uyelik.Editions;
using Hudayim.Uyelik.MultiTenancy;

namespace Hudayim.Uyelik.Identity
{
    public static class IdentityRegistrar
    {
        public static IdentityBuilder Register(IServiceCollection services)
        {
            services.AddLogging();

            return services.AddAbpIdentity<Tenant, User, Role>()
                .AddAbpTenantManager<TenantManager>()
                .AddAbpUserManager<UserManager>()
                .AddAbpRoleManager<RoleManager>()
                .AddAbpEditionManager<EditionManager>()
                .AddAbpUserStore<UserStore>()
                .AddAbpRoleStore<RoleStore>()
                .AddAbpLogInManager<LogInManager>()
                .AddAbpSignInManager<SignInManager>()
                .AddAbpSecurityStampValidator<SecurityStampValidator>()
                .AddAbpUserClaimsPrincipalFactory<UserClaimsPrincipalFactory>()
                .AddPermissionChecker<PermissionChecker>()
                .AddDefaultTokenProviders();
        }
    }
}
