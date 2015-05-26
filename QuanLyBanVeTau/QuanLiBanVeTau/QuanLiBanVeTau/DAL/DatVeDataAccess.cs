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
    class DatVeDataAccess
    {
        private DataProvider _provider = new DataProvider();
	
		public DatVeDataAccess()
		{
			_provider.connect();
		}

        // Sử dụng Procedure KHÔNG có parameter input
        public List<DatVeInfo> GetDSDatVe()
        {
            // GetDSDatVe là 1 procedure đã được tạo sẵn
            SqlDataReader reader = (SqlDataReader)_provider.executeQuery("GetDSDatVe");

            List<DatVeInfo> List_DV = new List<DatVeInfo>();

            while (reader.Read())
            {
                DatVeInfo DV = new DatVeInfo();
                DV.MaDatVe = reader["MADATVE"].ToString();
                DV.MaLichTrinh = reader["MALICHTRINH"].ToString();
                DV.MaHK = reader["MAHK"].ToString();
                DV.TongGia = Convert.ToDouble(reader["TONGGIA"]);
                DV.NgayHetHan = Convert.ToDateTime(reader["NGAYHETHAN"].ToString());
                List_DV.Add(DV);
            }

            reader.Close();
            return List_DV;
        }


        // Sử dụng Procedure có parameter input
        public List<DatVeInfo> GetDatVe(string MaDatVe)
        {
            // Một list các parameter
            List<SqlParameter> paramters = new List<SqlParameter>();
           paramters.Add(new SqlParameter("@MaDatVe", MaDatVe));
           
            SqlDataReader reader = (SqlDataReader)_provider.executeQueryParameter("GetDatVe",paramters);
            List<DatVeInfo> List_DV = new List<DatVeInfo>();

            while (reader.Read())
            {
                DatVeInfo DV = new DatVeInfo();
                DV.MaDatVe = reader["MADATVE"].ToString();
                DV.MaLichTrinh = reader["MALICHTRINH"].ToString();
                DV.MaHK = reader["MAHK"].ToString();
                DV.TongGia = Convert.ToDouble(reader["TONGGIA"]);
                DV.NgayHetHan = Convert.ToDateTime(reader["NGAYHETHAN"].ToString());
                //thong tin them
                DV.TenHK = reader["TENHK"].ToString();
                DV.CMND = reader["CMND"].ToString();
                DV.GiaVe = Convert.ToDouble(reader["GIA"]);
                DV.GioKhoiHanh = Convert.ToDateTime(reader["GIOKHOIHANH"].ToString());
                DV.MaTau = reader["MATAU"].ToString();
                DV.NgayKhoiHanh = Convert.ToDateTime(reader["NGAYKHOIHANH"]);
                DV.SoGhe = Convert.ToInt32(reader["SOGHE"]);
                DV.SoToa = Convert.ToInt32(reader["SOTOA"]);
                DV.TenGaDen = reader["TENGADEN"].ToString();
                DV.TenGaDi = reader["TENGADI"].ToString();
                List_DV.Add(DV);
            }
            reader.Close();
            return List_DV;
        }

		public void insert(DatVeInfo info)
		{


            string insertCommand;
            if(info.MaHK != null)
            {
                insertCommand = @"set dateformat dmy " +
                "INSERT INTO DATVE (MADATVE, MALICHTRINH, MAHK,TONGGIA, NGAYHETHAN) VALUES('" +
                info.MaDatVe + "', '" +
                info.MaLichTrinh + "', '" +
                info.MaHK + "', " +
                info.TongGia + ", '" +
                info.NgayHetHan + "')";
            }
            else
            {
                insertCommand = @"set dateformat dmy " +
                "INSERT INTO DATVE (MADATVE,MALICHTRINH, MAHK,TONGGIA, NGAYHETHAN) VALUES('" +
                info.MaDatVe + "', '" +
                info.MaLichTrinh + "', null," +
                info.TongGia + ", '" +
                info.NgayHetHan + "')";
            }

			_provider.executeNonQuery(insertCommand);
		}

        public void update(DatVeInfo info)
		{
            string updateCommand = "UPDATE DATVE " +
                                    "SET MALICHTRINH = '" + info.MaLichTrinh + "', " +
                                    " TONGGIA = '" + info.TongGia + "', " +
                                    " NGAYHETHAN = '" + info.NgayHetHan + "'" +
                                    " WHERE MADATVE = '" + info.MaDatVe + "'";

			_provider.executeNonQuery(updateCommand);
		}

		public void delete(DatVeInfo info)
		{
            string deleteCommand = "DELETE FROM DATVE WHERE MADATVE = '" + info.MaDatVe + "'";
			_provider.executeNonQuery(deleteCommand);
		}
    }
}
