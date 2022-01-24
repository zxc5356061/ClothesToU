using ClothesToU.Site.Models.UseCases.EditProfile;
using ClothesToU.Site.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.Extensions
{
    public static partial class EditProfileResponseExt
    {
        public static EditProfileVM ToEditProfileVM(this EditProfileResponse source)
        {
            return new EditProfileVM
            {
                Id = source.Data.Id,
                Account = source.Data.Account,
                Name = source.Data.Name,
                IsConfirmed = source.Data.IsConfirmed,
                ConfirmCode = source.Data.ConfirmCode,
                Mobile = source.Data.Mobile,
                Address = source.Data.Address,
            };
        }
    }
}