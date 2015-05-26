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
    class DTGiamGiaDataAccess
    {
        private DataProvider _provider = new DataProvider();
	
		public DTGiamGiaDataAccess()
		{
			_provider.connect();
		}

        // Sử dụng Procedure KHÔNG có parameter input
        public List<DTGiamGiaInfo> GetDSDTGiamGia()
        {
            // GetDSDTGiamGia là 1 procedure đã được tạo sẵn
            SqlDataReader reader = (SqlDataReader)_provider.executeQuery("GetDSDTGiamGia");

            List<DTGiamGiaInfo> List_DT = new List<DTGiamGiaInfo>();

            while (reader.Read())
            {
                DTGiamGiaInfo DT = new DTGiamGiaInfo();
                DT.MaDT = Convert.ToInt32(reader["MaDT"]);
                DT.TenDT = reader["TenDT"].ToString();
                DT.HeSo = Convert.ToDouble(reader["HeSo"]);
                List_DT.Add(DT);
            }

            reader.Close();
            return List_DT;
        }


        // Sử dụng Procedure có parameter input
        public DTGiamGiaInfo GetDTTheoMDT(string MaDT)
        {
            // Một list các parameter
            List<SqlParameter> paramters = new List<SqlParameter>();
           paramters.Add(new SqlParameter("@MaDT", MaDT));
           
            //string query = "SELECT * FROM DTGIAMGIA WHERE MADT LIKE '%"+ MaDT +"%'";

            // Gọi hàm excute sử dụng procedure có parameter
            SqlDataReader reader = (SqlDataReader)_provider.executeQueryParameter("GetDTTheoMaDT",paramters);

            DTGiamGiaInfo DT = null;

            while (reader.Read())
            {
                DT = new DTGiamGiaInfo();
                DT.MaDT = Convert.ToInt32(reader["MaDT"]);
                DT.TenDT = reader["TenDT"].ToString();
                DT.HeSo = Convert.ToDouble(reader["HeSo"]);

            }

            reader.Close();
            return DT;
        }

		public void insert(DTGiamGiaInfo info)
		{

            //List<SqlParameter> paramters = new List<SqlParameter>();
            //paramters.Add(new SqlParameter("@MaDT", info.MaDT));
            string insertCommand = @"INSERT INTO DTGIAMGIA (TENDT, HESO) VALUES(N'" +
                info.TenDT + "', " +
                info.HeSo + ")";

			_provider.executeNonQuery(insertCommand);
		}

        public void update(DTGiamGiaInfo info)
		{
			string updateCommand = "UPDATE DTGIAMGIA " +
									"SET TENDT = N'" + info.TenDT + "', " +
                                    " HESO = " + info.HeSo + 
									" WHERE MADT = " + info.MaDT;

			_provider.executeNonQuery(updateCommand);
		}

		public void delete(DTGiamGiaInfo info)
		{
            string deleteCommand = "DELETE FROM DTGIAMGIA WHERE MADT = " + info.MaDT;
			_provider.executeNonQuery(deleteCommand);
		}
    }
}
