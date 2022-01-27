using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.ValueObjects
{
	public class DeductStockInfo
	{
		public int ProductId { get; set; }

		/// <summary>
		/// 傳入正數
		/// </summary>
		public int Qty { get; set; }
	}
}