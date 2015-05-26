using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanVeTau.DTO
{
    class LoaiGheInfo
    {
        private string _maLoaiGhe;
        private string _tenGhe;

        public string MaLoaiGhe
        {
            get { return _maLoaiGhe; }
            set
            {
                if (value == null)
                    throw new Exception("Ma Loai Ghe khong duoc trong");
                _maLoaiGhe = value;
            }
        }

        public string TenGhe
        {
            get { return _tenGhe; }
            set
            {
                if (value == null) throw new Exception("Ten Loai Ghe khong duoc trong ");
                _tenGhe = value;
            }
        }
    }
}
