using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.BackEnd.Site.Models.Entities
{
	public class ProdEntity
	{
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public int Stock { get; set; }

       
        public string FileName { get; set; }

        public bool Status { get; set; }

     
        public string Size { get; set; }

        public string Color { get; set; }

        public DateTime ModifiedTime { get; set; }


    }
}