using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using QuanLiBanVeTau.DTO;
using QuanLiBanVeTau.BLL;
namespace QuanLiBanVeTau.DAL
{
    class GheDataAccess
    {
         private DataProvider _provider = new DataProvider();
	
		public GheDataAccess()
		{
			_provider.connect();
		}

        // Sử dụng Procedure có parameter input
        public List<GheInfo> GetDSGhe(string MaToa,string MaLoaiGhe)
        {
            // Một list các parameter
            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@MaToa", MaToa));
            paramters.Add(new SqlParameter("@MaLoaiGhe", MaLoaiGhe));

            // Gọi hàm excute sử dụng procedure có parameter
            SqlDataReader reader = (SqlDataReader)_provider.executeQueryParameter("GetDSGhe",paramters);

            List<GheInfo> List_Ghe = new List<GheInfo>();

            while (reader.Read())
            {
                GheInfo ghe = new GheInfo();
                ghe.MaGhe = reader["MAGHE"].ToString();
                ghe.MaToa = reader["MATOA"].ToString();
                ghe.SoGhe = Convert.ToInt32(reader["SOGHE"]);
                ghe.MaLoaiGhe = reader["MALOAIGHE"].ToString();
                List_Ghe.Add(ghe);
            }
            reader.Close();
            return List_Ghe;
        }


        public List<LoaiGheInfo> GetDSLoaiGheTrongToa(string MaToa)
        {
            // Một list các parameter
            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@MaToa", MaToa));


            // Gọi hàm excute sử dụng procedure có parameter
            SqlDataReader reader = (SqlDataReader)_provider.executeQueryParameter("GetDSLoaiGheTrongToa", paramters);

            LoaiGheControl loaiGheControl = new LoaiGheControl();
            List<LoaiGheInfo> List_LoaiGhe = loaiGheControl.GetDSLoaiGhe();
            List<LoaiGheInfo> list = new List<LoaiGheInfo>();
            while (reader.Read())
            {
                string MaLoaiGhe = reader["MALOAIGHE"].ToString();
                foreach(LoaiGheInfo info in List_LoaiGhe)
                {
                    if(info.MaLoaiGhe == MaLoaiGhe)
                    {
                        list.Add(info);
                        break;
                    }
                }
            }
            reader.Close();
            return list;
        }
    }
}
