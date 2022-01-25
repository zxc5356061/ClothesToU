using ClothesToU.Site.Models.Core.Interfaces;
using ClothesToU.Site.Models.Entities;
using ClothesToU.Site.Models.Extensions;
using ClothesToU.Site.Models.Infrastractures;
using ClothesToU.Site.Models.Repositories;
using ClothesToU.Site.Models.UseCases;
using ClothesToU.Site.Models.UseCases.EditProfile;
using ClothesToU.Site.Models.UseCases.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;

namespace ClothesToU.Site.Models.Core
{
	public class MemberService
	{
		private readonly IRegisterRepository registerRepository;
		private readonly ILoginRepository loginRepository;
		private readonly IEditMemberDataRepository editMemberDataRepository;
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
		public MemberService(IEditMemberDataRepository _editMemberDataRepository)
        {
			this.editMemberDataRepository = _editMemberDataRepository;

		}


		//New Register
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
			MemberEntity registerEntity = new MemberEntity
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

		}//New Register_end

		//Member Login
		public bool IsValid(LoginRequest request)
        {
			LoginEntity member = loginRepository.Load(request.Account);//去撈資料庫的會員資料。
			string passwordcheck = HashUtility.ToSHA256(request.Password, SaltEntity.SALT);
			if (member == null) { return false; }//如果會員不存在。
			if (member.EncryptedPassword == passwordcheck) { return true; }//如果會員存在，且密碼正確。
			return false;
		}

		//手寫以下內容手動抓取cookies
		//ASP.NET Application life cycle
		public string ProcessLogin(string account, bool rememberMe, out HttpCookie cookie)
        {
			//Refer to Global.asax.cs
			//將userID, Level存到Cookie中

			////取得目前的使用者屬於哪個群組 >若要加入UserRoles，則DTO, Entities與Extensions都要加property
			//string userRoles = loginRepository.Load(account).Roles;//Get user roles from EmployeeEntity
			
			//建立一張認證票
			FormsAuthenticationTicket ticket = new FormsAuthenticationTicket
												(
													1,                          //版本別，沒特別用處
													account,
													DateTime.Now,               //ticket發行日
													DateTime.Now.AddDays(2),    //ticket到期日
													rememberMe,                 //是否續存
													//userRoles,                //使用者資料
													"/"                         //cookie位置
												);
			//將cookie加密
			string value = FormsAuthentication.Encrypt(ticket);
			//存入cookie
			cookie = new HttpCookie(FormsAuthentication.FormsCookieName, value);
			//導引回目的地的網頁
			string url = FormsAuthentication.GetRedirectUrl(account, true); //第2個參數沒用
			return url;
		}//Member Login_end

		public void EditProfile(EditProfileRequest request)
        {
			
			// 取得在db裡的原始記錄
			MemberEntity entity = editMemberDataRepository.Load(request.Account);
			//if (entity == null) throw new Exception("找不到要修改的會員記錄");

			//更新紀錄
			entity.Name = request.Name;
			entity.Address = request.Address;
			entity.Mobile = request.Mobile;
			entity.Account = request.Account;

			editMemberDataRepository.Update(entity);
		}
	}
}