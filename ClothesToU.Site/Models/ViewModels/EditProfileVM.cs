using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.ViewModels
{
    public class EditProfileVM
    {

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