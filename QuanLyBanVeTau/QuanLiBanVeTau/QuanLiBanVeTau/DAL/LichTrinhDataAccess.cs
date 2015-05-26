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
    class LichTrinhDataAccess
    {
        private DataProvider _provider = new DataProvider();
	
		public LichTrinhDataAccess()
		{
			_provider.connect();
		}

        // Sử dụng Procedure KHÔNG có parameter input
        public List<LichTrinhInfo> GetDSLichTrinh()
        {
            // GetDSLichTrinh là 1 procedure đã được tạo sẵn
            SqlDataReader reader = (SqlDataReader)_provider.executeQuery("GetDSLichTrinh");

            List<LichTrinhInfo> List_LT = new List<LichTrinhInfo>();

            while (reader.Read())
            {
                LichTrinhInfo LT = new LichTrinhInfo();
                LT.MaLichTrinh = reader["MALICHTRINH"].ToString();
                LT.MaTau = reader["MaTau"].ToString();
                LT.NgayKhoiHanh = Convert.ToDateTime(reader["NgayKhoiHanh"].ToString());
                LT.NgayDen = Convert.ToDateTime(reader["NgayDen"].ToString());
                LT.MaGaDi = reader["MAGADI"].ToString();
                LT.MaGaDen = reader["MAGADEN"].ToString();
                List_LT.Add(LT);
            }

            reader.Close();
            return List_LT;
        }


        // Sử dụng Procedure có parameter input
        public LichTrinhInfo GetLTTheoMaLT(string MaLichTrinh)
        {
            // Một list các parameter
            List<SqlParameter> paramters = new List<SqlParameter>();
           paramters.Add(new SqlParameter("@MaLichTrinh", MaLichTrinh));
          
            SqlDataReader reader = (SqlDataReader)_provider.executeQueryParameter("GetLTTheoMaLT",paramters);

            LichTrinhInfo LT = null;

            while (reader.Read())
            {
                LT = new LichTrinhInfo();
                LT.MaLichTrinh = reader["MALICHTRINH"].ToString();
                LT.MaTau = reader["MaTau"].ToString();
                LT.NgayKhoiHanh = Convert.ToDateTime(reader["NgayKhoiHanh"].ToString());
                LT.NgayDen = Convert.ToDateTime(reader["NgayDen"].ToString());
                LT.MaGaDi = reader["MAGADI"].ToString();
                LT.MaGaDen = reader["MAGADEN"].ToString();
            }

            reader.Close();
            return LT;
        }

        public List<LichTrinhInfo> GetDSLichTrinh(string MaGaDi, string MaGaDen, string MaTau, DateTime TuNgay, DateTime DenNgay)
        {

            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@MaGaDi", MaGaDi));
            paramters.Add(new SqlParameter("@MaGaDen", MaGaDen));
            paramters.Add(new SqlParameter("@MaTau", MaTau));
            paramters.Add(new SqlParameter("@TuNgay", TuNgay));
            paramters.Add(new SqlParameter("@DenNgay", DenNgay));

            // GetDSLichTrinh là 1 procedure đã được tạo sẵn
            SqlDataReader reader = (SqlDataReader)_provider.executeQueryParameter("GetDSLichTrinhTheoYeuCau", paramters);

            List<LichTrinhInfo> List_LT = new List<LichTrinhInfo>();

            while (reader.Read())
            {
                LichTrinhInfo LT = new LichTrinhInfo();
                LT = new LichTrinhInfo();
                LT.MaLichTrinh = reader["MALICHTRINH"].ToString();
                LT.MaTau = reader["MaTau"].ToString();
                LT.NgayKhoiHanh = Convert.ToDateTime(reader["NgayKhoiHanh"]);
                LT.NgayDen = Convert.ToDateTime(reader["NgayDen"]);
                LT.MaGaDi = reader["MAGADI"].ToString();
                LT.MaGaDen = reader["MAGADEN"].ToString();
               
                List_LT.Add(LT);
            }

            reader.Close();
            return List_LT;
        }
		public void insert(LichTrinhInfo info)
		{

            string insertCommand = @"set dateformat dmy " + "INSERT INTO LICHTRINH(MALICHTRINH, MATAU, NGAYKHOIHANH, NGAYDEN) VALUES('" +
                info.MaLichTrinh + "', '" +
                info.MaTau + "', '" +
                info.NgayKhoiHanh + "', '" +
                info.NgayDen  + "')";

			_provider.executeNonQuery(insertCommand);
		}

        public void update(LichTrinhInfo info)
		{
			string updateCommand = " set dateformat dmy " + 
                                    "UPDATE LICHTRINH " +
									"SET MATAU = '" + info.MaTau + "'," +
                                    " NGAYKHOIHANH = '" + info.NgayKhoiHanh + "'," +                                    
                                    " NGAYDEN = '" + info.NgayDen + "'" +                                    
									" WHERE MALICHTRINH = '" + info.MaLichTrinh + "'";

			_provider.executeNonQuery(updateCommand);
		}

		public void delete(LichTrinhInfo info)
		{
            string deleteCommand = "DELETE FROM LICHTRINH WHERE MALICHTRINH = '" + info.MaLichTrinh + "'";
			_provider.executeNonQuery(deleteCommand);
		}
    }
}
