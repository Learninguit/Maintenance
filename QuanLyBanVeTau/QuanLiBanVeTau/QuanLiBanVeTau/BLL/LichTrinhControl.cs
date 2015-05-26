using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanVeTau.DTO;
using QuanLiBanVeTau.DAL;
namespace QuanLiBanVeTau.BLL
{
    class LichTrinhControl
    {
        private LichTrinhDataAccess data = new LichTrinhDataAccess();

        public void insert(LichTrinhInfo info)
        {
            data.insert(info);
        }

        public void delete(LichTrinhInfo info)
        {
            data.delete(info);
        }

        public void update(LichTrinhInfo info)
        {
            data.update(info);
        }

        public List<LichTrinhInfo> GetDSLichTrinh()
        {
            return data.GetDSLichTrinh();
        }

        public LichTrinhInfo GetLTTheoMaLT(string MaLichTrinh)
        {
            return data.GetLTTheoMaLT(MaLichTrinh);
        }
        public List<LichTrinhInfo> GetDSLichTrinh(object MaGaDi, object MaGaDen, object MaTau, DateTime TuNgay, DateTime DenNgay)
        {
            if (MaGaDi == null) MaGaDi = "";
            else if (MaGaDi.ToString() == "All") MaGaDi = "";
            if (MaGaDen == null) MaGaDen = "";
            else if (MaGaDen.ToString() == "All") MaGaDen = "";
            if (MaTau == null) MaTau = "";
            else if (MaTau.ToString() == "All") MaTau = "";
            if (TuNgay.Year < 2010) TuNgay = new DateTime(2010,1,1);
            if (DenNgay.Year < 2010) DenNgay = new DateTime(2100, 1, 1);
            return data.GetDSLichTrinh(MaGaDi.ToString(), MaGaDen.ToString(),MaTau.ToString(),TuNgay,DenNgay);
        }
    }
}
