using Microsoft.EntityFrameworkCore;
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
    public partial class FrmLichThiDau : Form
    {
        QuanLyGiaiDauBongDaContext context = new QuanLyGiaiDauBongDaContext();
        public FrmLichThiDau()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Panel panel = new Panel();
            panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            panel.Size = new Size((300), 100);
            flowLayoutPanel1.Controls.Add(panel);
        }

        private void FrmLichThiDau_Load(object sender, EventArgs e)
        {
            try
            {
                LoadMatch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void LoadMatch()
        {
            //context = new QuanLyGiaiDauBongDaContext();
            List<Match> matches = new List<Match>(); 
            foreach (var item in context.Matches.ToList())
            {
                item.Host = context.Clubs.SingleOrDefault(s => s.ClubId == item.HostId);
                item.Guest = context.Clubs.SingleOrDefault(s => s.ClubId == item.GuestId);
                matches.Add(item);
            }
            foreach (var item in matches)
            {
                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                panel.AutoSize = true;

                panel.Width = flowLayoutPanel1.Width;

                //CONTENT OF PANEL
                TextBox textBox = new TextBox();
                textBox.Text = item.PlayDate.ToString();
                textBox.Size = new Size(180, 20);
                Button btnHost = new Button();
                btnHost.AutoSize = true;
                btnHost.Image = Image.FromFile(@"..\..\..\Resources\"+ item.Host.LogoUrl);
                btnHost.ImageAlign = ContentAlignment.MiddleCenter;
                btnHost.Text = item.Host.Name.ToString();
                btnHost.TextAlign = ContentAlignment.BottomCenter;


                Button btnGuest = new Button();
                btnGuest.AutoSize = true;
                btnGuest.Image = Image.FromFile(@"..\..\..\Resources\" + item.Guest.LogoUrl);
                btnGuest.ImageAlign = ContentAlignment.MiddleCenter;
                btnGuest.Text = item.Guest.Name.ToString();
                btnGuest.TextAlign = ContentAlignment.BottomCenter;
                

                panel.FlowDirection = FlowDirection.LeftToRight;

                panel.Controls.Add(new Label() { Text = "Ngày Thi Đấu: ", AutoSize = true }); 
                panel.Controls.Add(textBox);
                panel.Controls.Add(btnHost);
                panel.Controls.Add(new Label() { Text = "VS" });
                panel.Controls.Add(btnGuest);
                

                flowLayoutPanel1.Controls.Add(panel);
                flowLayoutPanel1.AutoScroll = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmAddMatch frmAddMatch = new FrmAddMatch();
            this.Hide();
            frmAddMatch.ShowDialog();
            this.Show();
        }
    }
}
