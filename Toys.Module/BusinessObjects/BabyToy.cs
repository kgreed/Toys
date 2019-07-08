using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Data;
using DevExpress.Persistent.Base;

namespace Toys.Module.BusinessObjects
{
  [NavigationItem("2 Data")]
  public class BabyToy  : IToyType  {

      [ForeignKey("Toy")]
      public int Id { get; set; }

      public bool HelpsTeething { get; set; }

      public bool GoodForCrawling { get; set; }
     
      public virtual Toy Toy { get; set; }
     
  }
}
