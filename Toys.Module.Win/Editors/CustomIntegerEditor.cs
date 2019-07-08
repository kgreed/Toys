//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using DevExpress.ExpressApp.Model;
//using DevExpress.ExpressApp.Editors;
//using DevExpress.ExpressApp.Win.Editors;
//using DevExpress.XtraEditors.Repository;
//namespace Toys.Module.Win.Editors
//{
    
//    // ... 
//    [PropertyEditor(typeof(Int32), false)]
//    public class CustomIntegerEditor : PropertyEditor, IInplaceEditSupport
//    {
//        private NumericUpDown control = null;
//        protected override void ReadValueCore()
//        {
//            if (control != null)
//            {
//                if (CurrentObject != null)
//                {
//                    control.ReadOnly = false;
//                    control.Value = (int)PropertyValue;
//                }
//                else
//                {
//                    control.ReadOnly = true;
//                    control.Value = 0;
//                }
//            }
//        }
//        private void control_ValueChanged(object sender, EventArgs e)
//        {
//            if (!IsValueReading)
//            {
//                OnControlValueChanged();
//                WriteValueCore();
//            }
//        }
//        protected override object CreateControlCore()
//        {
//            control = new NumericUpDown();
//            control.Minimum = 0;
//            control.Maximum = 5;
//            control.ValueChanged += control_ValueChanged;
//            return control;
//        }
//        protected override void OnControlCreated()
//        {
//            base.OnControlCreated();
//            ReadValue();
//        }
//        public CustomIntegerEditor(Type objectType, IModelMemberViewItem info)
//            : base(objectType, info)
//        {
//        }
//        protected override void Dispose(bool disposing)
//        {
//            if (control != null)
//            {
//                control.ValueChanged -= control_ValueChanged;
//                control = null;
//            }
//            base.Dispose(disposing);
//        }
//        RepositoryItem IInplaceEditSupport.CreateRepositoryItem()
//        {
//            RepositoryItemSpinEdit item = new RepositoryItemSpinEdit();
//            item.MinValue = 0;
//            item.MaxValue = 5;
//            item.Mask.EditMask = "0";
//            return item;
//        }
//        protected override object GetControlValueCore()
//        {
//            if (control != null)
//            {
//                return (int)control.Value;
//            }
//            return null;
//        }
//    }
//}
