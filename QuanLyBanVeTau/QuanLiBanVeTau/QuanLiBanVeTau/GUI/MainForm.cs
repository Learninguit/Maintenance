using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using QuanLiBanVeTau.BLL;
using QuanLiBanVeTau.DAL;
using QuanLiBanVeTau.DTO;
namespace QuanLiBanVeTau.GUI
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public DangNhapForm loginForm = new DangNhapForm();
        LichTrinhUC lichTrinhUC = new LichTrinhUC();
        VeTauUC veTauUC;

        LuuTruForm luuTruFrom = new LuuTruForm();
        public MainForm()
        {
            InitializeComponent();
            lichTrinhUC.Dock = DockStyle.Fill;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            ShowFormDangNhap();
            GaTauControl gaTauControl = new GaTauControl();

            GaTauInfo gaTauInfo = new GaTauInfo();
            gaTauInfo.TenGa = "All";
            gaTauInfo.MaGa = "All";
            List<GaTauInfo> listGaDi = gaTauControl.GetDSGaTau();
            listGaDi.Add(gaTauInfo);
            
            //chèn dữ liệu vào Ga đi
            cmbGaDi.DataSource = listGaDi;
            cmbGaDi.DisplayMember = "TenGa";
            cmbGaDi.ValueMember = "MaGa";
            cmbGaDi.SelectedIndex = -1;
            //Chèn dữ liệu vào ga đến
            List<GaTauInfo> listGaDen = gaTauControl.GetDSGaTau();
            listGaDen.Add(gaTauInfo);
            
            cmbGaDen.DataSource = listGaDen;
            cmbGaDen.DisplayMember = "TenGa";
            cmbGaDen.ValueMember = "MaGa";
            cmbGaDen.SelectedIndex = -1;
            //Chèn dữ liệu và đoàn tàu
            DoanTauControl doanTauControl = new DoanTauControl();
            DoanTauInfo doanTauInfo = new DoanTauInfo();
            doanTauInfo.MaTau = "All";
            List<DoanTauInfo> listDoanTau = doanTauControl.GetDSDoanTau();
            listDoanTau.Add(doanTauInfo);

            cmbMaTau.DataSource = listDoanTau;
            cmbMaTau.DisplayMember = "MaTau";
            cmbMaTau.ValueMember = "MaTau";
            cmbMaTau.SelectedIndex = -1;
            //Chèn dữ liệu vào laoi ghe
            LoaiGheControl loaiGheControl = new LoaiGheControl();
            cmbLoaiToa.DataSource = loaiGheControl.GetDSLoaiGhe();
            cmbLoaiToa.DisplayMember = "MaLoaiGhe";
            cmbLoaiToa.ValueMember = "MaLoaiGhe";
            cmbLoaiToa.SelectedIndex = -1;

            this.ClientPanel.Controls.Clear();
            lichTrinhUC.gCtrlLichTrinh.DataSource = lichTrinhControl.GetDSLichTrinh();
            this.ClientPanel.Controls.Add(lichTrinhUC);
        }

        public void ShowFormDangNhap()
        {
            //disable control cua form chinh
            this.Enabled = false;
            loginForm.ShowDialog();
            if (loginForm.DialogResult == System.Windows.Forms.DialogResult.Cancel)
            {
                Application.Exit();
            }
            else
            {
                //Sau khi dang nhap thanh cong thi enable lai control cua main form
                this.Enabled = true;
                this.Visible = true;
                this.ribbonChucNang.Visible = true;
                this.ribbonThongKe.Visible = true;
                // Kiem tra tai khoan
                if (loginForm.account is HanhKhachInfo)
                {
                    // Nếu là hành khách thì tắt chức năng thống kê, lưu trữ
                    //chức năng đặt vé và trả vé
                    this.ribbonChucNang.Visible = false;
                    this.ribbonThongKe.Visible = false;
                    this.btnRbDoiVe.Enabled = false;
                    this.btnRbTraVe.Enabled = false;
                }
                else if (((NhanVienInfo)loginForm.account).MaNV == "PBV")
                {
                    //Nếu là nhân viên bán vé thì disable chức năng
                    //thống kế và lưu trữ
                    this.ribbonChucNang.Visible = false;
                    this.ribbonThongKe.Visible = false;
                }
                else if (((NhanVienInfo)loginForm.account).MaNV == "PKT")
                {
                    //Nếu là nhân viên kế toán thì disable chức năng lưu trữ
                    this.ribbonChucNang.Visible = false;
                }
            }
        }

        private void btnRbDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowFormDangNhap();
        }

        public void btnRbDatVe_ItemClick(object sender, ItemClickEventArgs e)
        {
            //try
            //{
            //    veTauUC = new VeTauUC();
            //    veTauUC.Dock = DockStyle.Fill;
            //    if (lichTrinhUC.gVLichTrinh.FocusedRowHandle < 0) throw new Exception("Chưa chọn lịch trình");
            //    veTauUC.choosedLichTrinhInfo = new LichTrinhInfo(lichTrinhUC.gVLichTrinh.GetFocusedRowCellValue("MaGaDi").ToString(), lichTrinhUC.gVLichTrinh.GetFocusedRowCellValue("MaGaDen").ToString(), lichTrinhUC.gVLichTrinh.GetFocusedRowCellValue("MaTau").ToString(), (DateTime)lichTrinhUC.gVLichTrinh.GetFocusedRowCellValue("NgayKhoiHanh"), (DateTime)lichTrinhUC.gVLichTrinh.GetFocusedRowCellValue("GioKhoiHanh"), (DateTime)lichTrinhUC.gVLichTrinh.GetFocusedRowCellValue("NgayDen"), (DateTime)lichTrinhUC.gVLichTrinh.GetFocusedRowCellValue("GioDen"));
            //    ClientPanel.Controls.Clear();
            //    veTauUC.tabVetau.SelectedTabPageIndex = 0;
            //    ClientPanel.Controls.Add(veTauUC);
            //}
            //catch(Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}           
        }

        private void btnRbTraVe_ItemClick(object sender, ItemClickEventArgs e)
        {
            veTauUC = new VeTauUC();
            veTauUC.Dock = DockStyle.Fill;
            ClientPanel.Controls.Clear();
            veTauUC.tabVetau.SelectedTabPageIndex = 2;
            ClientPanel.Controls.Add(veTauUC);
        }

        LichTrinhControl lichTrinhControl = new LichTrinhControl();

        private void btnRbLichTrinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            ClientPanel.Controls.Clear();
            lichTrinhUC.gCtrlLichTrinh.DataSource = lichTrinhControl.GetDSLichTrinh();
            ClientPanel.Controls.Add(lichTrinhUC);
        }

        private void btnRbDoiVe_ItemClick(object sender, ItemClickEventArgs e)
        {
            veTauUC = new VeTauUC();
            veTauUC.Dock = DockStyle.Fill;
            ClientPanel.Controls.Clear();

            veTauUC.tabVetau.SelectedTabPageIndex = 1;
            ClientPanel.Controls.Add(veTauUC);
        }

        TkeControls dThuControls = new TkeControls();
        private void btnRbDoanhThu_ItemClick(object sender, ItemClickEventArgs e)
        {
            ClientPanel.Controls.Clear();
            dThuControls.Dock = DockStyle.Fill;
            ClientPanel.Controls.Add(dThuControls);
        }

        private void gCtrlDTGiamGia_Load(object sender, EventArgs e)
        {
            DTGiamGiaControl dTGiamGiaControl = new DTGiamGiaControl();
            gCtrlDTGiamGia.DataSource = dTGiamGiaControl.GetDSDTGiamGia();
        }

        private void btnLuuTruLichTrinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LuuTruForm lTruForm = new LuuTruForm();
            lTruForm.tabLuuTru.SelectedTabPageIndex = 0;
            lTruForm.ShowDialog();
            
        }

        private void btnLuuTruDonGia_ItemClick(object sender, ItemClickEventArgs e)
        {
            LuuTruForm lTruForm = new LuuTruForm();
            lTruForm.tabLuuTru.SelectedTabPageIndex = 1;
            lTruForm.ShowDialog();
            
        }

        private void btnLuuTruUuDai_ItemClick(object sender, ItemClickEventArgs e)
        {
            LuuTruForm lTruForm = new LuuTruForm();
            lTruForm.tabLuuTru.SelectedTabPageIndex = 2;
            lTruForm.ShowDialog();
           
        }

        private void tbnRbNhaGa_ItemClick(object sender, ItemClickEventArgs e)
        {
            LuuTruForm lTruForm = new LuuTruForm();
            lTruForm.tabLuuTru.SelectedTabPageIndex = 3;
            lTruForm.ShowDialog();
        }

        private void btnRbDoanTau_ItemClick(object sender, ItemClickEventArgs e)
        {
            LuuTruForm lTruForm = new LuuTruForm();
            lTruForm.tabLuuTru.SelectedTabPageIndex = 4;
            lTruForm.ShowDialog();
        }

        GaTauControl gaTauControl = new GaTauControl();
        private void gCtrlNhaGa_Load(object sender, EventArgs e)
        {
            gCtrlNhaGa.DataSource = gaTauControl.GetDSGaTau();
        }

        DoanTauControl doanTauControl = new DoanTauControl();
        private void gCtrlDoantau_Load(object sender, EventArgs e)
        {
            gCtrlDoantau.DataSource = doanTauControl.GetDSDoanTau();
        }

        GiaVeControl giaVeControl = new GiaVeControl();
        LoaiGheControl loaiGheControl = new LoaiGheControl();
        private void gCtrlGiaVe_Load(object sender, EventArgs e)
        {
            gCtrlGiaVe.DataSource = giaVeControl.GetDSGiaVe();
            LUTenLoaiGhe.DataSource = loaiGheControl.GetDSLoaiGhe();
        }

        private void tabDangXuat_ItemPressed(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            this.ShowFormDangNhap();
        }

        private void cmbGaDi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lichTrinhUC.gCtrlLichTrinh.DataSource = lichTrinhControl.GetDSLichTrinh(cmbGaDi.SelectedValue, cmbGaDen.SelectedValue, cmbMaTau.SelectedValue, deTuNgay.DateTime, deDenNgay.DateTime);
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void cmbGaDen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lichTrinhUC.gCtrlLichTrinh.DataSource = lichTrinhControl.GetDSLichTrinh(cmbGaDi.SelectedValue, cmbGaDen.SelectedValue, cmbMaTau.SelectedValue, deTuNgay.DateTime, deDenNgay.DateTime);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void deTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lichTrinhUC.gCtrlLichTrinh.DataSource = lichTrinhControl.GetDSLichTrinh(cmbGaDi.SelectedValue, cmbGaDen.SelectedValue, cmbMaTau.SelectedValue, deTuNgay.DateTime, deDenNgay.DateTime);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void deDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lichTrinhUC.gCtrlLichTrinh.DataSource = lichTrinhControl.GetDSLichTrinh(cmbGaDi.SelectedValue, cmbGaDen.SelectedValue, cmbMaTau.SelectedValue, deTuNgay.DateTime, deDenNgay.DateTime);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void cmbMaTau_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lichTrinhUC.gCtrlLichTrinh.DataSource = lichTrinhControl.GetDSLichTrinh(cmbGaDi.SelectedValue, cmbGaDen.SelectedValue, cmbMaTau.SelectedValue, deTuNgay.DateTime, deDenNgay.DateTime);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}