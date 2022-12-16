using System.Collections.Generic;

namespace Hudayim.Uyelik.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
