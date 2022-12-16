using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;

namespace Hudayim.Uyelik.Entities
{
	public class Kampanya : FullAuditedEntity
	{
		[Required]
		public string Ad { get; set; }
		public string Aciklama { get; set; }
		public DateTime BaslangicTarihi { get; set; }
		public DateTime BitisTarihi { get; set; }
		public int SiraNo { get; set; }
		public int? IndirimOrani { get; set; }
		public string ResimYolu { get; set; }
		public string ResimAdi { get; set; }
		public bool AktifMi { get; set; }
		public int? FirmaId { get; set; }
		public virtual Firma Firma { get; set; }

	}
}
