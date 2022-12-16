using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hudayim.Uyelik.Migrator.Data.EntityFramework.Uyelik.Models
{
	public partial class UlkelerListesiExcel
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Ad { get; set; }

	}
}
