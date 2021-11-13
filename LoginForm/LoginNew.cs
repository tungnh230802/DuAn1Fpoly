using RJCodeAdvance.ControlVouchers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RJCodeAdvance
{
    public partial class LoginNew : Form
    {
        public LoginNew()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string mail = guna2TextBox1.Text;
            UC_Voucher.mail = mail;
            FrmSchedule2.mail = mail;
            FrmBeverageCP frm = new FrmBeverageCP();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}
