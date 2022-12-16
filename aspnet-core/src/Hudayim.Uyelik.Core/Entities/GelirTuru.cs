using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace Hudayim.Uyelik.Entities
{
	public class GelirTuru : FullAuditedEntity
	{
		public string Ad { get; set; }
		public int SiraNo { get; set; }
		public bool AktifMi { get; set; }
		public virtual ICollection<Gelir> Gelirler { get; set; }

	}
}
