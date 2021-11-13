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
    public class BUS_Customer
    {
        DAL_Customer Customer = new DAL_Customer();
        public DataTable getData()
        {
            return Customer.getData();
        }
        public bool UpdateCustomer(DTO_Customer customer)
        {
            return Customer.UpdateCustomer(customer);
        }
        public DataTable SearchCustomer(string email)
        {
            return Customer.SearchCustomer(email);
        }
        public bool UpdateCustomerAfterSendVoucher(DTO_Customer voucher)
        {
            return Customer.UpdateCustomerAfterSendVoucher(voucher);
        }
    }
}
