using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Auction.Data.Models
{
    public class Lot
    {
        [Key]
        public int Id { get; set; }
        public string PublicationName { get; set; }
        public string Discription { get; set; }
        public int StartCost { get; set; }
        public int CurrentCost { get; set; }
        public byte[] AvatarLot { get; set; }
        public string ImgUrlLot { get; set; }
        public DateTime DateLot { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public List<Bet> Comments { get; set; }
    }
}
