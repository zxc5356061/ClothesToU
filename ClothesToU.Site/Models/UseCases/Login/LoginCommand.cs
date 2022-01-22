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

            LoginResponse response = new LoginResponse();
            response.IsSuccess = service.IsValid(request);

            return response;
        }
    }
}