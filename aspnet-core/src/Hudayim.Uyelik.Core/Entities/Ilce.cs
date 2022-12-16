using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hudayim.Uyelik.Entities
{
	public class Ilce : FullAuditedEntity
	{
		[Required]
		public string Ad { get; set; }
		public int SiraNo { get; set; }
		public int? IlId { get; set; }
		public int? SourceId { get; set; }
		public virtual Il Il { get; set; }
		public virtual ICollection<Mahalle> Mahalleler { get; set; }

	}
}
