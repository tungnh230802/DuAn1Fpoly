using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RJCodeAdvance.ControlIngredient
{
    public partial class UC_Input_Ingredient : UserControl
    {
        public UC_Input_Ingredient()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Unit frm = new Unit();
            frm.ShowDialog();
        }
    }
}
