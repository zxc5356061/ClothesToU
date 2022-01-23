using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.ViewModels
{
    public class EditProfileVM
    {
        
        [Display(Name = "修改密碼")]
        [Required]
        [StringLength(64)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "請再輸入一次修改後的密碼")]
        [Required]
        [StringLength(64)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Display(Name = "修改姓名")]
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Display(Name = "修改手機")]
        [StringLength(10)]
        public string Mobile { get; set; }

        [Display(Name = "修改地址")]
        [StringLength(50)]
        public string Address { get; set; }
    }
}