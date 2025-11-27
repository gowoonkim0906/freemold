using Freemold.Modules;
using Freemold.Modules.Common;
using Freemold.Modules.Models;
using Freemold.Modules.Repositories;
using Freemold.Modules.Services;
using ImageMagick;
using ImageMagick.Formats;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using standardmold.Admin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Web;
using allinkbeauty.Admin.Filters;


namespace standardmold.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAllinkbeautyService _allinkbeautyService;
        private readonly ICodeService _codeService;
        private readonly IFileService _fileService;

        public HomeController(ILogger<HomeController> logger, IAllinkbeautyService allinkbeautyService, ICodeService codeService, IFileService fileService)
        {
            _logger = logger;
            _allinkbeautyService = allinkbeautyService;
            _codeService = codeService;
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [LoginRequired]
        public IActionResult Statistics(DateTime? sDate = null, DateTime? eDate = null) {

            List<StatisticsModel> list1 = new List<StatisticsModel>();
            List<StatisticsHourModel> list2 = new List<StatisticsHourModel>();
            List<StatisticsRefererModel> list3 = new List<StatisticsRefererModel>();
            List<StatisticsCountryModel> list4 = new List<StatisticsCountryModel>();
            
            list1 = _allinkbeautyService.StatisticsList(sDate, eDate);
            list2 = _allinkbeautyService.StatisticsHourList(sDate, eDate);
            list3 = _allinkbeautyService.StatisticsRefererList(sDate, eDate);
            list4 = _allinkbeautyService.StatisticsCountryList(sDate, eDate);

            int datatotlacnt = list1.Sum(x => x.TotalCnt);
            int datamobile = list1.Sum(x => x.Mobile);
            int datapc = datatotlacnt - datamobile;


            ViewBag.sDate = sDate?.ToString("yyyy-MM-dd") ?? DateTime.Now.ToString("yyyy-MM-dd");
            ViewBag.eDate = eDate?.ToString("yyyy-MM-dd") ?? DateTime.Now.ToString("yyyy-MM-dd");
            ViewBag.datatotlacnt = datatotlacnt;
            ViewBag.datamobile = datamobile;
            ViewBag.datapc = datatotlacnt - datamobile;
            ViewBag.datelist = list1;
            ViewBag.hourlist = list2;
            ViewBag.hourtotal = list2.Sum(x => x.TotalCnt);
            ViewBag.refererlist = list3;
            ViewBag.countrylist = list4;

            return View();
        }

        [LoginRequired]
        public IActionResult InquiryList(int page = 1 ) {

            int pagesize = 10;
            int pageno = (page - 1) * pagesize;
            int totalcount = 0;
            int pageblock = 10;



            List<InquiryModel> list = new List<InquiryModel>();
            list = _allinkbeautyService.InquiryList();

            totalcount = list == null ? 0 : list.Count;
            list = list?.Skip(pageno).Take(pagesize).ToList();


            ViewBag.page = page;
            ViewBag.pagesize = 10;
            ViewBag.totalcount = totalcount;
            ViewBag.pageblock = pageblock;

            return View(list);
        }

        public async Task<IActionResult> ProductList(int page = 1)
        {
            int pagesize = 30;
            int pageno = (page - 1) * pagesize;
            int totalcount = 0;
            int pageblock = 10;

            List<AdminProductModel> list = new List<AdminProductModel>();
            list = _allinkbeautyService.ProductList();

            totalcount = list == null ? 0 : list.Count;
            var items = list?.Skip(pageno).Take(pagesize).ToList();

            var keys = items.Select(x => x.PCategory ?? string.Empty)
                    .Where(k => !string.IsNullOrWhiteSpace(k))
                    .Distinct()
                    .ToList();


            var tasks = keys.ToDictionary(k => k, k => _codeService.GetCategoryFullname(k));
            await Task.WhenAll(tasks.Values);

            var catMap = tasks.ToDictionary(kv => kv.Key, kv => kv.Value.Result);

            foreach (var it in items)
            {
                if (!string.IsNullOrEmpty(it.PCategory) &&
                    catMap.TryGetValue(it.PCategory, out var fullName))
                {
                    it.PCategoryName = fullName;
                }
            }


            ViewBag.page = page;
            ViewBag.pagesize = pagesize;
            ViewBag.totalcount = totalcount;
            ViewBag.pageblock = pageblock;
            ViewBag.pageno = pageno;
            ViewBag.list = items;
            ViewBag.fileurl = SiteConfig.fileurl;

            return View();
        }

        public async Task<IActionResult> KProductList(int page = 1)
        {
            int pagesize = 30;
            int pageno = (page - 1) * pagesize;
            int totalcount = 0;
            int pageblock = 10;

            List<AdminProductModel> list = new List<AdminProductModel>();
            list = _allinkbeautyService.KProductList();

            totalcount = list == null ? 0 : list.Count;
            var items = list?.Skip(pageno).Take(pagesize).ToList();

            var keys = items.Select(x => x.PCategory ?? string.Empty)
                    .Where(k => !string.IsNullOrWhiteSpace(k))
                    .Distinct()
                    .ToList();


            var tasks = keys.ToDictionary(k => k, k => _codeService.GetCategoryFullname(k));
            await Task.WhenAll(tasks.Values);

            var catMap = tasks.ToDictionary(kv => kv.Key, kv => kv.Value.Result);

            foreach (var it in items)
            {
                if (!string.IsNullOrEmpty(it.PCategory) &&
                    catMap.TryGetValue(it.PCategory, out var fullName))
                {
                    it.PCategoryName = fullName;
                }
            }


            ViewBag.page = page;
            ViewBag.pagesize = pagesize;
            ViewBag.totalcount = totalcount;
            ViewBag.pageblock = pageblock;
            ViewBag.pageno = pageno;
            ViewBag.list = items;
            ViewBag.fileurl = SiteConfig.fileurl;

            return View();
        }

        public async Task<IActionResult> CProductList(int page = 1)
        {
            int pagesize = 30;
            int pageno = (page - 1) * pagesize;
            int totalcount = 0;
            int pageblock = 10;

            List<AdminProductModel> list = new List<AdminProductModel>();
            list = _allinkbeautyService.CProductList();

            totalcount = list == null ? 0 : list.Count;
            var items = list?.Skip(pageno).Take(pagesize).ToList();


            var keys = items.Select(x => x.PCategory ?? string.Empty)
                    .Where(k => !string.IsNullOrWhiteSpace(k))
                    .Distinct()
                    .ToList();


            var tasks = keys.ToDictionary(k => k, k => _codeService.GetCategoryFullname(k));
            await Task.WhenAll(tasks.Values);

            var catMap = tasks.ToDictionary(kv => kv.Key, kv => kv.Value.Result);

            foreach (var it in items)
            {
                if (!string.IsNullOrEmpty(it.PCategory) &&
                    catMap.TryGetValue(it.PCategory, out var fullName))
                {
                    it.PCategoryName = fullName;
                }
            }

            ViewBag.page = page;
            ViewBag.pagesize = pagesize;
            ViewBag.totalcount = totalcount;
            ViewBag.pageblock = pageblock;
            ViewBag.pageno = pageno;
            ViewBag.list = items;
            ViewBag.fileurl = SiteConfig.fileurl;

            return View();
        }

        public async Task<IActionResult> CProductEdit(int produid)
        {
            ProductDetailModel productinfo = _allinkbeautyService.ProductView(produid);


            List<TbCode> codelist = new List<TbCode>();
            codelist = await _codeService.GetCodeList("원산지");

            List<TbCategory> categorylist = new List<TbCategory>();
            categorylist = await _codeService.GetCategoryList("0000" , "Y");

            var tasks = await _codeService.GetCategoryFullnameLIst(productinfo.Cat);


            ViewBag.productinfo = productinfo;
            ViewBag.productcategory = tasks;
            ViewBag.categorylist = categorylist;
            ViewBag.codelist = codelist;    

            return View();
        }

        public async Task<IActionResult> ProductListData(int page = 1, string acode = "A001", string searchval ="", string approval = "", string kview = "")
        {
            int pagesize = 30;
            int pageno = 0;
            int totalcount = 0;
            int pageblock = 10;

            pageno = (page - 1) * pagesize; 

            ProductSearchModel ps = new ProductSearchModel()
            {
                category1 = acode,
                searchval = searchval,
                approval = approval,
                kview = kview
            };


            List<KbeautyProductModel> list = new List<KbeautyProductModel>();
            list = await _allinkbeautyService.uspKbeautyProductList(ps); 

            totalcount = list == null ? 0 : list.Count;
            var items = list?.Skip(pageno).Take(pagesize).ToList();


            var keys = items.Select(x => x.PCategory ?? string.Empty)
                    .Where(k => !string.IsNullOrWhiteSpace(k))
                    .Distinct()
                    .ToList();


            var tasks = keys.ToDictionary(k => k, k => _codeService.GetCategoryFullname(k));
            await Task.WhenAll(tasks.Values);

            var catMap = tasks.ToDictionary(kv => kv.Key, kv => kv.Value.Result);

            foreach (var it in items)
            {
                if (!string.IsNullOrEmpty(it.PCategory) &&
                    catMap.TryGetValue(it.PCategory, out var fullName))
                {
                    it.PCategoryName = fullName;
                }
            }

            pageno = totalcount - ((page - 1) * pagesize);

            ViewBag.page = page;
            ViewBag.pagesize = pagesize;
            ViewBag.totalcount = totalcount;
            ViewBag.pageblock = pageblock;
            ViewBag.pageno = pageno;
            ViewBag.filepath = SiteConfig.fileurl;

            return PartialView("_ProductListPartial", items);
        }

        public IActionResult ProductPageData(int page , int pagesize , int totalcount, int pageblock)
        {
            

            ViewBag.page = page;
            ViewBag.pagesize = pagesize;
            ViewBag.totalcount = totalcount;
            ViewBag.pageblock = pageblock;

            return PartialView("_Pagination2");
        }

        public async Task<IActionResult> ProductEdit(int produid)
        {
            ProductDetailModel productinfo = _allinkbeautyService.ProductView(produid);


            List<TbCode> codelist = new List<TbCode>();
            codelist = await _codeService.GetCodeList("원산지");

            List<TbCategory> categorylist = new List<TbCategory>();
            categorylist = await _codeService.GetCategoryList("0000", "Y");

            var tasks = await _codeService.GetCategoryFullnameLIst(productinfo.Cat);


            ViewBag.productinfo = productinfo;
            ViewBag.productcategory = tasks;
            ViewBag.categorylist = categorylist;
            ViewBag.codelist = codelist;
            ViewBag.fileurl = SiteConfig.fileurl;

            return View();
        }

        public async Task<IActionResult> ProductEdit2(int produid)
        {
            ProductDetailModel productinfo = _allinkbeautyService.ProductView(produid);


            List<TbCode> codelist = new List<TbCode>();
            codelist = await _codeService.GetCodeList("원산지");

            List<TbCategory> categorylist = new List<TbCategory>();
            categorylist = await _codeService.GetCategoryList("0000", "Y");

            var tasks = await _codeService.GetCategoryFullnameLIst(productinfo.Cat);


            ViewBag.productinfo = productinfo;
            ViewBag.productcategory = tasks;
            ViewBag.categorylist = categorylist;
            ViewBag.codelist = codelist;
            ViewBag.fileurl = SiteConfig.fileurl;

            return View();
        }

        public IActionResult ModalProductImage(int produid)
        {

            ProductDetailModel productinfo = _allinkbeautyService.ProductView(produid);

            ViewBag.productinfo = productinfo;

            return View();

        }

        [LoginRequired]
        public async Task<IActionResult> ContactList(int page = 1)
        {

            int pagesize = 10;
            int pageno = 0;
            int totalcount = 0;
            int pageblock = 10;


            var listAll = await _allinkbeautyService.ContactList();

            totalcount = listAll?.Count ?? 0;

            var list = listAll?.OrderByDescending(m => m.idx)
                       .Skip((page - 1) * pagesize)
                       .Take(pagesize)
                       .ToList();

            pageno = totalcount - ((page - 1) * pagesize);

            ViewBag.page = page;
            ViewBag.pagesize = 10;
            ViewBag.totalcount = totalcount;
            ViewBag.pageblock = pageblock;
            ViewBag.pageno = pageno;

            return View(list);

        }

        [LoginRequired]
        public async Task<IActionResult> ContactUsList(int page = 1)
        {
            int pagesize = 10;
            int pageno = 0;
            int totalcount = 0;
            int pageblock = 10;


            var listAll = await _allinkbeautyService.ContactUsList();

            totalcount = listAll?.Count ?? 0;

            var list = listAll?.OrderByDescending(m => m.idx)
                       .Skip((page - 1) * pagesize)
                       .Take(pagesize)
                       .ToList();

            pageno = totalcount - ((page -1) * pagesize);

            ViewBag.page = page;
            ViewBag.pagesize = 10;
            ViewBag.totalcount = totalcount;
            ViewBag.pageblock = pageblock;
            ViewBag.pageno = pageno;

            return View(list);


        }

        public async Task<IActionResult> ModalCategory(string ACode, string[] selectcode) {

            List<CategoryModel> list = new List<CategoryModel>();
            list = await _codeService.GetModalVwNcategoryList(ACode, "Y", selectcode);


            ViewBag.categoryList = list;    

            return View();
        }

        [LoginRequired]
        public IActionResult FormulaList()
        {
            return View();
        }

        [LoginRequired]
        public IActionResult PackagingList()
        {
            return View();
        }

        public async Task<JsonResult> CategoryList(string[] ACode) { 
        
            List<VwNcategoryList> list = new List<VwNcategoryList>();
            list =  await _codeService.GetVwNcategoryList(ACode);

            return Json(new { Item1 = "success", Item2 = list });   
        }

        public JsonResult InquiryView(int idx) {

            InquiryViewModel result1 = _allinkbeautyService.InquiryView(idx);

            AdminProductDetailModel result2 = null;

            if (result1 != null) {
                result2 = _allinkbeautyService.InquiryProductView(result1.pidx);
            }

            return Json(new { Item1 = "success", Item2 = result1, Item3 = result2 });

        }

        [HttpPost]  
        public async Task<JsonResult> AjaxProductEdit(ProductSaveModel productSaveModel, string delete_existing_ids, string image_order, List<IFormFile> files)
        {
            string rcode = "fail";
            string msg = string.Empty;
            bool filebool = false;

            rcode = await _allinkbeautyService.ProductUpdate(productSaveModel, delete_existing_ids, image_order, files);

            return Json(new { Item1 = rcode, Item2 = msg });
        }


        [HttpPost]
        public async Task<JsonResult> AjaxProductChangeViewBeauty(long ProdUid, string PUseSt)
        {
            try {


                string result = await _allinkbeautyService.ProductViewUpdate(ProdUid, PUseSt);


                return Json(new { Item1 = result });

            }catch{

                return Json(new { Item1 = "fail" });
                }

            
        }


        [HttpPost]
        public async Task<JsonResult> AjaxEditorImageSave(IFormFile file)
        {
            try
            {
                string url = string.Empty;   

                if (file == null || file.Length == 0)
                {
                    return Json(new { success = false, message = "파일이 없습니다." });
                }

                url = await _allinkbeautyService.EditorImageSave(file);


                return Json(new { success = true, url });

            }
            catch
            {

                return Json(new { success = false, message = "예기치 못한 오류가 발생했습니다." });
            }


        }


        [HttpPost]
        public JsonResult AjaxLoginCheck(string id, string password)
        {
            try
            {
                if (id == "admink" && password == "admink!@#")
                {

                    HttpContext.Session.SetString("admin", "admink");
                    return Json(new { item1 = "success" });
                }
                else {
                    return Json(new { item1 = "fail" });
                }
 
            }
            catch
            {
                return Json(new { item1 = "fail" });
            }
        }


        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // 모든 세션 삭제
            return Redirect("~/");
        }


        [Route("blocked")]
        public IActionResult Blocked()
        {
            string block = HttpContext.Session.GetString("block") ?? "false";
            ViewBag.ip = HttpContext.Session.GetString("ClientIp");


            if(block.ToLower() == "false")
            {
                return Redirect("/");
            }

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
