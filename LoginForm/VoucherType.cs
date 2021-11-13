using BUS_QuanLy;
using DTO_QuanLy;
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
    public partial class VoucherType : Form
    {
        public VoucherType(UC_Voucher frm1)
        {
            InitializeComponent();
        }
        BUS_LoaiVoucher typeVouchers = new BUS_LoaiVoucher();
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
        // bt lưu
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (txtSale.Text == "")
            {
                MessageBox.Show("Vui lòng nhập khuyến mãi");
            }
            else
            {
                DTO_LoaiVoucher typevouchers = new DTO_LoaiVoucher(float.Parse(txtSale.Text));
                if (typeVouchers.InsertTypeVoucher(typevouchers))
                {
                    MessageBox.Show("Insert thành công");
                    LoadData();
                    resetValue();
                }
                else
                {
                    MessageBox.Show("Đã có khuyến mãi: " + txtSale.Text + "%");
                    resetValue();
                }
            }
            insert();
        }
        public string id;
        // click datagribview
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Rows.Count > 1)
            {
                id = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtSale.Text = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();

                guna2Button3.Enabled = true;
                guna2Button4.Enabled = true;
                guna2Button5.Enabled = false;
            }
        }

        private void VoucherType_Load(object sender, EventArgs e)
        {
            resetValue();
            LoadData();
        }
        void LoadData()
        {
            guna2DataGridView1.DataSource = typeVouchers.getData();
            guna2DataGridView1.Columns[0].HeaderText = "ID";
            guna2DataGridView1.Columns[1].HeaderText = "Khuyến mãi";
        }
        // reset form
        void resetValue()
        {
            guna2Button3.Enabled = false;
            guna2Button4.Enabled = false;
            guna2Button5.Enabled = false;

            txtSale.Text = null;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            guna2Button3.Enabled = false;
            guna2Button4.Enabled = false;
            guna2Button5.Enabled = true;
            txtSale.Text = null;
        }
        //xóa
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn Xóa loại voucher này", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (typeVouchers.DeleteDataTypeVoucher(int.Parse(id)))
                {
                    MessageBox.Show("Xóa thành công");
                    resetValue();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }
            }
            else
            {
                resetValue();
            }
            insert();
        }
        //sửa
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            DTO_LoaiVoucher typeVoucher = new DTO_LoaiVoucher(int.Parse(id), float.Parse(txtSale.Text));
            if (MessageBox.Show("Bạn chắc chắn muốn sửa lịch này", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (typeVouchers.UpdateDataTypeVoucher(typeVoucher))
                {
                    MessageBox.Show("Sửa thành công");
                    resetValue();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Đã có loại voucher: " + txtSale.Text + "%");
                }
            }
            else
            {
                resetValue();
            }
            insert();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dttypeVoucher = typeVouchers.SearchDataTypeVoucher(float.Parse(txtSearch.Text));
            if (dttypeVoucher.Rows.Count > 0)
            {
                guna2DataGridView1.DataSource = dttypeVoucher;
                guna2DataGridView1.Columns[0].HeaderText = "ID";
                guna2DataGridView1.Columns[1].HeaderText = "Khuyến mãi";
            }
            else
            {
                MessageBox.Show("Không tìm thấy voucher: " + txtSearch.Text + "%");
            }
        }
    }
}
