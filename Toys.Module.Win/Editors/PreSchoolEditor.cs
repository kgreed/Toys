using System;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Win.Editors;
using Toys.Module.BusinessObjects;
using Toys.Module.DTO;

namespace Toys.Module.Win.Editors
{
    [PropertyEditor(typeof(PreSchoolToy), true)]
    public class PreSchoolEditor : WinPropertyEditor
    {
        private PreSchoolControl control;
        protected override void ReadValueCore()
        {
            base.ReadValueCore();
            if (control == null) return;
            var b = CurrentObject as NPToy;
            if (b?.PreSchoolToy == null) return;
            control.PreSchoolToyDto = new PreSchoolToyDto(b.PreSchoolToy);
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
            control = new PreSchoolControl();
            control.ValueChanged += control_ValueChanged;
            return control;
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

        public PreSchoolEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model)
        {
        }
        protected override void WriteValueCore()
        {
            if (CurrentObject == null) return;
            var b = CurrentObject as NPToy;
            control.WriteDtoBack(b.PreSchoolToy);
        }
        public override bool IsCaptionVisible => false;
    }
}