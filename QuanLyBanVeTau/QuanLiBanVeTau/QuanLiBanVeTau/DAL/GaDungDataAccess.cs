using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanVeTau.DTO;
using System.Data.SqlClient;
namespace QuanLiBanVeTau.DAL
{
    class GaDungDataAccess
    {
         private DataProvider _provider = new DataProvider();
	
		public GaDungDataAccess()
		{
			_provider.connect();
		}

        // Sử dụng Procedure có parameter input
        public List<GaDungInfo> GetDSGaDung(string MaTau)
        {
            // Một list các parameter
            List<SqlParameter> paramters = new List<SqlParameter>();
           paramters.Add(new SqlParameter("@MaTau", MaTau));
           
           
            SqlDataReader reader = (SqlDataReader)_provider.executeQueryParameter("GetDSGaDung",paramters);

            List<GaDungInfo> List_GD = new List<GaDungInfo>();

            while (reader.Read())
            {
                GaDungInfo GD = new GaDungInfo();
                GD.MaTau = reader["MATAU"].ToString();
                GD.MaGa = reader["MAGA"].ToString();
                GD.TenGa = reader["TENGA"].ToString();
                GD.Km = Convert.ToInt32(reader["KM"].ToString());
                GD.ThoiGianDung = Convert.ToInt32(reader["THOIGIANDUNG"].ToString());
                List_GD.Add(GD);
            }

            reader.Close();
            return List_GD;
        }

        public GaDungInfo GetGaDung(string MaTau, string MaGa)
        {
            // Một list các parameter
            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@MaTau", MaTau));
            paramters.Add(new SqlParameter("@MaGa", MaGa));

            SqlDataReader reader = (SqlDataReader)_provider.executeQueryParameter("GetGaDung", paramters);

            GaDungInfo GD  = null;

            while (reader.Read())
            {
                GD = new GaDungInfo();
                GD.MaTau = reader["MATAU"].ToString();
                GD.MaGa = reader["MAGA"].ToString();
                GD.Km = Convert.ToInt32(reader["KM"].ToString());
                GD.ThoiGianDung = Convert.ToInt32(reader["THOIGIANDUNG"].ToString());
            }

            reader.Close();
            return GD;
        }

		public void insert(GaDungInfo info)
		{

            //List<SqlParameter> paramters = new List<SqlParameter>();
            //paramters.Add(new SqlParameter("@MAGA", info.MaGa));
            string insertCommand = @"INSERT INTO GADUNG (MATAU, MAGA, KM, THOIGIANDUNG) VALUES('" +
                info.MaTau + "', '" +
                info.MaGa + "', " +
                info.Km + "," + info.ThoiGianDung + ")";

			_provider.executeNonQuery(insertCommand);
		}

        public void update(GaDungInfo info)
		{
			string updateCommand = "UPDATE GADUNG " +
									"SET MAGA = '" + info.MaGa + "', " +
                                    " KM = " + info.Km + "," +
                                    " THOIGIANDUNG = " + info.ThoiGianDung +
									" WHERE MATAU = '" + info.MaTau + "' and " + " MAGA = '" + info.MaGa + "'" ;

			_provider.executeNonQuery(updateCommand);
		}

		public void delete(GaDungInfo info)
		{
            string deleteCommand = "DELETE FROM GADUNG WHERE MAGA = '" + info.MaGa + "' and " + " MATAU = '" + info.MaTau + "'";
			_provider.executeNonQuery(deleteCommand);
		}
    }
}
