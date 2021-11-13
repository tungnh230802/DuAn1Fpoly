using DAL_QuanLy;
using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_tables
    {
        DAL_tables tables = new DAL_tables();
        public DataTable getData()
        {
            return tables.getData();
        }
        public bool InsertDataTable(DTO_tables Tables)
        {
            return tables.InsertDataTable(Tables);
        }
        public bool UpdateDataTable(DTO_tables Tables)
        {
            return tables.UpdateDataTable(Tables);
        }
        public bool DeleteDataTable(int id)
        {
            return tables.DeleteDataTable(id);
        }
        public DataTable SearchTable(string name)
        {
            return tables.SearchTable(name);
        }
    }
}
