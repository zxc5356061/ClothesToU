using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "會員帳號")]
        [Required]
        [StringLength(20)]
        [DataType(DataType.EmailAddress)]
        public string Account { get; set; }

        [Display(Name = "密碼")]
        [Required]
        [StringLength(64)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "請再輸入一次密碼")]
        [Required]
        [StringLength(64)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Display(Name = "姓名")]
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Display(Name = "手機")]
        [StringLength(10)]
        public string Mobile { get; set; }

        [Display(Name = "地址")]
        [StringLength(50)]
        public string Address { get; set; }
    }
}