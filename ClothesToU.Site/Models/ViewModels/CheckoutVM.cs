using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.ViewModels
{
    public class CheckoutVM
    {
		[Display(Name = "收件人")]
		[Required]
		[MaxLength(30)]
		public string Recipient { get; set; }

		[Display(Name = "地址")]
		[Required]
		[MaxLength(200)]
		public string ShippingAddress { get; set; }

		[Display(Name = "手機")]
		[Required]
		[MaxLength(10)]
		public string RecipientMobile { get; set; }
	}
}