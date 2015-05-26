using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QuanLiBanVeTau
{
    public partial class TkeControls : DevExpress.XtraEditors.XtraUserControl
    {
        public TkeControls()
        {
            InitializeComponent();
        }

        private void cmbTieuChiThongKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientPanel.Controls.Clear();
            if (cmbTieuChiThongKe.SelectedText == "Vé tàu")
            {
                TKeVeTauControls tKeVeTauControls = new TKeVeTauControls();
                tKeVeTauControls.Dock = DockStyle.Fill;
                ClientPanel.Controls.Add(tKeVeTauControls);
            }
            else if (cmbTieuChiThongKe.SelectedText == "Vé đón/tiễn")
                {
                    TKeVeDTienControls tKeVeDTienControls = new TKeVeDTienControls();
                    tKeVeDTienControls.Dock = DockStyle.Fill;
                    ClientPanel.Controls.Add(tKeVeDTienControls);
            }
            else if (cmbTieuChiThongKe.SelectedText == "Tổng doanh thu")
            {
                TKeTongDThuControls tKeTongDThuControls = new TKeTongDThuControls();
                tKeTongDThuControls.Dock = DockStyle.Fill;
                ClientPanel.Controls.Add(tKeTongDThuControls);
            }
            else if (cmbTieuChiThongKe.SelectedText == "Lịch trình")
            {
                TKeDSachLTrinhControls tKeDSachLTrinhControls = new TKeDSachLTrinhControls();
                tKeDSachLTrinhControls.Dock = DockStyle.Fill;
                ClientPanel.Controls.Add(tKeDSachLTrinhControls);
            }
            else if (cmbTieuChiThongKe.SelectedText == "Tình trạng vé")
            {
                TKeDSachTTrangVeControls tKeDSachTTrangVeControls = new TKeDSachTTrangVeControls();
                tKeDSachTTrangVeControls.Dock = DockStyle.Fill;
                ClientPanel.Controls.Add(tKeDSachTTrangVeControls);
            }
        }
    }
}
