using ClothesToU.Site.Models.UseCases.Login;
using ClothesToU.Site.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.Extensions
{
    public static partial class LoginVMExt
    {
        public static LoginRequest ToLoginRequest(this LoginVM source)
        {
            return new LoginRequest
            {
                Account = source.Account,
                Password = source.Password,
            };
        }
    }
}