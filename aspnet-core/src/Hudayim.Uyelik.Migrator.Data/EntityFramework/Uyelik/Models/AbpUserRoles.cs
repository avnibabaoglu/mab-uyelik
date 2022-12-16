using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hudayim.Uyelik.Migrator.Data.EntityFramework.Uyelik.Models
{
	public partial class AbpUserRoles
	{
		public long Id { get; set; }
		public System.DateTime CreationTime { get; set; }
		public Nullable<long> CreatorUserId { get; set; }
		public Nullable<int> TenantId { get; set; }
		public long UserId { get; set; }
		public int RoleId { get; set; }

	}
}
