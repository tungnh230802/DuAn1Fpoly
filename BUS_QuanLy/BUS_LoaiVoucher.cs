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
    public class BUS_LoaiVoucher
    {
        DAL_LoaiVoucher typevoucher = new DAL_LoaiVoucher();
        public DataTable getData()
        {
            return typevoucher.getData();
        }
        public bool InsertTypeVoucher(DTO_LoaiVoucher typeVoucher)
        {
            return typevoucher.InsertTypeVoucher(typeVoucher);
        }
        public bool DeleteDataTypeVoucher(int id)
        {
            return typevoucher.DeleteDataTypeVoucher(id);
        }
        public bool UpdateDataTypeVoucher(DTO_LoaiVoucher typeVoucher)
        {
            return typevoucher.UpdateDataTypeVoucher(typeVoucher);
        }
        public DataTable SearchDataTypeVoucher(float sale)
        {
            return typevoucher.SearchDataTypeVoucher(sale);
        }
    }
}
