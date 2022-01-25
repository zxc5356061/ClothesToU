using ClothesToU.Site.Models.EFModels;
using ClothesToU.Site.Models.Entities;
using ClothesToU.Site.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.Extensions
{
    public static partial class MemberEntityExt
    {
        public static Member ToEFMember(this MemberEntity source)
        {
            return new Member
            {
                Account = source.Account,
                Password = source.Password,
                Name = source.Name,
                Mobile = source.Mobile,
                Address = source.Address,
            };
        }

        public static EditProfileVM ToEditProfileVM(this MemberEntity source)
        {
            return new EditProfileVM
            {
                Id = source.Id,
                Account = source.Account,
                Name = source.Name,
                Mobile = source.Mobile,
                Address = source.Address
            };
        }
    }
}