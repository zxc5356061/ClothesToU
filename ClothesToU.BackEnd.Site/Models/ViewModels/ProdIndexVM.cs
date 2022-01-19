using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothesToU.BackEnd.Site.Models.ViewModels
{
	public class ProdIndexVM
	{
        
        public int Id { get; set; }


        [Display(Name = "商品分類")]
        public int CategoryId { get; set; }

        [Display(Name = "標題")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description{ get; set; }

        [Display(Name = "商品價格")]
        public int Price { get; set; }

        [Display(Name = "庫存")]
        public int Stock { get; set; }
        
        [Required]
        [StringLength(50)]
        public string FileName { get; set; }

        public bool Status { get; set; }


        [Display(Name = "尺寸")]
        [Required]
        [StringLength(2)]
        public string Size { get; set; }

        [Display(Name = "顏色")]
        [Required]
        [StringLength(10)]
        public string Color { get; set; }

        [Display(Name = "異動日期")]
        [DisplayFormat(ApplyFormatInEditMode =false,DataFormatString ="{0:yyyy/MM/dd HH:mm:ss}")]
        public DateTime ModifiedTime { get; set; }

        [Display(Name = "描述")]
        public string BriefDescription
        {
            get
            {
                if (string.IsNullOrEmpty(this.Description))
                {
                    return string.Empty;
                }
                int maxLength = 15;
                return this.Description.Length > maxLength
                    ? this.Description.Substring(0, maxLength) + "..."
                    : this.Description;
            }
        }
    }
}