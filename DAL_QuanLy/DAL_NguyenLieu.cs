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
    public class DAL_NguyenLieu : DBConnect
    {
        public DataTable getIngredient()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_GetIngredient";
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            finally
            {
                _conn.Close();
            }
        }
        public DataTable getIngredientType()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select Id_type, Name from TypesOfIngredient";
                cmd.Connection = _conn;
                DataTable dtLNL = new DataTable();
                dtLNL.Load(cmd.ExecuteReader());
                return dtLNL;
            }
            finally
            {
                _conn.Close();
            }
        }
        public DataTable getSupplier()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select Id_supplier, Name from Suppliers";
                cmd.Connection = _conn;
                DataTable dtNCC = new DataTable();
                dtNCC.Load(cmd.ExecuteReader());
                return dtNCC;
            }
            finally
            {
                _conn.Close();
            }
        }
        public bool InsertNguyenLieu(DTO_NguyenLieu nl)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_IngredientInsert";
                cmd.Parameters.AddWithValue("Name", nl.Name);
                cmd.Parameters.AddWithValue("Id_supplier", nl.Id_Supplier);
                cmd.Parameters.AddWithValue("Id_type", nl.Id_Type);
                cmd.Parameters.AddWithValue("Price", nl.Price);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool UpdateNguyenLieu(DTO_NguyenLieu nl)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_IngredientUpdate";
                cmd.Parameters.AddWithValue("Name", nl.Name);
                cmd.Parameters.AddWithValue("Id_supplier", nl.Id_Supplier);
                cmd.Parameters.AddWithValue("Id_type", nl.Id_Type);
                cmd.Parameters.AddWithValue("Price", nl.Price);
                cmd.Parameters.AddWithValue("Id_ingredient", nl.Id_Ingredient);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool DeleteNguyenLieu(int id_Ingredient)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_IngredientDelete";
                cmd.Parameters.AddWithValue("Id_ingredient", id_Ingredient);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public DataTable SearchNguyenLieu(string name)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_IngredientSearch";
                cmd.Parameters.AddWithValue("Name", name);
                DataTable dtNguyenLieu = new DataTable();

                dtNguyenLieu.Load(cmd.ExecuteReader());
                return dtNguyenLieu;
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
