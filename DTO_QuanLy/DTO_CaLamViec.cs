using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_CaLamViec
    {
        private string timeBegin;
        private string timeEnd;
        private int id_Shifts;
        public string TimeBegin
        {
            get
            {
                return timeBegin;
            }
            set
            {
               timeBegin = value;
            }
        }
        public string TimeEnd
        {
            get
            {
                return timeEnd;
            }
            set
            {
                timeEnd = value;
            }
        }
        public int Id_Shifts
        {
            get
            {
                return id_Shifts;
            }
            set
            {
                id_Shifts = value;
            }
        }
        public DTO_CaLamViec(int id_shifts, string timebegin, string timeend)
        {
            this.id_Shifts = id_shifts;
            this.timeBegin = timebegin;
            this.timeEnd = timeend;
        }

        public DTO_CaLamViec(int v)
        {
        }
    }
}
