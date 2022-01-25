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
        public string Account { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Mobile { get; set; }

        [StringLength(50)]
        public string Address { get; set; }
    }
}