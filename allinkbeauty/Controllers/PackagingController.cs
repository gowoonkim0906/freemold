﻿using Freemold.Modules;
using Freemold.Modules.Models;
using Freemold.Modules.Services;
using Microsoft.AspNetCore.Mvc;

namespace allinkbeauty.Controllers
{
    public class PackagingController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICodeService _codeService;
        private readonly IAllinkbeautyService _allinkbeautyService;
        private readonly IFileService _fileService;

        public PackagingController(ILogger<HomeController> logger, ICodeService codeService, IAllinkbeautyService allinkbeautyService, IFileService fileService)
        {
            _logger = logger;
            _codeService = codeService;
            _allinkbeautyService = allinkbeautyService;
            _fileService = fileService;
        }
        public async Task<IActionResult> Index(int page = 1, string code1 = "", string code2 = "", string volume1 = "", string volume2 = "")
        {
            List<TbCategory> categorylist = new List<TbCategory>();
            categorylist = await _codeService.GetCategoryList("A001", "Y");

            List<TbCategory> categorylist2 = new List<TbCategory>();
            if(code1 != "") {
                categorylist2 = await _codeService.GetCategoryList(code1, "Y");
            }

            List<TbCode> codelist = new List<TbCode>();
            codelist = await _codeService.GetCodeList("용량");


            ViewBag.categorylist = categorylist;
            ViewBag.categorylist2 = categorylist2;
            ViewBag.codelist = codelist;

            ViewBag.filepath = _fileService.RootPath;
            ViewBag.page = page;
            ViewBag.code1 = code1;
            ViewBag.code2 = code2;
            ViewBag.volume1 = volume1;
            ViewBag.volume2 = volume2;

            return View();
        }

        public async Task<JsonResult> PackagingList(int page = 1, string category1 = "" , string category2 = "", string volume1 = "", string volume2 = "")
        {
            int pagesize = 16;
            int pageno = (page - 1) * pagesize;
            int totalcount = 0;


            List<KbeautyProductModel> list = new List<KbeautyProductModel>();
            list = await _allinkbeautyService.KbeautyProductList("A001",category1, category2, volume1, volume2); //프리몰드 A001

            totalcount = list == null ? 0 : list.Count;
            var items = list?.Skip(pageno).Take(pagesize).ToList();


            return Json(new { item1 = "success", item2 = items , item3 = page, item4 = pagesize, item5 = totalcount });
        }

        public async Task<JsonResult> CategoryList(string ACode)
        {

            List<TbCategory> categorylist = new List<TbCategory>();
            categorylist = await _codeService.GetCategoryList(ACode, "Y");

            return Json(new { Item1 = "success", Item2 = categorylist });
        }



        public async Task<IActionResult> PackagingInfo(long produid, int page, string code1, string code2, string volume1, string volume2)
        {
            
            KbeautyProductModel productinfo = new KbeautyProductModel();

            productinfo =  await _allinkbeautyService.KbeautyProductView(produid);


            ViewBag.productinfo = productinfo;  
            ViewBag.page = page;
            ViewBag.code1 = code1;
            ViewBag.code2 = code2;    
            ViewBag.volume1 = volume1;  
            ViewBag.volume2 = volume2;  

            return View();
        }

    }
}
