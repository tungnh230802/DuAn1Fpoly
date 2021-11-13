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
    public partial class FrmShift2 : Form
    {
        public FrmShift2(FrmSchedule2 frm1)
        {
            InitializeComponent();
        }
        public delegate void UpdateDelegate(Object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;
        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }
        }
        protected void insert()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        BUS_CaLamViec shift = new BUS_CaLamViec();
        private void FrmShift2_Load(object sender, EventArgs e)
        {
            restValue();
            loadDate();
        }
        void loadDate()
        {
            guna2DataGridView1.DataSource = shift.getShifts();
            guna2DataGridView1.Columns[2].HeaderText = "Tên ca";
            guna2DataGridView1.Columns[0].HeaderText = "Thời gian bắt đầu";
            guna2DataGridView1.Columns[1].HeaderText = "Thời gian kết thúc";
        }
        // reset value
        void restValue()
        {
            txtTenCa.Text = null;
            txtThoiGianBatDau.Text = null;
            txtThoiGianKetThuc.Text = null;
            txtNhaptenCa.Text = null;

            txtTenCa.Enabled = false;
            txtThoiGianBatDau.Enabled = false;
            txtThoiGianKetThuc.Enabled = false;

            btLuu2.Enabled = false;
            btXoa2.Enabled = false;
            btSua2.Enabled = false;
        }
        //thêm
        private void btThem_Click(object sender, EventArgs e)
        {
            txtTenCa.Enabled = true;
            txtThoiGianBatDau.Enabled = true;
            txtThoiGianKetThuc.Enabled = true;

            btLuu2.Enabled = true;
            btXoa2.Enabled = true;
            btSua2.Enabled = true;
        }
        //lưu
        private void btLuu2_Click(object sender, EventArgs e)
        {
            if (txtTenCa.Text.Trim().Length == 0 || txtThoiGianBatDau.Text.Trim().Length == 0 || txtThoiGianKetThuc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DTO_CaLamViec shifts = new DTO_CaLamViec(int.Parse(txtTenCa.Text), txtThoiGianBatDau.Text, txtThoiGianKetThuc.Text);
                if (shift.InsertShifts(shifts))
                {
                    MessageBox.Show("Insert thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    restValue();
                    loadDate();
                }
                else
                {
                    MessageBox.Show("Insert không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    restValue();
                }
            }
            insert();
        }
        //xóa
        private void btXoa2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("\tBạn chắc chắn muốn xóa ca " + txtTenCa.Text + " \n\tThời gian bắt đầu: "+txtThoiGianBatDau.Text+"\n\tThời gian kết thúc: "+txtThoiGianKetThuc.Text, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (shift.DeleteShifts(int.Parse(txtTenCa.Text)))
                {
                    MessageBox.Show("Delete thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    restValue();
                    loadDate();
                }
                else
                {
                    MessageBox.Show("Delete không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    restValue();
                }
            }
            else
            {
            }
            insert();
        }
        // click datagridview
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Rows.Count > 0)
            {
                txtThoiGianBatDau.Enabled = true;
                txtThoiGianKetThuc.Enabled = true;
                txtTenCa.Enabled = false;
                btSua2.Enabled = true;
                btXoa2.Enabled = true;

                txtTenCa.Text = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtThoiGianBatDau.Text = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtThoiGianKetThuc.Text = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
        }
        //bt sửa
        private void btSua2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("\tBạn chắc chắn muốn sửa ca " + txtTenCa.Text + " \n\tThời gian bắt đầu: " + txtThoiGianBatDau.Text + "\n\tThời gian kết thúc: " + txtThoiGianKetThuc.Text, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txtThoiGianBatDau.Text.Trim().Length == 0 || txtThoiGianKetThuc.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập đầy đủ thông tin !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DTO_CaLamViec shifts = new DTO_CaLamViec(int.Parse(txtTenCa.Text), txtThoiGianBatDau.Text, txtThoiGianKetThuc.Text);
                    if (shift.UpdateShifts(shifts))
                    {
                        MessageBox.Show("Update thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        restValue();
                        loadDate();
                    }
                    else
                    {
                        MessageBox.Show("Update không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        restValue();
                    }
                }
            }
            else
            {
            }
            insert();
        }
        //tìm kiếm
        private void btTimKiem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtNhaptenCa.Text);
            DataTable shifts = shift.SearchShift(id);
            if (shifts.Rows.Count > 0)
            {
                guna2DataGridView1.DataSource = shifts;
                guna2DataGridView1.Columns[0].HeaderText = "Tên ca";
                guna2DataGridView1.Columns[1].HeaderText = "Thời gian bắt đầu";
                guna2DataGridView1.Columns[2].HeaderText = "Thời gian kết thúc";
            }
            else
            {
                MessageBox.Show("Không tìm thấy ca làm nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            restValue();
        }
    }
}
