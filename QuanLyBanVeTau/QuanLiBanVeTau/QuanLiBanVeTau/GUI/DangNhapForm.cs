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
using QuanLiBanVeTau.DAL;
using QuanLiBanVeTau.BLL;
using QuanLiBanVeTau.DTO;
namespace QuanLiBanVeTau.GUI
{
    public partial class DangNhapForm : DevExpress.XtraEditors.XtraForm
    {
        HanhKhachControl hanhKhachControl = new HanhKhachControl();
        NhanVienControl nhanVienControl = new NhanVienControl();
        DangKiForm signForm = new DangKiForm();
        public object account = null;
        public DangNhapForm()
        {
            InitializeComponent();
            cmbLoaiTaiKhoan.Properties.Items.AddRange(new string[] { "Nhân viên", "Hành khách" });
        }

        private void DangNhapForm_Load(object sender, EventArgs e)
        {
            
            cmbLoaiTaiKhoan.SelectedIndex = 0;
            txtTenTaiKhoan.Text = "";
            txtPassword.Text = "";
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbLoaiTaiKhoan.SelectedIndex == 0)
                {
                    account = nhanVienControl.DangNhap(txtTenTaiKhoan.Text, txtPassword.Text);
                    if (account != null)
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        throw new Exception("Tài khoản hoặc password không đúng");
                    }
                }
                else if (cmbLoaiTaiKhoan.SelectedIndex == 1)
                {
                    account = hanhKhachControl.DangNhap(txtTenTaiKhoan.Text, txtPassword.Text);
                    if (account != null)
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        throw new Exception("Tài khoản hoặc password không đúng");
                    }
                }
                
            }
            catch (Exception ex)
            {
                DevExpress.LookAndFeel.UserLookAndFeel skin = new DevExpress.LookAndFeel.UserLookAndFeel(this);
                XtraMessageBox.Show(skin, ex.Message);
            }
           
        }

        private void lbDangKi_Click(object sender, EventArgs e)
        {
            signForm.ShowDialog();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

       

       
    }
}