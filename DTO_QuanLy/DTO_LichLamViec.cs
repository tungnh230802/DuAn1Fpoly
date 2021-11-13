using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_LichLamViec
    {
        private int id_schedule;
        private int id_employee;
        private int id_shift;
        private int day;
        public int Id_Schedule
        {
            get
            {
                return id_schedule;
            }
            set
            {
                id_schedule = value;
            }
        }
        public int Id_Shifts
        {
            get
            {
                return id_shift;
            }
            set
            {
                id_shift = value;
            }
        }
        public int Id_employee
        {
            get
            {
                return id_employee;
            }
            set
            {
                id_employee = value;
            }
        }
        public int days
        {
            get
            {
                return day;
            }
            set
            {
                day = value;
            }
        }
        public DTO_LichLamViec(int ID_employee, int ID_shift, int Day)
        {
            this.id_employee = ID_employee;
            this.id_shift = ID_shift;
            this.day = Day;
        }
        public DTO_LichLamViec(int id ,int ID_employee, int ID_shift, int Day)
        {
            this.id_schedule = id;
            this.id_employee = ID_employee;
            this.id_shift = ID_shift;
            this.day = Day;
        }
    }
}
