using ClothesToU.Site.Models.Core;
using ClothesToU.Site.Models.Extensions;
using ClothesToU.Site.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.UseCases
{
    public class RegisterCommand
    {
        public RegisterResponse Execute(RegisterVM registerVM)
        {
            var service = new MemberService();
            RegisterRequest request = registerVM.ToRegisterRequest();
            RegisterResponse response = service.CreateNewMember(request);

            return response;
        }
    }
}