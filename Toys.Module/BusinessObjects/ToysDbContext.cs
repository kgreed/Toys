using System;
using System.Data.Entity;
using System.Data.Common;
using DevExpress.ExpressApp.EF.Updating;
using DevExpress.ExpressApp.Design;

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
         
        public ToysDbContext()
        {
        }

        public DbSet<ModuleInfo> ModulesInfo { get; set; }
        public DbSet<Toy> Toys { get; set; }
        public DbSet<BabyToy> BabyToys { get; set; }
        public DbSet<ToddlerToy> ToddlerToys { get; set; }
        public DbSet<Brand> Brands { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Toy>().HasOptional(x => x.BabyToy).WithRequired(y => y.Toy);
            modelBuilder.Entity<Toy>().HasOptional(x => x.PreSchoolToy).WithRequired(y => y.Toy);
            modelBuilder.Entity<Toy>().HasOptional(x => x.ToddlerToy).WithRequired(y => y.Toy);
            base.OnModelCreating(modelBuilder);
        }
    }
}