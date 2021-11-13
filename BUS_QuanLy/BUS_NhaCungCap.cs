using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLy;
using DTO_QuanLy;

namespace BUS_QuanLy
{
    public class BUS_NhaCungCap
    {
        DAL_NhaCungCap quanlyNhaCungCap = new DAL_NhaCungCap();
        public DataTable getSupplier()
        {
            return quanlyNhaCungCap.getSupplier();
        }
        public bool InsertNhaCungCap(DTO_NhaCungCap ncc)
        {
            return quanlyNhaCungCap.InsertNhaCungCap(ncc);
        }
        public bool UpdateNhaCungCap(DTO_NhaCungCap ncc)
        {
            return quanlyNhaCungCap.UpdateNhaCungCap(ncc);
        }
        public bool DeleteNhaCungCap(int id_Supplier)
        {
            return quanlyNhaCungCap.DeleteNhaCungCap(id_Supplier);
        }
        public DataTable SearchNhaCungCap(string name)
        {
            return quanlyNhaCungCap.SearchNhaCungCap(name);
        }
    }
}
