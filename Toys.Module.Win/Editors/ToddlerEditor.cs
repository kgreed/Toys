using System;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Win.Editors;
using Toys.Module.BusinessObjects;
using Toys.Module.DTO;

namespace Toys.Module.Win.Editors
{
    [PropertyEditor(typeof(ToddlerToy), true)]
    public class ToddlerEditor : WinPropertyEditor
    {
        private ToddlerControl control;
        protected override void ReadValueCore()
        {
            base.ReadValueCore();
            if (control == null) return;
            var b = CurrentObject as NPToy;
            if (b?.ToddlerToy == null) return;
            control.ToddlerToyDto = new ToddlerToyDto(b.ToddlerToy);
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
            control = new ToddlerControl();
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
        protected override void WriteValueCore()
        {
            if (CurrentObject == null) return;
            var b = CurrentObject as NPToy;
            control.WriteDtoBack(b.ToddlerToy);
        }
        public ToddlerEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model)
        {
        }

        public override bool IsCaptionVisible => false;
    }
}