using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.ViewModels
{
    public class EditProfileVM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name ="帳號")]
        public string Account { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        [StringLength(10)]
        [Display(Name = "手機")]
        public string Mobile { get; set; }

        [StringLength(50)]
        [Display(Name = "地址")]
        public string Address { get; set; }
    }
}