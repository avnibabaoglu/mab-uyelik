using Abp.Auditing;
using Hudayim.Uyelik.Common;
using Hudayim.Uyelik.Entities.Enums;
using System.Collections.Generic;

namespace Hudayim.Uyelik.Commons
{
	public class CommonAppService : UyelikAppServiceBase, ICommonAppService
	{
		[DisableAuditing]
		public List<NameValueIntCustomType> GetDonemTurleriList()
		{
			var result = new List<NameValueIntCustomType>();

			result = new List<NameValueIntCustomType>
				{
					new NameValueIntCustomType { NAME = "Mezun", VALUE = (int)DonemTuruEnum.Mezun},
					new NameValueIntCustomType { NAME = "Gelir", VALUE = (int)DonemTuruEnum.Gelir},
					new NameValueIntCustomType { NAME = "Diğer", VALUE = (int)DonemTuruEnum.Diger}
				};

			return result;
		}

		[DisableAuditing]
		public List<NameValueIntCustomType> GetKategoriTurleriList()
		{
			var result = new List<NameValueIntCustomType>();

			result = new List<NameValueIntCustomType>
				{
					new NameValueIntCustomType { NAME = "Kullanıcı", VALUE = (int)KategoriTuruEnum.Kullanici},
					new NameValueIntCustomType { NAME = "Firma", VALUE = (int)KategoriTuruEnum.Firma},
					new NameValueIntCustomType { NAME = "Diger", VALUE = (int)KategoriTuruEnum.Diger}
				};

			return result;
		}

	}
}
