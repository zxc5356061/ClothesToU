using ClothesToU.BackEnd.Site.Models.EFModels;
using ClothesToU.Site.Models.Core.Interfaces.CartInterfaces;
using ClothesToU.Site.Models.Entities.CartEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.Repositories.CartRepositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly AppDbContext _db;
		public ProductRepository(AppDbContext db)
		{
			_db = db;
		}

		public IEnumerable<ProductEntity> Search(int? categoryId, string productName, bool? status)
		{
			IEnumerable<Product> query = _db.Products;

			if (categoryId.HasValue) query = query.Where(x => x.CategoryId == categoryId);

			if (!string.IsNullOrEmpty(productName)) query = query.Where(x => x.Name.Contains(productName));

			if (status.HasValue) query = query.Where(x => x.Status == status);

			query = query.OrderBy(x => x.Name);

			return query.Select(x => x.ToEntity());
		}

		public ProductEntity Load(int productId, bool? status)
		{
			IEnumerable<Product> query = _db.Products
				.AsNoTracking()
				.Where(x => x.Id == productId);

			if (status.HasValue) query = query.Where(x => x.Status == status);

			Product product = query.SingleOrDefault();

			return product == null ? null : product.ToEntity();
		}
	}
}