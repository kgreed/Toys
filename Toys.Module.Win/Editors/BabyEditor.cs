using System;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Win.Editors;
using Toys.Module.BusinessObjects;
using Toys.Module.DTO;

namespace Toys.Module.Win.Editors
{
    [PropertyEditor(typeof(BabyToy), true)]
    public class BabyEditor : WinPropertyEditor
    {
        private BabyControl control;
        protected override void ReadValueCore()
        {
            base.ReadValueCore();
            if (control == null) return;
            var b = CurrentObject as NPToy;
            if (b?.BabyToy == null) return;
            control.BabyToyDto = new BabyToyDto( b.BabyToy);
        }
        private void control_ValueChanged(object sender, EventArgs e)
        {
            if (IsValueReading) return;
            OnControlValueChanged();
            WriteValueCore();
            var npToy = CurrentObject as NPToy;
            npToy.SetModified();
        }

        protected override object CreateControlCore()
        {
           control = new BabyControl();
           control.ValueChanged += control_ValueChanged;
           return control;
        }

        protected override void OnControlCreated()
        {
            base.OnControlCreated();
            ReadValue();
        }

        protected override void Dispose(bool disposing)
        {
            if (control != null)
            {
                control.ValueChanged -= control_ValueChanged;
                control = null;
            }
            base.Dispose(disposing);
        }

        public BabyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model)
        {
        }
     
        protected override void WriteValueCore()
        {
            if (CurrentObject == null) return;
            var b = CurrentObject as NPToy;
            control.WriteDtoBack(b.BabyToy);
        }

        public override bool IsCaptionVisible => false;
    }
}