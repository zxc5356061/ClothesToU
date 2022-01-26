using ClothesToU.BackEnd.Site.Models.DTOs;
using ClothesToU.BackEnd.Site.Models.Entities;
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
			ProdEntity entity = new ProdEntity
			{
				Name = request.Name,
				Description = request.Description,
				CategoryId = request.CategoryId,
				Price = request.Price,
				FileName = request.FileName,
				Size = request.Size,
				Color = request.Color,
				ModifiedTime = DateTime.Now,
			};
			_repo.Create(entity);




		}

		public void Update(EditProdRequest request)
		{
			ProdEntity entity = this._repo.Load(request.Id);

			entity.Name = request.Name;
			entity.Description = request.Description;
			entity.CategoryId = request.CategoryId;
			entity.Price = request.Price;
			entity.FileName = request.FileName;
			entity.Size = request.Size;
			entity.Color = request.Color;
			entity.ModifiedTime = DateTime.Now;
			_repo.Update(entity);
		
		}


		public void Delete(int prodId)
		{
			this._repo.Delete(prodId);
		}
		
	}
}