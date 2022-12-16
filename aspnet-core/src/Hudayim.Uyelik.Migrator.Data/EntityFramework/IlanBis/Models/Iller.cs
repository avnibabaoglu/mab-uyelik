using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hudayim.Uyelik.Migrator.Data.EntityFramework.IlanBis.Models
{
	public partial class Iller
	{
		public Iller()
		{
			Ilceler = new HashSet<Ilceler>();
		}

		public int Id { get; set; }
		[Required]
		[StringLength(50)]
		public string Ad { get; set; }
		[StringLength(15)]
		public string Ulke { get; set; }
		public long? AxRecId { get; set; }
		[StringLength(20)]
		public string AxStateId { get; set; }
		[StringLength(50)]
		public string KlasorAd { get; set; }
		public int? SorumluSubeId { get; set; }
		[StringLength(2)]
		public string PlakaKodu { get; set; }
		[Column("Ulke_Id")]
		public int? UlkeId { get; set; }
		[Column("KIWIRecordId")]
		public long? KiwirecordId { get; set; }

		[ForeignKey("SorumluSubeId")]
		[InverseProperty("Iller")]
		public Ulkeler UlkeNavigation { get; set; }


		[InverseProperty("Il")]
		public ICollection<Ilceler> Ilceler { get; set; }
	}
}
