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
    public partial class FrmDanhSachClub : Form
    {
        public FrmDanhSachClub()
        {
            InitializeComponent();
        }
        QuanLyGiaiDauBongDaContext context = new QuanLyGiaiDauBongDaContext();
        public void LoadList()
        {
            var clubs = context.Clubs.Include(c => c.Country).Include(x => x.Stadium).ToList();
            label7.DataBindings.Clear();
            label8.DataBindings.Clear();
            label9.DataBindings.Clear();
            label10.DataBindings.Clear();
            label11.DataBindings.Clear();
            label7.DataBindings.Add("Text", clubs, "YearCreated");
            label8.DataBindings.Add("Text", clubs, "Address");
            label9.DataBindings.Add("Text", clubs, "City");
            label10.DataBindings.Add("Text", clubs, "CountryId");
            label11.DataBindings.Add("Text", clubs, "StadiumId");
            labelNameClub.DataBindings.Add("Text", clubs, "Name");
            picLogo.BackgroundImage = Image.FromFile(@"..\..\..\Resources\mu.png");
            //var binding = new Binding("Text", clubs, "LogoUrl");
            //binding.Format += delegate (object sentFrom, ConvertEventArgs convertEventArgs)
            //{
            //    convertEventArgs.Value = @"..\..\..\Resources\" + convertEventArgs.Value;
            //};
            //picLogo.BackgroundImage = Image.FromFile(binding.DataSource.ToString());
            dgvClub.DataSource = clubs;
        }

        private void FrmDanhSachDoiBong_Load(object sender, EventArgs e)
        {
            try
            {
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
