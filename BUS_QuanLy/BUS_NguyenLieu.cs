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
    public class BUS_NguyenLieu
    {
        DAL_NguyenLieu quanlyNguyenLieu = new DAL_NguyenLieu();
        public DataTable getIngredient()
        {
            return quanlyNguyenLieu.getIngredient();
        }
        public DataTable getIngredientType()
        {
            return quanlyNguyenLieu.getIngredientType();
        }
        public DataTable getSupplier()
        {
            return quanlyNguyenLieu.getSupplier();
        }
        public bool InsertNguyenLieu(DTO_NguyenLieu nl)
        {
            return quanlyNguyenLieu.InsertNguyenLieu(nl);
        }
        public bool UpdateNguyenLieu(DTO_NguyenLieu nl)
        {
            return quanlyNguyenLieu.UpdateNguyenLieu(nl);
        }
        public bool DeleteNguyenLieu(int id_Ingredient)
        {
            return quanlyNguyenLieu.DeleteNguyenLieu(id_Ingredient);
        }
        public DataTable SearchNguyenLieu(string name)
        {
            return quanlyNguyenLieu.SearchNguyenLieu(name);
        }
    }
}
