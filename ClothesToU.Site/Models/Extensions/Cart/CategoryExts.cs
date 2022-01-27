using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.Extensions.Cart
{
    public static partial class CategoryExts
    {
        public static CategoryEntity ToCategoryEntity(this Category source)
        {
            return new CategoryEntity
            {
                Id = source.Id,
                Name = source.Name,
                DisplayOrder = source.DisplayOrder,
            };
        }
    }
}