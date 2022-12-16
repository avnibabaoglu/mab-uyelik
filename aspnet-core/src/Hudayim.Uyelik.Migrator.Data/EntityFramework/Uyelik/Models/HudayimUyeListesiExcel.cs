using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hudayim.Uyelik.Migrator.Data.EntityFramework.Uyelik.Models
{
	public partial class HudayimUyeListesiExcel
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int AboneNo { get; set; }
		public string Adi { get; set; }
		public string Soyadi { get; set; }
		public string Adres { get; set; }
		public string GuncelIlce { get; set; }
		public string GuncelIl { get; set; }
		public string GuncelMail { get; set; }
		public string GuncelSabitTelefon { get; set; }
		public string GuncelGsmTelefon { get; set; }
		public string GuncelGsmTelefon2 { get; set; }
		public string Faks { get; set; }
		public Nullable<System.DateTime> KayitTarihi { get; set; }
		public string Kategori { get; set; }
		public string MezunOlduguOkul { get; set; }
		public int? MezuniyetYili { get; set; }
		public string GuncelCalisilanKurum { get; set; }
		public string GuncelGorevi { get; set; }
		public string GuncelPozisyonu { get; set; }
		public string MezunOlduguBolum { get; set; }
		public string Birim { get; set; }
		public string Aciklama { get; set; }
	}
}
