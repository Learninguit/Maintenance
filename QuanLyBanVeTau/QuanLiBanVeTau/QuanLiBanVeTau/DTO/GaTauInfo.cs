using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanVeTau.DTO
{
    class GaTauInfo
    {
        string _maga;
        string _tenga;
        string _diachi;

        public string MaGa
        {
            get { return _maga; }
            set
            {
                if (value == null)
                    throw new Exception("Ma ga khong duoc trong");
                _maga = value;
            }
        }
        public string TenGa
        {
            get { return _tenga; }
            set {
                if (value == null)
                    throw new Exception("Ten ga khong duoc trong");
                _tenga = value; }
        }
        public  string DiaChi
        {
            get { return _diachi; }
            set { _diachi = value; }
        }

        int _cayso;
        public int CaySo
        {
            get { return _cayso; }
            set { _cayso = value; }
        }
        public GaTauInfo()
        { }
        public GaTauInfo(string maga, string ten, string diachi, int cayso)
        {
            this.MaGa = maga;
            this.TenGa = ten;
            this.DiaChi = diachi;
            this.CaySo = cayso;
        }
    }
}
