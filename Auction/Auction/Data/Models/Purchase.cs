using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }
        public string PurchaseName { get; set; }
        public string Discription { get; set; }
        public int StartCost { get; set; }
        public int CurrentCost { get; set; }
        public byte[] AvatarPurchase { get; set; }
        public bool Status { get; set; }
        public DateTime DatePurchase { get; set; } = DateTime.Now;
        public string UserId { get; set; }
        public string OwnerName { get; set; }
        public virtual User User { get; set; }
    }
}
