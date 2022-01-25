using ClothesToU.Site.Models.Core.Interfaces;
using ClothesToU.Site.Models.Entities;
using ClothesToU.Site.Models.Repositories;
using ClothesToU.Site.Models.UseCases;
using ClothesToU.Site.Models.UseCases.Login;
using ClothesToU.Site.Models.ViewModels;
using ClothesToU.Site.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ClothesToU.Site.Models.UseCases.EditProfile;
using ClothesToU.Site.Models.Core;

namespace ClothesToU.Site.Controllers
{
    public class MembersController : Controller
    {
        IEditMemberDataRepository editMemberDataRepository = new EditMemberDataRepository();
        
        // GET: Members
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid == false)
            {
                return View(registerVM);
            }

            RegisterCommand command = new RegisterCommand();
            RegisterResponse response = command.Execute(registerVM);
            if (response.IsSuccess == true)
            {
                // 建檔成功 redirect to confirm page
                return View("RegisterConfirm");
            }
            else
            {
                ModelState.AddModelError(string.Empty, response.ErrorMessage);
                return View(registerVM);
            }

        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM loginVM)
        {
            LoginCommand loginCommand = new LoginCommand();
            if (loginCommand.Execute(loginVM).IsSuccess == true)
            {
                // 記住登入成功的會員
                var rememberMe = false;
                string returnUrl = loginCommand.ToProcessLogin(loginVM.Account, rememberMe, out HttpCookie cookie);
                Response.Cookies.Add(cookie);
                return Redirect(returnUrl);
            }

            ModelState.AddModelError(string.Empty, "您的帳號或密碼有誤!");
            return this.View();
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult EditProfile()
        {
            string currentUserAccount = User.Identity.Name;//Get data from IPrincipal

            MemberEntity entity = editMemberDataRepository.Load(currentUserAccount);
            EditProfileVM model = entity.ToEditProfileVM();

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditProfile(EditProfileVM model)
        {
            string currentUserAccount = User.Identity.Name;
            MemberService service = new MemberService();

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            EditProfileRequest request = model.ToEditProfileRequest(currentUserAccount);
            // 取得在db裡的原始記錄
            //MemberEntity entity = editMemberDataRepository.Load(request.CurrentUserAccount);
            //if (entity == null) throw new Exception("找不到要修改的會員記錄");
            
            try
            {
                ////更新紀錄
                //entity.Name = request.Name;
                //entity.Address = request.Address;
                //entity.Mobile = request.Mobile;
                //entity.Account = request.Account;

                //editMemberDataRepository.Update(entity);
                service.EditProfile(request);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            if (ModelState.IsValid == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }

        }

    }
}