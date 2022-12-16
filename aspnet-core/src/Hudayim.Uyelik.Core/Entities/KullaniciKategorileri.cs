using Abp.Domain.Entities.Auditing;
using Hudayim.Uyelik.Authorization.Users;

namespace Hudayim.Uyelik.Entities
{
	public class KullaniciKategorileri : FullAuditedEntity
	{
		public long UserId { get; set; }
		public int KategoriId { get; set; }
		public string Description { get; set; }
		public virtual User User { get; set; }
		public virtual Kategori Kategori { get; set; }

	}
}
