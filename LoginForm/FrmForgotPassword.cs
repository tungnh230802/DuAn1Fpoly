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
    public partial class FrmForgotPassword : Form
    {
        BUS_NhanVien busNV = new BUS_QuanLy.BUS_NhanVien();
        public FrmForgotPassword()
        {
            InitializeComponent();
        }

        // Gửi mật khẩu mới vê Email
        private void btGuiMatKhau_Click(object sender, EventArgs e)
        {
            //if (txtEmail.Text != "")
            //{
            //    if (busNV.NhanVienQuenMatKhau(txtEmail.Text))
            //    {
            //        StringBuilder builder = new StringBuilder();
            //        builder.Append(RandomString(4, true));
            //        builder.Append(RandomNumber(1000, 9999));
            //        builder.Append(RandomString(2, false));
            //        string matkhaumoi = busNV.encryption(builder.ToString());
            //        busNV.TaoMatKhauMoi(txtEmail.Text, matkhaumoi);
            //        SendMail(txtEmail.Text, builder.ToString());
            //    }
            //    else
            //    {
            //        MessageBox.Show("Email không tồn tại, vui lòng nhập lại email! ");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Bạn cần nhập lại email nhận thông tin phục hồi mật khẩu!");
            //    txtEmail.Focus();
            //} 
        }

        //Tạo chuỗi ngẫu nhiên
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        //Tạo số ngẫu nhiên
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        //Gửi Email
        public void SendMail(string email, string matkhau)
        {
            try
            {
                //Now we must create a Smtp client to send our mail
                SmtpClient client = new SmtpClient("stmp.gmail.com", 25);  //smtp.gmail.com // For gmail
                //Authentication
                //This is where the valid email account comes into play. You must have a valid email
                //Account(with password) to give our program a place to send the mail from.
                NetworkCredential cred = new NetworkCredential("sender@gmail.com", "chonduoi");
                MailMessage Msg = new MailMessage();
                Msg.From = new MailAddress("sender@gmail.com");//Nothing but above Credentials or your credentials(****@gmail.com)
                //Recipient e-mail address.
                Msg.To.Add(email);
                //Assign the subject of our message
                Msg.Subject = "Bạn đã sử dụng tính năng quên Mật khẩu";
                //Create the content(body) of our message
                Msg.Body = "Chào anh/chị. Mật khẩu mới truy cập vào phần mềm là " + matkhau;
                //Send our account login details to the client.
                client.Credentials = cred;
                //Enabling SSL(Secure Sockets Layer, encryption) is reqiured by most email providers to send mail
                client.EnableSsl = true;
                client.Send(Msg); // Send our email
                //Confirmation After click the Button
                MessageBox.Show("Một email phục hồi mật khẩu đã gửi tới bạn!");
            }
            catch (Exception ex)
            {
                //If mail doesn't send error message will be displayed
                MessageBox.Show(ex.Message);
            }
        }      
    }
}
