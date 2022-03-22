using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyGiaiDauBongDa.Models
{
    public partial class Feedback
    {
        public string UserName { get; set; }
        public string Problem { get; set; }
        public string Content { get; set; }
        public int RateId { get; set; }

        public virtual Rate Rate { get; set; }
    }
}
