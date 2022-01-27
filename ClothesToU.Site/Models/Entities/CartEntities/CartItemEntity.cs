using ClothesToU.Site.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.Entities.CartEntities
{
	public class CartItemEntity
	{
		public CartItemEntity(CartProductEntity product, int qty)
		{
			Product = product;
			Qty = qty;
		}

		public int Id { get; set; }

		private CartProductEntity _Product;
		public CartProductEntity Product
		{
			get => _Product;
			set => _Product = value != null ? value : throw new Exception("Product不能是null");
		}

		private int _Qty;
		public int Qty
		{
			get => _Qty;
			set => _Qty = value > 0 ? value : throw new Exception("Qty必須是正數");
		}

		public int SubTotal => Product.Price * Qty;
	}

	public static class CartItemExts
	{
		public static CartItemEntity ToEntity(this CartItem source)
		{
			CartProductEntity prod = source.Product.ToCartProduct();
			return new CartItemEntity(prod, source.Qty) { Id = source.Id };
		}

		public static CartItem ToEF(this CartItemEntity source, int cartId)
		{
			return new CartItem { Id = source.Id, CartId = cartId, ProductId = source.Product.Id, Qty = source.Qty };
		}
	}
}