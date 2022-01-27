using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.Core.Interfaces
{
    public class CartMediator
    {
		private readonly ICartService _cart;
		private readonly IOrderService _order;
		private readonly IStockService _stock;

		public CartMediator(ICartService cart, IOrderService order, IStockService stock)
		{
			_cart = cart;
			_order = order;
			_stock = stock;

			_cart.RequestCheckout += _cart_RequestCheckout;
		}

		private void _cart_RequestCheckout(ICartService sender, string customerAccount)
		{
			CartEntity cart = _cart.Current(customerAccount);

			CreateOrderRequest request = _cart.ToCreateOrderRequest(cart);
			_order.PlaceOrder(request);

			DeductStockInfo[] info = _cart.GetDeductStockInfo(cart);
			_stock.Deduct(info);

			_cart.EmptyCart(customerAccount);
		}
	}
}