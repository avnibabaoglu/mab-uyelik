using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hudayim.Uyelik.Entities
{
	public class Firma : FullAuditedEntity
	{
		[Required]
		public string Ad { get; set; }
		public string Aciklama { get; set; }
		public string WebAdresi { get; set; }
		public string Mail { get; set; }
		public string Telefon { get; set; }
		public string Adres { get; set; }
		public string ResimYolu { get; set; }
		public string ResimAdi { get; set; }
		public int SiraNo { get; set; }
		public bool AktifMi { get; set; }
		public int? IlId { get; set; }
		public int? KategoriId { get; set; }
		public virtual Il Il { get; set; }
		public virtual ICollection<Kampanya> Kampanyalar { get; set; }
		public virtual Kategori Kategori { get; set; }

	}
}
