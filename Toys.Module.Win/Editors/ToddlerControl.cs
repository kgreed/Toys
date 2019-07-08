using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Toys.Module.BusinessObjects;
using Toys.Module.DTO;

namespace Toys.Module.Win.Editors
{
    public partial class ToddlerControl : XtraUserControl
    {
        public ToddlerControl()
        {
            InitializeComponent();
            chkGoodForWalking.CheckedChanged += ChkGoodForWalking_CheckedChanged;
            chkHelpsTalking.CheckedChanged += ChkHelpsTalking_CheckedChanged;
        }

        private ToddlerToyDto dto;

        public ToddlerToyDto ToddlerToyDto { get => dto;
            set
            {
                dto = value;
                chkGoodForWalking.Checked = dto.GoodForWalking;
                chkHelpsTalking.Checked = dto.HelpsTalking;
            }
        }
        private void ChkHelpsTalking_CheckedChanged(object sender, EventArgs e)
        {
            var chk = sender as CheckBox;
            dto.HelpsTalking = chk.Checked;
            ValueChanged(this, new EventArgs());
        }
        public event EventHandler<EventArgs> ValueChanged;


        private void ChkGoodForWalking_CheckedChanged(object sender, EventArgs e)
        {
            var chk = sender as CheckBox;
            dto.GoodForWalking = chk.Checked;
            ValueChanged(this, new EventArgs());
        }

        private void ToddlerControl_Load(object sender, EventArgs e)
        {

        }
        internal void WriteDtoBack(ToddlerToy toddlerToy)
        {
            toddlerToy.GoodForWalking = ToddlerToyDto.GoodForWalking;
            toddlerToy.HelpsTalking = ToddlerToyDto.HelpsTalking;

        }

    }
}
