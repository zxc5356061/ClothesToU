using ClothesToU.BackEnd.Site.Models.EFModels;
using ClothesToU.BackEnd.Site.Models.Entities;
using ClothesToU.BackEnd.Site.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.BackEnd.Site.Models.Infrastructures.ExtMethods
{
	public static class ProdEntityExts
	{
		public static Product ToProd(this ProdEntity source)
			=> new Product
			{
				
				Name = source.Name,
				Description = source.Description,
				FileName = source.FileName,
				Price = source.Price,
				Size = source.Size,
				Color = source.Color,
				ModifiedTime = source.ModifiedTime

			};
		public static ProdIndexVM ToIndexVM(this ProdEntity source)
			=> new ProdIndexVM
			{
				Id = source.Id,
				Name = source.Name,
				Description = source.Description,
				ModifiedTime = source.ModifiedTime,
				FileName = source.FileName,
				Color=source.Color,
				Size=source.Size,
				Stock=source.Stock,
				Status=source.Status,
				Price=source.Price,
			};


	}
}