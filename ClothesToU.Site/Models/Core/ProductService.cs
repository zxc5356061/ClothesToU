using ClothesToU.Site.Models.Core.Interfaces.CartInterfaces;
using ClothesToU.Site.Models.Entities.CartEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.Core
{
	public class ProductService
	{
		private readonly IProductRepository _repository;

		public ProductService(IProductRepository repository)
		{
			_repository = repository;
		}

		public IEnumerable<ProductEntity> SearchActiveProducts(int? categoryId, string productName)
			=> _repository.Search(categoryId, productName, true);

		public ProductEntity LoadActiveProduct(int productId)
			=> _repository.Load(productId, true);
	}
}