using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string Gender { get; set; }
        public IFormFile Avatar { get; set; }
    }
}
