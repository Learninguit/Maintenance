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
    class GiaVeDataAccess
    {
        private DataProvider _provider = new DataProvider();
	
		public GiaVeDataAccess()
		{
			_provider.connect();
		}

        // Sử dụng Procedure KHÔNG có parameter input
        public List<GiaVeInfo> GetDSGiaVe()
        {
            // GetDSGiaVe là 1 procedure đã được tạo sẵn
            SqlDataReader reader = (SqlDataReader)_provider.executeQuery("GetDSGiaVe");

            List<GiaVeInfo> List_GV = new List<GiaVeInfo>();

            while (reader.Read())
            {
                GiaVeInfo GV = new GiaVeInfo();
                GV.MaGiaVe = Convert.ToInt32(reader["MADONGIA"].ToString());                
                GV.MaTau = reader["MATAU"].ToString();
                GV.MaLoaiGhe = reader["MALOAIGHE"].ToString();
                GV.TenGhe = reader["TENGHE"].ToString();
                GV.DonGia = Convert.ToDouble(reader["DONGIA"].ToString());
                List_GV.Add(GV);
            }

            reader.Close();
            return List_GV;
        }


        public GiaVeInfo GetGiaVe(string MaGiaVe)
        {
            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@MaGiaVe", MaGiaVe));
            // GetDSGiaVe là 1 procedure đã được tạo sẵn
            SqlDataReader reader = (SqlDataReader)_provider.executeQueryParameter("GetGiaVeTheoMaGiaVe",paramters);

            GiaVeInfo GV = null;

            while (reader.Read())
            {
                GV = new GiaVeInfo();
                GV.MaGiaVe = Convert.ToInt32(reader["MADONGIA"].ToString());
                GV.MaTau = reader["MATAU"].ToString();
                GV.MaLoaiGhe = reader["MALOAIGHE"].ToString();
                GV.TenGhe = reader["TENGHE"].ToString();
                GV.DonGia = Convert.ToDouble(reader["DONGIA"].ToString());

            }
            reader.Close();
            return GV;
        }

        public GiaVeInfo GetGiaVe(string MaTau, string MaLoaiGhe)
        {
            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@MaTau", MaTau));
            paramters.Add(new SqlParameter("@MaLoaiGhe", MaLoaiGhe));
            // GetDSGiaVe là 1 procedure đã được tạo sẵn
            SqlDataReader reader = (SqlDataReader)_provider.executeQueryParameter("GetGiaVe", paramters);

            GiaVeInfo GV = null;

            while (reader.Read())
            {
                GV = new GiaVeInfo();
                GV.MaGiaVe = Convert.ToInt32(reader["MADONGIA"].ToString());
                GV.MaTau = reader["MATAU"].ToString();
                GV.MaLoaiGhe = reader["MALOAIGHE"].ToString();
                GV.TenGhe = reader["TENGHE"].ToString();
                GV.DonGia = Convert.ToDouble(reader["DONGIA"].ToString());

            }
            reader.Close();
            return GV;
        }
        

		public void insert(GiaVeInfo info)
		{

            //List<SqlParameter> paramters = new List<SqlParameter>();
            //paramters.Add(new SqlParameter("@MAVE", info.MaVe));
            string insertCommand = @"INSERT INTO DONGIAVE(MATAU, MALOAIGHE, DONGIA) VALUES('" +
                info.MaTau + "', '" +
                info.MaLoaiGhe + "'," +
                info.DonGia + ")";

			_provider.executeNonQuery(insertCommand);
		}

        public void update(GiaVeInfo info)
		{
			string updateCommand = "UPDATE DONGIAVE " +
									"SET MATAU = '" + info.MaTau + "', " +
                                    " MALOAIGHE = '" + info.MaLoaiGhe + "', " +
                                    " DONGIA = " + info.DonGia +
									" WHERE MADONGIA = " + info.MaGiaVe;

			_provider.executeNonQuery(updateCommand);
		}

		public void delete(GiaVeInfo info)
		{
            string deleteCommand = "DELETE FROM DONGIAVE WHERE MADONGIA = " + info.MaGiaVe;
			_provider.executeNonQuery(deleteCommand);
		}
    }
}
