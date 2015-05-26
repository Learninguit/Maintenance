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
    class HanhKhachDataAccess
    {
        private DataProvider _provider = new DataProvider();
	
		public HanhKhachDataAccess()
		{
			_provider.connect();
		}

        // Sử dụng Procedure KHÔNG có parameter input
        public List<HanhKhachInfo> GetDSHanhKhach()
        {
            // GetDSHanhKhach là 1 procedure đã được tạo sẵn
            SqlDataReader reader = (SqlDataReader)_provider.executeQuery("GetDSHanhKhach");

            List<HanhKhachInfo> List_HK = new List<HanhKhachInfo>();

            while (reader.Read())
            {
                HanhKhachInfo  HK= new HanhKhachInfo();
                HK.MaHK = reader["MAHK"].ToString();
                HK.HoTen = reader["HOTEN"].ToString();
                HK.GioiTinh = reader["GIOITINH"].ToString();
                HK.NgaySinh = Convert.ToDateTime(reader["NGAYSINH"]);
                HK.DiaChi = reader["DIACHI"].ToString();
                HK.CMND = reader["CMND"].ToString();
                HK.DienThoai = reader["SDT"].ToString();
                HK.Email = reader["EMAIL"].ToString();
                HK.TaiKhoan = reader["TAIKHOAN"].ToString();
                HK.MatKhau = reader["MATKHAU"].ToString();
                List_HK.Add(HK);
            }

            reader.Close();
            return List_HK;
        }


        // Sử dụng Procedure có parameter input
        public HanhKhachInfo CheckTaiKhoan(string TaiKhoan)
        {
            // Một list các parameter
            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@TaiKhoan", TaiKhoan));
           
            SqlDataReader reader = (SqlDataReader)_provider.executeQueryParameter("CheckTaiKhoanHanhKhach",paramters);

            HanhKhachInfo HK = null;

            if (reader.Read())
            {
                HK = new HanhKhachInfo();
                HK.MaHK = reader["MAHK"].ToString();
                HK.HoTen = reader["HOTEN"].ToString();
                HK.GioiTinh = reader["GIOITINH"].ToString();
                HK.NgaySinh = Convert.ToDateTime(reader["NGAYSINH"]);
                HK.DiaChi = reader["DIACHI"].ToString();
                HK.CMND = reader["CMND"].ToString();
                HK.DienThoai = reader["SDT"].ToString();
                HK.Email = reader["EMAIL"].ToString();
                HK.TaiKhoan = reader["TAIKHOAN"].ToString();
                HK.MatKhau = reader["MATKHAU"].ToString();
            }

            reader.Close();
            return HK;
        }

        public HanhKhachInfo DangNhap(string TaiKhoan, string MatKhau)
        {
            // Một list các parameter
            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@TaiKhoan", TaiKhoan));
            paramters.Add(new SqlParameter("@MatKhau", MatKhau));

            SqlDataReader reader = (SqlDataReader)_provider.executeQueryParameter("DangNhapHanhKhach", paramters);

            HanhKhachInfo HK = null;

            if (reader.Read())
            {
                HK = new HanhKhachInfo();
                HK.MaHK = reader["MAHK"].ToString();
                HK.HoTen = reader["HOTEN"].ToString();
                HK.GioiTinh = reader["GIOITINH"].ToString();
                HK.NgaySinh = Convert.ToDateTime(reader["NGAYSINH"]);
                HK.DiaChi = reader["DIACHI"].ToString();
                HK.CMND = reader["CMND"].ToString();
                HK.DienThoai = reader["SDT"].ToString();
                HK.Email = reader["EMAIL"].ToString();
                HK.TaiKhoan = reader["TAIKHOAN"].ToString();
                HK.MatKhau = reader["MATKHAU"].ToString();
            }

            reader.Close();
            return HK;
        }

		public void insert(HanhKhachInfo info)
		{

            string insertCommand = @"set dateformat dmy " +
            "INSERT INTO HANHKHACH (MAHK, HOTEN, GIOITINH, NGAYSINH, DIACHI, CMND, SDT, EMAIL,TAIKHOAN,MATKHAU) VALUES('" +
                info.MaHK + "', N'" +                
                info.HoTen + "', N'" +
                info.GioiTinh + "', '" +
                info.NgaySinh.ToShortDateString() + "', N'" +
                info.DiaChi + "', '" +
                info.CMND + "', '" +
                info.DienThoai + "', '" +
                info.Email + "', '" +
                info.TaiKhoan + "', '" +
                info.MatKhau + "')";
			_provider.executeNonQuery(insertCommand);
		}

        public void update(HanhKhachInfo info)
		{
			string updateCommand = "UPDATE HANHKHACH " +
									"SET HOTEN = N'" + info.HoTen + "', " +
                                    " GIOITINH = '" + info.GioiTinh + "', " +
                                    " NGAYSINH = '" + info.NgaySinh.ToShortDateString() + "', " +
                                    " DIACHI = N'" + info.DiaChi + "', " +
                                    " CMND = '" + info.CMND + "', " +
                                    " SDT = '" + info.DienThoai + "', " +
                                    " EMAIL = '" + info.Email + "'" +
                                    " TAIKHOAN = '" + info.TaiKhoan + "'" +
                                    " MATKHAU = '" + info.MatKhau + "'" +
									" WHERE MAHK = '" + info.MaHK + "'";

			_provider.executeNonQuery(updateCommand);
		}

		public void delete(HanhKhachInfo info)
		{
            string deleteCommand = "DELETE FROM HANHKHACH WHERE MAHK = '" + info.MaHK + "'";
			_provider.executeNonQuery(deleteCommand);
		}
    }
}
