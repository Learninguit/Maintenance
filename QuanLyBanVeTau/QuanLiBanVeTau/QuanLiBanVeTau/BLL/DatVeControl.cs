using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanVeTau.DTO;
using QuanLiBanVeTau.DAL;
namespace QuanLiBanVeTau.BLL
{
    class DatVeControl
    {
        private DatVeDataAccess data = new DatVeDataAccess();

        public void insert(DatVeInfo info)
        {
            data.insert(info);
        }

        public void delete(DatVeInfo info)
        {
            data.delete(info);
        }

        public void update(DatVeInfo info)
        {
            data.update(info);
        }

        public List<DatVeInfo> GetDSDatVe()
        {
            return data.GetDSDatVe();
        }
        public List<DatVeInfo> GetDatVe(string MaDatVe)
        {
            return data.GetDatVe(MaDatVe);
        }
    }
}