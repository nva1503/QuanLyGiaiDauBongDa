using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyGiaiDauBongDa.Models
{
    public partial class Club
    {
        public Club()
        {
            MatchGuests = new HashSet<Match>();
            MatchHosts = new HashSet<Match>();
        }

        public int ClubId { get; set; }
        public string Name { get; set; }
        public string YearCreated { get; set; }
        public int? CountryId { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int? StadiumId { get; set; }
        public string LogoUrl { get; set; }

        public virtual Country Country { get; set; }
        public virtual Stadiun Stadium { get; set; }
        public virtual ICollection<Match> MatchGuests { get; set; }
        public virtual ICollection<Match> MatchHosts { get; set; }
    }
}
