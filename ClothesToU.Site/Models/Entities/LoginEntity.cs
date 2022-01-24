using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.Entities
{
    public class LoginEntity
    {
        public string Account { get; set; }
        public string EncryptedPassword { get; set; }
        //public string Roles { get; set; }

    }
}