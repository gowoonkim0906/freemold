using Freemold.Modules.Common;
using Freemold.Modules.Models;
using Freemold.Modules.Models.Table;
using Freemold.Modules.Repositories;
using ImageMagick;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Freemold.Modules.Services
{
    public class AllinkbeautyService : IAllinkbeautyService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CommonRepository _commonRepository;
        private readonly StatisticsRepository _statisticsRepository;
        private readonly CommunityRepository _communityRepository;
        private readonly ProductRepository _productRepository;
        private readonly CodeRepository _codeRepository;
        private readonly BeautyRepository _beautyRepository;
        private readonly IFileService _fileService;

        public AllinkbeautyService(
            IHttpContextAccessor httpContextAccessor,
            CommonRepository commonRepository, 
            StatisticsRepository statisticsRepository, 
            CommunityRepository communityRepository, 
            ProductRepository productRepository,
            CodeRepository codeRepository,
            BeautyRepository beautyRepository,
            IFileService fileService)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._commonRepository = commonRepository;
            this._statisticsRepository = statisticsRepository;
            this._communityRepository = communityRepository;
            this._communityRepository = communityRepository;
            this._productRepository = productRepository;
            this._codeRepository = codeRepository;
            this._beautyRepository = beautyRepository;
            this._fileService = fileService;
        }

        public List<StatisticsModel> StatisticsList(DateTime? sDate = null , DateTime? eDate = null) {

            

            var list =
                _statisticsRepository.GetConnectionAllInKBeauty(sDate, eDate)
                .GroupBy(m => m.InDate.Date)
                .Select(g => new StatisticsModel
                {
                    InDate = g.Key.ToString("yyyy-MM-dd"),
                    TotalCnt = g.Count(),
                    Mobile = g.Count(x =>
                             x.UserAgent.Contains("iPhone") ||
                             x.UserAgent.Contains("Android"))
                })
                .ToList();


            return list;
        }

        public List<StatisticsHourModel> StatisticsHourList(DateTime? sDate = null, DateTime? eDate = null)
        {

            var raw =
                _statisticsRepository.GetConnectionAllInKBeauty(sDate, eDate)
                .GroupBy(m => m.RegDate.Hour)
                .Select(g => new { Hour = g.Key, TotalCnt = g.Count() }).OrderBy(g => g.Hour).ToList();



            var list = raw.Select(m => new StatisticsHourModel
            {
                sHour = $"{m.Hour:D2}시",
                TotalCnt = m.TotalCnt
            }).ToList();

            return list;
        }

        public List<StatisticsRefererModel> StatisticsRefererList(DateTime? sDate = null, DateTime? eDate = null)
        {

            var raw = _statisticsRepository.GetConnectionAllInKBeauty(sDate, eDate)
                            .Select(m => m.HttpReferer ?? "")   // 최소 컬럼만
                            .AsNoTracking()
                            .ToList();         

            var list = raw
                        .Select(r => r ?? "")
                        .Select(r => r.Replace("http://", "").Replace("https://", ""))
                        .Select(r => r.Contains("allinkbeauty.com") ? "" : r)
                        .Select(r => {
                            var idx = r.IndexOf('/');
                            return idx >= 0 ? r.Substring(0, idx) : r;
                        })
                        .GroupBy(referer => referer)
                        .Select(g => new StatisticsRefererModel
                        {
                            HttpReferer = g.Key,
                            TotalCnt = g.Count()
                        })
                        .OrderByDescending(x => x.TotalCnt)
                        .ToList();


            return list;
        }


        public List<StatisticsCountryModel> StatisticsCountryList(DateTime? sDate = null, DateTime? eDate = null)
        {

            var list = _statisticsRepository.GetConnectionCountryAllInKBeauty(sDate, eDate)
                            .GroupBy(m => new { m.CCode, m.CName })
                            .Select(g => new StatisticsCountryModel
                            {
                                CCode = g.Key.CCode,
                                CName = g.Key.CName,
                                TotalCnt = g.Count()
                            })
                            .OrderByDescending(x => x.TotalCnt)
                            .ToList();


            return list;
        }

        public List<InquiryModel> InquiryList()
        {
            var result = _communityRepository.GetInquiryList().OrderByDescending(m => m.Idx).ToList();

            return result;
        }




        public InquiryViewModel InquiryView(int idx)
        {
            InquiryViewModel result = new InquiryViewModel();

            if (idx <= 0) return new InquiryViewModel();


            result = _communityRepository.GetInquiryView().AsNoTracking()
                .Where(m => m.Idx == idx)
                .Select(m => new InquiryViewModel
                {
                    pidx = m.PIdx,
                    name = m.Name,
                    company = m.Company,
                    inquiry = m.Inquiry,
                    regCountry = m.RegCountry,
                    RegDate = m.RegDate.ToString("yyyy.MM.dd")
                })
                .SingleOrDefault() ?? new InquiryViewModel();


            return result;
        }

        public AdminProductDetailModel InquiryProductView(int idx)
        {
            var result = _productRepository.GetInquiryProductView().FirstOrDefault(m => m.ProdUid == idx) ?? null;

            return result ?? new AdminProductDetailModel();
        }

        public List<AdminProductModel> ProductList()
        {
            var result = _productRepository.GetProductList()
                        //.Where(m => m.Deleted == "N" && m.PayUse == "Y" && m.Approval == "Y" && m.POrigin == "대한민국" && m.ProdType == "")
                        .Where(m => m.Deleted == "N" && m.PayUse == "Y" && m.Approval == "Y")
                        .OrderByDescending(m => m.PModdate).ToList();
            return result;
        }

        public List<AdminProductModel> KProductList()
        {
            var result = _productRepository.GetKProductList()
                        .Where(m => m.Deleted == "N" && m.PayUse == "Y" && m.Approval == "Y")
                        .OrderByDescending(m => m.PModdate).ToList();
            return result;
        }

        public List<AdminProductModel> CProductList()
        {
            var result = _productRepository.GetCProductList()
                        .Where(m => m.Deleted == "N" && m.PayUse == "Y" && m.Approval == "Y" &&  m.MemberUid == 635)
                        .OrderByDescending(m => m.PModdate).ToList();
            return result;
        }

        public ProductDetailModel ProductView(int ProdUid)
        {
            var result = _productRepository.GetProductView().FirstOrDefault(m => m.ProdUid == ProdUid) ?? null;

            return result ?? new ProductDetailModel();
        }

        public async Task<string> ProductUpdate(ProductSaveModel productSaveModel, string delete_existing_ids, string image_order, List<IFormFile> files)
        {
            string result = "sucess";

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
                result = "fail";

                return result;
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

                            if (strImage.Contains(ext))
                            {

                                await _fileService.SaveWithWatermarkAsync(f, fs, logoPath, ext);
                            }
                            else
                            {
                                // 이미지가 아니면 그대로 저장
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
                else if (key == "existing")
                {
                    arrfilename[arri] = value;
                }

                arri++;
            }


            productSaveModel.p_category = ";"+productSaveModel.p_category.Replace(",",";;")+";";

            productSaveModel.p_img1 = arrfilename[0];
            productSaveModel.p_img2 = arrfilename[1];
            productSaveModel.p_img3 = arrfilename[2];
            productSaveModel.p_img4 = arrfilename[3];
            productSaveModel.p_img5 = arrfilename[4];
            productSaveModel.p_img6 = arrfilename[5];


            result = await _productRepository.ProductUpdate(productSaveModel);

            return result;
        }

        public async Task<string> ProductViewUpdate(long ProdUid, string PUseSt) { 
        
            string result = "OK";

            result = await _productRepository.ProductViewUpdate(ProdUid, PUseSt);

            return result;
        }

        public async Task<List<KbeautyProductModel>>  KbeautyProductList(string category1, string category2, string category3,string volume1,string volume2, CancellationToken ct = default)
        {

            DateOnly datefrom = DateOnly.FromDateTime(DateTime.Today);
            DateOnly dateto = DateOnly.FromDateTime(DateTime.Today.AddDays(-10));


            IQueryable<KbeautyProductModel> query = _productRepository.GetKbeautyProductList(category1)
            .Where(m => m.StartDate <= datefrom
                        && m.EndDate >= dateto
                        && m.UpCat == ";" + category1 + ";");

            if (!string.IsNullOrWhiteSpace(category3)) //2차카테고리 선택시
            {
                query = query.Where(m => EF.Functions.Like(";" + (m.PCategory) + ";", "%;" + category3 + ";%"));
            }
            else if (!string.IsNullOrWhiteSpace(category2)) //1차카테고리 선택시
            {
                query = query.Where(m => EF.Functions.Like(";" + (m.PCategory) + ";", "%;" + category2 + ";%"));
            }

            //용량 검색
            if (!string.IsNullOrWhiteSpace(volume1) && !string.IsNullOrWhiteSpace(volume2))
            {
                if (double.TryParse(volume1, out double vol1) && double.TryParse(volume2, out double vol2))
                {
                    query = query.Where(m => m.PCapacity >= vol1 && m.PCapacity <= vol2);
                }
            }


            var result = query
                        .OrderByDescending(m => m.PRegDate).AsNoTracking(); 

            return await result.ToListAsync(ct);
        }

        public async Task<List<KbeautyProductModel>> uspKbeautyProductList(ProductSearchModel ps , CancellationToken ct = default)
        {
            DateOnly datefrom = DateOnly.FromDateTime(DateTime.Today);
            DateOnly dateto = DateOnly.FromDateTime(DateTime.Today.AddDays(-10));

            var data = await _productRepository
                .GetuspKbeautyProductList(ps.category1)
                .ToListAsync(ct);  // List<UspKbeautyProductModel>

            var query = data
                .Where(m =>
                    m.START_DATE <= datefrom &&
                    m.END_DATE >= dateto &&
                    m.UpCat == ";" + ps.category1 + ";");

            //노출여부
            if ((ps.kview ?? "N") == "Y")
            {
                query = query.Where(m => m.P_USE_ST == "Y");
            }else if ((ps.kview ?? "N") == "N")
            {
                query = query.Where(m => m.P_USE_ST != "Y");
            }

            //승인여부
            if ((ps.approval ?? "N") == "Y")
            {
                query = query.Where(m => m.APPROVAL == "Y" && (m.APPROVAL_BEFORE ?? "N" ) == "Y");
            }
            else if ((ps.approval ?? "N") == "N")
            {
                query = query.Where(m => m.APPROVAL != "Y" && (m.APPROVAL_BEFORE ?? "N") != "Y");
            }


            //검색어
            if (!string.IsNullOrWhiteSpace(ps.searchval)) {

                query = query.Where(m => 
                    m.P_CODE.Contains(ps.searchval) ||
                    m.P_NAME.Contains(ps.searchval) ||
                    m.P_SIZE.Contains(ps.searchval) ||
                    m.P_QUALITY.Contains(ps.searchval) ||
                    m.P_CAPACITY.ToString().Contains(ps.searchval) ||
                    m.COMPANY_NAME.Contains(ps.searchval)
                );
            }
            

            if (!string.IsNullOrWhiteSpace(ps.category3))
            {
                query = query.Where(m => (";" + m.P_CATEGORY + ";")
                    .Contains(";" + ps.category3 + ";", StringComparison.OrdinalIgnoreCase));
            }
            else if (!string.IsNullOrWhiteSpace(ps.category2))
            {
                query = query.Where(m => (";" + m.P_CATEGORY + ";")
                    .Contains(";" + ps.category2 + ";", StringComparison.OrdinalIgnoreCase));
            }

            if (double.TryParse(ps.volume1, out double vol1) &&
                double.TryParse(ps.volume2, out double vol2))
            {
                query = query.Where(m => m.P_CAPACITY >= vol1 && m.P_CAPACITY <= vol2);
            }

            

            var result = query
                .Select(m => new KbeautyProductModel
                {
                    ProdUid = m.PROD_UID,
                    PCode = m.P_CODE,
                    PCodeEn = m.P_CODE_EN,
                    UpCat = m.UpCat,
                    PName = m.P_NAME,
                    PCapacity = m.P_CAPACITY,
                    PCapUnit = m.P_CAP_UNIT,
                    PSize = m.P_SIZE,
                    PHit = m.P_HIT,
                    PQuality = m.P_QUALITY,
                    POrigin = m.P_ORIGIN,
                    ProdType = m.ProdType,
                    PCategory = m.P_CATEGORY,
                    PImg1 = m.P_IMG1,
                    PApproval = m.P_APPROVAL,
                    PApprovalBefore = m.P_APPROVAL_BEFORE,
                    Deleted = m.Deleted,
                    PUse = m.P_USE,
                    PUseST = m.P_USE_ST,
                    PRegDate = m.P_REGDATE,
                    Visit = m.Visit,
                    CompanyName = m.COMPANY_NAME,
                    PayUse = m.PayUse,
                    Approval = m.APPROVAL,
                    ApprovalBefore = m.APPROVAL_BEFORE,
                    ApprovalView = m.APPROVAL_VIEW,
                    StartDate = m.START_DATE,
                    EndDate = m.END_DATE,
                    ImgCnt = m.ImgCnt
                })
                .OrderByDescending(m => m.PRegDate)
                .ToList();

            return result;  // ✅ OK
        }


        public async Task<KbeautyProductModel> KbeautyProductView(long produid, CancellationToken ct = default)
        {

            var result = await _productRepository
                           .GetKbeautyProductView()
                           .Where(m => m.ProdUid == produid)
                           .FirstOrDefaultAsync(ct);

            return result ?? new KbeautyProductModel();
        }
        public async Task<string> ContactInsert(TB_ALLINKBEAUTY_CONTACT input, CancellationToken ct = default)
        {

            try
            {
                var result = await _beautyRepository.ContactInsert(input, ct);

                return result;
            }
            catch
            {
                return "fail";
            }
        }

        public async Task<string> ContactUsInsert(TB_ALLINKBEAUTY_CONTACT_US input, CancellationToken ct = default)
        {

            try
            {
                var result = await _beautyRepository.ContactUsInsert(input, ct);

                return result;
            }
            catch
            {
                return "fail";
            }
        }


        public async Task<List<ContactModel>>  ContactList(CancellationToken ct = default)
        {
            var result = _beautyRepository.GetContactList().OrderByDescending(m => m.idx).AsNoTracking();

            return await result.ToListAsync(ct); ;
        }


        public async Task<List<TB_ALLINKBEAUTY_CONTACT_US>> ContactUsList(CancellationToken ct = default)
        {
            var result = _beautyRepository.GetContactUsList().OrderByDescending(m => m.idx).AsNoTracking();

            return await result.ToListAsync(ct); ;
        }

        public async Task<UspconnectionModel> AllinKVisitorInsert(string regip) {

       

            var httpContext = _httpContextAccessor.HttpContext;

            string Domain = httpContext.Request.Host.Host ?? "";
            string userAgent = httpContext.Request.Headers["User-Agent"].ToString() ?? "";
            string HttpReferer = httpContext.Request.Headers["Referer"].ToString() ?? "";

            string[] blockkeywords = { "bot", "bytespider", "go-http-client", "bingbot", "googlebot", "daum", "facebook", "yeti", "node-fetch", "python-requests" };

            bool containsAny = blockkeywords.Any(k => userAgent.Contains(k, StringComparison.OrdinalIgnoreCase));

            TB_CONNECTION_ALLINKBEAUTY connection = new TB_CONNECTION_ALLINKBEAUTY();

            connection.Domain = Domain;
            connection.UserAgent = userAgent;
            connection.HttpReferer = HttpReferer;
            connection.RegIP = regip;

            if (containsAny)
            {
                var result = new UspconnectionModel();
                return result;
            }
            else {

                var result = _commonRepository.AllinKVisitorInsert(connection);
                return await result;
            }

        }

        
        public bool BlockIp(string ip)
        {
            var result = false;

            try
            {
                var cnt = _commonRepository.GetBlockIp().AsNoTracking()
                          .Where(m => m.BlockIp == ip).Count();

                if (cnt > 0)
                {
                    return true; //이미 차단된 아이피
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex) {

                return true;
            }
            

        }
    }
}
