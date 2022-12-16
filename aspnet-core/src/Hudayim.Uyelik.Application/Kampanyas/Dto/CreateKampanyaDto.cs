using System;

namespace Hudayim.Uyelik.Kampanyas.Dto
{
	public class CreateKampanyaDto
	{
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
		public string FirmaAdi { get; set; }
		public int? FirmaKategoriId { get; set; }
		public string FirmaKategoriAdi { get; set; }
		public string FirmaMailAdresi { get; set; }
		public string FirmaTelefon { get; set; }
		public DateTime? CreationTime { get; set; }
		public long? CreatorUserId { get; set; }
		public DateTime? LastModificationTime { get; set; }
		public long? LastModifierUserId { get; set; }
		public bool? IsDeleted { get; set; }
		public long? DeleterUserId { get; set; }
		public DateTime? DeletionTime { get; set; }

	}
}
