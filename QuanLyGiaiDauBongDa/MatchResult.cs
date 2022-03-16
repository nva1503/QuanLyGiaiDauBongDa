using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyGiaiDauBongDa
{
    public partial class MatchResult
    {
        public int MatchId { get; set; }
        public string PlayStage { get; set; }
        public int? ClubId { get; set; }
        public string WinLose { get; set; }
        public int? GoalScore { get; set; }

        public virtual Club Club { get; set; }
        public virtual Match Match { get; set; }
    }
}
