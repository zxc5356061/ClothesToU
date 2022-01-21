using ClothesToU.Site.Models.Core.Interfaces;
using ClothesToU.Site.Models.EFModels;
using ClothesToU.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        //Constructor
        private AppDbContext db;
        public LoginRepository()
        {
            this.db = new AppDbContext();
        }
        //
        //Get data from EF model objects into Entity object
        public LoginEntity Load(string account)
        {
            Member member = db.Members.SingleOrDefault(x => x.Account == account);
            if (member == null) return null;

            return new LoginEntity
            {
                Account = member.Account,
                Password = member.Password//EncryptedPassword
            };
        }
    }
}