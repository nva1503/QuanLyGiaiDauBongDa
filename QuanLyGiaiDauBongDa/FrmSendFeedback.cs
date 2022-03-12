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
    public partial class FrmSendFeedback : Form
    {
        public FrmSendFeedback()
        {
            InitializeComponent();
        }
        string userName;
        public FrmSendFeedback(string username) : this()
        {
            userName = username;
            
        }
        private void btnSend_Click(object sender, EventArgs e)
        {

        }

        private void FrmSendFeedback_Load(object sender, EventArgs e)
        {
            labelUsername.Text = userName;
        }

        private void btnAboutUs_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
        }
    }
}
