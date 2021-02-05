using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsProphetAPI.Dtos
{
    public class UserRegisterDto
    {
        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "You must specify a username between 4 and 20 characters.")]
        public string Username { get; set; }
        [Required]
        [StringLength(32, MinimumLength = 6, ErrorMessage = "You must specify a password between 6 and 32 characters.")]
        public string Password { get; set; }
    }
}
