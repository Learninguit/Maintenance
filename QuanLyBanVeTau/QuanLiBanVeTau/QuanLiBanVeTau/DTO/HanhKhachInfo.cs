using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanVeTau.DTO
{
    class HanhKhachInfo
    {
        string _mahk;
        string _hoten;
        string _gioitinh;
        DateTime _ngaysinh;
        string _diachi;
        string _cmnd;
        string _sdt;
        string _email;
        string _taikhoan;
        string _matkhau;

        public string MaHK
        {
            get { return _mahk; }
            set
            {
                _mahk = value;
            }
        }
        public string HoTen
        {
            get { return _hoten; }
            set
            {
                if (value == "") throw new Exception("Họ tên hành khách không được trống");
                _hoten = value;
            }
        }
        public string GioiTinh
        {
            get { return _gioitinh; }
            set { _gioitinh = value; }
        }
        public DateTime NgaySinh
        {
            get { return _ngaysinh; }
            set{
                if (value == null) throw new Exception("Ngày sinh không được trống");
                _ngaysinh = value;
            }
        }
        public string DiaChi
        {
            get { return _diachi; }
            set
            {
                if (value == "") throw new Exception("Địa chỉ không được trống");
                _diachi = value;
            }
        }
        public string CMND
        {
            get { return _cmnd; }
            set
            {
                if (value == "") throw new Exception("CMND không được trống");
                _cmnd = value;
            }
        }
        public string DienThoai
        {
            get { return _sdt; }
            set { _sdt = value; }
        }
        public string Email
        {
            get { return _email; }
            set {
                if (value == "") throw new Exception("Email không được trống");
                _email = value;
            }
        }

        public string TaiKhoan
        {
            get
            {
                return _taikhoan;
            }
            set
            {
                if (value == "") throw new Exception("Tên tài khoản không được trống");
                _taikhoan = value;
            }
        }

        public string MatKhau
        {
            get { return _matkhau; }
            set
            {
                if (value == "") throw new Exception("Mật khẩu không được trống");
                _matkhau = value;
            }
        }
        public HanhKhachInfo()
        {
        }
        public HanhKhachInfo(string mahk, string hoten,string gioitinh, DateTime ngaysinh, string diachi ,string cmnd, string sdt,string email, string taikhoan, string matkhau)
        {
            this.MaHK = mahk;
            this.HoTen = hoten;
            this.GioiTinh = gioitinh;
            this.NgaySinh = ngaysinh;
            this.DiaChi = diachi;
            this.CMND = cmnd;
            this.DienThoai = sdt;
            this.Email = email;
            this.TaiKhoan = taikhoan;
            this.MatKhau = matkhau;
        }
    }
}
