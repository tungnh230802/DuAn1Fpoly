using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_Role : DBConnect
    {
        public bool InsertRoleNhanVien(DTO_Role ro)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "INSERT_DATA_TO_ROLE";
                cmd.Parameters.AddWithValue("Id_role", ro.ID_Role);
                cmd.Parameters.AddWithValue("Name", ro.name);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool UpdateRoleNhanVien(DTO_Role ro)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UPDATE_DATA_TO_ROLE";
                cmd.Parameters.AddWithValue("Name", ro.name);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool DeleteRoleNhanVien(int id_role)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DELETE_DATA_FROM_ROLE";
                cmd.Parameters.AddWithValue("Id_role", id_role);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public DataTable SearchRoleNhanVien(int id_role)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SEARCH_ROLE";
                cmd.Parameters.AddWithValue("Employee_role", id_role);
                cmd.Connection = _conn;
                DataTable dtEmployee = new DataTable();
                dtEmployee.Load(cmd.ExecuteReader());
                return dtEmployee;
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
