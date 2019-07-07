using System;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Win.Editors;
using Toys.Module.BusinessObjects;

namespace Toys.Module.Win.Editors
{
    [PropertyEditor(typeof(PreSchoolToy), true)]
    public class PreSchoolEditor : WinPropertyEditor
    {
        protected override object CreateControlCore()
        {
            throw new NotImplementedException();
        }

        public PreSchoolEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model)
        {
        }
    }
}