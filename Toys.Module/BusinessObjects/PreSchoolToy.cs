using DevExpress.ExpressApp.Data;
using DevExpress.Persistent.Base;

namespace Toys.Module.BusinessObjects
{
    [NavigationItem("2 Data")]
    public class PreSchoolToy
    {
        [Key]
        public int Id { get; set; }

        public bool HelpsReading { get; set; }

        public bool GoodForSocial { get; set; }

        public virtual Toy Toy { get; set; }
    }
}