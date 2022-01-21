using ClothesToU.Site.Models.Core.Interfaces;
using ClothesToU.Site.Models.Entities;
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
		private readonly IRegisterRepository repository;
		public MemberService()
		{
			this.repository = new RegisterRepository();
		}
		public MemberService(IRegisterRepository repo)
		{
			this.repository = repo;
		}

		public RegisterResponse CreateNewMember(RegisterRequest request)
		{
			// 判斷帳號是否已存在
			if (repository.IsExist(request.Account))
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
			repository.Create(registerEntity);

			return new RegisterResponse
			{
				IsSuccess = true,
				Data = registerEntity
			};

		}
	}
}