using Abp.Application.Services.Dto;
using System;

namespace Hudayim.Uyelik.Firmas.Dto
{
	public class FirmaDto : EntityDto<int>
	{
		public string Ad { get; set; }
		public string Aciklama { get; set; }
		public string WebAdresi { get; set; }
		public string Mail { get; set; }
		public string Telefon { get; set; }
		public string Adres { get; set; }
		public string ResimYolu { get; set; }
		public string ResimAdi { get; set; }
		public string ResimTamYolu { get; set; }
		public int SiraNo { get; set; }
		public bool AktifMi { get; set; }
		public int? IlId { get; set; }
		public string IlAdi { get; set; }
		public int? KategoriId { get; set; }
		public string KategoriAdi { get; set; }
		public DateTime? CreationTime { get; set; }
		public long? CreatorUserId { get; set; }
		public DateTime? LastModificationTime { get; set; }
		public long? LastModifierUserId { get; set; }
		public bool? IsDeleted { get; set; }
		public long? DeleterUserId { get; set; }
		public DateTime? DeletionTime { get; set; }

	}
}
