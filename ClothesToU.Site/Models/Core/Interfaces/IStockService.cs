using ClothesToU.Site.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesToU.Site.Models.Core
{
    public interface IStockService
    {
		/// <summary>
		/// 新增訂單時，用來扣除庫存量
		/// </summary>
		/// <param name="info"></param>
		void Deduct(DeductStockInfo[] info);

		/// <summary>
		/// 客戶自行退訂尚未出貨的訂單時，自動加回庫存量
		/// </summary>
		/// <param name="info"></param>
		void Revise(ReviseStockInfo[] info);
	}
}
