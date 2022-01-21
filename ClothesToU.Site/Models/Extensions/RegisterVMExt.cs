using ClothesToU.Site.Models.UseCases;
using ClothesToU.Site.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.Extensions
{
    public static partial class RegisterVMExt
    {
        public static RegisterRequest ToRegisterRequest(this RegisterVM source)
        {
            return new RegisterRequest
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