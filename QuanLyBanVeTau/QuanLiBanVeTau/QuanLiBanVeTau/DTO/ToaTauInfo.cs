using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanVeTau.DTO
{
    class ToaTauInfo
    {
        private string _matoa;
        private string _matau;
        private int _sotoa;
        private int _soluongghe;

        public string MaToa
        {
            get { return _matoa; }
            set 
            {
                if (value == "" || value == null) throw new Exception("Mã toa không được trống");
                _matoa = value;
            }
        }
        public string MaTau
        {
            get { return _matau; }
            set 
            {
                if (value == "" || value == null) throw new Exception("Mã tàu không được trống");
                _matau = value;
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
        public int SoLuongGhe
        {
            get { return _soluongghe; }
            set 
            {
                if (value <= 0) throw new Exception("Số lượng ghế phải lớn hơn 0");
                    _soluongghe = value; 
            }
        }
    }
}
