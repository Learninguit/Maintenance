using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanVeTau.DTO
{
    class GheInfo
    {
        string _maghe;
        string _matoa;
        int _soghe;
        string _maloaighe;
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
        public int SoGhe
        {
            get { return _soghe; }
            set 
            {
                if (value <= 0) throw new Exception("Số ghế phải lớn hơn 0");
                _soghe = value; 
            }
        }
        public string MaLoaiGhe
        {
            get { return _maloaighe; }
            set
            {
                if (value == "" || value == null) throw new Exception("Mã loại ghế không được trống");
                _maloaighe = value; 
            }
        }
        public GheInfo()
        { }
        public GheInfo(string maghe,string matoa,int soghe ,string maloaighe)
        {
            this.MaGhe = maghe;
            this.MaToa = matoa;
            this.SoGhe = soghe;
            this.MaLoaiGhe = maloaighe;
        }
    }
}
