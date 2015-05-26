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
    class DoanTauDataAccess
    {
        private DataProvider _provider = new DataProvider();
	
		public DoanTauDataAccess()
		{
			_provider.connect();
		}

        // Sử dụng Procedure KHÔNG có parameter input
        public List<DoanTauInfo> GetDSDoanTau()
        {
            // GetDSDoanTau là 1 procedure đã được tạo sẵn
            SqlDataReader reader = (SqlDataReader)_provider.executeQuery("GetDSDoanTau");

            List<DoanTauInfo> List_DTau = new List<DoanTauInfo>();

            while (reader.Read())
            {
                DoanTauInfo DTau = new DoanTauInfo();
                DTau.MaTau = reader["MaTau"].ToString();
                //DTau.TocDoTrungBinh = Convert.ToInt32(reader["TOCDOTRUNGBINH"]);
                DTau.MaGaDau = reader["MAGADAU"].ToString();
                DTau.TenGaDau = reader["TENGADAU"].ToString();
                DTau.TenGaCuoi = reader["TENGACUOI"].ToString();
                DTau.MaGaCuoi = reader["MAGACUOI"].ToString();
                DTau.TongSoToa = Convert.ToInt16(reader["TongSoToa"].ToString());
                DTau.GhiChu = reader["GhiChu"].ToString();
                List_DTau.Add(DTau);
            }

            reader.Close();
            return List_DTau;
        }
        // Sử dụng Procedure có parameter input
        public DoanTauInfo GetDTauTheoMTau(string MaTau)
        {
            // Một list các parameter
            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@MaTau", MaTau));

            SqlDataReader reader = (SqlDataReader)_provider.executeQueryParameter("GetDTauTheoMaTau", paramters);

            DoanTauInfo DTau = null;
            if (reader.Read())
            {
                DTau = new DoanTauInfo();
                DTau.MaTau = reader["MaTau"].ToString();
                //DTau.TocDoTrungBinh = Convert.ToInt32(reader["TOCDOTRUNGBINH"].ToString());
                DTau.MaGaDau = reader["MAGADAU"].ToString();
                DTau.TenGaDau = reader["TENGADAU"].ToString();
                DTau.TenGaCuoi = reader["TENGACUOI"].ToString();
                DTau.MaGaCuoi = reader["MAGACUOI"].ToString();
                DTau.TongSoToa = Convert.ToInt16(reader["TongSoToa"].ToString());
                DTau.GhiChu = reader["GhiChu"].ToString();
            }

            reader.Close();
            return DTau;
        }

		public void insert(DoanTauInfo info)
		{

            //List<SqlParameter> paramters = new List<SqlParameter>();
            //paramters.Add(new SqlParameter("@MaTau", info.MaTau));
            string insertCommand = @"INSERT INTO DOANTAU(MATAU,MAGADAU,MAGACUOI,TONGSOTOA,GHICHU) VALUES('" +
                info.MaTau + "', '" +
                info.MaGaDau + "', '" +
                info.MaGaCuoi + "', " +
                info.TongSoToa + ",'" +
                info.GhiChu + "')";

			_provider.executeNonQuery(insertCommand);
		}

        public void update(DoanTauInfo info)
		{
			string updateCommand = "UPDATE DOANTAU " +
									"SET TONGSOTOA = " + info.TongSoToa +
                                    " MAGADAU = '" + info.MaGaDau + "'" +
                                    " MAGACUOI = '" + info.MaGaCuoi + "'" +
									" WHERE MATAU = '" + info.MaTau + "'";

			_provider.executeNonQuery(updateCommand);
		}

		public void delete(DoanTauInfo info)
		{
            string deleteCommand = "DELETE FROM DOANTAU WHERE MATAU = '" + info.MaTau + "'";
			_provider.executeNonQuery(deleteCommand);
		}
    }
}
