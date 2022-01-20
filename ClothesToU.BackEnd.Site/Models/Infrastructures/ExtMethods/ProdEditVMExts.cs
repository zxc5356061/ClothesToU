using ClothesToU.BackEnd.Site.Models.DTOs;
using ClothesToU.BackEnd.Site.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.BackEnd.Site.Models.Infrastructures.ExtMethods
{
	public static class ProdEditVMExts
	
		{
			public static EditProdRequest ToRequest(this ProdEditVM source)
			{
				return new EditProdRequest
				{
					Id = source.Id,
					Name = source.Name,
					CategoryId = source.CategoryId,
					Description = source.Description,
					FileName = source.FileName,
					Color = source.Color,
					Size = source.Size,
					Price = source.Price,
				};
			}
		}
}