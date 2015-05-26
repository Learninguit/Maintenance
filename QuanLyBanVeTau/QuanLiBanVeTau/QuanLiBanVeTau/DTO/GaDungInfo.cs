using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanVeTau.DTO
{
    class GaDungInfo
    {
        string _matau;
        string _maga;
        string _tenga;
        int _km;
        int _thoigiandung;
        public string MaTau
        {
            get { return _matau; }
            set
            {
                if (value == null || value == "") throw new Exception("Mã tàu không được trống");
                _matau = value;
            }
        }
        public string MaGa
        {
            get { return _maga; }
            set
            {
                if (value == null || value == "")
                    throw new Exception("Mã ga dừng không được trống");
                _maga = value;
            }
        }
        public string TenGa
        {
            get { return _tenga; }
            set { 
                if (value == null || value == "") throw new Exception("Tên ga dừng không được trống");
                _tenga = value;
          }
        }
        public int Km
        {
            get { return _km; }
            set
            {
                if (value < 0) throw new Exception("Khoảng cách từ ga đầu đến ga cuối phải lớn hơn 0");
                _km = value;
            }
        }
        public int ThoiGianDung
        {
            get { return _thoigiandung; }
            set
            {
                if (value < 0) throw new Exception("thời gian dừng ở một ga phải lớn hơn hoặc bằng 0");
                _thoigiandung = value;
            }
        }
    }
}
