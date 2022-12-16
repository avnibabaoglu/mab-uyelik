using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hudayim.Uyelik.Migrator.Data.EntityFramework.IlanBis.Models
{
	public partial class Ulkeler
	{
		public Ulkeler()
		{
			Iller = new HashSet<Iller>();
		}

		public int Id { get; set; }
		[Required]
		[StringLength(50)]
		public string Ad { get; set; }
		public long? AxRecId { get; set; }
		[StringLength(20)]
		public string AxCountryRegionId { get; set; }
		[Column("ISOKodu")]
		[StringLength(2)]
		public string Isokodu { get; set; }
		[Column("KIWIRecordId")]
		public long? KiwirecordId { get; set; }

		[InverseProperty("UlkeNavigation")]
		public ICollection<Iller> Iller { get; set; }
	}
}
