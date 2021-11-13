using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_TypesOfBeverage:DBConnect
    {
        public DataTable getBeverage()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TypeOfBeverageGet";
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }

            finally
            {
                _conn.Close();
            }
        }
        public bool InsertLoaiDoUong(string name)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TypeOfBeverageInsertSearch";
                cmd.Parameters.AddWithValue("Name", name);
                cmd.Parameters.AddWithValue("StatementType", "insert");
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public bool UpdateLoaiDoUong(DTO_TypesOfBeverage du)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TypeOfBeverageUpdate";
                cmd.Parameters.AddWithValue("@id_type", du.ID_Type);
                cmd.Parameters.AddWithValue("@Name", du.Name);
                cmd.Connection = _conn;
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public bool DeleteDoUong(int id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TypeOfBeverageDelete";
                cmd.Parameters.AddWithValue("id", id);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public DataTable SearchLoaiDoUong(string name)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TypeOfBeverageInsertSearch";
                cmd.Parameters.AddWithValue("Name", name);
                cmd.Parameters.AddWithValue("StatementType", "search");
                cmd.Connection = _conn;
                DataTable dtDoUong = new DataTable();
                dtDoUong.Load(cmd.ExecuteReader());
                return dtDoUong;
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
