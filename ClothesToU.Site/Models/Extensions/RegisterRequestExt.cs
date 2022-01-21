using ClothesToU.Site.Models.Entities;
using ClothesToU.Site.Models.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.Extensions
{
    public static partial class RegisterRequestExt
    {
        public static RegisterEntity ToRegisterEntity(this RegisterRequest source)
        {
            return new RegisterEntity
            {
                Account = source.Account,
                Password = source.Password,
                Name = source.Name,
                Mobile = source.Mobile,
                Address = source.Address,
            };
        }
    }
}