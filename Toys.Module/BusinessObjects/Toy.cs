using System.ComponentModel.DataAnnotations.Schema;
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

        public int Category_Id { get; set; }
        [ForeignKey("Category_Id")]
        public virtual Category Category { get; set; }

        public string Make { get; set; }
    }
}