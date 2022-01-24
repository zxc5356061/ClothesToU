using ClothesToU.BackEnd.Site.Models.Infrastructures.ExtMethods;
using ClothesToU.BackEnd.Site.Models.Infrastructures.Repositories;
using ClothesToU.BackEnd.Site.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothesToU.Site.Controllers
{
    public class FrontProductsController : Controller
    {
        private ProdService service;
        private BackEnd.Site.Models.Interfaces.IProdRepository repository;
        public FrontProductsController()
        {
            service = new ProdService();
            repository = new ProdRepository();
        }
        public ActionResult Index2()
        {
            var data = repository
                .Search(null, null)
                .Select(x => x.ToIndexVM());

            return View(data);
        }
    }
}