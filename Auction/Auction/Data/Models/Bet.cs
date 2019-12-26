using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Auction.Data.Models
{
    public class Bet
    {
        [Key]
        public int Id { get; set; }
        public string Author { get; set; }
        public int CurrentBet { get; set; }
        public DateTime DateBet { get; set; } = DateTime.Now;
        public string LotId { get; set; }
        public string LotNane { get; set; }
        public virtual Lot Lot { get; set; }
    }
}
