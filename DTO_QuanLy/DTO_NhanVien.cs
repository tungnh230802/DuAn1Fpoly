using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_NhanVien
    {
        private int Id_role;
        private int Gender;
        private string Email;
        private string Address;
        private string Password;
        private string DayOfBirth;
        private int Id_employee;
        private string Name;
        private float Salary;
        public int ID_Role
        {
            get
            {
                return Id_role;
            }
            set
            {
                Id_role = value;
            }
        }
        public int GenDer
        {
            get
            {
                return Gender;
            }
            set
            {
                Gender = value;
            }
        }
        public string email
        {
            get
            {
                return Email;
            }
            set
            {
                Email = value;
            }
        }
        public string address
        {
            get
            {
                return Address;
            }
            set
            {
                Address = value;
            }
        }
        public string password
        {
            get
            {
                return Password;
            }
            set
            {
                Password = value;
            }
        }
        public string dayOfBirth
        {
            get
            {
                return DayOfBirth;
            }
            set
            {
                DayOfBirth = value;
            }
        }
        public int id_employee
        {
            get
            {
                return Id_employee;
            }
            set
            {
                Id_employee = value;
            }
        }
        public string name
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }
        public float salary
        {
            get
            {
                return Salary;
            }
            set
            {
                Salary = value;
            }
        }
        public DTO_NhanVien(string email, int id_role, int gender, string address, string password, string dayofbrith, int id_employee, string name, float salary)
        {
            this.Email = email;
            this.Id_role = id_role;
            this.Gender = gender;
            this.Address = address;
            this.Password = password;
            this.DayOfBirth = dayofbrith;
            this.Id_employee = id_employee;
            this.Name = name;
            this.Salary = salary;
        }
        
        public DTO_NhanVien()
        {
        }
    }
}
