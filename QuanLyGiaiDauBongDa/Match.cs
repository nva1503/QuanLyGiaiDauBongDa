﻿using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyGiaiDauBongDa
{
    public partial class Match
    {
        public Match()
        {
            Goals = new HashSet<Goal>();
        }

        public int MatchId { get; set; }
        public DateTime? PlayDate { get; set; }
        public int HostId { get; set; }
        public int GuestId { get; set; }
        public int? RefereeId { get; set; }
        public int? VenueId { get; set; }

        public virtual Club Guest { get; set; }
        public virtual Club Host { get; set; }
        public virtual Referee Referee { get; set; }
        public virtual Venue Venue { get; set; }
        public virtual ICollection<Goal> Goals { get; set; }
    }
}
