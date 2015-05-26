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
using QuanLiBanVeTau.BLL;
using QuanLiBanVeTau.DAL;
using QuanLiBanVeTau.DTO;
using System.Collections;
using DevExpress.XtraReports.UI;
namespace QuanLiBanVeTau.GUI
{
    public partial class VeTauUC : DevExpress.XtraEditors.XtraUserControl
    {
        public LichTrinhInfo choosedLichTrinhInfo;
        public VeTauUC()
        {
            InitializeComponent();
        }

        LichTrinhControl lichTrinhControl = new LichTrinhControl();
        GaTauControl gaTauControl = new GaTauControl();
        LoaiGheControl loaiGheControl = new LoaiGheControl();

        DTGiamGiaControl dTGiamGiaControl = new DTGiamGiaControl();

        GheControl gheControl = new GheControl();
        GheInfo gheInfo = new GheInfo();

        ToaTauControl toaTauControl = new ToaTauControl();

        GiaVeControl giaVeControl = new GiaVeControl();

        List<LichTrinhInfo> listLichTrinh = new List<LichTrinhInfo>();
        private void VeTauUC_Load(object sender, EventArgs e)
        {
            try
            {
                if(choosedLichTrinhInfo != null)
                {
                    listLichTrinh.Clear();
                    listLichTrinh.Add(lichTrinhControl.GetLTTheoMaLT(choosedLichTrinhInfo.MaLichTrinh));
                    gCtrlLichTrinh.DataSource = listLichTrinh;
                    lUEGaDi.DataSource = gaTauControl.GetDSGaTau();
                    lUEGaDen.DataSource = gaTauControl.GetDSGaTau();

                    cmbUuDai.DisplayMember = "TenDT";
                    cmbUuDai.ValueMember = "MaDT";
                    cmbUuDai.DataSource = dTGiamGiaControl.GetDSDTGiamGia();

                    cmbSoToa.DisplayMember = "SoToa";
                    cmbSoToa.ValueMember = "MaToa";
                    cmbSoToa.DataSource = toaTauControl.GetDSToaTau(choosedLichTrinhInfo.MaTau);
                }
                MainForm mainForm = (MainForm)this.ParentForm;
                this.Enabled = true;
                this.Visible = true;
                if(mainForm.loginForm.account is HanhKhachInfo)
                {
                    this.btnInHoaDon.Visible = false;
                    this.btnInVe.Visible = false;
                    this.tabDoiVe.PageVisible = false;
                    
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(this.LookAndFeel, ex.Message);
            }           
        }

        private void cmbSoToa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Cập nhật số toa
                gheInfo.MaToa = cmbSoToa.SelectedValue.ToString();
                //Lấy nhưng loại ghế có trong toa
                cmbLoaiGhe.DisplayMember = "TenGhe";
                cmbLoaiGhe.ValueMember = "MaLoaiGhe";
                cmbLoaiGhe.DataSource = gheControl.GetDSLoaiGheTrongToa(gheInfo);
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(this.LookAndFeel,ex.Message);
            }
        }

        private void cmbLoaiGhe_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Lấy mã loại ghế được chọn
                gheInfo.MaLoaiGhe = cmbLoaiGhe.SelectedValue.ToString();
                //Lấy danh sách ghế
                cmbSoGhe.DisplayMember = "SoGhe";
                cmbSoGhe.ValueMember = "MaGhe";
                cmbSoGhe.DataSource = gheControl.GetDSGhe(gheInfo);

