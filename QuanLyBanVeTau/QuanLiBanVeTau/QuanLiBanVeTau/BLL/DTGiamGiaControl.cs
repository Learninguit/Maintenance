using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanVeTau.DTO;
using QuanLiBanVeTau.DAL;
namespace QuanLiBanVeTau.BLL
{
    class DTGiamGiaControl
    {
        private DTGiamGiaDataAccess data = new DTGiamGiaDataAccess();

        public void insert(DTGiamGiaInfo info)
        {
            data.insert(info);
        }

        public void delete(DTGiamGiaInfo info)
        {
            data.delete(info);
        }

        public void update(DTGiamGiaInfo info)
        {
            data.update(info);
        }

        public List<DTGiamGiaInfo> GetDSDTGiamGia()
        {
            return data.GetDSDTGiamGia();
        }

        public DTGiamGiaInfo GetDTTheoMDT(string MaDT)
        {
            return data.GetDTTheoMDT(MaDT);
        }
        public double GetTiLe(string MaDT)
        {
            return data.GetDTTheoMDT(MaDT).HeSo;
        }
    }
}
