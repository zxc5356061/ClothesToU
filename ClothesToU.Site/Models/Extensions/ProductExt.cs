using ClothesToU.Site.Models.EFModels;
using ClothesToU.Site.Models.Entities.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.Extensions
{
    public static partial class ProductExt
    {
        public static CartProductEntity ToCartProductEntity(this Product source)
        {
            return new CartProductEntity
            {
                Id = source.Id,
                Name = source.Name,
                Price = source.Price,
            };
        }
    }
}