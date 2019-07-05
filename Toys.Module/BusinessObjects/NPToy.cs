using System;
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
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
 

namespace Toys.Module.BusinessObjects
{
    [DomainComponent]
    [DefaultClassOptions]
    [NavigationItem("Main")]
    public class NPToy : INonPersistent, IObjectSpaceLink, INotifyPropertyChanged
    {
        public NPToy() {
            
        }

        [DevExpress.ExpressApp.Data.Key]
        [ModelDefault("AllowEdit", "False")]
        public int Id { get; set; }
       
        public string Name { get; set; }

        [ModelDefault("AllowEdit", "False")]
        public int CategoryId { get; set; }


        [DataSourceProperty("Categories")]
        [NotMapped]

        IObjectSpace persistentObjectSpace => ((NonPersistentObjectSpace)ObjectSpace)?.AdditionalObjectSpaces?.FirstOrDefault();

        [DataSourceProperty("Categories")]
        [NotMapped]
        public virtual Category Category
        {
            get => persistentObjectSpace?.GetObjectByKey<Category>(CategoryId);
            set => CategoryId = value.Id;
        }
        [Browsable(false)] public IList<Category> Categories => persistentObjectSpace?.GetObjects<Category>(CriteriaOperator.Parse("[Id] > 0"));

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
                var sql = "select t.Id, t.Name, c.Id as CategoryId, c.Name as CategoryName from toys t inner join categories c on t.Category_Id = c.Id";
            
                if (SearchText?.Length > 0)
                {
                    sql += " where t.name like @name";
                    parameters.Add( new SqlParameter("@name",$"%{SearchText}%"));
                }

                var results = connect.Database.SqlQuery<NPToy>(sql,parameters.ToArray()).ToList();
                return results.ConvertAll(x => (INonPersistent)x);
            }
        }

        public void NPOnSaving(IObjectSpace osParam)
        {
            var os = ((NonPersistentObjectSpace)ObjectSpace).AdditionalObjectSpaces.FirstOrDefault();  // why cant I use this instead of passing in as a parameter?
            var areSame = osParam.Equals(os); // true

            var category = os.FindObject<Category>(CriteriaOperator.Parse("[Id] = ?", CategoryId));
            if (category == null)
            {
                throw new Exception($"Category {CategoryId} was not found");
            }

            var toy = os.FindObject<Toy>(CriteriaOperator.Parse("[Id] = ?", Id));
            toy.Name = Name;
            toy.Category = category;
            os.SetModified(toy);
        }

        [NotMapped]
        [Browsable(false)]
        public IObjectSpace ObjectSpace { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;


    }
}