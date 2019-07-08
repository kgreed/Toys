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
    public partial class PreSchoolControl : XtraUserControl
    {
        public event EventHandler<EventArgs> ValueChanged;

        public PreSchoolControl()
        {
            InitializeComponent();
            chkSocial.CheckedChanged += ChkSocial_CheckedChanged;
            chkReading.CheckedChanged += ChkReading_CheckedChanged;
        }

        private void ChkReading_CheckedChanged(object sender, EventArgs e)
        {
            var chk = sender as CheckBox;
            dto.GoodForSocial= chk.Checked;
            ValueChanged(this, new EventArgs());
        }

        private void ChkSocial_CheckedChanged(object sender, EventArgs e)
        {
            var chk = sender as CheckBox;
            dto.HelpsReading = chk.Checked;
            ValueChanged(this, new EventArgs());
        }

        private PreSchoolToyDto dto;
        public PreSchoolToyDto PreSchoolToyDto
        {
            get => dto;
            set
            {
                dto = value;
                chkReading.Checked = dto.HelpsReading;
                chkSocial.Checked = dto.GoodForSocial;
            }
        }
        


        private void PreSchoolControl_Load(object sender, EventArgs e)
        {

        }

        public void WriteDtoBack(PreSchoolToy toy)
        {
            toy.GoodForSocial = PreSchoolToyDto.GoodForSocial;
            toy.HelpsReading = PreSchoolToyDto.HelpsReading;
        }
    }
}
