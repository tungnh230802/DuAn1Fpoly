using DAL_QuanLy;
using DTO_QuanLy;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BUS_QuanLy
{
    public class BUS_Role
    {
        DAL_Role dalRole = new DAL_Role();
        public bool InsertRoleNhanVien(DTO_Role ro)
        {
            return dalRole.InsertRoleNhanVien(ro);
        }
        public bool UpdateRoleNhanVien(DTO_Role ro)
        {
            return dalRole.UpdateRoleNhanVien(ro);
        }
        public bool DeleteRoleNhanVien(int id_role)
        {
            return dalRole.DeleteRoleNhanVien(id_role);
        }
        public DataTable SearchRoleNhanVien(int id_role)
        {
            return dalRole.SearchRoleNhanVien(id_role);
        }
    }
}
