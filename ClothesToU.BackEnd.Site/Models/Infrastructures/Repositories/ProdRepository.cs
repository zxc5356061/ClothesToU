using ClothesToU.BackEnd.Site.Models.EFModels;
using ClothesToU.BackEnd.Site.Models.Entities;
using ClothesToU.BackEnd.Site.Models.Infrastructures.ExtMethods;
using ClothesToU.BackEnd.Site.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.BackEnd.Site.Models.Infrastructures.Repositories
{
	public class ProdRepository : IProdRepository
	{
		private AppDbContext db = new AppDbContext();
		public void Create(ProdEntity entity)
		{
			db.Products.Add(entity.ToProd());
			db.SaveChanges();
		}

		public void Delete(int prodId)
		{
			var model=db.Products.Find(prodId);
			if (model == null) return;
		}

		public ProdEntity Load(int prodId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ProdEntity> Search(string name, string description)
		{
			throw new NotImplementedException();
		}

		public void Update(ProdEntity entity)
		{
			throw new NotImplementedException();
		}
	}
}