using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyGiaiDauBongDa
{
    public partial class Referee
    {
        public Referee()
        {
            Matches = new HashSet<Match>();
        }

        public int RefereeId { get; set; }
        public string RefereeName { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}
