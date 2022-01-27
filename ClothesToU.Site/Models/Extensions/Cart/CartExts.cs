using ClothesToU.Site.Models.EFModels;
using ClothesToU.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.Extensions
{
    public static partial class CartExts
    {
		public static CartEntity ToCartEntity(this Cart source)
		{
			var items = source.CartItems.Select(x => x.ToEntity()).ToList();

			return new CartEntity(source.Id, source.MemberAccount, items);
		}

		public static Cart ToEFCart(this CartEntity source)
		{
			var items = source.GetItems().Select(x => x.ToEF(source.Id)).ToList();

			return new Cart { Id = source.Id, MemberAccount = source.CustomerAccount, CartItems = items };
		}
	}
}