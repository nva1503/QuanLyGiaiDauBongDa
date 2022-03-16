using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyGiaiDauBongDa
{
    public partial class Stadiun
    {
        public Stadiun()
        {
            Clubs = new HashSet<Club>();
        }

        public int StadiumId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Club> Clubs { get; set; }
    }
}
