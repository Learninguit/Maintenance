using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanVeTau.DTO;
using QuanLiBanVeTau.DAL;
namespace QuanLiBanVeTau.BLL
{
    class GiaVeControl
    {
        private GiaVeDataAccess data = new GiaVeDataAccess();

        public void insert(GiaVeInfo info)
        {
            data.insert(info);
        }

        public void delete(GiaVeInfo info)
        {
            data.delete(info);
        }

        public void update(GiaVeInfo info)
        {
            data.update(info);
        }

        public List<GiaVeInfo> GetDSGiaVe()
        {
            return data.GetDSGiaVe();
        }
        public GiaVeInfo GetGiaVe(object MaGiaVe)
        {
            if (MaGiaVe == null) MaGiaVe = "";
            return data.GetGiaVe(MaGiaVe.ToString());
        }

        public GiaVeInfo GetGiaVe(object MaTau = null, object MaLoaiGhe = null)
        {
            if(MaTau == null || MaLoaiGhe == null)
            {
                MaTau = "";
                MaLoaiGhe = "";
            }
            return data.GetGiaVe(MaTau.ToString(), MaLoaiGhe.ToString());
        }

        public double GetDonGia(string MaGiaVe)
        {
            return data.GetGiaVe(MaGiaVe).DonGia * 1000;
        }

        public double GetGiaVe(string  MaGiaVe, double TiLe)
        {
            return this.GetDonGia(MaGiaVe) * TiLe;
        }
        //public List<GiaVeInfo> GetDSGVTheoMLT_T(string MaLichTrinh, string MaToa)
        //{
        //    return data.getDsGVTheoMLT_T(MaLichTrinh, MaToa);
        //}
    }
}
