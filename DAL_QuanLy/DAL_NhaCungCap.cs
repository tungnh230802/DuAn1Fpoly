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
    public class DAL_NhaCungCap : DBConnect
    {
        public DataTable getSupplier()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_GetSupplier";
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            finally
            {
                _conn.Close();
            }
        }
        public bool InsertNhaCungCap(DTO_NhaCungCap ncc)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_SupplierInsert";
                cmd.Parameters.AddWithValue("Name", ncc.Name);
                cmd.Parameters.AddWithValue("Email", ncc.Email);
                cmd.Parameters.AddWithValue("Address", ncc.Address);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool UpdateNhaCungCap(DTO_NhaCungCap ncc)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_SupplierUpdate";
                cmd.Parameters.AddWithValue("Name", ncc.Name);
                cmd.Parameters.AddWithValue("Email", ncc.Email);
                cmd.Parameters.AddWithValue("Address", ncc.Address);
                cmd.Parameters.AddWithValue("Id_supplier", ncc.Id_Supplier);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool DeleteNhaCungCap(int id_Supplier)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_SupplierDelete";
                cmd.Parameters.AddWithValue("Id_supplier", id_Supplier);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public DataTable SearchNhaCungCap(string name)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_SupplierSearch";
                cmd.Parameters.AddWithValue("Name", name);
                DataTable dtNhaCungCap = new DataTable();

                dtNhaCungCap.Load(cmd.ExecuteReader());
                return dtNhaCungCap;
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
