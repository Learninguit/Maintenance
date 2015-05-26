using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanVeTau.DTO;
using System.Data.SqlClient;
namespace QuanLiBanVeTau.DAL
{
    class NhanVienDataAccess
    {
        private DataProvider _provider = new DataProvider();
	
		public NhanVienDataAccess()
		{
			_provider.connect();
		}

        // Sử dụng Procedure KHÔNG có parameter input
        public List<NhanVienInfo> GetDSNhanVien()
        {
            // GetDSHanhKhach là 1 procedure đã được tạo sẵn
            SqlDataReader reader = (SqlDataReader)_provider.executeQuery("GetDSNhanVien");

            List<NhanVienInfo> List_NV = new List<NhanVienInfo>();

            while (reader.Read())
            {
                NhanVienInfo  NV= new NhanVienInfo();
                NV.MaNV = reader["MAHK"].ToString();
                NV.HoTen = reader["HOTEN"].ToString();
                NV.GioiTinh = reader["GIOITINH"].ToString();
                NV.NgaySinh = Convert.ToDateTime(reader["NGAYSINH"]);
                NV.NgayVaoLam = Convert.ToDateTime(reader["NGAYVAOLAM"]);
                NV.DiaChi = reader["DIACHI"].ToString();
                NV.CMND = reader["CMND"].ToString();
                NV.DienThoai = reader["SDT"].ToString();
                NV.Email = reader["EMAIL"].ToString();
                NV.TaiKhoan = reader["TAIKHOAN"].ToString();
                NV.MatKhau = reader["MATKHAU"].ToString();
                List_NV.Add(NV);
            }

            reader.Close();
            return List_NV;
        }


        public NhanVienInfo DangNhap(string TaiKhoan, string MatKhau)
        {
            // Một list các parameter
            List<SqlParameter> paramters = new List<SqlParameter>();
            paramters.Add(new SqlParameter("@TaiKhoan", TaiKhoan));
            paramters.Add(new SqlParameter("@MatKhau", MatKhau));

            SqlDataReader reader = (SqlDataReader)_provider.executeQueryParameter("DangNhapNhanVien", paramters);

            NhanVienInfo NV = null;

            if (reader.Read())
            {
                NV = new NhanVienInfo();
                NV.MaNV = reader["MANV"].ToString();
                NV.HoTen = reader["HOTEN"].ToString();
                NV.GioiTinh = reader["GIOITINH"].ToString();
                NV.NgaySinh = Convert.ToDateTime(reader["NGAYSINH"]);
                NV.NgayVaoLam = Convert.ToDateTime(reader["NGAYVAOLAM"]);
                NV.DiaChi = reader["DIACHI"].ToString();
                NV.CMND = reader["CMND"].ToString();
                NV.DienThoai = reader["SDT"].ToString();
                NV.Email = reader["EMAIL"].ToString();
                NV.MaPB = reader["MAPB"].ToString();
                NV.TaiKhoan = reader["TAIKHOAN"].ToString();
                NV.MatKhau = reader["MATKHAU"].ToString();
            }

            reader.Close();
            return NV;
        }



		public void insert(NhanVienInfo info)
		{

            string insertCommand = @"set dateformat dmy " +
            "INSERT INTO NHANVIEN (MAHK, HOTEN, GIOITINH, NGAYSINH,NGAYVAOLAM, DIACHI, CMND, SDT, EMAIL,MAPB,TAIKHOAN,MATKHAU) VALUES('" +
                info.MaNV + "', N'" +                
                info.HoTen + "', N'" +
                info.GioiTinh + "', '" +
                info.NgaySinh.ToShortDateString() + "','" +
                info.NgayVaoLam.ToShortDateString() + "', N'" +
                info.DiaChi + "', '" +
                info.CMND + "', '" +
                info.DienThoai + "', '" +
                info.Email + "', '" +
                info.MaPB + "', '" +
                info.TaiKhoan + "', '" +
                info.MatKhau + "')";
			_provider.executeNonQuery(insertCommand);
		}

        public void update(NhanVienInfo info)
		{
			string updateCommand = "UPDATE NHANVIEN " +
									"SET HOTEN = N'" + info.HoTen + "', " +
                                    " GIOITINH = '" + info.GioiTinh + "', " +
                                    " NGAYSINH = '" + info.NgaySinh.ToShortDateString() + "', " +
                                    " NGAYVAOLAM = '" + info.NgayVaoLam.ToShortDateString() + "', " +
                                    " DIACHI = N'" + info.DiaChi + "', " +
                                    " CMND = '" + info.CMND + "', " +
                                    " SDT = '" + info.DienThoai + "', " +
                                    " EMAIL = '" + info.Email + "'" +
                                    " MAPB = '" + info.MaPB + "'" +
                                    " TAIKHOAN = '" + info.TaiKhoan + "'" +
                                    " MATKHAU = '" + info.MatKhau + "'" +
									" WHERE MANV = '" + info.MaNV + "'";

			_provider.executeNonQuery(updateCommand);
		}

		public void delete(NhanVienInfo info)
		{
            string deleteCommand = "DELETE FROM HANHKHACH WHERE MAHK = '" + info.MaNV + "'";
			_provider.executeNonQuery(deleteCommand);
		}
    }
}
