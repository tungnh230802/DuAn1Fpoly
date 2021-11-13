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
    public class BUS_LichLamViec
    {
        DAL_LichLamViec schedules = new DAL_LichLamViec();
        public DataTable getData()
        {
            return schedules.getDataSchedule();
        }
        public DataTable getDataName()
        {
            return schedules.getDataName();
        }
        public DataTable getDataId()
        {
            return schedules.getDataId();
        }
        public bool InsertSchedule(DTO_LichLamViec schedule)
        {
            return schedules.InsertSchedule(schedule);
        }
        public bool DeleteDataSchedule(int id_shift, int id_employee, int day)
        {
            return schedules.DeleteDataSchedule(id_shift, id_employee, day);
        }
        public bool UpdateSchedule(DTO_LichLamViec schedule)
        {
            return schedules.UpdateSchedule(schedule);
        }
        public DataTable searchSchedules(int id)
        {
            return schedules.searchSchedules(id);
        }
    }
}
