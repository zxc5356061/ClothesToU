using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.Entities.Cart
{
    public class CartItemEntity
    {
		//Constructor
		public CartItemEntity(CartProductEntity product, int qty)
		{
			Product = product;
			Qty = qty;
		}//Constructor_End

		public int Id { get; set; }


		private CartProductEntity _Product;
		public CartProductEntity Product
		{
            //get => _Product;
            //set => _Product = value != null ? value : throw new Exception("Product不能是null");
            get
            {   return this._Product;}
			set
            {
				this._Product = value != null ? value : throw new Exception("Product不能是Null");
            }
		}

		private int _Qty;
		public int Qty
		{
			//get => _Qty;
			//set => _Qty = value > 0 ? value : throw new Exception("Qty必須是正數");
			get { return this._Qty; }
            set
            {
				this._Qty = value > 0 ? value : throw new Exception("Qty必須是正數");
            }
		}

		public int SubTotal
        {
            get { return Product.Price * Qty; }
        }
	}
}