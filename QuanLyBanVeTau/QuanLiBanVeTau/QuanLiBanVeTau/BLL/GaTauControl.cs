using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanVeTau.DTO;
using QuanLiBanVeTau.DAL;
namespace QuanLiBanVeTau.BLL
{
    class GaTauControl
    {
        private GaTauDataAccess data = new GaTauDataAccess();

        public void insert(GaTauInfo info)
        {
            data.insert(info);
        }

        public void delete(GaTauInfo info)
        {
            data.delete(info);
        }

        public void update(GaTauInfo info)
        {
            data.update(info);
        }

        public List<GaTauInfo> GetDSGaTau()
        {
            List<GaTauInfo> list;
            list = data.GetDSGaTau();
            return list;
        }

        public List<GaTauInfo> GetDSGTheoMaGa(string MaGa)
        {
            return data.getDsGTheoMGa(MaGa);
        }
    }
}
