using ClothesToU.Site.Models.Core;
using ClothesToU.Site.Models.Extensions;
using ClothesToU.Site.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.UseCases.Login
{
    public class LoginCommand
    {
        public LoginResponse Execute(LoginVM loginVM)
        {
            var service = new MemberService();
            
            LoginRequest request = loginVM.ToLoginRequest();

            return new LoginResponse
            {
                IsSuccess = service.IsValid(request),
            };
        }

        public string ToProcessLogin(string account, bool rememberMe, out HttpCookie cookie)
        {
            MemberService getURL = new MemberService();
            return getURL.ProcessLogin(account, rememberMe, out cookie).ToString();
            
        }
    }
}