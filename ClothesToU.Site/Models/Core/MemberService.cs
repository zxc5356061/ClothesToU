using ClothesToU.Site.Models.Core.Interfaces;
using ClothesToU.Site.Models.Entities;
using ClothesToU.Site.Models.Infrastractures;
using ClothesToU.Site.Models.Repositories;
using ClothesToU.Site.Models.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesToU.Site.Models.Core
{
	public class MemberService
	{
		private readonly IRegisterRepository registerRepository;
		private readonly ILoginRepository loginRepository;
		public MemberService()
		{
			this.registerRepository = new RegisterRepository();
			this.loginRepository = new LoginRepository();
		}
		public MemberService(IRegisterRepository _registerRepository)
		{
			this.registerRepository = _registerRepository;
		}
		public MemberService(ILoginRepository _loginRepository)
		{
			this.loginRepository = _loginRepository;
		}



		public RegisterResponse CreateNewMember(RegisterRequest request)
		{
			// 判斷帳號是否已存在
			if (registerRepository.IsExist(request.Account))
			{
				return new RegisterResponse
				{
					IsSuccess = false,
					ErrorMessage = "此帳號已經存在"
				};
			}

			// 真正地建立一個會員記錄
			//	 建立 ConfirmCode
			//	 叫用 IRepo 進行建檔工作
			string confirmCode = Guid.NewGuid().ToString("N");
			RegisterEntity registerEntity = new RegisterEntity
			{
				Account = request.Account,
				Password = request.Password,
				Name = request.Name,
				Mobile = request.Mobile,
				Address = request.Address,
				ConfirmCode = confirmCode,
			};
			registerRepository.Create(registerEntity);

			return new RegisterResponse
			{
				IsSuccess = true,
				Data = registerEntity
			};

		}

		public bool IsValid(string account, string password)
        {
			LoginEntity member = loginRepository.Load(account);//去撈資料庫的會員資料。
			string inputPassword = HashUtility.ToSHA256(password, SaltEntity.SALT);
			if (member == null) { return false; }//如果會員不存在。
			if (member.EncryptedPassword == inputPassword) { return true; }//如果會員存在，且密碼正確。
			return false;
		}

		public string ProcessLogin(string account, bool rememberMe, out HttpCookie cookie)
        {
			throw new NotImplementedException();
		}
	}
}