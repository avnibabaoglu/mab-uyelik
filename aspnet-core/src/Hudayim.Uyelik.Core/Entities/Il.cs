using Abp.Domain.Entities.Auditing;
using Hudayim.Uyelik.Authorization.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hudayim.Uyelik.Entities
{
	public class Il : FullAuditedEntity
	{
		[Required]
		public string Ad { get; set; }
		public string PlakaKodu { get; set; }
		public int SiraNo { get; set; }
		public int? UlkeId { get; set; }
		public int? SourceId { get; set; }
		public virtual Ulke Ulke { get; set; }
		public virtual ICollection<Ilce> Ilceler { get; set; }
		public virtual ICollection<User> Users { get; set; }

	}
}
