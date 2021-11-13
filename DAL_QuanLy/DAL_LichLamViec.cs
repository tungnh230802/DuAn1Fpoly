using System;
using DTO_QuanLy;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_LichLamViec : DBConnect
    {
        // danh sách lịch làm việc
        public DataTable getDataSchedule()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getDataSchedule";
                DataTable schedules = new DataTable();
                schedules.Load(cmd.ExecuteReader());
                return schedules;
            }
            finally
            {
                _conn.Close();
            }
        }
        // danh sách tên nhân viên
        public DataTable getDataName()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "loadName";
                DataTable schedules = new DataTable();
                schedules.Load(cmd.ExecuteReader());
                return schedules;
            }
            finally
            {
                _conn.Close();
            }
        }
        // danh sách Id shift
        public DataTable getDataId()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "loadIdShift";
                DataTable schedules = new DataTable();
                schedules.Load(cmd.ExecuteReader());
                return schedules;
            }
            finally
            {
                _conn.Close();
            }
        }
        // thêm lịch làm việc
        public bool InsertSchedule(DTO_LichLamViec schedules)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertDataSchedule";
                cmd.Parameters.AddWithValue("Id_employee", schedules.Id_employee);
                cmd.Parameters.AddWithValue("Id_shift", schedules.Id_Shifts);
                cmd.Parameters.AddWithValue("day", schedules.days);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        // xóa lịch làm việc
        public bool DeleteDataSchedule(int id_shift, int id_employee, int day)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteDataSchedule";
                cmd.Parameters.AddWithValue("Id_shift", id_shift);
                cmd.Parameters.AddWithValue("Id_employee", id_employee);
                cmd.Parameters.AddWithValue("day", day);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        // update lịch làm việc
        public bool UpdateSchedule(DTO_LichLamViec schedule)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateDataSchedule";
                cmd.Parameters.AddWithValue("Id_employee", schedule.Id_employee);
                cmd.Parameters.AddWithValue("Id_shift", schedule.Id_Shifts);
                cmd.Parameters.AddWithValue("day", schedule.days);
                cmd.Parameters.AddWithValue("Id_schedule", schedule.Id_Schedule);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        // search lịch làm việc
        public DataTable searchSchedules(int id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "searchSchedules";
                cmd.Parameters.AddWithValue("Id_employee", id);
                DataTable dtSchedule = new DataTable();
                dtSchedule.Load(cmd.ExecuteReader());
                return dtSchedule;
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
