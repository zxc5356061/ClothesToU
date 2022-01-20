using ClothesToU.BackEnd.Site.Models.Infrastructures.ExtMethods;
using ClothesToU.BackEnd.Site.Models.Infrastructures.Repositories;
using ClothesToU.BackEnd.Site.Models.Interfaces;
using ClothesToU.BackEnd.Site.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothesToU.BackEnd.Site.Controllers
{
    public class ProductsController : Controller
    {

        private ProdService service;
        private IProdRepository repository;
        public ProductsController()
		{
            service = new ProdService();
            repository = new ProdRepository();
		}

        
        public ActionResult Index(string name,string description)
        {
            var data=repository
                .Search(name, description)
                .Select(x => x.ToIndexVM());

            ViewBag.C_Name =name;
            ViewBag.C_Description = description;
            return View(data);
        }

       
    }
}