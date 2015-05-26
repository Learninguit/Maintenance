using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanVeTau.DTO
{
    class DatVeInfo
    {
        
        string _madatve;
        string _malichtrinh;
        string _mahk = null;
        double _tonggia;
        DateTime _ngayhethan;
        //Thong tin them
        string _tenhk;
        public string TenHK
        {
            get { return _tenhk; }
            set
            {
                _tenhk = value;
            }
        }

        string _cmnd;
        public string CMND
        {
            get { return _cmnd; }
            set { _cmnd = value; }
        }
        string _matau;
        public string MaTau
        {
            get { return _matau; }
            set
            {
                _matau = value;
            }
        }
        int _sotoa;
        public int SoToa
        {
            get { return _sotoa; }
            set { _sotoa = value; }
        }
        int _soghe;
        public int SoGhe
        {
            get { return _soghe; }
            set { _soghe = value; }
        }
        string _tengadi;
        public string TenGaDi
        {
            get { return _tengadi; }
            set { _tengadi = value; }
        }
        string _tengaden;
        public string TenGaDen
        {
            get { return _tengaden; }
            set
            {
                _tengaden = value;
            }
        }
        DateTime _ngaykhoihanh;
        public DateTime NgayKhoiHanh
        {
            get { return _ngaykhoihanh; }
            set { _ngaykhoihanh = value; }
        }
       DateTime _giokhoihanh;
        public DateTime GioKhoiHanh
       {
           get { return _giokhoihanh; }
           set { _giokhoihanh = value; }
       }

        double _giave;
        public double GiaVe
        {
            get { return _giave; }
            set { _giave = value; }
        }

        public string MaDatVe
        {
            get { return _madatve; }
            set
            {
                if (value == null || value == "") throw new Exception("Mã đặt vé phải lớn hơn 0");
                _madatve = value;
            }
        }
        public string MaLichTrinh
        {
            get { return _malichtrinh; }
            set
            {
                if (value == null || value == "") throw new Exception("Mã lịch trình không được trống");
                _malichtrinh = value;
            }
        }
        public string MaHK
        {
            get { return _mahk; }
            set
            {
                _mahk = value;
            }
        }
        
        public double TongGia
        {
            get { return _tonggia; }
            set
            {
                if (value < 0) throw new Exception("Tổng giá đặt vé phải lơn hơn hoặc bằng 0");
                _tonggia = value;
            }
        }
        public DateTime NgayHetHan
        {
            get { return _ngayhethan; }
            set { _ngayhethan = value; }
        }
    }
}
