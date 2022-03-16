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
    public partial class FrmLichThiDauChoClub : Form
    {
        QuanLyGiaiDauBongDaContext context = new QuanLyGiaiDauBongDaContext();
        //Khởi tạo object Câu Lạc Bộ
        Club club = new Club();
        public FrmLichThiDauChoClub(Club club)
        {
            InitializeComponent();
            this.club = club;
        }

        private void FrmLichThiDauChoClub_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSchedule();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadSchedule()
        {
            lbClub.Text = club.Name;
            pbClub.Image = Image.FromFile(@"..\..\..\Resources\" + club.LogoUrl);
            pbClub.SizeMode = PictureBoxSizeMode.Zoom;
            flpSchedule.AutoScroll = true;

            List<Match> matches = new List<Match>();
            foreach (var item in context.Matches.ToList())
            {
                if (item.HostId == club.ClubId || item.GuestId == club.ClubId)
                {
                    item.Host = context.Clubs.SingleOrDefault(s => s.ClubId == item.HostId);
                    item.Guest = context.Clubs.SingleOrDefault(s => s.ClubId == item.GuestId);
                    matches.Add(item);
                }   
            }

            foreach (Match item in matches)
            {
                //Tạo panel cho trận đấu
                FlowLayoutPanel match = new FlowLayoutPanel();
                match.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                match.Size = new System.Drawing.Size(flpSchedule.Width-30, 70);

                //Nội dung kết quả trận đấu
                Label time = new Label();
                time.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                time.AutoSize = true;
                time.Text = item.PlayDate.ToString() + ":";
                match.Controls.Add(time);

                Label content = new Label();
                content.Size = new System.Drawing.Size(550, 70);
                content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                string result = "0 - 0";
                if (item.HostId == club.ClubId)
                {
                    content.Text = "HOST VS " + item.Guest.Name + "\n         " + result;
                }
                else
                {
                    content.Text = "GUEST VS " + item.Host.Name + "\n          " + result;
                }

                Button squad = new Button();
                squad.Size = new System.Drawing.Size(70, 60);
                squad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                squad.Text = "Squad";

                Button detail = new Button();
                detail.Size = new System.Drawing.Size(70, 60);
                detail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                detail.Text = "Detail";

                match.Controls.Add(content);
                match.Controls.Add(squad);
                match.Controls.Add(detail);
                

                flpSchedule.Controls.Add(match);
            }
        }
    }
}
