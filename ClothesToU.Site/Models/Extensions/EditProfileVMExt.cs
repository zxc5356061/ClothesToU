using ClothesToU.Site.Models.UseCases.EditProfile;
using ClothesToU.Site.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.Extensions
{
    public static partial class EditProfileVMExt
    {
        public static EditProfileRequest ToEditProfileRequest(this EditProfileVM source, string currentUserAccount)
        {
            return new EditProfileRequest
            {
                CurrentUserAccount = currentUserAccount,
                Account = source.Account,
                Name = source.Name,
                Mobile = source.Mobile,
                Address = source.Address,
            };
        }
    }
}