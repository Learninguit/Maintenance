using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using QuanLiBanVeTau.BLL;
using QuanLiBanVeTau.DAL;
using QuanLiBanVeTau.DTO;
namespace QuanLiBanVeTau.GUI
{
    public partial class LuuTruForm : DevExpress.XtraEditors.XtraForm
    {
        public LuuTruForm()
        {
            InitializeComponent();
        }
        GiaVeControl giaVeControl = new GiaVeControl();
        DoanTauControl doanTauControl = new DoanTauControl();
        GaTauControl gatauControl = new GaTauControl();
        LoaiGheControl loaiGheControl = new LoaiGheControl();
        private void gCtrlGiaVe_Load(object sender, EventArgs e)
        {
            gCtrlGiaVe.DataSource = giaVeControl.GetDSGiaVe();

            cmbDonGiaMaTau.DataSource = doanTauControl.GetDSDoanTau();
            cmbDonGiaMaTau.DisplayMember = "MaTau";
            cmbDonGiaMaTau.ValueMember = "MaTau";
            cmbDonGiaMaTau.SelectedIndex = -1;


            cmbDonGiaLoaiGhe.DataSource = loaiGheControl.GetDSLoaiGhe();
            cmbDonGiaLoaiGhe.DisplayMember = "TenGhe";
            cmbDonGiaLoaiGhe.ValueMember = "MaLoaiGhe";
            cmbDonGiaLoaiGhe.SelectedIndex = -1;

            lUEDonGiaMaTau.DataSource = doanTauControl.GetDSDoanTau();
            lUEDonGiaLoaiGhe.DataSource = loaiGheControl.GetDSLoaiGhe();

        }


        private void btnThemDonGia_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDonGiaMaTau.SelectedIndex < 0) throw new Exception("Lỗi!\nChưa chọn mã tàu");              
                if (cmbDonGiaLoaiGhe.SelectedIndex < 0) throw new Exception("Lỗi!\nChưa chọn loại ghế");
                if (txtDonGia.Text == String.Empty) throw new Exception("Lỗi!\nChưa nhập đơn giá");                     
                GiaVeInfo giaVeInfo = new GiaVeInfo();
                giaVeInfo.MaGiaVe = this.TaoMaGiaVe();
                giaVeInfo.MaTau = cmbDonGiaMaTau.SelectedValue.ToString();
                giaVeInfo.MaLoaiGhe = cmbDonGiaLoaiGhe.SelectedValue.ToString();
                giaVeInfo.DonGia = Convert.ToDouble(txtDonGia.Text);                
               
