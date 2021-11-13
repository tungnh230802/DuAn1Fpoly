using BUS_QuanLy;
using DTO_QuanLy;
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
    public partial class FrmTable : Form
    {
        public FrmTable()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
        BUS_tables tables = new BUS_tables();
        private void FrmTable_Load(object sender, EventArgs e)
        {
            resetValue();
            loadData();
            tinhTrang();
        }
        //reset value
        void resetValue()
        {
            txtName.Enabled = false;
            btLuu.Enabled = false;
            btXoa.Enabled = false;
            btSua.Enabled = false;
        }
        //load data
        void loadData()
        {
            guna2DataGridView1.DataSource = tables.getData();
            guna2DataGridView1.Columns[0].HeaderText = "Tên bàn";
            guna2DataGridView1.Columns[1].HeaderText = "Tình trạng";
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            txtName.Enabled = true;
            btLuu.Enabled = true;
            btXoa.Enabled = false;
            btSua.Enabled = false;
            txtName.Text = "";
        }
        // lưu
        private void btLuu_Click(object sender, EventArgs e)
        {
            string status = null;
            if (rdTrong.Checked)
            {
                status = "Trống";
            }
            else
            {
                status = "Có người";
            }
            if(txtName.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên bàn");
            }
            else
            {
                DTO_tables Tables = new DTO_tables(txtName.Text, status);
                if (tables.InsertDataTable(Tables))
                {
                    MessageBox.Show("Thêm bàn thành công");
                    resetValue();
                    loadData();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }
        //click datagridview
        public string id;
        public string Status;
        public string name;
        void tinhTrang()
        {
            if (rdTrong.Checked)
            {
                Status = "Trống";
            }
            if (rdCoNguoi.Checked)
            {
                Status = "Có người";
            }
        }
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(guna2DataGridView1.Rows.Count > 0)
            {
                string status = null;
                id = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtName.Text = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
                name = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
                status = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();
                if(status == "Trống")
                {
                    rdTrong.Checked = true;
                }
                if(status == "Có người")
                {
                    rdCoNguoi.Checked = true;
                }
                btSua.Enabled = true;
                btXoa.Enabled = true;
                txtName.Enabled = true;
            }
        }
        // sửa
        private void btSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn sửa bàn " + name, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DTO_tables Tables = new DTO_tables(txtName.Text, Status, int.Parse(id));
                if (tables.UpdateDataTable(Tables))
                {
                    MessageBox.Show("Update thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
                else
                {
                    MessageBox.Show("Tên bàn đã tồn tại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
            }
        }
        //xóa
        private void btXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn sửa bàn " + name, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (tables.DeleteDataTable(int.Parse(id)))
                {
                    MessageBox.Show("Delete thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
                else
                {
                    MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
            }
        }
        // tìm kiếm
        private void btTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dt = tables.SearchTable(txtSearch.Text);
            guna2DataGridView1.DataSource = dt;
            guna2DataGridView1.Columns[0].HeaderText = "Tên bàn";
            guna2DataGridView1.Columns[1].HeaderText = "Tình trạng";
        }
    }
}
