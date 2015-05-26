using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanVeTau.DTO;
using QuanLiBanVeTau.DAL;
namespace QuanLiBanVeTau.BLL
{
    class CTDVControl
    {
        private CTDVDataAccess data = new CTDVDataAccess();

        public void insert(CTDVInfo info)
        {
            data.insert(info);
        }

        public void delete(CTDVInfo info)
        {
            data.delete(info);
        }

        public void update(CTDVInfo info)
        {
            data.update(info);
        }

        public List<CTDVInfo> GetDSCTDV()
        {
            return data.GetDSCTDV();
        }
        public List<CTDVInfo> GetDSCTDVTheoMaDatVe(string MaDatVe)
        {
            return data.GetDSCTDVTheoMaDatVe(MaDatVe);
        }
    }
}
