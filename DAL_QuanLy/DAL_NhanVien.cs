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
    public class DAL_NhanVien : DBConnect
    {
        public bool NhanVienDangNhap(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LOGIN";
                cmd.Parameters.AddWithValue("EMAIL", nv.email);
                cmd.Parameters.AddWithValue("PASSWORD", nv.password);
                if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                {
                    return true;
                }
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public bool NhanVienQuenMatKhau(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "FORGOT_PASSWORD";
                cmd.Parameters.AddWithValue("EMAIL", email);
                if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                {
                    return true;
                }
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public bool NhanVienDoiMatKhau(string email,string oldPassword,string newPassword)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CHANGE_PASSWORD";
                cmd.Parameters.AddWithValue("EMAIL", email);
                cmd.Parameters.AddWithValue("OLDPW", oldPassword);
                cmd.Parameters.AddWithValue("NEWPW", newPassword);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool TaoMatKhauMoi(string email, string np)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CREATE_NEW_PASS";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("matkhaumoi", np);
                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public bool InsertNhanVien(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "INSERT_DATA_TO_EMPLOYEE";
                cmd.Parameters.AddWithValue("Id_role", nv.ID_Role);
                cmd.Parameters.AddWithValue("Gender", nv.GenDer);
                cmd.Parameters.AddWithValue("Email", nv.email);
                cmd.Parameters.AddWithValue("Address", nv.address);
                cmd.Parameters.AddWithValue("Password", nv.password);
                cmd.Parameters.AddWithValue("DayOfBirth", nv.dayOfBirth);
                cmd.Parameters.AddWithValue("Name", nv.name);
                cmd.Parameters.AddWithValue("Salary", nv.salary);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public bool UpdateNhanVien(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UPDATE_DATA_TO_EMPLOYEE";
                cmd.Parameters.AddWithValue("Gender", nv.GenDer);
                cmd.Parameters.AddWithValue("Email", nv.email);
                cmd.Parameters.AddWithValue("Address", nv.address);
                cmd.Parameters.AddWithValue("DayOfBirth", nv.dayOfBirth);
                cmd.Parameters.AddWithValue("Name", nv.name);
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

        public bool DeleteNhanVien(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DELETE_DATA_FROM_EMPLOYEE";
                cmd.Parameters.AddWithValue("Email", email);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public DataTable SearchNhanVien(string name)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SEARCH_EMPLOYEE";
                cmd.Parameters.AddWithValue("Employee_Name", name);
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
