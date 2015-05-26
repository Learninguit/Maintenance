using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanVeTau.DTO
{
    class CTDVInfo
    {
        string _madatve;
        string _tenhk;
        string _madt;
        string _tendt;
        string _cmnd;
        string _matoa;
        int _sotoa;
        string _maghe;
        int _soghe;
        string _magiave;
        double _gia;
        public string MaDatVe
        {
            get { return _madatve; }
            set
            {
                if (value == null || value == "") throw new Exception("Mã đặt vé không được trống");
                _madatve = value;
            }
        }
        public string TenHK
        {
            get { return _tenhk; }
            set
            {
                if (value == null || value == "") throw new Exception("Họ tên hành khách không được trống");
                _tenhk = value;
            }
        }
        public string MaDT
        {
            get { return _madt; }
            set
            {
                if (value == null || value == "") throw new Exception("Mã đối tượng không được trống");
                _madt = value;
            }
        }

        public string TenDT
        {
            get { return _tendt; }
            set
            {
                if (value == null || value == "") throw new Exception("Tên đối tượng không được trống");
                _tendt = value;
            }
        }

        public string CMND
        {
            get { return _cmnd; }
            set 
            {
                if (value == null || value == "") throw new Exception("CMND không được trống");
                _cmnd = value;
            }
        }
        public double Gia
        {
            get { return _gia; }
            set {
                if (value < 0) throw new Exception("Giá vé phải lớn hơn không");
                _gia = value; }
        }

        public string MaGiaVe
        {
            get { return _magiave; }
            set 
            {
                if (value == null || value == "") throw new Exception("Mã đơn giá không được trống");
                _magiave = value;
            }
        }
        public string MaGhe
        {
            get { return _maghe; }
            set
            {
                if (value == null || value == "") throw new Exception("Mã ghế không được trống");
                _maghe = value;
            }
        }

        public string MaToa
        {
            get { return _matoa; }
            set
            {
                if (value == null || value == "") throw new Exception("Mã toa không được trống");
                _matoa = value;
            }
        }
        public int SoToa
        {
            get { return _sotoa; }
            set
            {
                if (value <= 0) throw new Exception("Số toa phải lớn hơn 0");
                _sotoa = value;
            }
        }

        public int SoGhe
        {
            get { return _soghe; }
            set
            {
                if (value <= 0) throw new Exception("Số ghế phải lớn hơn 0");
                _soghe = value;
            }
        }
        public CTDVInfo()
        { }
        public CTDVInfo(string maDatVe, string hoTen, string maDT, string cMND, string maGhe, string maGiaVe, double gia)
        {
            this.MaDatVe = maDatVe;
            this.TenHK = hoTen;
            this.MaDT = maDT;
            this.CMND = cMND;
            this.MaGhe = maGhe;
            this.MaGiaVe = MaGiaVe;
            this.Gia = gia;
        }
    }
}