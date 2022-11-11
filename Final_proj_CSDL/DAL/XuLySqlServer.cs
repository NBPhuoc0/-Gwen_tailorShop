using System.Data.SqlClient;
using System.Data;

namespace Final_proj_CSDL.DAL
{
    internal class XuLySqlServer
    {
        private string ChuoiKetNoi = @"Data Source=NBP;Initial Catalog=gwen;Integrated Security=True";
        public DataTable LoadData_sp(string sql)
        {
            using (SqlConnection cnn = new SqlConnection(ChuoiKetNoi))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
        public DataTable LoadData_vw(string sql)
        {
            using (SqlConnection cnn = new SqlConnection(ChuoiKetNoi))
            {
                cnn.Open();
                string sql_c = "SELECT * from dbo." + sql;
                SqlCommand cmd = new SqlCommand(sql_c, cnn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
        public DataTable LoadDataParameter(string sql, string[] name, object[] values, int parameter)
        {
            using (SqlConnection cnn = new SqlConnection(ChuoiKetNoi))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < parameter; i++)
                {
                    cmd.Parameters.AddWithValue(name[i], values[i]);
                }
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;
            }
        }
        public bool Execute_sp(string sql, string[] name, object[] values, int parameter)
        {
            using (SqlConnection cnn = new SqlConnection(ChuoiKetNoi))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < parameter; i++)
                {
                    cmd.Parameters.AddWithValue(name[i], values[i]);
                }
                cmd.ExecuteNonQuery();
                return true;
            }
        }
        public DataTable Execute_fn(string sql, string[] name, object[] values, int parameter)
        {
            using (SqlConnection cnn = new SqlConnection(ChuoiKetNoi))
            {
                cnn.Open();
                string sql_c = "SELECT * from dbo." + sql + "(";
                for (int i = 0; i < parameter; i++)
                {
                    sql_c += name[i];
                    if (i < parameter - 1)
                        sql_c += ",";
                }
                sql_c += ")";
                SqlCommand cmd = new SqlCommand(sql_c, cnn);
                //cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < parameter; i++)
                {
                    cmd.Parameters.AddWithValue(name[i], values[i]);
                }
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;
            }
        }
        public object GetOneValue(string sql, string[] name, object[] values, int parameter)
        {
            using (SqlConnection cnn = new SqlConnection(ChuoiKetNoi))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < parameter; i++)
                {
                    cmd.Parameters.AddWithValue(name[i], values[i]);
                }
                return cmd.ExecuteScalar();
            }
        }
    }
}
