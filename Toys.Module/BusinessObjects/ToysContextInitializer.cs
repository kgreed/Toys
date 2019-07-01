using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EF.DesignTime;

namespace Toys.Module.BusinessObjects
{
    public class ToysContextInitializer : DbContextTypesInfoInitializerBase {
        protected override DbContext CreateDbContext() {
            // return new ToysDbContext("App=EntityFramework");
            DbContextInfo contextInfo = new DbContextInfo(typeof(ToysDbContext), new DbProviderInfo(providerInvariantName: "System.Data.SqlClient", providerManifestToken: ""));
            return contextInfo.CreateInstance();
        }
    }
}