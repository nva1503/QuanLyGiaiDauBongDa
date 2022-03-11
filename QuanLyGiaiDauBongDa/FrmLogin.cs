
using QuanLyGiaiDauBongDa.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGiaiDauBongDa
{
    public partial class FrmLogin : Form
    {
        QuanLyGiaiDauBongDaContext _db = new QuanLyGiaiDauBongDaContext();
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            
        }

       

        private void btnLogin_Click(object sender, EventArgs e)
        {
            

            try
            {
                var accounts = (from a in _db.Accounts select new { a.Username,a.Password }).ToList();
                bool isLogin = false;
                foreach (var a in accounts)
                {
                    if (txtUsername.Text.Trim().Equals(a.Username) && txtPassword.Text.Trim().Equals(a.Password))
                    {
                        isLogin = true;
                    }
                   
                }
                if (isLogin == true) {
                    MessageBox.Show("Bạn đã đăng nhập thành công !", "Thông Báo", MessageBoxButtons.OK);
                    FrmHomePage h = new FrmHomePage(txtUsername.Text.Trim());
                    this.Hide();//ẩn form login
                    h.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
          
           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát chương trình?","Thông Báo",MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
            {
                e.Cancel = true;//cancel event e
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRegister frmRegister = new FrmRegister();
            this.Hide();
            frmRegister.ShowDialog();
           
        }
    }
}
