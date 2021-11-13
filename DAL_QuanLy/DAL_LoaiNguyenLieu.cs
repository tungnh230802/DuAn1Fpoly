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
    public class DAL_LoaiNguyenLieu : DBConnect
    {
        public DataTable getTypeOfIngredient()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_GetTypeOfIngredient";
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            finally
            {
                _conn.Close();
            }
        }
        public bool InsertLoaiNguyenLieu(DTO_LoaiNguyenLieu lnl)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TypeOfIngredientInsert";
                cmd.Parameters.AddWithValue("Name", lnl.Name);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool UpdateLoaiNguyenLieu(DTO_LoaiNguyenLieu lnl)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TypeOfIngredientUpdate";
                cmd.Parameters.AddWithValue("Name", lnl.Name);
                cmd.Parameters.AddWithValue("Id_ingredient", lnl.Id_Type);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool DeleteLoaiNguyenLieu(int id_Type)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TypeOfIngredientDelete";
                cmd.Parameters.AddWithValue("Id_type", id_Type);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public DataTable SearchLoaiNguyenLieu(string name)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TypeOfIngredientSearch";
                cmd.Parameters.AddWithValue("Name", name);
                DataTable dtLoaiNguyenLieu = new DataTable();

                dtLoaiNguyenLieu.Load(cmd.ExecuteReader());
                return dtLoaiNguyenLieu;
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
