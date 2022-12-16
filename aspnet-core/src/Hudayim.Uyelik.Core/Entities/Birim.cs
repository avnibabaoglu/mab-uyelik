using Abp.Domain.Entities.Auditing;
using Hudayim.Uyelik.Authorization.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hudayim.Uyelik.Entities
{
	public class Birim : FullAuditedEntity
	{
		[Required]
		public string Ad { get; set; }
		public int SiraNo { get; set; }
		public bool AktifMi { get; set; }
		public bool PlatformMu { get; set; }
		public virtual ICollection<User> Users { get; set; }

	}
}
