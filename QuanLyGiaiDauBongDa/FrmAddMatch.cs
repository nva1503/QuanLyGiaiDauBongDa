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
        Match match = new();
        public FrmAddMatch()
        {
            InitializeComponent();
        }
        public FrmAddMatch(Match match)
        {
            InitializeComponent();
            this.match = match;
        }
        private void Loadmatch()
        {
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

            if (match.MatchId != 0)
            {
                cbHost.SelectedValue = match.HostId;
                cbGuest.SelectedValue = match.GuestId;
                cbReferee.SelectedValue = match.RefereeId;
                cbVenue.SelectedValue = match.VenueId;
                dateTimePicker1.Value = DateTime.Parse(match.PlayDate.ToString());
            }
        }
        private void FrmAddMatch_Load(object sender, EventArgs e)
        {
            try
            {
                if (match.MatchId == 0) 
                {
                    Loadmatch();
                } else
                {
                    if (!(from r in context.MatchResults where r.MatchId == match.MatchId select r).Any())
                    {
                        Loadmatch();
                    } else
                    {
                        MessageBox.Show("Trận đấu đã diễn ra");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (match.MatchId != 0)
            {
                Match m = context.Matches.SingleOrDefault(m => m.MatchId == match.MatchId);
                m.HostId = int.Parse(cbHost.SelectedValue.ToString());
                m.GuestId = int.Parse(cbGuest.SelectedValue.ToString());
                m.VenueId = int.Parse(cbVenue.SelectedValue.ToString());
                m.RefereeId = int.Parse(cbReferee.SelectedValue.ToString());
                m.PlayDate = dateTimePicker1.Value;
                try
                {
                    context.Matches.Update(m);
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Match successful");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Match failed");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else
            {
                try
                {
                    context.Matches.Add(new Match()
                    {
                        HostId = int.Parse(cbHost.SelectedValue.ToString()),
                        GuestId = int.Parse(cbGuest.SelectedValue.ToString()),
                        RefereeId = int.Parse(cbReferee.SelectedValue.ToString()),
                        PlayDate = dateTimePicker1.Value,
                        VenueId = int.Parse(cbVenue.SelectedValue.ToString())
                    });
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Match successful");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Match failed");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
