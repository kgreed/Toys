using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Toys.Module.BusinessObjects;
using Toys.Module.DTO;

namespace Toys.Module.Win.Editors
{
    public partial class BabyControl : XtraUserControl
    {
        public BabyControl()
        {
            InitializeComponent();
           
            chkCrawling.CheckedChanged += ChkCrawling_CheckedChanged;
            chkTeething.CheckedChanged += ChkTeething_CheckedChanged1;


        }

        private void ChkTeething_CheckedChanged1(object sender, EventArgs e)
        {
            var chk = sender as CheckBox;
            dto.HelpsTeething = chk.Checked;
            ValueChanged(this, new EventArgs());
        }

        private void ChkCrawling_CheckedChanged(object sender, EventArgs e)
        {
            var chk = sender as CheckBox;
            dto.GoodForCrawling = chk.Checked;
            ValueChanged(this, new EventArgs());
        }

        

        private BabyToyDto dto;
        public BabyToyDto BabyToyDto { get => dto;
            set
            {
                dto = value;
                chkCrawling.Checked = dto.GoodForCrawling;
                chkTeething.Checked = dto.HelpsTeething;
            }
        }

        private void BabyControl_Load(object sender, System.EventArgs e)
        {
            // sender is Toys.Module.Win.Editors.BabyControl
           
        }


        public event EventHandler<EventArgs> ValueChanged;

    

        internal void WriteDtoBack(BabyToy babyToy)
        {
            babyToy.GoodForCrawling =BabyToyDto.GoodForCrawling;
            babyToy.HelpsTeething =BabyToyDto.HelpsTeething;
        }
    }
}
