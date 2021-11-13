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
    public class DAL_Vouchers : DBConnect
    {
        public DataTable getSale()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getSaleForVoucher";
                DataTable dtSale = new DataTable();
                dtSale.Load(cmd.ExecuteReader());
                return dtSale;
            }
            finally
            {
                _conn.Close();
            }
        }
        public DataTable getConfigurationSale(int id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getConfigurationSale";
                cmd.Parameters.AddWithValue("id", id);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            finally
            {
                _conn.Close();
            }
        }
        public DataTable getEmailSendVoucher(int reward)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getEmailSendVoucher";
                cmd.Parameters.AddWithValue("reward", reward);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            finally
            {
                _conn.Close();
            }
        }
        public DataTable getVoucherSendMail(int voucher)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getVoucherSendMail";
                cmd.Parameters.AddWithValue("id_type", voucher);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            finally
            {
                _conn.Close();
            }
        }
        
        public bool UpdateVoucherForSend(DTO_Vouchers vouchers)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateVoucherForSend";
                cmd.Parameters.AddWithValue("Id_voucher", vouchers.id_vouchers);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public DataTable getData()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getDataVoucher";
                DataTable dtVoucher = new DataTable();
                dtVoucher.Load(cmd.ExecuteReader());
                return dtVoucher;
            }
            finally
            {
                _conn.Close();
            }
        }
        public bool InsertDatevoucher(DTO_Vouchers vouchers)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insertDataVoucher";
                cmd.Parameters.AddWithValue("Id_voucher", vouchers.id_vouchers);
                cmd.Parameters.AddWithValue("DayBegin", vouchers.daybegin);
                cmd.Parameters.AddWithValue("DayEnd", vouchers.dayend);
                cmd.Parameters.AddWithValue("mail", vouchers.Mail);
                cmd.Parameters.AddWithValue("Id_type", vouchers.id_type);
                cmd.Parameters.AddWithValue("Status", vouchers.status);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public DataTable searchDataVoucher(int id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SearchDataVoucher";
                cmd.Parameters.AddWithValue("Id_type", id);
                DataTable dtVoucher = new DataTable();
                dtVoucher.Load(cmd.ExecuteReader());
                return dtVoucher;
            }
            finally
            {
                _conn.Close();
            }
        }
        public DataTable getCountSaleVoucher(int id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getCountSaleVoucher";
                cmd.Parameters.AddWithValue("Id_type", id);
                DataTable dtVoucher = new DataTable();
                dtVoucher.Load(cmd.ExecuteReader());
                return dtVoucher;
            }
            finally
            {
                _conn.Close();
            }
        }
        public bool deleteVoucher(int id, string dayend, string daystart)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteDataVoucher";
                cmd.Parameters.AddWithValue("Id_type", id);
                cmd.Parameters.AddWithValue("DayBegin", dayend);
                cmd.Parameters.AddWithValue("DayEnd", daystart);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
    }
}
