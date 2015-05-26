using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanVeTau.DAL;
using QuanLiBanVeTau.DTO;
namespace QuanLiBanVeTau.BLL
{
    class HoaDonControl
    {
        private HoaDonDataAccess data = new HoaDonDataAccess();

        public void insert(HoaDonInfo info)
        {
            data.insert(info);
        }

        public void delete(HoaDonInfo info)
        {
            data.delete(info);
        }

        public void update(HoaDonInfo info)
        {
            data.update(info);
        }

        public List<HoaDonInfo> GetDSHoaDon()
        {
            return data.GetDSHoaDon();
        }
        public HoaDonInfo GetHDTheoMHD(string MaHD)
        {
            return data.GetHDTheoMHD(MaHD);
        }
        public List<HoaDonInfo> GetDSHDTheoMaDatVe(string MaDatVe)
        {
            return data.GetDSHDTheoMaDatVe(MaDatVe);
        }
    }
}
