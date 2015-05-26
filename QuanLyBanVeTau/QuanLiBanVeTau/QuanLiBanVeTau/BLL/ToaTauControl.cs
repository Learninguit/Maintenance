using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanVeTau.DTO;
using QuanLiBanVeTau.DAL;
namespace QuanLiBanVeTau.BLL
{
    class ToaTauControl
    {
        private ToaTauDataAccess data = new ToaTauDataAccess();

        public void insert(ToaTauInfo info)
        {
            data.insert(info);
        }

        public void delete(ToaTauInfo info)
        {
            data.delete(info);
        }

        public void update(ToaTauInfo info)
        {
            data.update(info);
        }

        public List<ToaTauInfo> GetDSToaTau()
        {
            return data.GetDSToaTau();
        }

        public List<ToaTauInfo> GetDSToaTau(string MaTau)
        {
            if (MaTau == "" || MaTau == null)
                throw new Exception("Mã tàu không được trống");
            return data.GetDSToaTau(MaTau);
        }
    }
}
