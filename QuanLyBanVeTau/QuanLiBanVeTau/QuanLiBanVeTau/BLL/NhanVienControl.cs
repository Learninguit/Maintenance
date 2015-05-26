using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanVeTau.DAL;
using QuanLiBanVeTau.DTO;
namespace QuanLiBanVeTau.BLL
{
    class NhanVienControl
    {
        private NhanVienDataAccess data = new NhanVienDataAccess();
        public void insert(NhanVienInfo info)
        {
            data.insert(info);
        }

        public void delete(NhanVienInfo info)
        {
            data.delete(info);
        }

        public void update(NhanVienInfo info)
        {
            data.update(info);
        }

        public List<NhanVienInfo> GetDSNhanVien()
        {
            return data.GetDSNhanVien();
        }

        public NhanVienInfo DangNhap(string TaiKhoan, string MatKhau)
        {
            if (TaiKhoan == "") throw new Exception("Nhập tên tài khoản");
            if (MatKhau == "") throw new Exception("Nhập mật khẩu");
            return data.DangNhap(TaiKhoan, MatKhau);
        }
    }
}
