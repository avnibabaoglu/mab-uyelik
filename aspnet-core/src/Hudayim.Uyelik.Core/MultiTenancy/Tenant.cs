using Abp.MultiTenancy;
using Hudayim.Uyelik.Authorization.Users;

namespace Hudayim.Uyelik.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
