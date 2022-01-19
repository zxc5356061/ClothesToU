using ClothesToU.BackEnd.Site.Models.Infrastructures.Repositories;
using ClothesToU.BackEnd.Site.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.BackEnd.Site.Models.Services
{
	public class ProdService
	{
		private readonly IProdRepository _repo;
		public ProdService()
		{
			this._repo = new ProdRepository();
		}
		public ProdService(IProdRepository repo)
		{
			_repo = repo;
		}
		public void Create(CreateProdRequest request)
		{

		}
	}
}