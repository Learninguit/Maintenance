using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using QuanLiBanVeTau.DTO;
namespace QuanLiBanVeTau.DAL
{
    class LoaiGheDataAccess
    {
        private DataProvider _provider = new DataProvider();
	
		public LoaiGheDataAccess()
		{
			_provider.connect();
		}

        // Sử dụng Procedure KHÔNG có parameter input
        public List<LoaiGheInfo> GetDSLoaiGhe()
        {
            // GetDSToaTau là 1 procedure đã được tạo sẵn
            SqlDataReader reader = (SqlDataReader)_provider.executeQuery("GetDSLoaiGhe");

            List<LoaiGheInfo> List_LG = new List<LoaiGheInfo>();

            while (reader.Read())
            {
                LoaiGheInfo LG = new LoaiGheInfo();
                LG.MaLoaiGhe = reader["MALOAIGHE"].ToString();
                LG.TenGhe = reader["TENGHE"].ToString();
                List_LG.Add(LG);
            }

            reader.Close();
            return List_LG;
        }
    }
}
