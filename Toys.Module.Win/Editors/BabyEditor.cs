using System;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Win.Editors;
using Toys.Module.BusinessObjects;

namespace Toys.Module.Win.Editors
{
    [PropertyEditor(typeof(BabyToy), true)]
    public class BabyEditor : WinPropertyEditor
    {
        protected override object CreateControlCore()
        {
           return new BabyControl();
        }

        public BabyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model)
        {
        }
    }
}