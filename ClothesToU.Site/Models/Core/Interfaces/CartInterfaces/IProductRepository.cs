﻿using ClothesToU.Site.Models.Entities.CartEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesToU.Site.Models.Core.Interfaces.CartInterfaces
{
	public interface IProductRepository
	{
		/// <summary>
		/// 篩選商品
		/// </summary>
		/// <param name="categoryId"></param>
		/// <param name="productName"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		IEnumerable<ProductEntity> Search(int? categoryId, string productName, bool? status);

		/// <summary>
		/// 傳回一筆商品
		/// </summary>
		/// <param name="productId"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		ProductEntity Load(int productId, bool? status);
	}
}
