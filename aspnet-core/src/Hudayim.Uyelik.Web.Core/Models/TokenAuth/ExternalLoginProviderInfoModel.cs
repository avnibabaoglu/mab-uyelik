using Abp.AutoMapper;
using Hudayim.Uyelik.Authentication.External;

namespace Hudayim.Uyelik.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
