using System;
using System.Data;
using System.Data.Entity;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using DevExpress.ExpressApp.EF.Updating;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Design;
using DevExpress.XtraLayout.Customization;

namespace Toys.Module.BusinessObjects {
    [TypesInfoInitializer(typeof(ToysContextInitializer))]
	public class ToysDbContext : DbContext {
        public ToysDbContext(String connectionString)
            : base(connectionString)
        {
           Database.SetInitializer(new MyInitializer());
        }
        public ToysDbContext(DbConnection connection)
            : base(connection, false)
        {
            Database.SetInitializer(new MyInitializer());
        }
        //public ToysDbContext()
        //    : base("name=ConnectionString")
        //{
        //     Database.SetInitializer(new MyInitializer());
        //}
        public ToysDbContext()
        {
        }

        public DbSet<ModuleInfo> ModulesInfo { get; set; }
        public DbSet<Toy> Toys { get; set; }
        public DbSet<Category> Categories { get; set; }
 
    }
}