using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.ExpressApp.Data;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;

namespace Toys.Module.BusinessObjects
{
    [NavigationItem("2 Data")]
    public class Toy 
    {
        [Key]
        public int Id { get; set; }

        [Browsable(false)]
        public int ToyCategory { get; set; }

        [ImmediatePostData]
        [NotMapped]
        public ToyCategoryEnum ToyCategoryNum
        {
            get => (ToyCategoryEnum)ToyCategory;
            set => ToyCategory = (int)value;
        }

        public string Name { get; set; }

        public int Brand_Id { get; set; }
        [ForeignKey("Brand_Id")]
        public virtual Brand Brand { get; set; }   

        [Browsable(false)]
        public virtual BabyToy BabyToy { get; set; }
        [Browsable(false)]
        public virtual PreSchoolToy PreSchoolToy { get; set; }
        [Browsable(false)]
        public  virtual  ToddlerToy ToddlerToy { get; set; }

        [ModelDefault("RowCount","4")]
        public string Notes { get; set; }

        
    }
}