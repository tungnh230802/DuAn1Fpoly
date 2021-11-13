using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_NhaCungCap
    {
        private string name;
        private int id_Supplier;
        private string email;
        private string address;
        public DTO_NhaCungCap()
        {

        }
        public DTO_NhaCungCap(string name)
        {
            this.name = name;
        }
        public DTO_NhaCungCap(string name, string email, string address)
        {
            this.name = name;
            this.email = email;
            this.address = address;
        }
        public DTO_NhaCungCap(string name, string email, string address, int id_Supplier)
        {
            this.name = name;
            this.email = email;
            this.address = address;
            this.id_Supplier = id_Supplier;
        }
        public int Id_Supplier { get => id_Supplier; set => id_Supplier = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }
    }
}
