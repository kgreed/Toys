using System;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Win.Editors;
using Toys.Module.BusinessObjects;

namespace Toys.Module.Win.Editors
{
    [PropertyEditor(typeof(ToddlerToy), true)]
    public class ToddlerEditor : WinPropertyEditor
    {
        protected override object CreateControlCore()
        {
            throw new NotImplementedException();
        }

        public ToddlerEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model)
        {
        }
    }
}