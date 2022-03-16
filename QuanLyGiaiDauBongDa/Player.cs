using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyGiaiDauBongDa
{
    public partial class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Dob { get; set; }
        public int CountryId { get; set; }
        public string PositionId { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Image { get; set; }
        public int? ClubId { get; set; }

        public virtual Club Club { get; set; }
        public virtual Country Country { get; set; }
        public virtual PlayingPosition Position { get; set; }
    }
}
