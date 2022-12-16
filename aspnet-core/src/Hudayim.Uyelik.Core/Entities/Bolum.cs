using Abp.Domain.Entities.Auditing;
using Hudayim.Uyelik.Authorization.Users;
using System.Collections.Generic;

namespace Hudayim.Uyelik.Entities
{
	public class Bolum : FullAuditedEntity
	{
		public string Ad { get; set; }
		public int? SiraNo { get; set; }
		public bool? AktifMi { get; set; }
		public int? SourceId { get; set; }
		public int? FakulteId { get; set; }
		public int? UniversiteId { get; set; }
		public virtual Fakulte Fakulte { get; set; }
		public virtual Universite Universite { get; set; }
		public virtual ICollection<User> Users { get; set; }

	}
}
