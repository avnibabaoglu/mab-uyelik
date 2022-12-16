namespace Hudayim.Uyelik.Migrator.Data.EntityFramework.Uyelik.Models
{
	using System;

	public partial class BolumlerListesi
	{
		public int Id { get; set; }
		public Nullable<int> FakulteId { get; set; }
		public Nullable<int> UniversiteId { get; set; }
		public string Ad { get; set; }
		public Nullable<bool> Durum { get; set; }
	}
}
