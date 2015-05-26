using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanVeTau.DTO
{
    public class LichTrinhInfo
    {
        //KHAI BAO THEO TUNG COT TRONG BANG
        private string _malichtrinh;
        private string _matau;
        private DateTime _ngaykhoihanh;
        private DateTime _ngayden;

        string _tengadi;
        string _tengaden;

        string _magadi;
        string _magaden;

        public string TenGaDi
        {
            get { return _tengadi; }
            set { _tengadi = value; }
        }

        public string MaGaDi
        {
            get { return _magadi; }
            set { _magadi = value; }
        }

        public string TenGaDen
        {
            get { return _tengaden; }
            set { _tengaden = value; }
        }
        public string MaGaDen
        {
            get { return _magaden; }
            set { _magaden = value; }
        }
        public string MaLichTrinh
        {
            get { return _malichtrinh; }
            set
            {
                if (value == null)
                    throw new Exception("Mã lịch trình không được trống"); //PRIMARY KEY KHONG DUOC RONG
                _malichtrinh = value;
            }
        }
        public string MaTau
        {
            get { return _matau; }
            set
            {
                if (value == null || value == "")
                    throw new Exception("Mã tàu không được trống");
                _matau = value;
            }
        }


       
        public DateTime NgayKhoiHanh
        {
            get { return _ngaykhoihanh; }
            set
            {
                _ngaykhoihanh = value; 
            }
        }
    
        public DateTime NgayDen
        {
            get { return _ngayden; }
            set 
            {
                if (value < NgayKhoiHanh) throw new Exception("Ngày đến không được sớm hơn ngày khởi hành");
                _ngayden = value;
            }
        }
    

        public LichTrinhInfo()
        { }
        public LichTrinhInfo(string matau, DateTime ngkhoihanh, DateTime ngden)
        {
            this.MaTau = matau;
            this.NgayKhoiHanh = ngkhoihanh;
            this.NgayDen = ngden;
            this.MaLichTrinh = this.MaTau + this.NgayKhoiHanh.Date.Day + this.NgayKhoiHanh.Date.Month + this.NgayKhoiHanh.Hour + this.NgayKhoiHanh.Minute;
        }
    }
}
