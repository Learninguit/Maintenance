using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanVeTau.DTO;
using QuanLiBanVeTau.DAL;
namespace QuanLiBanVeTau.BLL
{
    class DoanTauControl
    {
        private DoanTauDataAccess data = new DoanTauDataAccess();

        public void insert(DoanTauInfo info)
        {
            data.insert(info);
        }

        public void delete(DoanTauInfo info)
        {
            data.delete(info);
        }

        public void update(DoanTauInfo info)
        {
            data.update(info);
        }

        public List<DoanTauInfo> GetDSDoanTau()
        {

            return data.GetDSDoanTau();
        }

        public DoanTauInfo GetDTauTheoMaTau(object MaTau)
        {
            if (MaTau == null) MaTau = "";
            return data.GetDTauTheoMTau(MaTau.ToString());
        }
    }
}
