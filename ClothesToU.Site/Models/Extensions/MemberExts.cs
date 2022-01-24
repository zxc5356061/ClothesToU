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
        public static MemberEntity ToMemberEntity(this Member source)
        {
            return new MemberEntity
            {
                Id = source.Id,
                Account = source.Account,
                Name = source.Name,
                Mobile = source.Mobile,
                Address = source.Address,
                ConfirmCode = source.ConfirmCode,
                Password = source.Password//EncryptedPassword 
            };
        }
    }
}