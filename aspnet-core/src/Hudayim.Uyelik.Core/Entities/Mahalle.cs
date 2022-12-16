using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace Hudayim.Uyelik.Entities
{
	public class Mahalle : FullAuditedEntity
	{
		[Required]
		public string Ad { get; set; }
		public int SiraNo { get; set; }
		public int? IlceId { get; set; }
		public int? SourceId { get; set; }
		public virtual Ilce Ilce { get; set; }

	}
}
