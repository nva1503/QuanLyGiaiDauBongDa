

using QuanLyGiaiDauBongDa.Models;
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
        QuanLyGiaiDauBongDaContext _db = new QuanLyGiaiDauBongDaContext();
        public FrmRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (ValidateInfomation())
            {
                bool isExist = CheckExistAccount(txtUsername.Text.Trim());
                if (isExist)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        Account account = new Account()
                        {
                            Username = txtUsername.Text.Trim(),
                            FullName = txtFname.Text.Trim(),
                            Email = txtEmail.Text.Trim(),
                            Password = txtPassword.Text,
                            Dob = DateTime.Parse(txtDOB.Text)
                        };
                        RoleAccount roll_acc = new RoleAccount()
                        {
                            Username = txtUsername.Text.Trim(),
                            RoleId = 2,
                        };
                        _db.Accounts.Add(account);
                        _db.RoleAccounts.Add(roll_acc);
                        int count = _db.SaveChanges();

                        if (count > 0)
                        {
                            MessageBox.Show("Tạo tài khoản thành công");
                            FrmLogin frmLogin = new FrmLogin();
                            this.Hide();
                            frmLogin.ShowDialog();
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Error");
                    }

                }
            }



        }

        private bool CheckExistAccount(string v)
        {
            bool isExist = false;
            var account = (from a in _db.Accounts select new { a.Username }).ToList();
            foreach (var acc in account)
            {
                if (txtUsername.Text.Trim().Equals(acc.Username))
                {
                    isExist = true;
                }
            }
            return isExist;
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
            if (txtUsername.Text.Trim().Equals("") || txtPassword.Text.Trim().Equals("") || txtEmail.Text.Trim().Equals("") || txtConfirmPassword.Text.Trim().Equals("") || txtFname.Text.Trim().Equals("") || txtDOB.Text.Trim().Equals(""))
            {
                mess += "Bạn phải nhập đầy đủ thông tin";
            }
            else if (!Regex.IsMatch(txtUsername.Text.Trim(), "^[A-Za-z0-9]+$"))
            {
                mess += "Tên đăng nhập không được chứa kí tự đặc biệt";
            }
            else if (!Regex.IsMatch(txtPassword.Text, "^[A-Za-z0-9]{6,32}$"))
            {
                mess += "Mật khẩu phải có độ dài từ 6 đến 32 kí tự và không chứa kí tự đặc biệt";
            }
            else if (!txtPassword.Text.Equals(txtConfirmPassword.Text))
            {
                mess += "Xác nhận mật khẩu không trùng với mật khẩu";
            }
            else if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                mess += "Email không hợp lệ ";
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
