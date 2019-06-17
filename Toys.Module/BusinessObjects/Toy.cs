using DevExpress.ExpressApp.Data;

namespace Toys.Module.BusinessObjects
{
    public class Toy
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Category Category { get; set; }


    }
}