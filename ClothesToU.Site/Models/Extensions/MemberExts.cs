using ClothesToU.Site.Models.EFModels;
using ClothesToU.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.Extensions
{
    public static partial class MemberExts
    {
        public static MemberEntity ToMemberEntity(this Member entity)
        {
            if (entity == null) return null;

            return new MemberEntity
            {
                Id = entity.Id,
                Account = entity.Account,
                Password = entity.Password,//EncryptedPassword
                Name = entity.Name,
                IsConfirmed = entity.IsConfirmed,
                ConfirmCode = entity.ConfirmCode,
                Mobile = entity.Mobile,
                Address = entity.Address,
            };
        }
    }
}