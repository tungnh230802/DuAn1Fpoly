using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QuanLy;
using DTO_QuanLy;

namespace RJCodeAdvance
{
    public partial class FrmIngredientType : Form
    {
        public FrmIngredientType()
        {
            InitializeComponent();
        }
        
        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string tenHang = txtSearch.Text;
            DataTable ds = busLNL.SearchLoaiNguyenLieu(tenHang);
            if (ds.Rows.Count > 0)
            {
                dgv.DataSource = ds;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ResetValue();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            ResetValue();
            txtTenLoaiNL.Enabled = true;
            btLuu.Enabled = true;
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgv.CurrentRow.Cells["Id_Type"].Value.ToString());
            if (MessageBox.Show("Bạn có chắc muốn xoá dữ liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (busLNL.DeleteLoaiNguyenLieu(id))
                {
                    ResetValue();
                    loaddgv();
                }
                else
                {
                    MessageBox.Show("Xoá không thành công");
                }
            }
            else
            {
                ResetValue();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkTextBox())
                {
                    DTO_LoaiNguyenLieu dtoTI = new DTO_LoaiNguyenLieu(txtTenLoaiNL.Text,
                        Convert.ToInt32(dgv.CurrentRow.Cells["Id_Type"].Value.ToString()));
                    if (busLNL.UpdateLoaiNguyenLieu(dtoTI))
                    {
                        MessageBox.Show("Thành công");
                        loaddgv();
                        ResetValue();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkTextBox())
                {
                    DTO_LoaiNguyenLieu dtoIT = new DTO_LoaiNguyenLieu(txtTenLoaiNL.Text);
                    if (busLNL.InsertLoaiNguyenLieu(dtoIT))
                    {
                        MessageBox.Show("Thành công");
                        loaddgv();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn thoát chương trình?",
                  "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void FrmIngredientType_Load(object sender, EventArgs e)
        {
            ResetValue();
            loaddgv();
        }
        void ResetValue()
        {
            txtTenLoaiNL.Enabled = false;
            txtTenLoaiNL.Text = "";
            txtSearch.Text = "";
            btXoa.Enabled = false; ;
            btSua.Enabled = false;
            btLuu.Enabled = false;
        }
        bool checkTextBox()
        {
            if (string.IsNullOrEmpty(txtTenLoaiNL.Text))
            {
                MessageBox.Show("Chưa nhập đủ thông tin");
                txtTenLoaiNL.Text = "";
                txtTenLoaiNL.Focus();
                return false;
            }
            return true;
        }
        BUS_LoaiNguyenLieu busLNL = new BUS_LoaiNguyenLieu();
        void loaddgv()
        {
            dgv.DataSource = busLNL.getTypeOfIngredient();
            dgv.Columns[0].HeaderText = "Id_Type";
            dgv.Columns[1].HeaderText = "Name";
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 1)
                {
                    btLuu.Enabled = false;
                    btXoa.Enabled = true;
                    btSua.Enabled = true;
                    txtTenLoaiNL.Enabled = true;
                    txtTenLoaiNL.Text = dgv.CurrentRow.Cells["Name"].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Bảng không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {

            }
        }
    }
}
