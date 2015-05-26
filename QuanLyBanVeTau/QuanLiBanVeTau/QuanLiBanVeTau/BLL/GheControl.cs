using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanVeTau.DTO;
using QuanLiBanVeTau.DAL;
namespace QuanLiBanVeTau.BLL
{
    class GheControl
    {
        private GheDataAccess data = new GheDataAccess();
        public List<GheInfo> GetDSGhe(GheInfo info)
        {
            return data.GetDSGhe(info.MaToa, info.MaLoaiGhe);
        }
        public List<LoaiGheInfo> GetDSLoaiGheTrongToa(GheInfo info)
        {
            return data.GetDSLoaiGheTrongToa(info.MaToa);
        }

    }
}
