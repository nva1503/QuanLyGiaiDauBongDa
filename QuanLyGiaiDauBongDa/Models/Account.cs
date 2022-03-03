using System;
using System.Collections.Generic;

#nullable disable

namespace QuanLyGiaiDauBongDa.Models
{
    public partial class Account
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime? Dob { get; set; }
    }
}
