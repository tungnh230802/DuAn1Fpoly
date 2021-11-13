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

namespace RJCodeAdvance.ControlIngredient
{
    public partial class UC_ingredient : UserControl
    {
        public UC_ingredient()
        {
            InitializeComponent();
        }
        BUS_NguyenLieu busIg = new BUS_NguyenLieu();
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FrmIngredientType frm = new FrmIngredientType();
            frm.ShowDialog(); 
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FrmSupplier frm = new FrmSupplier();
            frm.ShowDialog();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string tenHang = txtSearch.Text;
            DataTable ds = busIg.SearchNguyenLieu(tenHang);
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
            txtTenIngredient.Enabled = true;
            cbLoaiIngredient.Enabled = true;
            cbNhaCC.Enabled = true;
            txtGia.Enabled = true;
            btLuu.Enabled = true;
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgv.CurrentRow.Cells["Id_Ingredient"].Value.ToString());
            if (MessageBox.Show("Bạn có chắc muốn xoá dữ liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (busIg.DeleteNguyenLieu(id))
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
                    DTO_NguyenLieu dtoBe = new DTO_NguyenLieu(txtTenIngredient.Text,
                        Convert.ToInt32(cbNhaCC.SelectedValue), Convert.ToInt32(cbLoaiIngredient.SelectedValue),
                       float.Parse(txtGia.Text), Convert.ToInt32(dgv.CurrentRow.Cells["Id_Ingredient"].Value.ToString()));
                    if (busIg.UpdateNguyenLieu(dtoBe))
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
                    DTO_NguyenLieu dtoIg = new DTO_NguyenLieu(txtTenIngredient.Text,
                       Convert.ToInt32(cbNhaCC.SelectedValue), Convert.ToInt32(cbLoaiIngredient.SelectedValue),
                       float.Parse(txtGia.Text));
                    if (busIg.InsertNguyenLieu(dtoIg))
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

        private void UC_ingredient_Load(object sender, EventArgs e)
        {
            ResetValue();
            loadComBoBox();
            loaddgv();
        }
        void ResetValue()
        {
            txtTenIngredient.Enabled = false;
            txtTenIngredient.Text = "";
            cbLoaiIngredient.Enabled = false;
            cbLoaiIngredient.Text = "";
            txtGia.Enabled = false;
            txtGia.Text = "";
            cbNhaCC.Enabled = false;
            cbNhaCC.Text = "";
            txtSearch.Text = "";
            btXoa.Enabled = false; ;
            btSua.Enabled = false;
            btLuu.Enabled = false;
        }
        bool checkTextBox()
        {
            if (string.IsNullOrEmpty(txtTenIngredient.Text))
            {
                MessageBox.Show("Chưa nhập đủ thông tin");
                txtTenIngredient.Text = "";
                txtTenIngredient.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtGia.Text))
            {
                MessageBox.Show("Chưa nhập đủ thông tin");
                txtGia.Text = "";
                txtGia.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbLoaiIngredient.Text))
            {
                MessageBox.Show("Chưa nhập đủ thông tin");
                cbLoaiIngredient.Text = "";
                cbLoaiIngredient.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbNhaCC.Text))
            {
                MessageBox.Show("Chưa nhập đủ thông tin");
                cbNhaCC.Text = "";
                cbNhaCC.Focus();
                return false;
            }
            return true;
        }
        void loaddgv()
        {
            dgv.DataSource = busIg.getIngredient();
            dgv.Columns[0].HeaderText = "Id_Ingredient";
            dgv.Columns[1].HeaderText = "Name";
            dgv.Columns[2].HeaderText = "Id_Supplier";
            dgv.Columns[3].HeaderText = "Id_Type";
            dgv.Columns[4].HeaderText = "Price";
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        void loadComBoBox()
        {
            cbLoaiIngredient.Items.Clear();
            cbLoaiIngredient.DataSource = busIg.getIngredientType();
            cbLoaiIngredient.DisplayMember = "Name";
            cbLoaiIngredient.ValueMember = "Id_type";

            cbNhaCC.Items.Clear();
            cbNhaCC.DataSource = busIg.getSupplier();
            cbNhaCC.DisplayMember = "Name";
            cbNhaCC.ValueMember = "Id_supplier";
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
                    txtTenIngredient.Enabled = true;
                    cbLoaiIngredient.Enabled = true;
                    cbNhaCC.Enabled = true;
                    txtGia.Enabled = true;
                    txtTenIngredient.Text = dgv.CurrentRow.Cells["Name"].Value.ToString();
                    txtGia.Text = dgv.CurrentRow.Cells["Price"].Value.ToString();
                    cbLoaiIngredient.SelectedIndex = Convert.ToInt32(dgv.CurrentRow.Cells["Id_Type"].Value.ToString()) - 1;
                    cbNhaCC.SelectedIndex = Convert.ToInt32(dgv.CurrentRow.Cells["Id_Supplier"].Value.ToString()) - 1;
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
