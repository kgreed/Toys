using System.Data.Entity;
using DevExpress.ExpressApp.EF.DesignTime;

namespace Toys.Module.BusinessObjects
{
    public class ToysContextInitializer : DbContextTypesInfoInitializerBase {
        protected override DbContext CreateDbContext() {
            return new ToysDbContext("App=EntityFramework");
        }
    }
}