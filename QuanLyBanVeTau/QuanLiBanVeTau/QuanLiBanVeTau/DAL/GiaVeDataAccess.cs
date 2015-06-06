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
                //SỬA CHỖ NÀY
                //GV.MaGiaVe = Convert.ToInt32(reader["MADONGIA"].ToString());   
                GV.MaGiaVe = reader["MAGIAVE"].ToString();   
                GV.MaTau = reader["MATAU"].ToString();
                GV.MaLoaiGhe = reader["MALOAIGHE"].ToString();
                //SỬA CHỖ NÀY
                //GV.TenGhe = reader["TENGHE"].ToString();
                GV.DonGia = Convert.ToDouble(reader["DONGIA"].ToString());
                List_GV.Add(GV);
            }

            reader.Close();
            return List_GV;
        }


        public GiaVeInfo GetGiaVeTheoMa(string MaGiaVe)
        {
            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@MaGiaVe", MaGiaVe));
            // GetDSGiaVe là 1 procedure đã được tạo sẵn
            SqlDataReader reader = (SqlDataReader)_provider.executeQueryParameter("GetGiaVeTheoMaGiaVe",paramters);

            GiaVeInfo GV = null;

            while (reader.Read())
            {
                GV = new GiaVeInfo();
               // GV.MaGiaVe = Convert.ToInt32(reader["MADONGIA"].ToString());
                GV.MaGiaVe = reader["MAGIAVE"].ToString();   
                GV.MaTau = reader["MATAU"].ToString();
                GV.MaLoaiGhe = reader["MALOAIGHE"].ToString();
               // GV.TenGhe = reader["TENGHE"].ToString();
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
               //GV.MaGiaVe = Convert.ToInt32(reader["MADONGIA"].ToString());
                GV.MaGiaVe = reader["MAGIAVE"].ToString();   
                GV.MaTau = reader["MATAU"].ToString();
                GV.MaLoaiGhe = reader["MALOAIGHE"].ToString();
               // GV.TenGhe = reader["TENGHE"].ToString();
                GV.DonGia = Convert.ToDouble(reader["DONGIA"].ToString());

            }
            reader.Close();
            return GV;
        }
        

		public void insert(GiaVeInfo info)
		{

            //List<SqlParameter> paramters = new List<SqlParameter>();
            //paramters.Add(new SqlParameter("@MAVE", info.MaVe));
            string insertCommand = @"INSERT INTO GIAVE(MAGIAVE,MATAU, MALOAIGHE, DONGIA) VALUES('" +
                info.MaGiaVe + "', '" +
                info.MaTau + "', '" +
                info.MaLoaiGhe + "'," +
                info.DonGia + ")";

			_provider.executeNonQuery(insertCommand);
		}

        public void update(GiaVeInfo info)
		{
            //Sửa chỗ này
			string updateCommand = "UPDATE GIAVE " +
									"SET MATAU = '" + info.MaTau + "', " +
                                    " MALOAIGHE = '" + info.MaLoaiGhe + "', " +
                                    " DONGIA = '" + info.DonGia +"' "+
									" WHERE MAGIAVE = '" + info.MaGiaVe+"' ";

			_provider.executeNonQuery(updateCommand);
		}       
		public void delete(GiaVeInfo info)
		{
            //Sửa chỗ này
            string deleteCommand = "DELETE FROM GIAVE WHERE MAGIAVE = '" + info.MaGiaVe + "'";
			_provider.executeNonQuery(deleteCommand);
		}
        //public string MaTuTang()
        //{
        //    SqlConnection cnn = new SqlConnection(@"Data Source=VAIO;Initial Catalog=QUANLYBANVETAU;Integrated Security=True");
        //    cnn.Open();
        //    SqlCommand com = new SqlCommand("GetDSGiaVe",cnn);
        //    com.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter da = new SqlDataAdapter(com);
        //    DataTable dt =new DataTable();
        //    da.Fill(dt);
        //    cnn.Close();

        //    string s = "";
        //    if (dt.Rows.Count <= 0)
        //        s = "GV001";
        //    else
        //    {
        //        int k;
        //        s = "GV";
        //        k = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(2,3));
        //        k = k + 1;
        //        if (k < 10)
        //            s = s + "00";
        //        else if (k < 100)
        //            s = s + "0";
        //        s = s + k.ToString();
        //    }
        //    return s;

        //}
    }
}
