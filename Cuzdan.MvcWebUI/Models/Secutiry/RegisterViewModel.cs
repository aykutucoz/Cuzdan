using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cuzdan.MvcWebUI.Models.Secutiry
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",
            ErrorMessage ="Girdiğiniz şifreler birbirleri ile aynı olmalı!")]
        public string ConfirmedPassword { get; set; }
    }
}
