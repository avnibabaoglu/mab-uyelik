using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Hudayim.Uyelik.EntityFrameworkCore
{
    public static class UyelikDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<UyelikDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<UyelikDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
