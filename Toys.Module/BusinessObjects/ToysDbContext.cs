﻿using System;
using System.Data;
using System.Linq;
using System.Data.Entity;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.ComponentModel;
using DevExpress.ExpressApp.EF.Updating;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EF.DesignTime;

namespace Toys.Module.BusinessObjects {
	public class ToysContextInitializer : DbContextTypesInfoInitializerBase {
		protected override DbContext CreateDbContext() {
			return new ToysDbContext("App=EntityFramework");
		}
	}
	[TypesInfoInitializer(typeof(ToysContextInitializer))]
	public class ToysDbContext : DbContext {
		public ToysDbContext(String connectionString)
			: base(connectionString) {
		}
		public ToysDbContext(DbConnection connection)
			: base(connection, false) {
		}
		public ToysDbContext()
			: base("name=ConnectionString") {
		}
		public DbSet<ModuleInfo> ModulesInfo { get; set; }
	}
}