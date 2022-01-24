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
            //Controller直接存取Repository，不佳(?
            string currentUserAccount = User.Identity.Name;//Get data from IPrincipal

            MemberEntity entity = editMemberDataRepository.Load(currentUserAccount);
            EditProfileVM model = entity.ToEditProfileVM();

            return View(model);
        }

        //[Authorize]
        //[HttpPost]
        //public ActionResult EditProfile(EditProfileVM model)
        //{
        //    if (ModelState.IsValid == false)
        //    {
        //        return View(model);
        //    }


        //}

    }
}