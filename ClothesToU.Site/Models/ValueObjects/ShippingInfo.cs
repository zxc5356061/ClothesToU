using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.ValueObjects
{
    public class ShippingInfo
    {
        public string Recipient { get; set; }
        public string ShippingAddress { get; set; }
        public string RecipientMobile { get; set; }
    }
}