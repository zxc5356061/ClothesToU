using ClothesToU.BackEnd.Site.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.BackEnd.Site.Models.DTOs
{
	public class CreateProdRequest
	{
		public string Name { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string FileName { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }

    }

    public static class ProdCreateExts
	{
        public static CreateProdRequest  ToRequest(this ProdCreateVM source)
		{
            return new CreateProdRequest
            {
                Name = source.Name,
                Description = source.Description,
                Price = source.Price,
                FileName = source.FileName,
                Size = source.Size,
                Color = source.Color,
                CategoryId = source.CategoryId,
            };
		}

    }

}