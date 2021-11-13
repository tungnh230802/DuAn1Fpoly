using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_Vouchers
    {
        private string Id_Vouchers;
        private string DayBegin;
        private string DayEnd;
        private int Id_employee;
        private int Id_type;
        private int Status;
        private string mail;

        public string id_vouchers
        {
            get
            {
                return Id_Vouchers;
            }
            set
            {
                Id_Vouchers = value;
            }
        }
        public string daybegin
        {
            get
            {
                return DayBegin;
            }
            set
            {
                DayBegin = value;
            }
        }
        public string dayend
        {
            get
            {
                return DayEnd;
            }
            set
            {
                DayEnd = value;
            }
        }
        public int id_employee
        {
            get
            {
                return Id_employee;
            }
            set
            {
                Id_employee = value;
            }
        }
        public int id_type
        {
            get
            {
                return Id_type;
            }
            set
            {
                Id_type = value;
            }
        }
        public string Mail
        {
            get
            {
                return mail;
            }
            set
            {
                mail = value;
            }
        }
        public int status
        {
            get
            {
                return Status;
            }
            set
            {
                Status = value;
            }
        }
        public DTO_Vouchers(string id_Vouchers, string dayBegin, string dayEnd, string mail, int id_Type, int status)
        {
            this.Id_Vouchers = id_Vouchers;
            this.DayBegin = dayBegin;
            this.DayEnd = dayEnd;
            this.mail = mail;
            this.Id_type = id_Type;
            this.status = status;
        }
        public DTO_Vouchers(string id_Vouchers, string dayBegin, string dayEnd, string mail, int Status)
        {
            this.Id_Vouchers = id_Vouchers;
            this.DayBegin = dayBegin;
            this.DayEnd = dayEnd;
            this.mail = mail;
            this.Status = Status;
        }

        public DTO_Vouchers(string id_voucher)
        {
            this.Id_Vouchers = id_voucher;
        }
    }
}
