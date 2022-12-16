using Abp.Domain.Entities.Auditing;
using Hudayim.Uyelik.Authorization.Users;
using System.Collections.Generic;

namespace Hudayim.Uyelik.Entities
{
	public class Universite : FullAuditedEntity
	{
		public string Ad { get; set; }
		public int? SiraNo { get; set; }
		public int? SourceId { get; set; }
		public bool? AktifMi { get; set; }
		public virtual ICollection<User> Users { get; set; }
		public virtual ICollection<Fakulte> Fakulteler { get; set; }
		public virtual ICollection<Bolum> Bolumler { get; set; }

	}
}
