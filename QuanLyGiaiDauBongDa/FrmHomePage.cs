using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGiaiDauBongDa
{
    public partial class FrmHomePage : Form
    {
        public FrmHomePage()
        {
            InitializeComponent();
        }
        string userName;
        public FrmHomePage(string username): this()
        {
            userName = username;
            
        }
        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FrmHomePage_Load(object sender, EventArgs e)
        {
            statusStrip1.Text = "Welcome, Admin! Have a nice Day";
            txtTime.Text = "Hôm nay là: "+ DateTime.Now.DayOfWeek.ToString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void ádToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
             
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmDanhSachClub frmDanhSachDoiBong = new FrmDanhSachClub();
            this.Hide();
            frmDanhSachDoiBong.Show();
            this.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
        }

        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmLichThiDau FrmLichThiDau = new FrmLichThiDau();
            this.Hide();
            FrmLichThiDau.Show();
            this.Show();
        }

        private void btnAboutUs_Click(object sender, EventArgs e)
        {
            FrmAboutUs frmAboutUs = new FrmAboutUs(userName);
            frmAboutUs.ShowDialog();


        }
    }
}
