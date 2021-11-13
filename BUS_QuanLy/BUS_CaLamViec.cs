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
    public class BUS_CaLamViec
    {
        DAL_CaLamViec shifts = new DAL_CaLamViec();
        public DataTable getShifts()
        {
            return shifts.getShifts();
        }
        public bool InsertShifts(DTO_CaLamViec Shifts)
        {
            return shifts.InsertShifts(Shifts);
        }
        public bool DeleteShifts(int Shifts)
        {
            return shifts.DeleteShifts(Shifts);
        }
        public bool UpdateShifts(DTO_CaLamViec Shifts)
        {
            return shifts.UpdateShifts(Shifts);
        }
        public DataTable SearchShift(int id)
        {
            return shifts.SearchShift(id);
        }
    }
}
