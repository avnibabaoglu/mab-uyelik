using Abp.Domain.Entities.Auditing;
using Hudayim.Uyelik.Authorization.Users;
using System.Collections.Generic;

namespace Hudayim.Uyelik.Entities
{
	public class Meslek : FullAuditedEntity
	{
		public string Ad { get; set; }
		public string Kod { get; set; }
		public int? SiraNo { get; set; }
		public bool? AktifMi { get; set; }
		public virtual ICollection<User> Users { get; set; }
	}
}
