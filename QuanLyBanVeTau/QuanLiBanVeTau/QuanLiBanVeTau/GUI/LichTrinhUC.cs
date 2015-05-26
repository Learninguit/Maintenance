using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiBanVeTau.BLL;
using QuanLiBanVeTau.DAL;
using QuanLiBanVeTau.DTO;
namespace QuanLiBanVeTau.GUI
{
    public partial class LichTrinhUC : UserControl
    {
        public LichTrinhUC()
        {
            InitializeComponent();
        }

        LichTrinhControl lichTrinhControl = new LichTrinhControl();
        GaTauControl gaTauControl = new GaTauControl();
        private void gCtrlLichTrinh_Load(object sender, EventArgs e)
        {
            gCtrlLichTrinh.DataSource = lichTrinhControl.GetDSLichTrinh();
            lUEGaDen.DataSource = gaTauControl.GetDSGaTau();
            lUEGaDi.DataSource = gaTauControl.GetDSGaTau();
        }

        private void btnDatVe_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            MainForm mainForm = (MainForm)this.ParentForm;
            mainForm.btnRbDatVe_ItemClick(sender,null);
        }
       
    }
}
