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
    public partial class FrmAddMatch : Form
    {
        QuanLyGiaiDauBongDaContext context = new QuanLyGiaiDauBongDaContext();
        public FrmAddMatch()
        {
            InitializeComponent();
        }
        private void Loadmatch()
        {
            context = new QuanLyGiaiDauBongDaContext();

            cbGuest.DataSource = context.Clubs.ToList();
            cbGuest.DisplayMember = "Name";
            cbGuest.ValueMember = "ClubId";
            cbGuest.SelectedIndex = -1;

            cbHost.DataSource = context.Clubs.ToList();
            cbHost.DisplayMember = "Name";
            cbHost.ValueMember = "ClubId";
            cbHost.SelectedIndex = -1;

            cbVenue.DataSource = context.Venues.ToList();
            cbVenue.DisplayMember = "Name";
            cbVenue.ValueMember = "VenueId";
            cbHost.SelectedIndex = 1;

            cbReferee.DataSource = context.Referees.ToList();
            cbReferee.DisplayMember = "RefereeName";
            cbReferee.ValueMember = "RefereeId";
        }
        private void FrmAddMatch_Load(object sender, EventArgs e)
        {
            try
            {
                Loadmatch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbVenue_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCapacity.Text = "Hello";
        }

        private void cbVenue_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            

        }
    }
}
