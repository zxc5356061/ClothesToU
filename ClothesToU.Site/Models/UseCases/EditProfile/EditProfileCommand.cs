using ClothesToU.Site.Models.Core;
using ClothesToU.Site.Models.Extensions;
using ClothesToU.Site.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.UseCases.EditProfile
{
    public class EditProfileCommand
    {
        public EditProfileResponse Execute(EditProfileVM editProfileVM)
        {
            var service = new MemberService();
            //Request
            EditProfileRequest request = editProfileVM.ToEditProfileRequest();

            //Response
            if(service.EditProfile(request) == null)
            {
                return new EditProfileResponse
                {
                    IsSuccess = false,
                };
            }
            else
            {
                return new EditProfileResponse
                {
                    IsSuccess = true,
                    Data = service.EditProfile(request)
                };
            }
        }
    }
}