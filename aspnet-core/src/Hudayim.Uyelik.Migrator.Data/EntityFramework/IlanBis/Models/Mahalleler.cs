using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hudayim.Uyelik.Migrator.Data.EntityFramework.IlanBis.Models
{
	public partial class Mahalleler
	{
		public Mahalleler()
		{
		}

		public int Id { get; set; }
		public int IlceId { get; set; }
		[Required]
		[StringLength(120)]
		public string Ad { get; set; }
		[Column("KIWIRecordId")]
		public long? KiwirecordId { get; set; }

		[ForeignKey("IlceId")]
		[InverseProperty("Mahalleler")]
		public Ilceler Ilce { get; set; }

	}
}
