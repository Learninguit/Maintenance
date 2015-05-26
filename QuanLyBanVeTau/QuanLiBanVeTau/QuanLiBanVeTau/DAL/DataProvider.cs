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
    class DataProvider
    {
        protected static string _connectionString;

        protected SqlConnection connection;
        protected SqlDataAdapter adapter;
        protected SqlCommand command;


        public string ConnectionString = @"Data Source=VUKHANHUIT;Initial Catalog=QUANLYBANVETAU;Integrated Security=True";

        public void Dispose()
        {
            if (connection != null)
            {
                connection.Dispose();
                connection = null;
            }
            if (adapter != null)
            {
                adapter.Dispose();
                adapter = null;
            }
            if (command != null)
            {
                command.Dispose();
                command = null;
            }
        }

        public void connect()
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();
        }

        public void disconnect()
        {
            connection.Close();
        }


        // Sử dụng procedure có Parameter
        public IDataReader executeQueryParameter(string sqlString, List<SqlParameter> List_para)
        {

            command = new SqlCommand(sqlString, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter para in List_para)
            {
                command.Parameters.Add(para);
            }

            return command.ExecuteReader();
        }


        // Sử dụng procedure KHÔNG có Parameter
        public IDataReader executeQuery(string sqlString)
        {

            command = new SqlCommand(sqlString, connection);
            command.CommandType = CommandType.StoredProcedure;
            return command.ExecuteReader();
        }

        /*        public DataTable executeQuery(string sqlString)
                {
                    DataSet ds = new DataSet();
                    adapter = new OleDbDataAdapter(sqlString, connection);
                    adapter.Fill(ds);
                    return ds.Tables[0];
                }
        */
        // Sử dụng trực tiếp câu lệnh SQL
        public void executeNonQuery(string sqlString)
        {
            command = new SqlCommand(sqlString, connection);
            //command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
        }

        public object executeScalar(string sqlString)
        {
            command = new SqlCommand(sqlString, connection);
            return command.ExecuteScalar();
        }
        public object executeScalar(string sqlString, List<SqlParameter> List_para)
        {
            command = new SqlCommand(sqlString, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter para in List_para)
            {
                command.Parameters.Add(para);
            }
            return command.ExecuteScalar();
        }
    }
}
