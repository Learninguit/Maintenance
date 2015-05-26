using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanVeTau.DTO
{
    class HoaDonInfo
    {
        string _mahd;
        string _madatve;
        DateTime _ngaylap;
        string _manv;
        double _thanhtoan;
        double _thoilai;

        public string MaHD
        {
            get { return _mahd; }
            set 
            {
                if (value == null || value == "") throw new Exception("Mã hóa đơn phải hơn không");
                _mahd = value;
            }
        }
        public string MaDatVe
        {
            get { return _madatve; }
            set
            {
                if (value == null || value == "") throw new Exception("Mã đặt vé không được trống");
                _madatve = value;
            }
        }

        public DateTime NgayLap
        {
            get { return _ngaylap; }
            set { _ngaylap = value; }
        }
        public double ThanhToan
        {
            get { return _thanhtoan; }
            set
            {
                if (value < 0) throw new Exception("Giá trị thanh toán phải lớn hơn hoặc bằng 0");
                _thanhtoan = value;
            }
        }
        public double ThoiLai
        {
            get { return _thoilai; }
            set
            {
                if (value < 0) throw new Exception("Số tiền thối lại phải lớn 0");
                _thoilai = value;
            }
        }
        public string MaNV
        {
            get { return _manv; }
            set
            {
                if (value == null || value == "") throw new Exception("Mã nhân viên tính tiền không được trống");
                _manv = value;
            }
        }
    }
}
