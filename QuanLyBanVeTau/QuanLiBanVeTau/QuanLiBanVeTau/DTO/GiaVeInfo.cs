using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanVeTau.DTO
{
    class GiaVeInfo
    {
        private int _magiave;
        private string _matau;
        private string _maloaighe;
        public string _tenghe;
        private double _dongia;


        public int MaGiaVe
        {
            get { return _magiave; }
            set
            {
                if (value < 0)
                    throw new Exception("Mã giá vé không được trống");
                _magiave = value;
            }
        }
        

       
        public string MaTau
        {
            get { return _matau; }
            set
            {
                if (value == null || value == "") throw new Exception("Mã tàu không được trống");
                _matau = value;
            }
        }
        public string MaLoaiGhe
        {
            get { return _maloaighe; }
            set
            {
                if (value == null) throw new Exception("Mã loại ghế không được trống");
                _maloaighe = value;
            }
        }
        public string TenGhe
        {
            get { return _tenghe; }
            set { _tenghe = value; }
        }
        public double DonGia
        {
            get { return _dongia; }
            set 
            {
                if (value < 0) throw new Exception("Đơn giá phải lớn hơn hoặc bằng 0");
                _dongia = value; 
            }
        }
        public GiaVeInfo()
        { }
    }
}

