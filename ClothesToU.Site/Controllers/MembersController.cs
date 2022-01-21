using ClothesToU.Site.Models.UseCases;
using ClothesToU.Site.Models.ViewModels;
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
        // GET: Members
        public ActionResult Index()
        {
            return View();
        }

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
            throw new NotImplementedException();
        }
    }
}