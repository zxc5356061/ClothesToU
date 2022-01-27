using ClothesToU.Site.Models.EFModels;
using ClothesToU.Site.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.Entities.CartEntities
{
	public class OrderEntity
	{
		// 老師沒有寫好，需再自己補上CustomerAccount

		public OrderEntity(int id, int customerId, List<OrderItemEntity> items, DateTime createdTime, ShippingInfo shippingInfo)
		{
			Id = id;
			CustomerId = customerId;
			Items = items;
			CreatedTime = createdTime;
			ShippingInfo = shippingInfo;
		}

		public int Id { get; set; }

		public int CustomerId { get; set; }

		public string CustomerAccount { get; set; }

		private List<OrderItemEntity> _Items;

		public List<OrderItemEntity> Items
		{
			get => _Items;
			set => _Items = (value != null && value.Count == 0) ? value : throw new Exception("Items不能是空的");
		}

		public int Total => Items.Sum(x => x.SubTotal);

		public bool RequestRefund { get; set; }

		public DateTime? RequestRefundTime { get; set; }

		public DateTime CreatedTime { get; set; }

		private bool _Status;

		public bool Status
		{
			get => _Status;
			set => _Status = value;
		}

		private ShippingInfo _ShippingInfo;

		public ShippingInfo ShippingInfo
		{
			get => _ShippingInfo;
			set => _ShippingInfo = value != null ? value : throw new Exception("shippingInfo不能是null");
		}

		public bool AllowRefund
		{
			get
			{
				if (Status == 1) return true;
				if (Status == 2 && In7Days) return true;

				return false;
			}
		}

		/// <summary>
		/// 本系統沒有記錄客戶收貨日期，所以判斷七天可退貨的標準，暫時用訂單成立日期來計算
		/// </summary>
		private bool In7Days
		{
			get
			{
				return (DateTime.Today - this.CreatedTime).TotalDays <= 7.0;
			}
		}
	}

	public static partial class OrderExts
	{
		public static OrderEntity ToEntity(this Order source)
		{
			if (source == null) return null;

			List<OrderItemEntity> items = source.OrderItems.Select(x => x.ToEntity()).ToList();

			return new OrderEntity(
				source.Id,
				source.MemberId,
				items, source.CreatedTime,
				source.GetShippingInfo()
			)
			{
				CustomerAccount = source.Member.Account,
				Status = source.Status,
				RequestRefund = source.RequestRefund,
				RequestRefundTime = source.RequestRefundTime
			};
		}

		public static ShippingInfo GetShippingInfo(this Order source)
		{
			return new ShippingInfo
			{
				Recipient = source.Recipient,
				ShippingAddress = source.ShippingAddress,
				RecipientMobile = source.RecipientMobile
	};
		}
	}
}