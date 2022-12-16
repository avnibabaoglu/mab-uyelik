using Abp.Application.Services;
using Hudayim.Uyelik.Common;
using System.Collections.Generic;

namespace Hudayim.Uyelik.Commons
{
	public interface ICommonAppService : IApplicationService
	{
		List<NameValueIntCustomType> GetDonemTurleriList();
		List<NameValueIntCustomType> GetKategoriTurleriList();

	}
}
