using ClothesToU.Site.Models.EFModels;
using ClothesToU.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.Extensions
{
    public static partial class RegisterEntityExt
    {
        public static Member ToEFMember(this RegisterEntity source)
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
    }
}