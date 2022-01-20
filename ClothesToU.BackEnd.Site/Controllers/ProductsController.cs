using ClothesToU.BackEnd.Site.Models.DTOs;
using ClothesToU.BackEnd.Site.Models.Infrastructures.ExtMethods;
using ClothesToU.BackEnd.Site.Models.Infrastructures.Repositories;
using ClothesToU.BackEnd.Site.Models.Interfaces;
using ClothesToU.BackEnd.Site.Models.Services;
using ClothesToU.BackEnd.Site.Models.ViewModels;
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

        public ActionResult Create()
		{
            return View();
		}

        [HttpPost]
        public ActionResult Create(ProdCreateVM model,HttpPostedFileBase file)
		{

            //檢查有沒有上傳檔案(必填)
            if (file== null ||file.FileName==null || file.ContentLength==0)
			{
                ModelState.AddModelError("FileName", "檔案必填");
                return View(model);
			}
            //將檔案儲存，得知實際黨名
            string path = Server.MapPath("~/Files/");
            string newFileName = SaveFile(file, path);

            //將新增名存到model
            model.FileName = newFileName;
            //新增紀錄
            service.Create(model.ToRequest());
            //redirect to Index頁
            return RedirectToAction("Index");
		}

        private string SaveFile(HttpPostedFileBase file,string path)
		{
            string ext=System.IO.Path.GetExtension(file.FileName);
            string targetFileName=Guid.NewGuid().ToString("N")+ext;
            string fullName=System.IO.Path.Combine(path,targetFileName);
            file.SaveAs(fullName);
            return targetFileName;
        }

    }
}