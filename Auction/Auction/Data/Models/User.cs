using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Auction.Data.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string UserEmail { get; set; }
        public int Balance { get; set; }
        public byte[] Avatar { get; set; }
        public string ImgUrl { get; set; }
        public DateTime DateRegistration { get; set; } = DateTime.Now;
        public List<Lot> Lots { get; set; }
    }
}
