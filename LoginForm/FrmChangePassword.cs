using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_QuanLy;
using BUS_QuanLy;
using System.Net.Mail;
using System.Net;

namespace RJCodeAdvance
{
    public partial class FrmChangePassword : Form
    {
        BUS_NhanVien busNV = new BUS_QuanLy.BUS_NhanVien();

        public FrmChangePassword()
        {
            InitializeComponent();
        }

        //Btn Đổi mật khẩu
        //private void btDoiMatKhau_Click(object sender, EventArgs e)
        //{
        //    if (txtMatKhauCu.Text.Trim().Length == 0) // kiểm tra phải nhập data
        //    {
        //        MessageBox.Show("Bạn phải nhập mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        txtMatKhauCu.Focus();
        //        return;
        //    }
        //    if (txtMatKhauMoi.Text.Trim().Length == 0)
        //    {
        //        MessageBox.Show("Bạn phải nhập mật khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        txtMatKhauMoi.Focus();
        //        return;
        //    }
        //    if (txtNhapLaiMatKhau.Text.Trim().Length == 0)
        //    {
        //        MessageBox.Show("Bạn phải nhập lại mật khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        txtNhapLaiMatKhau.Focus();
        //        return;
        //    }
        //    else
        //    {
        //        if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật mật khẩu", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //        {
        //            Nếu đúng thì sẽ thực hiện
        //            string matKhauMoi = busNV.encryption(txtMatKhauMoi.Text);
        //            string matKhauCu = busNV.encryption(txtMatKhauCu.Text);
        //            if (busNV.NhanVienDoiMatKhau(txtEmail.Text, matKhauCu, matKhauMoi))
        //            {
        //                SendMail(txtEmail.Text, txtNhapLaiMatKhau.Text);
        //                MessageBox.Show("Cập nhật mật khẩu thành công, bạn phải đăng nhập lại");
        //                this.Close();
        //            }
        //            else
        //            {
        //                MessageBox.Show("Mật khẩu cũ không đúng, cập nhật mật khẩu không thành công");
        //                txtMatKhauCu.Text = null;
        //                txtMatKhauMoi.Text = null;
        //                txtNhapLaiMatKhau.Text = null;
        //            }
        //        }
        //        else
        //        {
        //            Nếu sai thì sẽ thực hiện
        //            txtMatKhauCu.Text = null;
        //            txtMatKhauMoi.Text = null;
        //            txtNhapLaiMatKhau.Text = null;
        //        }
        //    }
        //}

        //Btn thoát
        //private void btThoat_Click(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //}

        ////Gửi Email
        //public void SendMail(string email, string matkhau)
        //{
        //    try
        //    {
        //        //Now we must create a Smtp client to send our mail
        //        SmtpClient client = new SmtpClient("stmp.gmail.com", 25);  //smtp.gmail.com // For gmail
        //        //Authentication
        //        //This is where the valid email account comes into play. You must have a valid email
        //        //Account(with password) to give our program a place to send the mail from.
        //        NetworkCredential cred = new NetworkCredential("sender@gmail.com", "chonduoi");
        //        MailMessage Msg = new MailMessage();
        //        Msg.From = new MailAddress("sender@gmail.com");//Nothing but above Credentials or your credentials(****@gmail.com)
        //        //Recipient e-mail address.
        //        Msg.To.Add(email);
        //        //Assign the subject of our message
        //        Msg.Subject = "Bạn đã sử dụng tính năng quên Mật khẩu";
        //        //Create the content(body) of our message
        //        Msg.Body = "Chào anh/chị. Mật khẩu mới truy cập vào phần mềm là " + matkhau;
        //        //Send our account login details to the client.
        //        client.Credentials = cred;
        //        //Enabling SSL(Secure Sockets Layer, encryption) is reqiured by most email providers to send mail
        //        client.EnableSsl = true;
        //        client.Send(Msg); // Send our email
        //        //Confirmation After click the Button
        //        MessageBox.Show("Một email phục hồi mật khẩu đã gửi tới bạn!");
        //    }
        //    catch (Exception ex)
        //    {
        //        //If mail doesn't send error message will be displayed
        //        MessageBox.Show(ex.Message);
        //    }
        //} 
    }
}
