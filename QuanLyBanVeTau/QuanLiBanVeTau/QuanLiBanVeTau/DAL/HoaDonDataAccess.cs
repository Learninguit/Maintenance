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
    class HoaDonDataAccess
    {
        private DataProvider _provider = new DataProvider();
	
		public HoaDonDataAccess()
		{
			_provider.connect();
		}

        // Sử dụng Procedure KHÔNG có parameter input
        public List<HoaDonInfo> GetDSHoaDon()
        {
            // GetDSHoaDon là 1 procedure đã được tạo sẵn
            SqlDataReader reader = (SqlDataReader)_provider.executeQuery("GetDSHoaDon");

            List<HoaDonInfo> List_HD = new List<HoaDonInfo>();

            while (reader.Read())
            {
                HoaDonInfo HD = new HoaDonInfo();
                HD.MaHD = reader["MAHD"].ToString();
                HD.MaDatVe = reader["MADATVE"].ToString();
                HD.NgayLap = Convert.ToDateTime(reader["NgayLap"]);
                HD.MaNV = reader["MANV"].ToString();
                HD.ThanhToan = Convert.ToDouble(reader["THANHTOAN"]);
                HD.ThoiLai = Convert.ToDouble(reader["THOILAI"]);
                List_HD.Add(HD);
            }

            reader.Close();
            return List_HD;
        }


        // Sử dụng Procedure có parameter input
        public HoaDonInfo GetHDTheoMHD(string MaHD)
        {
            // Một list các parameter
            List<SqlParameter> paramters = new List<SqlParameter>();
           paramters.Add(new SqlParameter("@MaHD", MaHD));
           
            //string query = "SELECT * FROM HOADON WHERE MADATVE LIKE '%"+ MaDatVe +"%'";

            // Gọi hàm excute sử dụng procedure có parameter
            SqlDataReader reader = (SqlDataReader)_provider.executeQueryParameter("GetHDTheoMaHD",paramters);

            HoaDonInfo HD = null;

            while (reader.Read())
            {
                HD = new HoaDonInfo();
                HD.MaHD = reader["MAHD"].ToString();
                HD.MaDatVe = reader["MADATVE"].ToString();
                HD.NgayLap = Convert.ToDateTime(reader["NgayLap"]);
                HD.MaNV = reader["MANV"].ToString();
                HD.ThanhToan = Convert.ToDouble(reader["THANHTOAN"]);
                HD.ThoiLai = Convert.ToDouble(reader["THOILAI"]);

            }

            reader.Close();
            return HD;
        }

        // Sử dụng Procedure có parameter input
        public List<HoaDonInfo> GetDSHDTheoMaDatVe(string MaDatVe)
        {
            // Một list các parameter
            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@MaDatVe", MaDatVe));

            //string query = "SELECT * FROM HOADON WHERE MADatVe LIKE '%"+ MaDatVe +"%'";

            // Gọi hàm excute sử dụng procedure có parameter
            SqlDataReader reader = (SqlDataReader)_provider.executeQueryParameter("GetHDTheoMaDatVe", paramters);

            List<HoaDonInfo> List_HD = new List<HoaDonInfo>();

            while (reader.Read())
            {
                HoaDonInfo HD = new HoaDonInfo();
                HD.MaHD = reader["MAHD"].ToString();
                HD.MaDatVe = reader["MADATVE"].ToString();
                HD.NgayLap = Convert.ToDateTime(reader["NgayLap"]);
                HD.MaNV = reader["MANV"].ToString();
                HD.ThanhToan = Convert.ToDouble(reader["THANHTOAN"]);
                HD.ThoiLai = Convert.ToDouble(reader["THOILAI"]);
                List_HD.Add(HD);
            }

            reader.Close();
            return List_HD;
        }

		public void insert(HoaDonInfo info)
		{
            string insertCommand = @"set dateformat dmy INSERT INTO HOADON (MAHD, NGAYLAP, MADATVE, MANV, THANHTOAN, THOILAI) VALUES('" +
                info.MaHD + "', '" +
                info.NgayLap.ToShortDateString() + "', '" +
                info.MaDatVe + "', '" +
                info.MaNV + "', " +
                info.ThanhToan + "," +
                info.ThoiLai + ")";

			_provider.executeNonQuery(insertCommand);
		}

        public void update(HoaDonInfo info)
		{
			string updateCommand = "UPDATE HOADON " +
									"SET MADATVE = '" + info.MaDatVe + "', " +
                                    " NGAYLAP = '" + info.NgayLap.ToShortDateString() + "', " +
                                    " MANV = '" + info.MaNV + "'," +
                                    " THANHTOAN = " + info.ThanhToan + "," +
                                    " THOILAI = " + info.ThoiLai +
									" WHERE MAHD = '" + info.MaHD + "'";

			_provider.executeNonQuery(updateCommand);
		}

		public void delete(HoaDonInfo info)
		{
            string deleteCommand = "DELETE FROM HOADON WHERE MAHD = '" + info.MaHD + "'";
			_provider.executeNonQuery(deleteCommand);
		}
    }
}
