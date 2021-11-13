using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_tables
    {
        private string name;
        private string Status;
        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string status
        {
            get
            {
                return Status;
            }
            set
            {
                Status = value;
            }
        }
        public DTO_tables(string name, string status)
        {
            this.name = name;
            this.Status = status;
        }
        public DTO_tables(string name, string status, int id)
        {
            this.name = name;
            this.Status = status;
            this.id = id;
        }
    }
}
