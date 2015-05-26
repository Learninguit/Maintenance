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
    class CTDVDataAccess
    {
        private DataProvider _provider = new DataProvider();
	
		public CTDVDataAccess()
		{
			_provider.connect();
		}

        // Sử dụng Procedure KHÔNG có parameter input
        public List<CTDVInfo> GetDSCTDV()
        {
            // GetDSCTDV là 1 procedure đã được tạo sẵn
            SqlDataReader reader = (SqlDataReader)_provider.executeQuery("GetDSCTDV");

            List<CTDVInfo> List_CTDV = new List<CTDVInfo>();

            while (reader.Read())
            {
                CTDVInfo CTDV = new CTDVInfo();
                CTDV.MaDatVe = reader["MADATVE"].ToString();
                CTDV.TenHK = reader["TENHK"].ToString();
                CTDV.CMND = reader["CMND"].ToString();
                CTDV.MaDT = reader["MADT"].ToString();
                CTDV.TenDT = reader["TENDT"].ToString();
                CTDV.MaToa = reader["MATOA"].ToString();
                CTDV.SoToa = Convert.ToInt32(reader["SOTOA"]);
                CTDV.MaGhe = reader["MAGHE"].ToString();
                CTDV.SoGhe = Convert.ToInt32(reader["SOGHE"]);
                CTDV.MaGiaVe = reader["MAGIAVE"].ToString();
                CTDV.Gia = Convert.ToDouble(reader["GIA"]);
                List_CTDV.Add(CTDV);
            }

            reader.Close();
            return List_CTDV;
        }


        // Sử dụng Procedure có parameter input
        public List<CTDVInfo> GetDSCTDVTheoMaDatVe(string MaDatVe)
        {
            // Một list các parameter
            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@MaDatVe", MaDatVe));
           
            SqlDataReader reader = (SqlDataReader)_provider.executeQueryParameter("GetDSCTDVTheoMaDatVe",paramters);

            List<CTDVInfo> List_CTDV = new List<CTDVInfo>();

            while (reader.Read())
            {
                CTDVInfo CTDV = new CTDVInfo();
                CTDV.MaDatVe = reader["MADATVE"].ToString();
                CTDV.TenHK = reader["TENHK"].ToString();
                CTDV.CMND = reader["CMND"].ToString();
                CTDV.MaDT = reader["MADT"].ToString();
                CTDV.TenDT = reader["TENDT"].ToString();
                CTDV.MaToa = reader["MATOA"].ToString();
                CTDV.SoToa = Convert.ToInt32(reader["SOTOA"]);
                CTDV.MaGhe = reader["MAGHE"].ToString();
                CTDV.SoGhe = Convert.ToInt32(reader["SOGHE"]);
                CTDV.MaGiaVe = reader["MAGIAVE"].ToString();
                CTDV.Gia = Convert.ToDouble(reader["GIA"]);
                List_CTDV.Add(CTDV);
            }

            reader.Close();
            return List_CTDV;
        }

		public void insert(CTDVInfo info)
		{
            string insertCommand = @"INSERT INTO CTDV (MADATVE, TENHK, MADT, CMND, MAGHE, MAGIAVE, GIA) VALUES('" +
                info.MaDatVe + "', N'" +
                info.TenHK + "', '" +
                info.MaDT + "', '" +
                info.CMND + "', '" +
                info.MaGhe + "', '" +
                info.MaGiaVe + "', " +
                info.Gia + ")";
			_provider.executeNonQuery(insertCommand);
		}

        public void update(CTDVInfo info)
        {
            string updateCommand = "UPDATE CTDV " +
                                    "SET TENHK = N'" + info.TenHK + "', " +
                                    " MADT = '" + info.MaDT + "'," +
                                    " CMND = '" + info.CMND + "', " +
                                    " MAGHE = '" + info.MaGhe + "', " +
                                    " MAGIAVE= '" + info.MaGiaVe + "', " +
                                    " GIA = " + info.Gia +
                                    " WHERE MADATVE = '" + info.MaDatVe + "'";

            _provider.executeNonQuery(updateCommand);
        }

        public void delete(CTDVInfo info)
        {
            string deleteCommand = "DELETE FROM CTDV WHERE MADATVE = '" + info.MaDatVe + "' and MAGHE = '" + info.MaGhe + "'";
            _provider.executeNonQuery(deleteCommand);
        }
    }
}
