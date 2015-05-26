using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanVeTau.DTO;
using QuanLiBanVeTau.DAL;
namespace QuanLiBanVeTau.BLL
{
    class HanhKhachControl
    {
        private HanhKhachDataAccess data = new HanhKhachDataAccess();

        public void insert(HanhKhachInfo info)
        {
            data.insert(info);
        }

        public void delete(HanhKhachInfo info)
        {
            data.delete(info);
        }

        public void update(HanhKhachInfo info)
        {
            data.update(info);
        }

        public List<HanhKhachInfo> GetDSHanhKhach()
        {
            return data.GetDSHanhKhach();
        }

        public HanhKhachInfo CheckTaiKhoan(string taikhoan)
        {
            if (taikhoan == "") throw new Exception("Nhập tên tài khoản");
            return data.CheckTaiKhoan(taikhoan);
        }
        public HanhKhachInfo DangNhap(string TaiKhoan, string MatKhau)
        {
            if(TaiKhoan == "") throw new Exception("Nhập tên tài khoản");
            if(MatKhau == "") throw new Exception("Nhập mật khẩu");
            return data.DangNhap(TaiKhoan,MatKhau);
        }
    }
}
