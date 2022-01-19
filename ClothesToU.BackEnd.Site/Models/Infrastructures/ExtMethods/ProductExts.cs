using ClothesToU.BackEnd.Site.Models.EFModels;
using ClothesToU.BackEnd.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.BackEnd.Site.Models.Infrastructures.ExtMethods
{
	public  static class ProductExts
	{
		public static ProdEntity ToEntity(this Product source)
			=> new ProdEntity
			{
				Id = source.Id,
				Name = source.Name,
				Description = source.Description,
				ModifiedTime = source.ModifiedTime,
				FileName = source.FileName,
				Color = source.Color,
				Size = source.Size,
				Stock = source.Stock,
				Status = source.Status,
				Price = source.Price,
			};
	}
}