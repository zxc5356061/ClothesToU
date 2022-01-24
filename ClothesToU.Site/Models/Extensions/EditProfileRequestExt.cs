using ClothesToU.Site.Models.Entities;
using ClothesToU.Site.Models.UseCases.EditProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.Extensions
{
    public static partial class EditProfileRequestExt
    {
        public static MemberEntity ToMemberEntity(this EditProfileRequest source)
        {
            return new MemberEntity
            {
                Account = source.Account,
                Name = source.Name,
                IsConfirmed = source.IsConfirmed,
                ConfirmCode = source.ConfirmCode,
                Mobile = source.Mobile,
                Address = source.Address,
            };
        }
    }
}