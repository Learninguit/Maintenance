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
    class GaTauDataAccess
    {
        private DataProvider _provider = new DataProvider();
	
		public GaTauDataAccess()
		{
			_provider.connect();
		}

        // Sử dụng Procedure KHÔNG có parameter input
        public List<GaTauInfo> GetDSGaTau()
        {
            // GetDSGaTau là 1 procedure đã được tạo sẵn
            SqlDataReader reader = (SqlDataReader)_provider.executeQuery("GetDSGaTau");

            List<GaTauInfo> List_GT = new List<GaTauInfo>();

            while (reader.Read())
            {
                GaTauInfo GT = new GaTauInfo();
                GT.MaGa = reader["MAGA"].ToString();
                GT.TenGa = reader["TENGA"].ToString();
                GT.DiaChi = reader["DIACHI"].ToString();
                List_GT.Add(GT);
            }

            reader.Close();
            return List_GT;
        }


        // Sử dụng Procedure có parameter input
        public List<GaTauInfo> getDsGTheoMGa(string MaGa)
        {
            // Một list các parameter
            List<SqlParameter> paramters = new List<SqlParameter>();
           paramters.Add(new SqlParameter("@MaGa", MaGa));
           
            //string query = "SELECT * FROM GATAU WHERE MAGA LIKE '%"+ MaGa +"%'";

            // Gọi hàm excute sử dụng procedure có parameter
            SqlDataReader reader = (SqlDataReader)_provider.executeQueryParameter("GetGTTheoMaGa",paramters);

            List<GaTauInfo> List_GT = new List<GaTauInfo>();

            while (reader.Read())
            {
                GaTauInfo GT = new GaTauInfo();
                GT.MaGa = reader["MaGa"].ToString();
                GT.TenGa = reader["TenGa"].ToString();
                GT.DiaChi = reader["DiaChi"].ToString();
                List_GT.Add(GT);
            }

            reader.Close();
            return List_GT;
        }

		public void insert(GaTauInfo info)
		{

            //List<SqlParameter> paramters = new List<SqlParameter>();
            //paramters.Add(new SqlParameter("@MAGA", info.MaGa));
            string insertCommand = @"INSERT INTO GATAU (MAGA, TENGA, DIACHI) VALUES('" +
                info.MaGa + "', N'" +
                info.TenGa + "', N'" +
                info.DiaChi + "')";

			_provider.executeNonQuery(insertCommand);
		}

        public void update(GaTauInfo info)
		{
			string updateCommand = "UPDATE GATAU " +
									"SET TENGA = N'" + info.TenGa + "', " +
                                    " DIACHI = N'" + info.DiaChi + "'" +
									" WHERE MAGA = '" + info.MaGa + "'";

			_provider.executeNonQuery(updateCommand);
		}

		public void delete(GaTauInfo info)
		{
            string deleteCommand = "DELETE FROM GATAU WHERE MAGA = '" + info.MaGa + "'";
			_provider.executeNonQuery(deleteCommand);
		}
    }
}
