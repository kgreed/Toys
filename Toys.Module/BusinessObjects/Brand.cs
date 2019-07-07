using System.Collections.Generic;
using DevExpress.ExpressApp.Data;
using DevExpress.Persistent.Base;
using DevExpress.XtraPrinting;

namespace Toys.Module.BusinessObjects
{
    
    [NavigationItem("2 Data")]
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        
        public string Name { get; set; }

       

    }
}