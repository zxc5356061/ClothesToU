using ClothesToU.Site.Models.Core.Interfaces;
using ClothesToU.Site.Models.EFModels;
using ClothesToU.Site.Models.Entities;
using ClothesToU.Site.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.Repositories
{
    public class EditMemberDataRepository : IEditMemberDataRepository
    {
        private AppDbContext db = new AppDbContext();
        public MemberEntity Load(string account)
        {
            return db.Members.SingleOrDefault(x => x.Account == account)
                             .ToMemberEntity();
        }

        public MemberEntity Load(int memberId)
        {
            throw new NotImplementedException();
        }

        public void Update(EditProfileEntity entity)
        {
            throw new NotImplementedException();
        }

        public void UpdatePassword(int memberId, string encryptedPassword)
        {
            throw new NotImplementedException();
        }
    }
}