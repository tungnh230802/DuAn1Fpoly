using DAL_QuanLy;
using DTO_QuanLy;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BUS_QuanLy
{
    public class BUS_NhanVien
    {
        DAL_NhanVien dalNhanVien = new DAL_NhanVien();
        public bool NhanVienDangNhap(DTO_NhanVien nv)
        {
            return dalNhanVien.NhanVienDangNhap(nv);
        }
        public bool NhanVienQuenMatKhau(string email)
        {
            return dalNhanVien.NhanVienQuenMatKhau(email);
        }
        public bool TaoMatKhauMoi(string email, string np)
        {
            return dalNhanVien.TaoMatKhauMoi(email, np);
        }
        public bool NhanVienDoiMatKhau(string email, string oldPassWord, string newPassWord)
        {
            return dalNhanVien.NhanVienDoiMatKhau(email,oldPassWord, newPassWord);
        }     
        public bool InsertNhanVien(DTO_NhanVien nv)
        {
            return dalNhanVien.InsertNhanVien(nv);
        }
        public bool UpdateNhanVien(DTO_NhanVien nv)
        {
            return dalNhanVien.UpdateNhanVien(nv);
        }
        public bool DeleteNhanVien(string email)
        {
            return dalNhanVien.DeleteNhanVien(email);
        }
        public DataTable SearchNhanVien(string name)
        {
            return dalNhanVien.SearchNhanVien(name);
        }
        
        //Mã hóa MD5
        public string encryption(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            //Encrypt the given password string into encrypted data
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            //Create a new string by using encrypted data
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }
    }
}
