using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.ViewModels
{
    public class LotViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "LotName")]
        public string LotName { get; set; }

        [Required]
        [Display(Name = "Discription")]
        public string Discription { get; set; }

        public int StartCost { get; set; }

        [Required]
        [Display(Name = "AvatarLot")]
        public IFormFile AvatarLot { get; set; }
    }
}
