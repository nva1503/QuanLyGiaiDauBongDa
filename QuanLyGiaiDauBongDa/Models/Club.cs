using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
        [ForeignKey("StadiumId")]
        public virtual Stadiun Stadium { get; set; }
        public virtual ICollection<Match> MatchGuests { get; set; }
        public virtual ICollection<Match> MatchHosts { get; set; }
    }
}
