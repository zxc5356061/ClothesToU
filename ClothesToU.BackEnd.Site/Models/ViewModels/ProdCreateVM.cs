using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothesToU.BackEnd.Site.Models.ViewModels
{
	public class ProdCreateVM
	{
       
        [Display(Name = "商品分類")]
        public int CategoryId { get; set; }

        [Display(Name = "標題")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        [MaxLength(2000)]
        [Display(Name = "描述")]
        public string Description { get; set; }

        [Display(Name = "商品價格")]
        public int Price { get; set; }

     
        [StringLength(50)]
        [Display(Name = "檔案名稱")]
        public string FileName { get; set; }

        [Display(Name = "尺寸")]
        [Required]
        [MaxLength(2)]
        public string Size { get; set; }

        [Display(Name = "顏色")]
        [Required]
        [MaxLength(10)]
        public string Color { get; set; }
    }
}