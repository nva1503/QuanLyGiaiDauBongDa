using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyGiaiDauBongDa.Models
{
    public partial class Team
    {
        public int? ClubId { get; set; }
        public int? PlayerId { get; set; }
        public int? MatchId { get; set; }

        public virtual Club Club { get; set; }
        public virtual Match Match { get; set; }
        public virtual Player Player { get; set; }
    }
}
