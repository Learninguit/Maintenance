using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanVeTau.DTO
{
    class DoanTauInfo
    {
        string _matau;
        string _magadau;
        string _tengadau;
        string _magacuoi;
        string _tengacuoi;
        int _tongsotoa;
        int _tocdotrungbinh;
        string _ghichu;
        public string MaTau
        {
            get
            {
                return _matau;
            }
            set
            {
                if (value == null) throw new Exception("Ma tau khong duoc trong");
                _matau = value;
            }
        }

        public int TocDoTrungBinh
        {
            get { return _tocdotrungbinh; }
            set
            {
                if (value <= 0) throw new Exception("Tốc độ trung bình phải lớn hơn 0");
                _tocdotrungbinh = value;
            }
        }
        public string MaGaDau
        {
            get { return _magadau;}
            set 
            { 
                if (value == null) throw new Exception("Ma ga khong duoc trong");
                _magadau = value;
            }
        }

        public string MaGaCuoi
        {
            get { return _magacuoi; }
            set
            {
                if (value == null) throw new Exception("Ma ga khong duoc trong");
                _magacuoi = value;
            }
        }
        public int TongSoToa
        {
            get { return _tongsotoa; }
            set { _tongsotoa = value; }
        }
        public string GhiChu
        {
            get { return _ghichu; }
            set { _ghichu = value; }
        }
        public string TenGaDau
        {
            get { return _tengadau; }
            set
            {
                _tengadau = value;
            }
        }
        public string TenGaCuoi
        {
            get { return _tengacuoi; }
            set
            {
                _tengacuoi = value;
            }
        }
    }
}

