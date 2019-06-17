using DevExpress.ExpressApp.Data;

namespace Toys.Module.BusinessObjects
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
       
    }
}