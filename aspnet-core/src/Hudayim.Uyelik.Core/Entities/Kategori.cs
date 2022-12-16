using Abp.Domain.Entities.Auditing;
using Hudayim.Uyelik.Entities.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hudayim.Uyelik.Entities
{
	public class Kategori : FullAuditedEntity
	{
		[Required]
		public string Ad { get; set; }
		public int SiraNo { get; set; }
		public bool AktifMi { get; set; }
		public KategoriTuruEnum KategoriTuru { get; set; }
		public virtual ICollection<Firma> Firmalar { get; set; }

	}
}
