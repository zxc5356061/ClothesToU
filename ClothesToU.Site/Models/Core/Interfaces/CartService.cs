//using ClothesToU.Site.Models.Entities;
//using ClothesToU.Site.Models.UseCases.Cart;
//using ClothesToU.Site.Models.ValueObjects;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace ClothesToU.Site.Models.Core.Interfaces
//{
//    public class CartService : ICartService
//    {
//        public event Action<ICartService, string> RequestCheckout;

//        public void AddItem(string customerAccount, int productId, int qty = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public void Checkout(string customerAccount, ShippingInfo shippingInfo)
//        {
//            throw new NotImplementedException();
//        }

//        public CartEntity Current(string customerAccount)
//        {
//            throw new NotImplementedException();
//        }

//        public void EmptyCart(string customerAccount)
//        {
//            throw new NotImplementedException();
//        }

//        public DeductStockInfo[] GetDeductStockInfo(CartEntity cart)
//        {
//            throw new NotImplementedException();
//        }

//        public void RemoveItem(string customerAccount, int productId)
//        {
//            throw new NotImplementedException();
//        }

//        public CreateOrderRequest ToCreateOrderRequest(CartEntity cart)
//        {
//            throw new NotImplementedException();
//        }

//        public void UpdateItem(string customerAccount, int productId, int newQty)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}