using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Data;
using DevExpress.Persistent.Base;

namespace Toys.Module.BusinessObjects
{
    [NavigationItem("2 Data")]
    public class ToddlerToy : IToyType
    {
        [ForeignKey("Toy")]
        public int Id { get; set; }


        public bool HelpsTalking { get; set; }

        public bool GoodForWalking { get; set; }

        public virtual Toy Toy { get; set; }

    }
}