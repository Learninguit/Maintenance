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
using QuanLiBanVeTau.BLL;
using QuanLiBanVeTau.DAL;
using QuanLiBanVeTau.DTO;
using DevExpress.XtraEditors.Controls;
namespace QuanLiBanVeTau.GUI
{
    public partial class DangKiForm : DevExpress.XtraEditors.XtraForm
    {
        public DangKiForm()
        {
            InitializeComponent();
            cmbGioiTinh.Items.AddRange(new String[] { "Nam", "Nữ" });
        }

        HanhKhachControl hanhKhachControl = new HanhKhachControl();
        private void btnDangKi_Click(object sender, EventArgs e)
        {
            try
            {
                HanhKhachInfo hanhKhachInfo = new HanhKhachInfo();
                hanhKhachInfo.MaHK = txtCMND.Text;
                hanhKhachInfo.HoTen = txtHoTen.Text;
                hanhKhachInfo.GioiTinh = cmbGioiTinh.Text;
                hanhKhachInfo.NgaySinh = dENgaySinh.DateTime;
                hanhKhachInfo.DienThoai = txtSDT.Text;
                hanhKhachInfo.DiaChi = txtDiaChi.Text;
                hanhKhachInfo.TaiKhoan = txtTaiKhoan.Text;
                hanhKhachInfo.MatKhau = txtMatKhau.Text;
                hanhKhachInfo.Email = txtEmail.Text;
                hanhKhachInfo.CMND = txtCMND.Text;
                
                if (txtMatKhau.Text != txtXacNhanMK.Text)
                {
                    throw new Exception("Xác nhận mật khẩu không chính xác");
                }
                if (txtEmail.Text != txtXacNhanEmail.Text)
                {
                    throw new Exception("Xác nhận email không chính xác");
                }
                //Kiểm tra tên tài khoản đã có người đăng kí chưa
                if(hanhKhachControl.CheckTaiKhoan(hanhKhachInfo.TaiKhoan) != null)
                {
                    //Nếu có người sử dụng rồi thì ném ngoại lệ
                    throw new Exception("Tên tài khoản đã có người đăng kí");
                }
                // Nếu chưa thì tạo tài khoản
                hanhKhachControl.insert(hanhKhachInfo);
                XtraMessageBox.Show(this.LookAndFeel, "Đăng kí thành công");
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this.LookAndFeel, ex.Message);
            }

        }

       private void DangKiForm_Load(object sender, EventArgs e)
       {
           cmbGioiTinh.SelectedIndex = 0;
           txtCMND.Text = "";
           txtDiaChi.Text = "";
           txtEmail.Text = "";
           txtHoTen.Text = "";
           txtMatKhau.Text = "";
           txtSDT.Text = "";
           txtTaiKhoan.Text = "";
           txtXacNhanEmail.Text = "";
           txtXacNhanMK.Text = "";
       }
    }
}