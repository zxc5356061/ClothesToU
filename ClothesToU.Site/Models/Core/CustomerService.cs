using ClothesToU.Site.Models.Core.Interfaces.CartInterfaces;
using ClothesToU.Site.Models.Entities.CartEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.Core
{
	public class CustomerService
	{
		private readonly ICustomerRepository _repository;

		public CustomerService(ICustomerRepository repository)
		{
			_repository = repository;
		}

		public CustomerEntity Load(string customerAccount)
			=> _repository.IsExists(customerAccount)
				? Load(customerAccount)
				: throw new Exception("找不到有權限購物的客戶資訊");

		public int GetCustomerId(string customerAccount)
			=> Load(customerAccount).Id;
	}
}