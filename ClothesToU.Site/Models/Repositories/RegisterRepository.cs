using ClothesToU.Site.Models.Core.Interfaces;
using ClothesToU.Site.Models.EFModels;
using ClothesToU.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        private AppDbContext db = new AppDbContext();

        public bool IsExist(string account)
        {
            Member entity = db.Members.SingleOrDefault(member => member.Account == account);
            bool result = entity == null ? false : true;
            return result;
        }

        public void Create(RegisterEntity entity)
        {
            Member member = new Member
            {
                Account = entity.Account,
                Password = entity.EncryptedPassword,
                Name = entity.Name,
                Mobile = entity.Mobile,
                Address = entity.Address,
                IsConfirmed = true,//待日後實作信件驗證再修改
                ConfirmCode = entity.ConfirmCode
            };
            db.Members.Add(member);
            db.SaveChanges();
        }
    }
}