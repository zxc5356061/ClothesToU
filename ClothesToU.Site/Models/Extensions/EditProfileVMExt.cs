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
        public static EditProfileRequest ToEditProfileRequest(this EditProfileVM source, string currentAccount)
        {
            return new EditProfileRequest
            {
                Id = source.Id,
                Account = currentAccount,
                Name = source.Name,
                IsConfirmed = source.IsConfirmed,
                ConfirmCode = source.ConfirmCode,
                Mobile = source.Mobile,
                Address = source.Address,
            };
        }
    }
}