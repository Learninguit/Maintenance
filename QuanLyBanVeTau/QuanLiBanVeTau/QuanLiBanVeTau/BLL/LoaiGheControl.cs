using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanVeTau.DTO;
using QuanLiBanVeTau.DAL;
namespace QuanLiBanVeTau.BLL
{
    class LoaiGheControl
    {
        private LoaiGheDataAccess data = new LoaiGheDataAccess();

        //public void insert(ToaTauInfo info)
        //{
        //    data.insert(info);
        //}

        //public void delete(ToaTauInfo info)
        //{
        //    data.delete(info);
        //}

        //public void update(ToaTauInfo info)
        //{
        //    data.update(info);
        //}

        public List<LoaiGheInfo> GetDSLoaiGhe()
        {
            return data.GetDSLoaiGhe();
        }

        //public List<ToaTauInfo> GetDSTTTheoMaToa(string MaToa)
        //{
        //    return data.getDsTTheoMToa(MaToa);
        //}
    }
}
