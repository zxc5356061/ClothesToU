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

        public void Update(MemberEntity entity)
        {
            //Member account is not allowed to be amended.
            //Member password amending is implemented in "UpdatePassword" function.
            Member member = db.Members.Find(entity.Id);
            member.Account = entity.Account;
            member.Name = entity.Name;
            member.IsConfirmed = entity.IsConfirmed;
            member.ConfirmCode = entity.ConfirmCode;
            member.Mobile = entity.Mobile;
            member.Address = entity.Address;
            db.SaveChanges();
        }


        public MemberEntity Load(int memberId)
        {
            throw new NotImplementedException();
        }
        public void UpdatePassword(int memberId, string encryptedPassword)
        {
            throw new NotImplementedException();
        }
    }
}