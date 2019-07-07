using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.XtraScheduler.Outlook.Interop;
 
using Exception = System.Exception;


namespace Toys.Module.BusinessObjects
{
    [DomainComponent]
    [DefaultClassOptions]
    [NavigationItem("1 Main")]
    public class NPToy : INonPersistent, IObjectSpaceLink, INotifyPropertyChanged
    {
        public NPToy() {
            
        }

        [DevExpress.ExpressApp.Data.Key]
        [ModelDefault("AllowEdit", "False")]
        public int Id { get; set; }

        [Browsable(false)]
        public int CacheIndex { get; set; }

        private string _name;
        [ImmediatePostData]
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        //[Browsable(false)]
        private int ToyCategory { get; set; }
        [ImmediatePostData] public ToyCategoryEnum ToyCategoryNum { get =>(ToyCategoryEnum) ToyCategory;
            set
            {
                ToyCategory = (int) value;
                OnPropertyChanged();
            }  
        }

       
        private int _BrandId;
        [Browsable(false)]
        [ModelDefault("AllowEdit", "False")]
        public int BrandId {
            get => _BrandId;
            set
            {
                _BrandId = value;
                OnPropertyChanged();
            }
        }

        private BabyToy _babyToy;
        [Appearance("IsBabyToy", Visibility = ViewItemVisibility.Hide, Criteria =  "[ToyCategoryNum] != 1" )]
        [VisibleInListView(false)]
        [NotMapped]
        public BabyToy BabyToy {
            get => ToyCategoryNum != ToyCategoryEnum.Baby ? null : _babyToy;
            set => _babyToy = value;
        }

        
        [NotMapped]

        IObjectSpace persistentObjectSpace => ((NonPersistentObjectSpace)ObjectSpace)?.AdditionalObjectSpaces?.FirstOrDefault();

        [DataSourceProperty("Brands")]
        [NotMapped]
        [ImmediatePostData]
        public virtual Brand Brand
        {
            get => persistentObjectSpace?.GetObjectByKey<Brand>(BrandId);
            set
            {
                BrandId = value.Id; 
                OnPropertyChanged();
            }
        }

        [Browsable(false)] public IList<Brand> Categories => persistentObjectSpace?.GetObjects<Brand>(CriteriaOperator.Parse("[Id] > 0"));

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged == null) return;
            if (ObjectSpace == null) return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        [Browsable(false)]
        public string SearchText { get; set; }
        public List<INonPersistent> GetData(IObjectSpace os)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (var connect = new ToysDbContext(connectionString))
            {
                var parameters = new List<SqlParameter>();
                var sql = "select t.Id, t.Name, b.Id as BrandId, t.ToyCategory, b.Name as BrandName from toys t inner join brands b on t.Brand_Id = b.Id";
            
                if (SearchText?.Length > 0)
                {
                    sql += " where t.name like @name";
                    parameters.Add( new SqlParameter("@name",$"%{SearchText}%"));
                }
                var results = connect.Database.SqlQuery<NPToy>(sql,parameters.ToArray()).ToList();
                var npresults = results.ConvertAll(x => (INonPersistent)x);
                var index = 0;
                foreach (INonPersistent np in npresults)
                {
                    np.CacheIndex = index;
                    index++;
                }
                return npresults;
            }
        }

        public void NPOnSaving(IObjectSpace osParam)
        {
            var os = ((NonPersistentObjectSpace)ObjectSpace).AdditionalObjectSpaces.FirstOrDefault();  // why cant I use this instead of passing in as a parameter?
            var areSame = osParam.Equals(os); // true

            var brand = os.FindObject<Brand>(CriteriaOperator.Parse("[Id] = ?", BrandId));
            if (brand == null)
            {
                throw new Exception($"Category {BrandId} was not found");
            }

            var toy = os.FindObject<Toy>(CriteriaOperator.Parse("[Id] = ?", Id));
            toy.Name = Name;
            toy.Brand = brand;
            toy.ToyCategory = ToyCategory;
            os.SetModified(toy);
        }

        [NotMapped]
        [Browsable(false)]
        public IObjectSpace ObjectSpace { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;


    }
}