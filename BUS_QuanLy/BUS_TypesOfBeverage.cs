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
    public class BUS_TypesOfBeverage
    {
        DAL_TypesOfBeverage loaiDoLuong = new DAL_TypesOfBeverage();
        public bool InsertDoUong(string name)
        {
            return loaiDoLuong.InsertLoaiDoUong(name);
        }
        public bool UpdateDoUong(DTO_TypesOfBeverage dTO_TypesOfBeverage)
        {
            return loaiDoLuong .UpdateLoaiDoUong(dTO_TypesOfBeverage);
        }
        public bool DeleteDoUong(int id)
        {
            return loaiDoLuong .DeleteDoUong(id);
        }
        public DataTable SearchLoaiDoUong(string name)
        {
            return loaiDoLuong .SearchLoaiDoUong(name);
        }
        public DataTable getBeverage()
        {
            return loaiDoLuong.getBeverage();
        }
    }
}
