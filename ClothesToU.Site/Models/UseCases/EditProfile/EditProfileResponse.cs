using ClothesToU.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.UseCases.EditProfile
{
    public class EditProfileResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public MemberEntity Data { get; set; }
    }
}