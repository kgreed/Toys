using System.Data.Entity;

namespace Toys.Module.BusinessObjects
{
    public class MyInitializer : DropCreateDatabaseIfModelChanges<ToysDbContext>
    {
        protected override void Seed(ToysDbContext context)
        {
            SeedRecords(context);

            base.Seed(context);
        }

        public static void SeedRecords(ToysDbContext context)
        {


            var cat1 = new Category { Name = "Education" };
            var cat2 = new Category { Name = "Baby" };
            var cat3 = new Category { Name = "Toddler" };

            context.Categories.Add(cat1);
            context.Categories.Add(cat2);
            context.Categories.Add(cat3);

            var toy1 = new Toy { Name = "quisinair", Category = cat1 };
            var toy2 = new Toy { Name = "rattle", Category = cat2 };
            var toy3 = new Toy { Name = "blocks", Category = cat3 };
            context.Toys.Add(toy1);
            context.Toys.Add(toy2);
            context.Toys.Add(toy3);
            context.SaveChanges();


        }
    }
}