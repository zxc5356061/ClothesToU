using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.ValueObjects
{
    public class CreateOrderRequest
    {
        public int CustomerId { get; set; }
        public List<CreateOrderItem> Items { get; set; }
        public int Total /*=> Items.Sum(x => x.SubTotal);*/
        {
            get
            {
                return Items.Sum(CreateOrderItem => CreateOrderItem.SubTotal);
            }
        }
        public ShippingInfo ShippingInfo { get; set; }
    }
}