using Freemold.Modules.Common;
using Freemold.Modules.Models;
using Freemold.Modules.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Freemold.Modules.Services
{
    public class BannerService : IBannerService
    {
        private readonly AppDbContext _appdbcontext;
        private readonly BannerRepository _bannerRepository;
        private readonly IFileService _fileService;

        public BannerService(AppDbContext appdbcontext, BannerRepository bannerRepository, IFileService fileService)
        {

            this._appdbcontext = appdbcontext;
            this._bannerRepository = bannerRepository;
            this._fileService = fileService;
        }

        public async Task<List<TB_BANNER>> BannerList(List<int> bannerIds)
        {

            var today = DateTime.Today;

            var query = _bannerRepository.GetBannerList().AsNoTracking()
                        .Where(
                                        x => x.Deleted == "N"
                                            && x.isUse == "Y"
                                            && x.bType == "N"
                                            && (x.BannerUnlimit == "Y" || (x.sDate != null && x.eDate != null && x.sDate <= today && x.eDate >= today))
                                            && bannerIds.Contains(x.bIdx)
                                     )
                              .OrderByDescending(x => x.Idx)  //Idx 내림차순
                              .Take(3)                        //상위 3개만
                              .AsNoTracking();



            var list = await query.ToListAsync();

            return list;

        }

        //배너 설정 리스트
        public async Task<List<BannerSettingModel>> BannerSettingList()
        {
            var query = _bannerRepository.GetBannerSettingList().AsNoTracking();
            //.OrderBy(x => x.bcord )  //Idx 내림차순
            //.ThenBy(x => x.ord1)
            //.ThenBy(x => x.ord2);



            var list = await query.ToListAsync();

            return list;

        }


        public async Task<List<BannerSettingCategoryModel>> BannerSettingCategoryList()
        {
            var query = _bannerRepository.GetBannerSettingCategoryList().AsNoTracking()
            .OrderBy(x => x.aord)  
            .ThenBy(x => x.acode)
            .ThenBy(x => x.bord)
            .ThenBy(x => x.bcode)
            .ThenBy(x => x.cord)
            .ThenBy(x => x.ccode);



            var list = await query.ToListAsync();

            return list;

        }

        public async Task<BannerSettingModel?> BannerSettingView(int bidx)
        {

            return await _bannerRepository
                .GetBannerSettingList()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.banneridx == bidx);
        }

        public async Task<BannerSettingCategoryModel?> BannerSettingCategoryView(string bcode)
        {

            return await _bannerRepository
                .GetBannerSettingCategoryList()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.code == bcode);
        }


        public async Task<string> BannerSettingSet(BannerSetSettingModel input, CancellationToken ct = default)
        {

            try
            {
                string result = "success";


                if (input.bgubun == "b" && input.bidx > 0)
                {
                    result = await _bannerRepository.BannerTypeUpdate(input);
                }
                else if (input.bgubun == "c" && input.bidx > 0)
                {
                    result = await _bannerRepository.BannerTypeCatUpdate(input);
                }
                else if (input.bgubun == "c" && input.bidx == 0)
                {
                    result = await _bannerRepository.BannerTypeCatInsert(input);
                }
                else
                {
                    result = "fail";
                }

                return result;
            }
            catch (Exception ex)
            {
                return "fail";
            }

        }


        public async Task<PagedResult<BannerResponseModel>> TypeBannerList(int bidx, int page, int pagesize , string searchtype)
        {
            var today = DateTime.Today;
            var deadline = today.AddDays(30);

            var query = _bannerRepository.GetTypeBannerList(bidx).AsNoTracking();

            if (searchtype == "w") query = query.Where(x => x.bannerwaiting == "Y");  //대기
            if (searchtype == "d") query = query.Where(x => x.isuse == "Y" && x.edate >= today && x.edate <= deadline && x.sdate <= today);  //마감임박
            if (searchtype == "r") query = query.Where(x => x.isuse == "Y" && x.sdate > today);  //예약
            if (searchtype == "i") query = query.Where(x => x.isuse == "Y" && x.sdate <= today && x.edate >= today);  //운영중


            int totalCount = await query.CountAsync();


            var items = await query
            .OrderByDescending(x => x.isuse)  //내림차순
            .ThenByDescending(x => x.regdate)
            .Skip((page - 1) * pagesize)
            .Take(pagesize)
            .ToListAsync();


            return new PagedResult<BannerResponseModel>
            {
                items = items,
                totalcount = totalCount
            };

        }


        public async Task<BannerCntModel> TypeBannerCnt(int bidx)
        {

            var query = _bannerRepository.GetTypeBannerCntList(bidx);

            var item = await query.SingleOrDefaultAsync();

            if (item == null)
            {
                item = new BannerCntModel();
            }
            else {

                item.bvacant = item.bannercnt - item.bing; //공석 카운터
            }

            return  item;

        }

        public async Task<BannerManagementModel> TypeBannerView(int bidx)
        {

            var item = await _bannerRepository.GetBannerManagementList().Where(x => x.banneridx == bidx).SingleOrDefaultAsync();


            return item ?? new BannerManagementModel();



        }

        public async Task<string> TypeBannerDelete(BannerDeleteRequestModel item, CancellationToken ct = default)
        {

            try
            {
                string result = "success";


                result = await _bannerRepository.BannerDelete(item);

               

                return result;
            }
            catch (Exception ex)
            {
                return "fail";
            }

        }


        //배너신규등록
        public async Task<string> SetBanner(BannerSetRequestModel item, CancellationToken ct = default)
        {
            int totalbanner = 0;
            bool filereturn = false;
            string fnFolderDate = DateTime.Now.Year.ToString("D4") + "-" + DateTime.Now.Month.ToString("D2");
            string path = Path.GetFullPath(Path.Combine(_fileService.RootPath, "BannerImg", fnFolderDate));


            // 폴더가 없으면 생성
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string savefilename = "";
            string[] strImage = new[] { "jpg", "jpeg", "png", "webp", "bmp", "tif", "tiff", "gif" };


            try
            {
                totalbanner = await _bannerRepository.GetBannerList().AsNoTracking()
                    .Where(x => x.bIdx == item.bidx && x.isUse == "Y" && x.Deleted == "N" && x.sDate <= item.edate && x.eDate >= item.sdate).CountAsync();


                if (item.bcnt <= totalbanner)
                {
                    return "over";
                }


                if (item.bannerimage != null)
                {

                    var f = item.bannerimage;
                    var ext = Path.GetExtension(f.FileName).TrimStart('.').ToLowerInvariant();
                    var savedName = string.Empty;
                    var candidate = string.Empty;

                    savefilename = DateTime.Now.ToOADate().ToString(CultureInfo.InvariantCulture).Replace('.', '_');


                    if (strImage.Contains(ext))
                    {

                        candidate = Path.Combine(path, savefilename + "." + ext);


                        using (var fs = new FileStream(candidate, FileMode.CreateNew))
                        {

                            filereturn = await _fileService.SaveFile(f, fs);
                        }

                        //파일 저장 실폐시 fail 반환
                        if (!filereturn)
                        {

                            return "fail";
                        }

                        item.savebannerimage = Path.Combine(fnFolderDate, savefilename + "." + ext); //저장된 파일 경로

                        if (await _bannerRepository.BannerInsert(item) != "success") //배너 등록
                        {

                            _fileService.DeleteFile(candidate); //배너 등록 실패시 파일 삭제

                            return "fail";
                        }
                        else
                        {

                            return "success";
                        }

                    }
                    else
                    {

                        return "fail";
                    }


                }
                else
                {
                    return "fail";  //파일이 없으면 fail 반환

                }
            }
            catch (Exception ex)
            {
                return "fail";
            }

        }

        //배너수정
        public async Task<string> ModifyBanner(BannerSetRequestModel item, CancellationToken ct = default)
        {
            int totalbanner = 0;
            bool filereturn = false;
            var candidate = string.Empty;
            string fnFolderDate = DateTime.Now.Year.ToString("D4") + "-" + DateTime.Now.Month.ToString("D2");
            string path = Path.GetFullPath(Path.Combine(_fileService.RootPath, "BannerImg", fnFolderDate));


            // 폴더가 없으면 생성
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string savefilename = "";
            string[] strImage = new[] { "jpg", "jpeg", "png", "webp", "bmp", "tif", "tiff", "gif" };


            try
            {
                if (item.idx > 0)
                {

                    totalbanner = await _bannerRepository.GetBannerList().AsNoTracking()
                    .Where(x => x.bIdx == item.bidx && x.Idx != item.idx && x.isUse == "Y" && x.Deleted == "N" && x.sDate <= item.edate && x.eDate >= item.sdate).CountAsync();


                    if (item.bcnt <= totalbanner)
                    {
                        return "over";
                    }


                    if (item.bannerimage != null)
                    {

                        var f = item.bannerimage;
                        var ext = Path.GetExtension(f.FileName).TrimStart('.').ToLowerInvariant();
                        var savedName = string.Empty;
                        

                        savefilename = DateTime.Now.ToOADate().ToString(CultureInfo.InvariantCulture).Replace('.', '_');


                        if (strImage.Contains(ext))
                        {

                            candidate = Path.Combine(path, savefilename + "." + ext);


                            using (var fs = new FileStream(candidate, FileMode.CreateNew))
                            {

                                filereturn = await _fileService.SaveFile(f, fs);
                            }

                            //파일 저장 실폐시 fail 반환
                            if (!filereturn)
                            {
                                return "fail";
                            }

                            item.savebannerimage = Path.Combine(fnFolderDate, savefilename + "." + ext); //저장된 파일 경로

                        }
                        else
                        {

                            return "fail";
                        }
                    }
                    else {

                        item.savebannerimage = item.inputbannerimage; //저장된 파일 경로


                    }


                    if (await _bannerRepository.BannerUpdate(item) != "success") //배너 수정
                    {
                        if (item.bannerimage != null)
                        {
                           _fileService.DeleteFile(candidate); //배너 등록 실패시 파일 삭제
                        }

                        return "fail";
                    }
                    else
                    {
                        return "success";
                    }
                }
                else
                {
                    return "fail";
                }

            }
            catch (Exception ex)
            {
                return "fail";
            }

        }

        public async Task<BannerResponseModel> GetBanner(int banneridx, int idx)
        {

            var item = await _bannerRepository.GetTypeBannerList(banneridx).AsNoTracking()
                        .Where(x => x.idx == idx)
                        .SingleOrDefaultAsync();


            if (item == null)
            {
                item = new BannerResponseModel();
            }


            return item;

        }

        //배너검색 리스트
        public async Task<PagedResult<BannerSearchDataModel>> SearchBannerList(BannerSearchModel bannersearchmodel)
        {


            var today = DateTime.Today;
            var deadline = today.AddDays(30);

            IEnumerable<BannerSearchDataModel> query = await _bannerRepository.GetBannerSearchList(bannersearchmodel);

            // 프로시저에서 계산한 전체 건수
            int totalCount = query.FirstOrDefault()?.totalcount ?? 0;


            var items = query
            .ToList();


            return new PagedResult<BannerSearchDataModel>
            {
                items = items,
                totalcount = totalCount
            };

        }


        public async Task<BannerTotalCountModel> GetBannerTotalCount()
        {
            
            var items = await _bannerRepository.GetBannerTotalCount();

            return items;

        }

        public async Task<List<BannerTypeCountModel>> GetBannerTypeTotal() {


            var items = await _bannerRepository.GetBannerTypeTotal();

            return items;
        }


        public async Task<BannerCategoryCountModel> GetBannerCategoryTotal()
        {


            var items = await _bannerRepository.GetBannerCategoryTotal();

            return items;
        }
    }
}
