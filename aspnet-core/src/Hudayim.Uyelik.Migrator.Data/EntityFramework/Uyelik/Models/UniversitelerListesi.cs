namespace Hudayim.Uyelik.Migrator.Data.EntityFramework.Uyelik.Models
{
	using System;

	public partial class UniversitelerListesi
	{
		public int Id { get; set; }
		public string Ad { get; set; }
		public Nullable<bool> Durum { get; set; }
	}
}
