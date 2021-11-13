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
    public class DAL_LoaiVoucher : DBConnect
    {
        // load data
        public DataTable getData()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getDataTypeVouchers";
                DataTable dtType = new DataTable();
                dtType.Load(cmd.ExecuteReader());
                return dtType;
            }
            finally
            {
                _conn.Close();
            }
        }
        // insert data
        public bool InsertTypeVoucher(DTO_LoaiVoucher typeVoucher)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertDataTypeVoucher";
                cmd.Parameters.AddWithValue("Sale", typeVoucher.Sale);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        // delete dât 
        public bool DeleteDataTypeVoucher(int id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteDataTypeVoucher";
                cmd.Parameters.AddWithValue("Id", id);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        // update date
        public bool UpdateDataTypeVoucher(DTO_LoaiVoucher typeVoucher)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateDatatypeVoucher";
                cmd.Parameters.AddWithValue("Id", typeVoucher.id);
                cmd.Parameters.AddWithValue("Sale", typeVoucher.Sale);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public DataTable SearchDataTypeVoucher(float sale)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SearchDataTypeVoucher";
                cmd.Parameters.AddWithValue("Sale", sale);
                DataTable dtTypeVoucher = new DataTable();
                dtTypeVoucher.Load(cmd.ExecuteReader());
                return dtTypeVoucher;
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
