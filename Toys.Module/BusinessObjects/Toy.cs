using DevExpress.ExpressApp.Data;
using DevExpress.Persistent.Base;

namespace Toys.Module.BusinessObjects
{
    [NavigationItem("Main")]
    public class Toy
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Category Category { get; set; }


    }
}