using QuanLyGiaiDauBongDa.DBContext;
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
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            try
            {
                List<Account> accounts = new AccountDAO().GetAccounts();
                bool isLogin = false;
                foreach (var a in accounts)
                {
                    if (txtUsername.Text == a.userName && txtPassword.Text == a.passWord)
                    {
                        isLogin = true;
                    }
                   
                }
                if (isLogin == true) {
                    MessageBox.Show("Bạn đã đăng nhập thành công !", "Thông Báo", MessageBoxButtons.OK);
                    FrmHomePage h = new FrmHomePage();
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
