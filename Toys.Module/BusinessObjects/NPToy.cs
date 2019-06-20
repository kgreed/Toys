using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
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

        public int CategoryId { get; set; }

        private string _categoryName;
        public string CategoryName
        {
            get => _categoryName;
            set
            {
                if (_categoryName == value) return;
                _categoryName = value;
                OnPropertyChanged();
            }
        }
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
            using (var connect = new ToysDbContext())
            {
                var parameters = new List<SqlParameter>();
                var sql = "select t.Id, t.Name, c.Id as CategoryId, c.Name as CategoryName from toys t inner join categories c on t.Category_Id = c.Id";
            
                if (SearchText?.Length > 0)
                {
                    sql = sql + " where t.name like @name";
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

            var category = os.FindObject<Category>(CriteriaOperator.Parse("[Name] = ?", CategoryName));
            if (category == null)
            {
                throw new Exception($"I am sorry but you need to type the Category Name exactly. {CategoryName} was not found");
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