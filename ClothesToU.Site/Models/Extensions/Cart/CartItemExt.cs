using ClothesToU.Site.Models.EFModels;
using ClothesToU.Site.Models.Entities.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.Extensions
{
    public static partial class CartItemExt
    {
		public static CartItemEntity ToCartItemEntity(this CartItem source)
		{
			CartProductEntity prod = source.Product.ToCartProduct();
			return new CartItemEntity(prod, source.Qty) { Id = source.Id };
		}

		public static CartItem ToEFCartItem(this CartItemEntity source, int cartId)
		{
			return new CartItem { Id = source.Id, CartId = cartId, ProductId = source.Product.Id, Qty = source.Qty };
		}
	}
}