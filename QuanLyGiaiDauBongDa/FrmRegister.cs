using QuanLyGiaiDauBongDa.DBContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGiaiDauBongDa
{
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (ValidateInfomation())
            {
                if(new AccountDAO().CheckExistAccount(txtUsername.Text.Trim())==false)
                {
                    Account account = new Account()
                    {
                        userName = txtUsername.Text.Trim(),
                        fullName = txtFname.Text.Trim(),
                        email = txtEmail.Text.Trim(),
                        passWord = txtPassword.Text,
                        dob = DateTime.Parse(txtDOB.Text)
                    };
                    if(new AccountDAO().CreateAccount(account) > 0)
                    {
                        MessageBox.Show("Tạo tài khoản thành công");
                        FrmLogin frmLogin = new FrmLogin();
                        this.Hide();
                        frmLogin.ShowDialog();
                    }

                }
            }

            
            
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            this.Hide();
            frmLogin.ShowDialog();
        }
        private bool ValidateInfomation()
        {
            string mess = "";
            if(txtUsername.Text.Trim().Equals("") || txtPassword.Text.Trim().Equals("") || txtEmail.Text.Trim().Equals("") || txtConfirmPassword.Text.Trim().Equals("") || txtFname.Text.Trim().Equals("") || txtDOB.Text.Trim().Equals(""))
            {
                mess += "Bạn phải nhập đầy đủ thông tin";
            }
           else if (!Regex.IsMatch(txtUsername.Text.Trim(), "^[A-Za-z0-9]+$")){
                mess += "Tên đăng nhập không được chứa kí tự đặc biệt";
            }
           else if(!Regex.IsMatch(txtPassword.Text, "^[A-Za-z0-9]{6,32}$")){
                mess += "Mật khẩu phải có độ dài từ 6 đến 32 kí tự và không chứa kí tự đặc biệt";
            }
           else if (!txtPassword.Text.Equals(txtConfirmPassword.Text)){            
                mess += "Xác nhận mật khẩu không trùng với mật khẩu";
            }
            if (mess.Equals(""))
                return true;
            else
            {
                MessageBox.Show(mess, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
