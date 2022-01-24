using ClothesToU.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesToU.Site.Models.Core.Interfaces
{
    public interface IEditMemberDataRepository
    {
		//for updating general member data except password
		MemberEntity Load(string account);
		void Update(MemberEntity entity);

		//for updating password
		//MemberEntity Load(int memberId);
		void UpdatePassword(int memberId, string encryptedPassword);
	}
}
