using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hudayim.Uyelik.Migrator.Data.EntityFramework.IlanBis.Models
{
	public partial class Ilceler
	{
		public Ilceler()
		{
			Mahalleler = new HashSet<Mahalleler>();
		}

		public int Id { get; set; }
		public int IlId { get; set; }
		[Required]
		[StringLength(60)]
		public string Ad { get; set; }
		public long? AxRecId { get; set; }
		[StringLength(15)]
		public string AxCountyId { get; set; }
		[Column("KIWIRecordId")]
		public long? KiwirecordId { get; set; }

		[ForeignKey("IlId")]
		[InverseProperty("Ilceler")]
		public Iller Il { get; set; }

		[InverseProperty("Ilce")]
		public ICollection<Mahalleler> Mahalleler { get; set; }
	}
}
