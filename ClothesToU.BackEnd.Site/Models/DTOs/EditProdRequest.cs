using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.BackEnd.Site.Models.DTOs
{
	public class EditProdRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string FileName { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }

    }
}