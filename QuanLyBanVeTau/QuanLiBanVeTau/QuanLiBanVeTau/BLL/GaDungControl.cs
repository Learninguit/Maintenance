using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanVeTau.DTO;
using QuanLiBanVeTau.DAL;
namespace QuanLiBanVeTau.BLL
{
    class GaDungControl
    {
        private GaDungDataAccess data = new GaDungDataAccess();

        public void insert(GaDungInfo info)
        {
            data.insert(info);
        }

        public void delete(GaDungInfo info)
        {
            data.delete(info);
        }

        public void update(GaDungInfo info)
        {
            data.update(info);
        }

        public List<GaDungInfo> GetDSGaDung(object Matau)
        {
            if (Matau == null) return null;
            else return data.GetDSGaDung(Matau.ToString());
        }
        public GaDungInfo GetGaDung(object MaTau, object MaGaDung)
        {
            if (MaTau == null) return null;
            if (MaGaDung == null) return null;
            return data.GetGaDung(MaTau.ToString(),MaGaDung.ToString());
        }
    }
}
