using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "會員帳號")]
        [Required(ErrorMessage = "{0} is MUST-HAVE!")]
        [StringLength(20)]
        [DataType(DataType.EmailAddress)]
        public string Account { get; set; }

        [Display(Name = "密碼")]
        [Required(ErrorMessage = "{0} is MUST-HAVE!")]
        [StringLength(64)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}