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
    public class DAL_CaLamViec : DBConnect
    {
        // lấy dữ liệu của table shifts
        public DataTable getShifts()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetDataShifts";
                DataTable dtShifts = new DataTable();
                dtShifts.Load(cmd.ExecuteReader());
                return dtShifts;
            }
            finally
            {
                _conn.Close();
            }
        }
        // Thêm ca làm việc
        public bool InsertShifts(DTO_CaLamViec shifts)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertDataShifts";
                cmd.Parameters.AddWithValue("TimeBegin", shifts.TimeBegin);
                cmd.Parameters.AddWithValue("TimeEnd", shifts.TimeEnd);
                cmd.Parameters.AddWithValue("Id_shift", shifts.Id_Shifts);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        // Xóa ca làm việc
        public bool DeleteShifts(int id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteDataShifts";
                cmd.Parameters.AddWithValue("Id_shift", id);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        // Sửa ca làm việc
        public bool UpdateShifts(DTO_CaLamViec shifts)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateDataShifts";
                cmd.Parameters.AddWithValue("TimeBegin", shifts.TimeBegin);
                cmd.Parameters.AddWithValue("TimeEnd", shifts.TimeEnd);
                cmd.Parameters.AddWithValue("Id_shift", shifts.Id_Shifts);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        // tìm ca làm việc
        public DataTable SearchShift(int id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SearchDataShifts";
                cmd.Parameters.AddWithValue("Id_shift", id);
                DataTable dtShifts = new DataTable();
                dtShifts.Load(cmd.ExecuteReader());
                return dtShifts;
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
