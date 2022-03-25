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
        List<Match> matches = new List<Match>();
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
            }
        }

        private void LoadMatch()
        {
            flowLayoutPanel1.Controls.Clear();
            matches.Clear();
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
                textBox.ReadOnly = true;

                Button btnHost = new Button();
                btnHost.Size = new Size(100,100);
                btnHost.BackgroundImage = Image.FromFile(@"..\..\..\Resources\"+ item.Host.LogoUrl);
                btnHost.ImageAlign = ContentAlignment.MiddleCenter;
                btnHost.BackgroundImageLayout = ImageLayout.Stretch;

                Button btnGuest = new Button();
                btnGuest.Size = new Size(100, 100);
                btnGuest.BackgroundImage = Image.FromFile(@"..\..\..\Resources\" + item.Guest.LogoUrl);
                btnGuest.ImageAlign = ContentAlignment.MiddleCenter;
                btnGuest.BackgroundImageLayout = ImageLayout.Stretch;

                Button btnEdit = new Button();
                btnEdit.Size = new Size(80, 100);
                btnEdit.Text = "Edit";
                btnEdit.TextAlign = ContentAlignment.MiddleCenter;
                btnEdit.Click += delegate (object sender, EventArgs e) { btnEdit_Click(this, e, item); };

                Button btnResult = new Button();
                btnResult.Size = new Size(80, 100);
                btnResult.Text = "Result";
                btnResult.TextAlign = ContentAlignment.MiddleCenter;
                btnResult.Click += delegate (object sender, EventArgs e) { btnResult_Click(this, e, item); };


                panel.FlowDirection = FlowDirection.LeftToRight;

                panel.Controls.Add(new Label() { Text = "Ngày Thi Đấu: ", AutoSize = true }); 
                panel.Controls.Add(textBox);
                panel.Controls.Add(btnHost);
                panel.Controls.Add(new Label() { Text = "VS", Width = 50 }) ;
                panel.Controls.Add(btnGuest);
                panel.Controls.Add(btnEdit);
                panel.Controls.Add(btnResult);
                

                flowLayoutPanel1.Controls.Add(panel);
                flowLayoutPanel1.AutoScroll = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmAddMatch frmAddMatch = new FrmAddMatch();
            frmAddMatch.ShowDialog();
            this.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e, Match m)
        {
            FrmAddMatch frmAddMatch = new FrmAddMatch(m);
            frmAddMatch.ShowDialog();
            this.Close();

        }

        private void btnResult_Click(object sender, EventArgs e, Match m)
        {
            FrmEditMatch frmEditMatch = new FrmEditMatch(m);
            frmEditMatch.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //List<Club> clubs = context.Clubs.ToList();
            //int count = 1;
            //Match[,] matches = new Match[clubs.Count, clubs.Count - 1];
            //for (int i = 0; i < clubs.Count; i++)
            //{
            //    Match m = new Match() { HostId = i + 1, GuestId = i + 2, PlayDate = DateTime.Today };
            //    matches[i, 0] = m;
            //    context.Matches.Add(m);
            //    count++;
            //    i++;
            //}
            //for (int j = 1; j < clubs.Count - 1; j++)
            //{
            //    for (int i = 0; i < clubs.Count / 2; i++)
            //    {
            //        Match m = new Match() { HostId = i + 1, GuestId = (1 + (i + 1 + j + 1 - 1) % (clubs.Count / 2)), PlayDate = DateTime.Today };
            //        matches[i, j] = m;
            //        context.Matches.Add(m);
            //        count++;
            //    }
            //}
        }
    }
}
