using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyGiaiDauBongDa
{
    public partial class Team
    {
        public int? PlayerId { get; set; }
        public int? MatchId { get; set; }

        public virtual Match Match { get; set; }
        public virtual Player Player { get; set; }
    }
}
