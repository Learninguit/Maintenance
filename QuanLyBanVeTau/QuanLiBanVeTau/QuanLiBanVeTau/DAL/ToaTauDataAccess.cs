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
    class ToaTauDataAccess
    {
        private DataProvider _provider = new DataProvider();
	
		public ToaTauDataAccess()
		{
			_provider.connect();
		}

        // Sử dụng Procedure KHÔNG có parameter input
        public List<ToaTauInfo> GetDSToaTau()
        {
            // GetDSLoaiToa là 1 procedure đã được tạo sẵn
            SqlDataReader reader = (SqlDataReader)_provider.executeQuery("GetDSToaTau");

            List<ToaTauInfo> List_Toa = new List<ToaTauInfo>();

            while (reader.Read())
            {
                ToaTauInfo toaTau = new ToaTauInfo();
                toaTau.MaToa = reader["MATOA"].ToString();
                toaTau.MaTau = reader["MaTau"].ToString();
                toaTau.SoToa = Convert.ToInt32(reader["SoToa"]);
                toaTau.SoLuongGhe = Convert.ToInt32(reader["SoLuongGhe"]);
                List_Toa.Add(toaTau);
            }

            reader.Close();
            return List_Toa;
        }


        // Sử dụng Procedure có parameter input
        public List<ToaTauInfo> GetDSToaTau(string MaTau)
        {
            // Một list các parameter
            List<SqlParameter> paramters = new List<SqlParameter>();        
            paramters.Add(new SqlParameter("@MaTau", MaTau));
            
           
            //string query = "SELECT * FROM LOAITOA WHERE MATAU LIKE '%"+ MaTau +"%' AND MATOA LIKE '%"+ MaToa +"%'";

            // Gọi hàm excute sử dụng procedure có parameter
            SqlDataReader reader = (SqlDataReader)_provider.executeQueryParameter("GetDSToaTauTheoMaTau",paramters);

            List<ToaTauInfo> List_Toa = new List<ToaTauInfo>();

            while (reader.Read())
            {
                ToaTauInfo toaTau = new ToaTauInfo();
                toaTau.MaToa = reader["MATOA"].ToString();
                toaTau.MaTau = reader["MaTau"].ToString();
                toaTau.SoToa = Convert.ToInt32(reader["SoToa"].ToString());
                toaTau.SoLuongGhe = Convert.ToInt32(reader["SoLuongGhe"]);
                List_Toa.Add(toaTau);
            }
            reader.Close();
            return List_Toa;
        }

		public void insert(ToaTauInfo info)
		{

            //List<SqlParameter> paramters = new List<SqlParameter>();
            //paramters.Add(new SqlParameter("@MaTau", info.MaTau));
            //paramters.Add(new SqlParameter("@MaToa", info.MaToa));
            string insertCommand = @"INSERT INTO TOATAU (MATOA, MATAU, SOTOA, SOLUONGGHE) VALUES('" +
                info.MaToa + "', " +
                info.MaTau + "'," +
                info.SoToa + ", " +
                info.SoLuongGhe + ")";

			_provider.executeNonQuery(insertCommand);
		}

        public void update(ToaTauInfo info)
		{
            string updateCommand = "UPDATE TOATAU " +
                                    "SET SOLUONGGHE = " + info.SoLuongGhe +
                                    " WHERE MATOA = '" + info.MaToa + "'";

			_provider.executeNonQuery(updateCommand);
		}

        public void delete(ToaTauInfo info)
        {
            string deleteCommand = "DELETE FROM TOATAU WHERE MATOA = '" + info.MaToa + "'";
            _provider.executeNonQuery(deleteCommand);
        }
    }
}
