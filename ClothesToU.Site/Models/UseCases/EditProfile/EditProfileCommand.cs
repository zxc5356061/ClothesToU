using ClothesToU.Site.Models.Core;
using ClothesToU.Site.Models.Entities;
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
            MemberEntity result = service.EditProfile(request);
            if (result == null)
            {
                throw new Exception("找不到要修改的會員記錄");
            }

            return new EditProfileResponse
            {
                IsSuccess = true,
                Data = service.EditProfile(request)
            };
        }
    }
}