using ClothesToU.Site.Models.Entities.Cart;
using ClothesToU.Site.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.Entities
{
    public class CartEntity
    {
		//Constructors
		// New一個購物車用的
		public CartEntity(int id, string customerAccount)
		{
			this.Id = id;
			this.CustomerAccount = customerAccount;
			Items = new List<CartItemEntity>();
		}
		// Load用
		public CartEntity(int id, string customerAccount, List<CartItemEntity> items)
		{
			this.Id = id;
			this.CustomerAccount = customerAccount;
			Items = items;
		}//Constructors_End

		public int Id { get; set; }

		private string _CustomerAccount;
		public string CustomerAccount
		{
			get => _CustomerAccount;
			set => _CustomerAccount = string.IsNullOrEmpty(value) == false ? value
																		   : throw new Exception("CustomerAccount 不能是空值");
		}

		private List<CartItemEntity> Items;

		public int Total
        {
            get
            {
				return (Items == null || Items.Count == 0) ? 0 
														   : Items.Sum(cartItemEntity => cartItemEntity.SubTotal);
			}
        }
		public bool AllowCheckOut
        {
            get
            {
				return Items != null && Items.Count > 0;
            }
        }

		public ShippingInfo ShippingInfo { get; set; }

		// 因為Items被設為Private的關係，所以要透過此Method來傳出Items;
		public IEnumerable<CartItemEntity> GetItems()
		{
			return this.Items;
		}

		// AddItem 要避免直接存取repo，所以參數不寫 productId 而是寫 CartProductEntity product
		public void AddItem(CartProductEntity product, int qty)
		{
			if (product == null) throw new ArgumentNullException(nameof(product));
			if (qty <= 0) throw new ArgumentOutOfRangeException(nameof(qty));

			//與資料庫中比對現有的cartItem
			CartItemEntity item = Items.SingleOrDefault(cartItemEntity => cartItemEntity.Product.Id == product.Id);

			// 如果購物車裡面沒有那筆項目，就新增一筆
			if (item == null)
			{
				CartItemEntity cartItem = new CartItemEntity(product, qty);
				this.Items.Add(cartItem);
			}
			// 如果購物車裡有那筆項目，就直接對數量+1
			else
			{
				item.Qty = item.Qty + qty;
			}
		}

		public void RemoveItem(int productId)
		{
			//與資料庫中比對現有的cartItem
			CartItemEntity item = Items.SingleOrDefault(x => x.Product.Id == productId);
			
			//若項目不存在，結束
			if (item == null) return;
			//若項目存在，刪除
			Items.Remove(item);
		}

		//允許直接在購物車明細頁面更改商品數量
		public void UpdateQty(int productId, int newQty)
		{
			if (newQty <= 0)
			{
				RemoveItem(productId);
				return;
			}
			//與資料庫中比對現有的cartItem
			CartItemEntity item = Items.SingleOrDefault(x => x.Product.Id == productId);
			//若項目不存在，結束
			if (item == null) return;
			//若項目存在，更新數量
			item.Qty = newQty;
		}

	}
}