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

        public IActionResult KProductList(int page = 1)
        {
            int pagesize = 10;
            int pageno = (page - 1) * pagesize;
            int totalcount = 0;
            int pageblock = 10;

            List<AdminProductModel> list = new List<AdminProductModel>();
            list = _allinkbeautyService.KProductList();

            totalcount = list == null ? 0 : list.Count;
            list = list?.Skip(pageno).Take(pagesize).ToList();


            ViewBag.page = page;
            ViewBag.pagesize = 10;
            ViewBag.totalcount = totalcount;
            ViewBag.pageblock = pageblock;
            ViewBag.list = list;

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
            ViewBag.fileurl = _fileService.RootPath;

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

        public async Task<IActionResult> CategoryModal(string ACode, string[] selectcode) {

            List<CategoryModel> list = new List<CategoryModel>();
            list = await _codeService.GetModalVwNcategoryList(ACode, "Y", selectcode);


            ViewBag.categoryList = list;    

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

            string[] arrfilename = new[] { "", "", "", "", "", "" };

            var arrimgorder = (image_order ?? "")
                .Split(',', StringSplitOptions.RemoveEmptyEntries)  // 빈 항목 제거
                .Select(x => x.Trim())                              // 앞뒤 공백 제거
                .Select(x => {
                    var parts = x.Split(':', 2);                    // 2차: 콜론(최대 2조각)
                    return (Key: parts[0].Trim(), Value: (parts.Length > 1 ? parts[1].Trim() : ""));
                            })
                .ToList();



            string fnFolderDate = DateTime.Now.Year.ToString("D4") + "-" + DateTime.Now.Month.ToString("D2");

            string path = Path.GetFullPath(Path.Combine(_fileService.RootPath, "Product", fnFolderDate));

            if (!Directory.Exists(path))
            {
                // 폴더가 없으면 생성
                Directory.CreateDirectory(path);
            }

            string logoPath = Path.Combine(_fileService.WebRoot, "images", "freemold_watermark.png");
            if (!System.IO.File.Exists(logoPath))
            {
                return Json(new { Item1 = "fail", Item2 = "워터마크 파일을 찾을 수 없습니다.", Files = arrfilename });
            }

            int arri = 0;
            int arrfi = 0;
            string savefilename = "";

            string[] strImage = new[] { "jpg", "jpeg", "png", "webp", "bmp", "tif", "tiff", "gif" };


            foreach (var (key, value) in arrimgorder)
            {
                if (key == "new")
                {
                    var f = files[arrfi++];
                    var ext = Path.GetExtension(f.FileName).TrimStart('.').ToLowerInvariant();
                    var savedName = string.Empty;

                    savefilename = DateTime.Now.ToOADate().ToString(CultureInfo.InvariantCulture).Replace('.', '_');


                    for (int i = 0; ; i++)
                    {
                        var name = i == 0 ? $"{savefilename}.{ext}" : $"{savefilename} ({i}).{ext}";
                        var candidate = Path.Combine(path, name);

                        try
                        {
                            using var fs = new FileStream(candidate, FileMode.CreateNew, FileAccess.Write, FileShare.None);

                            if (strImage.Contains(ext)) {

                                await SaveWithWatermarkAsync2(f, fs, logoPath, ext);
                            }
                            else
                            {
                                // 이미지가 아니면 그대로 저장(필요 없다면 막아도 됨)
                                await f.CopyToAsync(fs);
                            }


                            //f.CopyToAsync(fs);
                            savedName = name;               // 최종 파일명
                            arrfilename[arri] = savedName;
                            break;
                        }
                        catch (IOException)
                        {
                            continue;
                        }
                    }


                }
                else if(key == "existing")
                {
                    arrfilename[arri] = value;
                }

                arri++;
            }



            return Json(new { Item1 = rcode, Item2 = msg });
        }


        private static async Task SaveWithWatermarkAsync(
            IFormFile inputFile,
            Stream outStream,
            string logoPath,
            string originalExt,
            double opacity = 0.35,  // 배경 워터마크는 0.10~0.25 정도 권장
            double _scaleIgnored = 0.0, // (COVER 모드에선 미사용)
            int? _padIgnored = null // (COVER 모드에선 미사용)
        )
                {
                    // 1) 입력 로드
                    using var inMs = new MemoryStream();
                    await inputFile.CopyToAsync(inMs);
                    inMs.Position = 0;

                    using var image = new MagickImage(inMs, new MagickReadSettings { ColorSpace = ColorSpace.sRGB });
                    image.AutoOrient();
                    image.Strip();

                    // 2) 로고 로드 (투명 PNG 권장)
                    using var logo = new MagickImage(logoPath);
                    logo.Alpha(AlphaOption.On);

                    // (선택) 로고가 흰 배경이면 흰색을 투명화 (완벽하진 않음)
                    try
                    {
                        logo.ColorFuzz = new Percentage(10); // 허용 오차
                        logo.Transparent(MagickColors.White);
                    }
                    catch { /* 버전 미지원 시 무시 */ }

                    // 3) COVER 스케일 계산: 이미지 전체를 덮도록
                    int iw = unchecked((int)image.Width);
                    int ih = unchecked((int)image.Height);
                    int lw = unchecked((int)logo.Width);
                    int lh = unchecked((int)logo.Height);

                    double scaleCover = Math.Max(iw / (double)lw, ih / (double)lh);
                    int coverW = Math.Max(1, (int)Math.Round(lw * scaleCover));
                    int coverH = Math.Max(1, (int)Math.Round(lh * scaleCover));

                    uint coverWu = (uint)Math.Max(1, coverW);
                    uint coverHu = (uint)Math.Max(1, coverH);

                    // 4) 로고 리사이즈(비율 유지, 꽉 채우기)
                    var geo = new MagickGeometry(coverWu, coverHu) { IgnoreAspectRatio = true };
                    logo.Resize(geo);

                    // 5) 배경 워터마크 투명도(더 옅게 권장)
                    double alpha = Math.Clamp(opacity, 0.05, 0.40);
                    logo.Evaluate(Channels.Alpha, EvaluateOperator.Multiply, alpha);

                    // 6) 중앙에 합성(배경처럼)
                    image.Composite(logo, Gravity.Center, 0, 0, CompositeOperator.Over);

                    // 7) 출력 포맷 결정
                    var ext = (originalExt ?? "").ToLowerInvariant();
                    (MagickFormat fmt, uint qualityU) = ext switch
                    {
                        "png" => (MagickFormat.Png, 0u),
                        "webp" => (MagickFormat.WebP, 82u),
                        _ => (MagickFormat.Jpeg, 82u),
                    };

                    if (fmt == MagickFormat.Jpeg)
                    {
                        // 일부 버전에선 uint만 허용 → uint로 고정
                        image.Quality = Math.Clamp(qualityU, 1u, 100u);
                        // (진행형/샘플링 등은 네 빌드에서 API가 없을 수 있어 생략)
                    }

                    // 8) 저장
                    image.Write(outStream, fmt);
                    await outStream.FlushAsync();
                }


        private static async Task SaveWithWatermarkAsync2(
            IFormFile inputFile,
            Stream outStream,
            string logoPath,
            string originalExt,
            double opacity = 0.30,   // 더 진하게 (0.6~0.85 권장)
            double tileScale = 0.20, // 기본: 짧은 변의 40% (크게 보이도록)
            int? gapPx = null        // 이번 버전에서는 overlap 우선, gap은 미사용
        )
        {
            using var inMs = new MemoryStream();
            await inputFile.CopyToAsync(inMs);
            inMs.Position = 0;

            using var image = new MagickImage(inMs, new MagickReadSettings { ColorSpace = ColorSpace.sRGB });
            image.AutoOrient();
            image.Strip();

            using var logo = new MagickImage(logoPath);
            logo.Alpha(AlphaOption.On);

            int iw = unchecked((int)image.Width);
            int ih = unchecked((int)image.Height);

            // ===== 1) 타일 크기: 짧은 변 기준 + 최소 픽셀 보장 =====
            int baseSide = Math.Min(iw, ih);                           // 짧은 변 기준이 체감상 안정적
            double scaleFactor = Math.Max(0.04, tileScale);            // 상한 제거(원하는 만큼 키울 수 있게)
            int tileLong = Math.Max(500, (int)Math.Round(baseSide * scaleFactor)); // 최소 700px 보장

            int lw0 = unchecked((int)logo.Width);
            int lh0 = unchecked((int)logo.Height);
            bool wide = lw0 >= lh0;

            int tileW = wide ? tileLong : Math.Max(1, (int)Math.Round(tileLong * (lw0 / (double)lh0)));
            int tileH = wide ? Math.Max(1, (int)Math.Round(tileLong * (lh0 / (double)lw0))) : tileLong;

            uint tileWu = (uint)Math.Max(1, tileW);
            uint tileHu = (uint)Math.Max(1, tileH);

            using var tile = (MagickImage)logo.Clone();
            tile.Resize(tileWu, tileHu);

            // ===== 2) 불투명도(진하게) & 색상 유지 =====
            double a = Math.Clamp(opacity, 0.05, 1.0); // 5%~100%
            tile.Evaluate(Channels.Alpha, EvaluateOperator.Multiply, a);
            // 흐릿해지는 Modulate(채도 0) 제거
            // tile.Modulate(new Percentage(100), new Percentage(100), new Percentage(100));

            // ===== 3) 캔버스 준비 =====
            var rs = new MagickReadSettings
            {
                Width = (uint)iw,
                Height = (uint)ih,
                BackgroundColor = MagickColors.Transparent
            };
            using var tiled = new MagickImage();
            tiled.Read("canvas:none", rs);
            tiled.Alpha(AlphaOption.Set);

            // ===== 4) 회전(선택) =====
            int rotateDeg = 0; // 10~15 정도 주면 패턴 티 감소 + 더 꽉 차 보임
            if (rotateDeg != 0)
            {
                tile.Rotate(rotateDeg);
                tileW = (int)tile.Width;
                tileH = (int)tile.Height;
            }

            // ===== 5) 겹치기 기반 스텝 계산 (촘촘함의 핵심) =====
            // overlap: 0.45 => 45% 겹침, 값이 클수록 더 촘촘
            double overlap = 0.50; // 0.35~0.65 권장. 아주 촘촘하게는 0.55~0.65
            int stepX = Math.Max(1, (int)Math.Round(tileW * (1.0 - overlap)));
            int stepY = Math.Max(1, (int)Math.Round(tileH * (1.0 - overlap)));

            // ===== 6) 오버타일링 + 2-패스(반 스텝 쉬프트) =====
            int baseOffX = -tileW / 2; // 음수 시작: 테두리 빈틈 방지
            int baseOffY = -tileH / 2;

            void Paint(int offsetX, int offsetY)
            {
                for (int y = offsetY, row = 0; y < ih + tileH; y += stepY, row++)
                {
                    int startX = offsetX + ((row % 2 == 0) ? 0 : stepX / 2); // 지그재그(벌집 느낌)
                    for (int x = startX; x < iw + tileW; x += stepX)
                        tiled.Composite(tile, x, y, CompositeOperator.Over);
                }
            }

            // 1패스: 기본
            Paint(baseOffX, baseOffY);
            // 2패스: 반 스텝 쉬프트(빈칸을 메움)
            Paint(baseOffX + stepX / 2, baseOffY + stepY / 2);

            image.Composite(tiled, Gravity.Northwest, 0, 0, CompositeOperator.Over);

            // ===== 7) 인코딩 =====
            var ext = (originalExt ?? "").ToLowerInvariant();
            (MagickFormat fmt, uint qualityU) = ext switch
            {
                "png" => (MagickFormat.Png, 0u),
                "webp" => (MagickFormat.WebP, 90u),
                _ => (MagickFormat.Jpeg, 90u),
            };

            if (fmt == MagickFormat.Jpeg)
                image.Quality = Math.Clamp(qualityU, 1u, 100u);

            image.Write(outStream, fmt);
            await outStream.FlushAsync();
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
