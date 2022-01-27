using ClothesToU.Site.Models.Core.Interfaces.CartInterfaces;
using ClothesToU.Site.Models.EFModels;
using ClothesToU.Site.Models.Entities.CartEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.Repositories.CartRepositories
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly AppDbContext _db;

		public CustomerRepository(AppDbContext db)
		{
			_db = db;
		}

		/// <summary>
		/// 有權限在本網站購物的會員才傳回true
		/// </summary>
		/// <param name="customerAccount"></param>
		/// <returns></returns>
		public bool IsExists(string customerAccount)
		{
			var member = _db.Members.SingleOrDefault(x => x.IsConfirmed == true && x.Account == customerAccount);

			return member != null;
		}

		public int GetCustomerId(string customerAccount)
			=> _db.Members.Single(x =>
														x.IsConfirmed == true &&
														x.Account == customerAccount).Id;

		public CustomerEntity Load(string customerAccount)
			=> _db.Members.Single(x =>
														x.IsConfirmed == true &&
														x.Account == customerAccount)
														.ToCustomerEntity();
	}
}