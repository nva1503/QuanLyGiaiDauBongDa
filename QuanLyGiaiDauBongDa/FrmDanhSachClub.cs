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
            txtYear.DataBindings.Clear();
            txtAddress.DataBindings.Clear();
            txtCity.DataBindings.Clear();
            txtCountry.DataBindings.Clear();
            txtStadium.DataBindings.Clear();
            txtYear.DataBindings.Add("Text", clubs, "YearCreated");
            txtAddress.DataBindings.Add("Text", clubs, "Address");
            txtCity.DataBindings.Add("Text", clubs, "City");
            txtCountry.DataBindings.Add("Text", clubs, "CountryId");
            txtStadium.DataBindings.Add("Text", clubs, "StadiumId");
            labelNameClub.DataBindings.Add("Text", clubs, "Name");
            picLogo.ImageLocation = "./logo.png"; 
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
    }
}
