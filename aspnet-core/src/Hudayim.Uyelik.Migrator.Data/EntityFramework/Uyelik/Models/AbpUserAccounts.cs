using System;

namespace Hudayim.Uyelik.Migrator.Data.EntityFramework.Uyelik.Models
{
	public partial class AbpUserAccounts
	{
		public long Id { get; set; }
		public System.DateTime CreationTime { get; set; }
		public Nullable<long> CreatorUserId { get; set; }
		public Nullable<long> DeleterUserId { get; set; }
		public Nullable<System.DateTime> DeletionTime { get; set; }
		public string EmailAddress { get; set; }
		public bool IsDeleted { get; set; }
		public Nullable<System.DateTime> LastModificationTime { get; set; }
		public Nullable<long> LastModifierUserId { get; set; }
		public Nullable<int> TenantId { get; set; }
		public long UserId { get; set; }
		public Nullable<long> UserLinkId { get; set; }
		public string UserName { get; set; }
	}
}
