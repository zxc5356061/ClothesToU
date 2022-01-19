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
			db.Products.Remove(model);
			db.SaveChanges();
		}

		public ProdEntity Load(int prodId)
		{
			var model = db.Products.Find(prodId);
			return model==null?null:model.ToEntity();
		}

		public IEnumerable<ProdEntity> Search(string name, string description)
		{
			var query=db.Products.AsQueryable();
			if(!string.IsNullOrEmpty(name))
			{
				query=query.Where(x=>x.Name.Contains(name));
			}
			if(!string.IsNullOrEmpty(description))
			{
				query=query.Where(x=>x.Description.Contains(description));
			}


			var data=query.OrderBy(x=>x.Name).ToList();
			var result=data.Select(x=>x.ToEntity());
			return result;

		}

		public void Update(ProdEntity entity)
		{
			Product model = db.Products.Find(entity.Id);
			 if(model== null) return;

			model.Name = entity.Name;
			model.Description = entity.Description;
			model.Stock = entity.Stock;
			model.Price = entity.Price;
			model.Size=entity.Size;
			model.Color=entity.Color;
			model.CategoryId=entity.CategoryId;

			db.SaveChanges();
		}
	}
}