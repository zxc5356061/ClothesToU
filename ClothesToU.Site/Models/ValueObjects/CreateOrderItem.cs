using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.ValueObjects
{
    public class CreateOrderItem
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Price { get; set; }

        public int Qty { get; set; }

        public int SubTotal /*=> Price * Qty;*/
        {
            get
            {
                return  Price * Qty;
            }
        }
    }
}