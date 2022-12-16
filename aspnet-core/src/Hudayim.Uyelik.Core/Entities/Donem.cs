using Abp.Domain.Entities.Auditing;
using Hudayim.Uyelik.Authorization.Users;
using Hudayim.Uyelik.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hudayim.Uyelik.Entities
{
	public class Donem : FullAuditedEntity
	{
		[Required]
		public string Ad { get; set; }
		public int SiraNo { get; set; }
		public DateTime BaslangicTarihi { get; set; }
		public DateTime BitisTarihi { get; set; }
		public bool AktifMi { get; set; }
		public DonemTuruEnum DonemTuru { get;set; }
		public virtual ICollection<User> Users { get; set; }

	}
}
