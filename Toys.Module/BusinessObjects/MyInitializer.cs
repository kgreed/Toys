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

            var brandMatel= context.Brands.Add(new Brand { Name = "Matel" });
            var brandHomeMade = context.Brands.Add(new Brand { Name = "Home Made" });
            var brandHasBro = context.Brands.Add(new Brand { Name = "HasBro" });

            context.Toys.Add(new Toy { Name = "play dough", Brand = brandHomeMade, ToyCategoryNum = ToyCategoryEnum.PreSchool });
            context.Toys.Add(new Toy { Name = "play doh", Brand = brandHasBro, ToyCategoryNum = ToyCategoryEnum.PreSchool });

            context.Toys.Add(new Toy { Name = "rattle", Brand = brandHomeMade, ToyCategoryNum = ToyCategoryEnum.Baby });
            context.Toys.Add(new Toy { Name = "blocks", Brand = brandMatel, ToyCategoryNum = ToyCategoryEnum.Toddler});


            

            context.SaveChanges();
        }
    }
}