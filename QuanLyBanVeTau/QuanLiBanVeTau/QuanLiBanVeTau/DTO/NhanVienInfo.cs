using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanVeTau.DTO
{
    class NhanVienInfo
    {
         string _manv;
        string _hoten;
        string _gioitinh;
        DateTime _ngaysinh;
        DateTime _ngayvaolam;
        string _diachi;
        string _cmnd;
        string _sdt;
        string _email;
        string _taikhoan;
        string _matkhau;
        string _mapb;

        public string MaNV
        {
            get { return _manv; }
            set
            {
                if (value == null) throw new Exception("Ma hanh khach khong duoc trong");
                _manv = value;
            }
        }
        public string HoTen
        {
            get { return _hoten; }
            set
            {
                if (value == null) throw new Exception("Ho ten hanh khach khong duoc trong");
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
                if (value == null) throw new Exception("Địa chỉ không được trống");
                _diachi = value;
            }
        }
        public string CMND
        {
            get { return _cmnd; }
            set
            {
                if (value == null) throw new Exception("CMND khong duoc trong");
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
            set { _email = value; }
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

        public string MaPB
        {
            get { return _mapb; }
            set { _mapb = value; }
        }

        public DateTime NgayVaoLam
        {
            get { return _ngayvaolam; }
            set { _ngayvaolam = value; }
        }
        public NhanVienInfo()
        {
        }
        public NhanVienInfo(string manv, string hoten,string gioitinh, DateTime ngaysinh, DateTime ngayvaolam, string diachi ,string cmnd, string sdt,string email,string mapb, string taikhoan, string matkhau)
        {
            this.MaNV = manv;
            this.HoTen = hoten;
            this.GioiTinh = gioitinh;
            this.NgaySinh = ngaysinh;
            this.NgayVaoLam = ngayvaolam;
            this.DiaChi = diachi;
            this.CMND = cmnd;
            this.DienThoai = sdt;
            this.Email = email;
            this.MaPB = mapb;
            this.TaiKhoan = taikhoan;
            this.MatKhau = matkhau;
        }
    }
}