                if (giaVeControl.GetGiaVe(giaVeInfo.MaTau, giaVeInfo.MaLoaiGhe) != null)
                {
                    DialogResult rs = XtraMessageBox.Show(this.LookAndFeel, "Đã tồn tại giá vé, bạn có muốn cập nhật", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (rs == DialogResult.Yes)
                    {
                        giaVeInfo.MaGiaVe = giaVeControl.GetGiaVe(giaVeInfo.MaTau, giaVeInfo.MaLoaiGhe).MaGiaVe;
                        //giaVeInfo.MaGiaVe = gVGiaVe.GetFocusedRowCellValue("MaGiaVe").ToString();
                        giaVeControl.update(giaVeInfo);
                        XtraMessageBox.Show(this.LookAndFeel, "Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    giaVeControl.insert(giaVeInfo);
                }
                //Thêm chỗ này
                cmbDonGiaMaTau.SelectedIndex = -1;
                cmbDonGiaLoaiGhe.SelectedIndex = -1;
                txtDonGia.Text = "";

                gCtrlGiaVe.DataSource = giaVeControl.GetDSGiaVe();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this.LookAndFeel, ex.Message);
            }
        }
        public string TaoMaGiaVe()
        {
            string magiave = string.Empty;
            //foreach (string s in cmbDonGiaMaTau.Text.Split(' '))
            //{
            //    magiave = magiave + Char.ToUpper(s[0]);
            //}
            magiave = magiave + cmbDonGiaMaTau.SelectedValue.ToString();
            foreach (string s in cmbDonGiaLoaiGhe.Text.Split(' '))
            {
                magiave = magiave + Char.ToUpper(s[0]);
            }
            
            //string s = "";
            
            //if (gVGiaVe.FocusedRowHandle <= 0)
            //    s = "GV001";
            //else
            //{
            //    int k;
            //    s = "GV";
            //    k = Convert.ToInt32(gVGiaVe.GetFocusedRowCellValue("MaGiaVe").ToString().Substring(2, 4));
            //    k = k + 1;
            //    if (k < 10)
            //        s = s + "00";
            //    else if (k < 100)
            //        s = s + "0";
            //    s = s + k.ToString();
            //}
            
           
            return magiave;
        }
        private void gVGiaVe_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            try
            {
                GiaVeInfo giaVeInfo = new GiaVeInfo();
                giaVeInfo.MaGiaVe = gVGiaVe.GetFocusedRowCellValue("MaGiaVe").ToString();
                giaVeInfo.MaTau = gVGiaVe.GetFocusedRowCellValue("MaTau").ToString();
                giaVeInfo.MaLoaiGhe = gVGiaVe.GetFocusedRowCellValue("MaLoaiGhe").ToString();
                giaVeInfo.DonGia = Convert.ToDouble(gVGiaVe.GetFocusedRowCellValue("DonGia"));

                if (giaVeControl.GetGiaVe(giaVeInfo.MaTau, giaVeInfo.MaLoaiGhe) != null && giaVeControl.GetGiaVe(giaVeInfo.MaTau, giaVeInfo.MaLoaiGhe).MaGiaVe != giaVeInfo.MaGiaVe)
                {
                    if (XtraMessageBox.Show(this.LookAndFeel, "Đã có giá vé này\nBạn có muốn cập nhật?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        giaVeControl.delete(giaVeInfo);
                        giaVeInfo.MaGiaVe = giaVeControl.GetGiaVe(giaVeInfo.MaTau, giaVeInfo.MaLoaiGhe).MaGiaVe;
                        giaVeControl.update(giaVeInfo);
                    }
                }
                else
                {
                    giaVeControl.update(giaVeInfo);
                }
                gCtrlGiaVe.DataSource = giaVeControl.GetDSGiaVe();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this.LookAndFeel, ex.Message);
            }
        }

        private void btnXoaGiaVe_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if(XtraMessageBox.Show(this.LookAndFeel, "Xóa giá vé?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                {
                    GiaVeInfo giaVeInfo = new GiaVeInfo();
                    giaVeInfo.MaGiaVe = gVGiaVe.GetFocusedRowCellValue("MaGiaVe").ToString();
                    giaVeControl.delete(giaVeInfo);
                    gCtrlGiaVe.DataSource = giaVeControl.GetDSGiaVe();
                }
                
            }
            catch
            {
                XtraMessageBox.Show(this.LookAndFeel, "Không xóa được","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        LichTrinhControl lichTrinhControl = new LichTrinhControl();
        private void gCtrlLichTrinh_Load(object sender, EventArgs e)
        {
            gCtrlLichTrinh.DataSource = lichTrinhControl.GetDSLichTrinh();
            lUELichTrinhMaTau.DataSource = doanTauControl.GetDSDoanTau();
            lUELichTrinhGaDau.DataSource = gatauControl.GetDSGaTau();
            lUELichTrinhGaCuoi.DataSource = gatauControl.GetDSGaTau();

            //Do du lieu vao combobox them lich trinh
            cmbLichTrinhMaTau.DataSource = doanTauControl.GetDSDoanTau();
            cmbLichTrinhMaTau.DisplayMember = "MaTau";
            cmbLichTrinhMaTau.ValueMember = "MaTau";
            cmbLichTrinhMaTau.SelectedIndex = -1;
        }

        private void cmbLichTrinhMaTau_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoanTauInfo doanTauInfo = doanTauControl.GetDTauTheoMaTau(cmbLichTrinhMaTau.SelectedValue);
            if (doanTauInfo != null)
            {
                txtLichTrinhGaDau.Text = doanTauInfo.TenGaDau;
                txtLichTrinhGaCuoi.Text = doanTauInfo.TenGaCuoi;
            }

        }

        private void dELichTrinhNgayDi_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DoanTauInfo doanTauInfo = doanTauControl.GetDTauTheoMaTau(cmbLichTrinhMaTau.SelectedValue);
                GaDungInfo gaDungDau = gaDungControl.GetGaDung(doanTauInfo.MaTau, doanTauInfo.MaGaDau);

                GaDungInfo gaDungCuoi = gaDungControl.GetGaDung(doanTauInfo.MaTau, doanTauInfo.MaGaCuoi);

                int khoangCach = gaDungCuoi.Km - gaDungDau.Km;
                int gio = khoangCach / doanTauInfo.TocDoTrungBinh;
                int phut = khoangCach % doanTauInfo.TocDoTrungBinh;

                TimeSpan timeSpan = new TimeSpan(gio, phut, 0);
               
                dELichTrinhNgayDen.DateTime = dELichTrinhNgayDi.DateTime.Add(timeSpan);
                
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void btnThemLichTrinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbLichTrinhMaTau.SelectedIndex < 0) throw new Exception("Chọn mã tàu");
                if (dELichTrinhNgayDi.EditValue == null) throw new Exception("Chọn ngày đi");

                LichTrinhInfo lichTrinhInfo = new LichTrinhInfo(cmbLichTrinhMaTau.SelectedValue.ToString(),dELichTrinhNgayDi.DateTime,dELichTrinhNgayDen.DateTime);

                List<LichTrinhInfo> listLichTrinh = lichTrinhControl.GetDSLichTrinh();
                foreach (LichTrinhInfo info in listLichTrinh)
                {
                    if (lichTrinhInfo.MaLichTrinh == info.MaLichTrinh)
                    {
                        if (XtraMessageBox.Show(this.LookAndFeel, "Trùng thông tin lịch trình!\nCập nhật lịch trình", "Thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            lichTrinhControl.update(lichTrinhInfo);
                        }
                        gCtrlLichTrinh.DataSource = lichTrinhControl.GetDSLichTrinh();
                        return;
                    }
                }
                lichTrinhControl.insert(lichTrinhInfo);
                gCtrlLichTrinh.DataSource = lichTrinhControl.GetDSLichTrinh();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this.LookAndFeel, ex.Message);
            }
        }

        private void btnXoaLichTrinh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if(XtraMessageBox.Show(this.LookAndFeel,"Xóa lịch trình?","Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LichTrinhInfo lichTrinhInfo = new LichTrinhInfo();
                    lichTrinhInfo.MaLichTrinh = gVLichTrinh.GetFocusedRowCellValue("MaLichTrinh").ToString();
                    lichTrinhControl.delete(lichTrinhInfo);
                    gCtrlLichTrinh.DataSource = lichTrinhControl.GetDSLichTrinh();
                }
                
            }
            catch
            {
                XtraMessageBox.Show(this.LookAndFeel, "Không xóa được");
            }
            
        }

        private void gVLichTrinh_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            try
            {

                LichTrinhInfo lichTrinhInfo = new LichTrinhInfo(gVLichTrinh.GetFocusedRowCellValue("MaTau").ToString(),(DateTime)gVLichTrinh.GetFocusedRowCellValue("NgayKhoiHanh"),(DateTime)gVLichTrinh.GetFocusedRowCellValue("NgayDen"));
                if(lichTrinhInfo.MaLichTrinh == gVLichTrinh.GetFocusedRowCellValue("MaLichTrinh").ToString())
                {
                    lichTrinhControl.update(lichTrinhInfo);
                    return;
                }
                else
                {
                    List<LichTrinhInfo>  listLichTrinh = lichTrinhControl.GetDSLichTrinh();
                    //Duyet xem lich trinh sau khi thay doi co trung voi ma lich trinh nao khong
                    foreach (LichTrinhInfo info in listLichTrinh)
                    {
                        if (info.MaLichTrinh == lichTrinhInfo.MaLichTrinh)
                        {
                            //Neu trung thi hoi nguoi dung co muon update hay khong
                            if (XtraMessageBox.Show(this.LookAndFeel, "Đã có lịch trình này\nBạn có muốn cập nhật?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                lichTrinhControl.update(lichTrinhInfo);
                            }
                            gCtrlLichTrinh.DataSource = lichTrinhControl.GetDSLichTrinh();
                            return;
                        }
                    }
                }
                  
                lichTrinhControl.insert(lichTrinhInfo);
                gCtrlLichTrinh.DataSource = lichTrinhControl.GetDSLichTrinh();
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this.LookAndFeel, ex.Message);
            }
        }

        

        DTGiamGiaControl dTGiamGiaControl = new DTGiamGiaControl();
        private void gCtrlDTGiamGia_Load(object sender, EventArgs e)
        {
            gCtrlDTGiamGia.DataSource = dTGiamGiaControl.GetDSDTGiamGia();
        }

        DTGiamGiaInfo dTGiamGiaInfo = new DTGiamGiaInfo();
        private void btnThemDoiTuong_Click(object sender, EventArgs e)
        {
            try
            {
                dTGiamGiaInfo.TenDT = txtTenDoiTuong.Text;
                dTGiamGiaInfo.HeSo = Convert.ToDouble(txtHeSo.Text);
                dTGiamGiaControl.insert(dTGiamGiaInfo);
                gCtrlDTGiamGia.DataSource = dTGiamGiaControl.GetDSDTGiamGia();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this.LookAndFeel, ex.Message);
            }
        }

        private void gVDTGiamGia_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            try
            {
                dTGiamGiaInfo.MaDT = Convert.ToInt32(gVDTGiamGia.GetRowCellValue(e.RowHandle, "MaDT"));
                dTGiamGiaInfo.TenDT = gVDTGiamGia.GetRowCellValue(e.RowHandle, "TenDT").ToString();
                dTGiamGiaInfo.HeSo = (Double)gVDTGiamGia.GetRowCellValue(e.RowHandle, "HeSo");
                dTGiamGiaControl.update(dTGiamGiaInfo);
                gCtrlDTGiamGia.DataSource = dTGiamGiaControl.GetDSDTGiamGia();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this.LookAndFeel, ex.Message);
            }
            
        }

        private void btnXoaDoiTuong_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if(XtraMessageBox.Show(this.LookAndFeel,"Xóa đối tượng giảm giá " + gVDTGiamGia.GetFocusedRowCellValue("TenDT") + "?","Xác nhận", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dTGiamGiaInfo.MaDT = Convert.ToInt32(gVDTGiamGia.GetFocusedRowCellValue("MaDT"));
                    dTGiamGiaControl.delete(dTGiamGiaInfo);
                    gCtrlDTGiamGia.DataSource = dTGiamGiaControl.GetDSDTGiamGia();
                }
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this.LookAndFeel,"Không xóa được","Lỗi", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        GaTauControl gaTauControl = new GaTauControl();

        private void btnThemNhaGa_Click(object sender, EventArgs e)
        {
            try
            {
                GaTauInfo gaTauInfo = new GaTauInfo();
                gaTauInfo.MaGa = this.TaoMaGa();
                gaTauInfo.DiaChi = txtDiaChi.Text;
                gaTauInfo.TenGa = txtTenGa.Text;
                gaTauControl.insert(gaTauInfo);
                gCtrlNhaGa.DataSource = gatauControl.GetDSGaTau();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this.LookAndFeel, ex.Message);
            }
        }
        public string TaoMaGa()
        {
            string maga = string.Empty;
            foreach (string s in cmbTinh.Text.Split(' '))
            {
                maga = maga + Char.ToUpper(s[0]);
            }
            foreach (string s in txtTenGa.Text.Split(' '))
            {
                maga = maga + Char.ToUpper(s[0]);
            }
            return maga;
        }

        private void btnXoaNhaGa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if(XtraMessageBox.Show(this.LookAndFeel,"Xóa ga " + gVNhaGa.GetFocusedRowCellValue("TenGa") +" ?","Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GaTauInfo gaTauInfo = new GaTauInfo();
                    gaTauInfo.MaGa = gVNhaGa.GetFocusedRowCellValue("MaGa").ToString();
                    gaTauControl.delete(gaTauInfo);
                    gCtrlNhaGa.DataSource = gaTauControl.GetDSGaTau();
                }                
            }
            catch
            {
                XtraMessageBox.Show(this.LookAndFeel, "Không xóa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gCtrlNhaGa_Load(object sender, EventArgs e)
        {
            gCtrlNhaGa.DataSource = gatauControl.GetDSGaTau();
        }

        private void btnThemDoanTau_Click(object sender, EventArgs e)
        {
            try
            {
                DoanTauInfo doanTauInfo = new DoanTauInfo();
                doanTauInfo.MaTau = txtMaTau.Text;
                doanTauInfo.MaGaDau = cmbGaDau.SelectedValue.ToString();
                doanTauInfo.MaGaCuoi = cmbGaCuoi.SelectedValue.ToString();
                doanTauInfo.TongSoToa = (int)nUDSoToa.Value;
                doanTauInfo.GhiChu = txtGhiChu.Text;
                doanTauControl.insert(doanTauInfo);
                gCtrlDoanTau.DataSource = doanTauControl.GetDSDoanTau();

            }
            catch
            {
                XtraMessageBox.Show(this.LookAndFeel, "Lỗi, không thêm được đoàn tàu");
            }

        }

        private void gCtrlDoanTau_Load(object sender, EventArgs e)
        {
            try
            {
                gCtrlDoanTau.DataSource = doanTauControl.GetDSDoanTau();

                cmbGaDau.DataSource = gaTauControl.GetDSGaTau();
                cmbGaDau.DisplayMember = "TenGa";
                cmbGaDau.ValueMember = "MaGa";
                cmbGaDau.SelectedIndex = -1;

                cmbGaCuoi.DataSource = gatauControl.GetDSGaTau();
                cmbGaCuoi.DisplayMember = "TenGa";
                cmbGaCuoi.ValueMember = "MaGa";
                cmbGaCuoi.SelectedIndex = -1;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(this.LookAndFeel, ex.Message);
            }
            
        }

        private void btnXoaDoanTau_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if(XtraMessageBox.Show(this.LookAndFeel,"Xóa tàu "+ gVDoanTau.GetFocusedRowCellValue("MaTau") +"?","Xác nhận", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DoanTauInfo doanTauInfo = new DoanTauInfo();
                    doanTauInfo.MaTau = gVDoanTau.GetFocusedRowCellValue("MaTau").ToString();

                    doanTauControl.delete(doanTauInfo);
                    gCtrlDoanTau.DataSource = doanTauControl.GetDSDoanTau();
                }
                
            }
            catch
            {
                XtraMessageBox.Show(this.LookAndFeel, "Không xóa được","Lỗi",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        GaDungControl gaDungControl = new GaDungControl();
        private void gCtrlGaDung_Load(object sender, EventArgs e)
        {
            try
            {
                cmbGaDungMaTau.DataSource = doanTauControl.GetDSDoanTau();
                cmbGaDungMaTau.DisplayMember = "MaTau";
                cmbGaDungMaTau.ValueMember = "MaTau";
                cmbGaDungMaTau.SelectedIndex = -1;

                
                cmbGaDung.DataSource = gatauControl.GetDSGaTau();
                cmbGaDung.DisplayMember = "TenGa";
                cmbGaDung.ValueMember = "MaGa";
                cmbGaDung.SelectedIndex = -1;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(this.LookAndFeel,ex.Message);
            }
        }

        private void cmbGaDungMaTau_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DoanTauInfo doanTauInfo = doanTauControl.GetDTauTheoMaTau(cmbGaDungMaTau.SelectedValue);
                if(doanTauInfo != null)
                {
                    txtGaDau.Text = doanTauControl.GetDTauTheoMaTau(cmbGaDungMaTau.SelectedValue).TenGaDau;
                    txtGaCuoi.Text = doanTauControl.GetDTauTheoMaTau(cmbGaDungMaTau.SelectedValue).TenGaCuoi;
                }
                gCtrlGaDung.DataSource = gaDungControl.GetDSGaDung(cmbGaDungMaTau.SelectedValue);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this.LookAndFeel,ex.Message);
            }
        }

        private void btnThemGaDung_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbGaDungMaTau.SelectedIndex < 0) throw new Exception("Chọn mã tàu");
                if (cmbGaDung.SelectedIndex < 0) throw new Exception("Chọn ga dừng");
                GaDungInfo gaDungInfo = new GaDungInfo();
                gaDungInfo.MaTau = cmbGaDungMaTau.SelectedValue.ToString();
                gaDungInfo.MaGa = cmbGaDung.SelectedValue.ToString();
                gaDungInfo.Km = (int)nbKm.Value;
                gaDungInfo.ThoiGianDung = (int)nbThoiGianDung.Value;

                gaDungControl.insert(gaDungInfo);
                gCtrlGaDung.DataSource = gaDungControl.GetDSGaDung(gaDungInfo.MaTau);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this.LookAndFeel, ex.Message);
            }
        }

        private void btnXoaGaDung_Click(object sender, EventArgs e)
        {
            try
            {
                if(XtraMessageBox.Show(this.LookAndFeel,"Xóa ga " + gVGaDung.GetFocusedRowCellValue("TenGa").ToString() + " của tàu " + gVGaDung.GetFocusedRowCellValue("MaTau").ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) ==  DialogResult.Yes)
                {
                    GaDungInfo gaDungInfo = new GaDungInfo();
                    gaDungInfo.MaTau = gVGaDung.GetFocusedRowCellValue("MaTau").ToString();
                    gaDungInfo.MaGa = gVGaDung.GetFocusedRowCellValue("MaGa").ToString();
                    gaDungControl.delete(gaDungInfo);
                    gCtrlGaDung.DataSource = gaDungControl.GetDSGaDung(cmbGaDungMaTau.SelectedValue);
                }
               
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this.LookAndFeel,"Không xóa được","Lỗi",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       
    }
}