                if (((List<GheInfo>)cmbSoGhe.DataSource).Count > 0)
                {
                    //Nếu còn ghế thì cho phép thêm hành khách
                    btnThemHanhKhach.Enabled = true;
                    //Cập nhật giá vé
                    this.TinhGiave();
                }    
                else
                {
                    //Nếu hết ghế thì thông báo hết ghế và không cho phép thêm hành khách
                    cmbSoGhe.Text = "(Hết ghế)";
                    cmbSoGhe.DataSource = null;
                    btnThemHanhKhach.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this.LookAndFeel, ex.Message);
            }
        }



        private void cmbUuDai_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.TinhGiave();
        }

        string MaGiaVe;
        public void TinhGiave()
        {
            //try
            //{
            //    MaGiaVe = choosedLichTrinhInfo.MaGaDi + choosedLichTrinhInfo.MaGaDen + choosedLichTrinhInfo.MaTau + cmbLoaiGhe.SelectedValue.ToString();
            //    txtDonGia.Text = giaVeControl.GetDonGia(MaGiaVe).ToString();
            //    txtGiaVe.Text = giaVeControl.GetGiaVe(MaGiaVe, dTGiamGiaControl.GetTiLe(cmbUuDai.SelectedValue.ToString())).ToString();
            //}
            //catch (Exception ex)
            //{
            //    txtDonGia.Text = "";
            //    txtGiaVe.Text = "";
            //}
        }

        bool flagDatVe = false;
        DatVeControl datVeControl = new DatVeControl();
        DatVeInfo datVeInfo;
        CTDVControl cTDVControl = new CTDVControl();
        private void btnThemHanhKhach_Click(object sender, EventArgs e)
        {
            try
            {
                //Kiểm tra có phải lần đầu thêm hanh khách hanh không
                if(flagDatVe == false)
                {
                    //Nếu phải thì thêm thông tin đặt vé
                    datVeInfo = new DatVeInfo();
                    datVeInfo.MaDatVe = this.TaoMaDatVe();
                    //Kiểm tra là nhân viên đang đặt vé hay la hành khách
                    MainForm mainFom = (MainForm)this.ParentForm;
                    if(mainFom.loginForm.account is HanhKhachInfo)
                    {
                        HanhKhachInfo info = (HanhKhachInfo)mainFom.loginForm.account;
                        //Nếu là hành khách thì thêm mã hành khách vào thông tin đặt vé
                        datVeInfo.MaHK = info.MaHK;
                    }
                    datVeInfo.MaLichTrinh = choosedLichTrinhInfo.MaLichTrinh;
                    datVeInfo.NgayHetHan = DateTime.Today.AddDays(3);
                    datVeControl.insert(datVeInfo);
                    //Sau khi tao một bảng đặt vé thì chỉ thêm chi tiết đặt vé chứ không thêm bảng ghi đặt vé nữa
                    flagDatVe = true;
                }
                //Lấy thông tin chi tiết đặt vé
                CTDVInfo cTDVInfo = new CTDVInfo();
                cTDVInfo.MaDatVe = datVeInfo.MaDatVe;
                cTDVInfo.TenHK = txtHoTen.Text;
                cTDVInfo.CMND = txtCMND.Text;
                cTDVInfo.MaDT = cmbUuDai.SelectedValue.ToString();
                cTDVInfo.MaGhe = cmbSoGhe.SelectedValue.ToString();
                cTDVInfo.MaGiaVe = MaGiaVe;
                cTDVInfo.Gia = Convert.ToDouble(txtGiaVe.Text);
                cTDVInfo.MaToa = cmbSoToa.SelectedValue.ToString();
                cTDVInfo.SoToa = Convert.ToInt32(cmbSoToa.Text);
                cTDVInfo.SoGhe = Convert.ToInt32(cmbSoGhe.Text);
                foreach (CTDVInfo info in cTDVControl.GetDSCTDVTheoMaDatVe(datVeInfo.MaDatVe))
                {
                    if (info.CMND == cTDVInfo.CMND)
                    {
                        throw new Exception("Một chứng minh nhân dân chỉ dùng cho một hành khách");
                    }
                }
                //Thêm hành khách vào bảng chi tiêt đặng vé để giữ ghế
                cTDVControl.insert(cTDVInfo);
                //Tính lại tổng giá của phiêu đặt vé
                datVeInfo.TongGia += cTDVInfo.Gia;
                //Update Đặt Vé
                datVeControl.update(datVeInfo);

                //Cập nhật datasources
                gCtrlHanhKhach.DataSource = cTDVControl.GetDSCTDVTheoMaDatVe(datVeInfo.MaDatVe);



                //Thay đổi datasources cua combobox
                cmbSoGhe.DataSource = gheControl.GetDSGhe(gheInfo);
                //Cập nhật tổng số vé
                lbTongSoVe.Text = cTDVControl.GetDSCTDVTheoMaDatVe(datVeInfo.MaDatVe).Count.ToString();
                //Cập nhật tổng số tiền lên màn hình
                lbTongTien.Text = datVeInfo.TongGia.ToString() + " VNĐ";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this.LookAndFeel, ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public string TaoMaDatVe()
        {
            int max = 0;
            List<DatVeInfo> list = datVeControl.GetDSDatVe();
            foreach(DatVeInfo info in list)
            {
                max = Math.Max(max, Convert.ToInt32(info.MaDatVe));
            }
            max++;
            return max.ToString();
        }

        private void btnDeleteHanhKhach_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //Lấy thông tin delete
            CTDVInfo deleteInfo = new CTDVInfo();
            deleteInfo.MaDatVe = gVHanhKhach.GetFocusedRowCellValue("MaDatVe").ToString();
            deleteInfo.MaGhe = gVHanhKhach.GetFocusedRowCellValue("MaGhe").ToString();
            deleteInfo.Gia = Convert.ToDouble(gVHanhKhach.GetFocusedRowCellValue("Gia"));
            cTDVControl.delete(deleteInfo);

            datVeInfo.TongGia -= deleteInfo.Gia;
            //Cập nhật datasources
            gCtrlHanhKhach.DataSource = cTDVControl.GetDSCTDVTheoMaDatVe(datVeInfo.MaDatVe);

            //Thay đổi datasources cua combobox
            cmbSoGhe.DataSource = gheControl.GetDSGhe(gheInfo);
            //Cập nhật tổng số vé
            lbTongSoVe.Text = cTDVControl.GetDSCTDVTheoMaDatVe(datVeInfo.MaDatVe).Count.ToString();
            //Cập nhật tổng số tiền lên màn hình
            lbTongTien.Text = datVeInfo.TongGia.ToString() + " VNĐ";
        }

        private void btnInPhieuDatVe_Click(object sender, EventArgs e)
        {
            try
            {
                if (datVeInfo == null) throw new Exception("Chưa chọn vé");
                DatVeReport datVeReport = new DatVeReport();
                datVeReport.FilterString = "[MADATVE] = '" + datVeInfo.MaDatVe + "'";
                datVeReport.CreateDocument();
                datVeReport.ShowPreviewDialog();
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(this.LookAndFeel, ex.Message);
            }
        }

        HoaDonInfo hoaDonInfo;
        HoaDonControl hoaDonControl = new HoaDonControl();
        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                hoaDonInfo = new HoaDonInfo();
                hoaDonInfo.MaHD = this.TaoMaHoaDon();
                hoaDonInfo.MaDatVe = datVeInfo.MaDatVe;
                MainForm mainform = (MainForm)this.ParentForm;
                hoaDonInfo.MaNV = ((NhanVienInfo)mainform.loginForm.account).MaNV;
                hoaDonInfo.NgayLap = DateTime.Today;
                hoaDonInfo.ThanhToan = Convert.ToDouble(this.txtThanhToan.Text);
                hoaDonInfo.ThoiLai = Convert.ToDouble(this.txtThoiLai.Text);
                hoaDonControl.insert(hoaDonInfo);
                HoaDonReport hoaDonReport = new HoaDonReport();
                hoaDonReport.FilterString = "[MAHD] = '" + hoaDonInfo.MaHD + "'";
                hoaDonReport.CreateDocument();
                hoaDonReport.ShowPreview();
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(this.LookAndFeel, ex.Message);
            }
        }

        public string TaoMaHoaDon()
        {
            int max = 0;
            List<HoaDonInfo> list = hoaDonControl.GetDSHoaDon();
            foreach (HoaDonInfo info in list)
            {
                max = Math.Max(max, Convert.ToInt32(info.MaHD));
            }
            max++;
            return max.ToString();
        }
        private void txtThanhToan_TextChanged(object sender, EventArgs e)
        {
            if(txtThanhToan.Text != null && txtThanhToan.Text != "" && datVeInfo != null)
            {
                this.txtThoiLai.Text = (Convert.ToDouble(this.txtThanhToan.Text) - datVeInfo.TongGia).ToString();
            } 
        }

        private void btnDoiVe_Click(object sender, EventArgs e)
        {
            gCtrlVeTra.DataSource = datVeControl.GetDatVe(txtMaVeTra.Text);
        }

        private void btnRbDoiVe_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CTDVInfo deleteInfo = new CTDVInfo();
            deleteInfo.MaDatVe = txtMaVeTra.Text;
            deleteInfo.MaGhe = gVVeTra.GetFocusedRowCellValue("MaTau").ToString() + gVVeTra.GetFocusedRowCellValue("SoToa").ToString() + gVVeTra.GetFocusedRowCellValue("SoGhe").ToString();
            cTDVControl.delete(deleteInfo);
            gCtrlVeTra.DataSource = datVeControl.GetDatVe(txtMaVeTra.Text);
        }

        
    }
}
