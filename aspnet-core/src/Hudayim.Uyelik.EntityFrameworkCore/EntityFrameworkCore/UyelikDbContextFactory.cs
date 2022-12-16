using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Hudayim.Uyelik.Configuration;
using Hudayim.Uyelik.Web;

namespace Hudayim.Uyelik.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class UyelikDbContextFactory : IDesignTimeDbContextFactory<UyelikDbContext>
    {
        public UyelikDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<UyelikDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            UyelikDbContextConfigurer.Configure(builder, configuration.GetConnectionString(UyelikConsts.ConnectionStringName));

            return new UyelikDbContext(builder.Options);
        }
    }
}
