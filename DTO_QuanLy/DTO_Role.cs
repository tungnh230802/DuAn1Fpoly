using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_Role
    {
        private int Id_role;
        private string Name;
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
        public DTO_Role(int id_role, string name)
        {
            this.Id_role = id_role;
            this.Name = name;
        }
        public DTO_Role() { }
    }
}
