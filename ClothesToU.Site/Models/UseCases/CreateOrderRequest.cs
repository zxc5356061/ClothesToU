using ClothesToU.Site.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.UseCases
{
	public class CreateOrderRequest
	{
		public int CustomerId { get; set; }

		public List<CreateOrderItem> Items { get; set; }

		public int Total => Items.Sum(x => x.SubTotal);

		public ShippingInfo ShippingInfo { get; set; }
	}
}