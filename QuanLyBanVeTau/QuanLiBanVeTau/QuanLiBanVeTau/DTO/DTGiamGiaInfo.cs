using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanVeTau.DTO
{
    class DTGiamGiaInfo
    {
        int _madt;
        string _tendt;
        double _heso;

        public int MaDT
        {
            get { return _madt; }
            set
            {
                _madt = value;
            }
        }

        public  string TenDT
        {
            get { return _tendt; }
            set { _tendt = value; }
        }

        public double HeSo
        {
            get { return _heso; }
            set
            {
                if (value > 1 || value < 0) throw new Exception("He so phai tu 0 den 1");
                _heso = value;
            }
        }
    }
}
