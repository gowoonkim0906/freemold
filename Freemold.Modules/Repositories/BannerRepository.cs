using Freemold.Modules.Common;
using Freemold.Modules.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Repositories
{
    public class BannerRepository : BaseRepository
    {
        public BannerRepository(AppDbContext _appdbcontext) : base(_appdbcontext)
        { }



        //카테고리 목록 조회
        public IQueryable<TB_BANNER> GetBannerList()
        {
            try
            {
                return _appdbcontext.TB_BANNER;
            }
            catch
            {
                throw;
            }
        }



        public IQueryable<BannerSettingModel> GetBannerSettingList()
        {
            try
            {
                var query = from p in _appdbcontext.TB_BANNER_CATEGORY
                            join c in _appdbcontext.TB_BANNER_TYPE on p.BCCode equals c.BCCode
                            where c.BannerPosition != "Menu"
                            select new BannerSettingModel
                            {
                                bccode = p.BCCode,
                                bcname = p.BCName,
                                bcord = p.BCOrd ?? 0,
                                banneridx = c.Idx,
                                bannertype = c.BannerType,
                                bannername = c.BannerName2,
                                bannercnt = c.BannerCnt,
                                bannersize = c.BannerSize,
                                bannersizex = c.BannerSizeX,
                                bannersizey = c.BannerSizeY,
                                bannerprice = c.BannerPrice,
                                bannermode = c.BannerMode,
                                bannermonths = c.BannerMonths ?? 0,
                                memo = c.Memo,
                                ord1 = c.Ord1,
                                ord2 = c.Ord2
                            };

                return query;
            }
            catch
            {
                throw;
            }
        }


        public IQueryable<BannerSettingCategoryModel> GetBannerSettingCategoryList()
        {
            try
            {
                var query = from p in _appdbcontext.VW_NCATEGORY_LIST
                            join c in _appdbcontext.TB_BANNER_TYPE_CAT on p.Code equals c.Code into pc
                            from c in pc.DefaultIfEmpty()
                            where p.Depth == 2
                            select new BannerSettingCategoryModel
                            {
                                catname = p.CatName,
                                code = p.Code,
                                aord = p.AOrd,
                                acode = p.ACode,
                                bord = p.BOrd,
                                bcode = p.BCode,
                                cord = p.COrd,
                                ccode = p.CCode,
                                banneridx = c != null ? c.Idx : 0,
                                bannercnt = c != null ? c.BannerCnt : 0,
                                bannersizex = c != null ? (c.BannerSizeX ?? 0) : 0,
                                bannersizey = c != null ? (c.BannerSizeY ?? 0) : 0,
                                bannerprice = c != null ? c.BannerPrice : 0,
                                bannermode = c != null ? c.BannerMode : null,
                                bannermonths = c != null ? (c.BannerMonths ?? 0) : 0,
                                memo = c != null ? c.Memo : null
                            };

                return query;
            }
            catch
            {
                throw;
            }
        }


        public IQueryable<BannerManagementModel> GetBannerManagementList()
        {
            try
            {
                var query = from p in _appdbcontext.TB_BANNER_CATEGORY
                            join c in _appdbcontext.TB_BANNER_TYPE on p.BCCode equals c.BCCode
                            join b in _appdbcontext.TB_BANNER on c.Idx equals b.bIdx into banners
                            where c.BannerPosition != "Menu"
                            select new BannerManagementModel
                            {
                                bccode = p.BCCode,
                                bcname = p.BCName,
                                bcord = p.BCOrd ?? 0,
                                banneridx = c.Idx,
                                bannertype = c.BannerType,
                                bannername = c.BannerName2,
                                bannercnt = c.BannerCnt,
                                ord1 = c.Ord1,
                                ord2 = c.Ord2
                            };

                return query;
            }
            catch
            {
                throw;
            }
        }


        public async Task<string> BannerTypeUpdate(BannerSetSettingModel item)
        {


            try
            {
                var p = await _appdbcontext.TB_BANNER_TYPE.FirstAsync(x => x.Idx == item.bidx);



                p.BannerPrice = item.bprice;
                p.BannerMonths = Convert.ToInt16(item.bmonths);
                p.BannerSizeX = Convert.ToInt16(item.bsizex);
                p.BannerSizeY = Convert.ToInt16(item.bsizey);
                p.BannerMode = item.bmode;
                p.Memo = item.bmemo;


                var rows = await _appdbcontext.SaveChangesAsync();

                return rows > 0 ? "success" : "fail";



            }
            catch (Exception ex)
            {
                _appdbcontext.ChangeTracker.Clear();

                // 디버깅용
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.ToString());

                return "fail";
            }



        }

        public async Task<string> BannerTypeCatUpdate(BannerSetSettingModel item)
        {
            

            try
            {
                var p = await _appdbcontext.TB_BANNER_TYPE_CAT.FirstAsync(x => x.Idx == item.bidx);

               

                p.BannerPrice = item.bprice;
                p.BannerMonths = Convert.ToInt16(item.bmonths);
                p.BannerSizeX = Convert.ToInt16(item.bsizex);
                p.BannerSizeY = Convert.ToInt16(item.bsizey);
                p.BannerMode = item.bmode;
                p.Memo = item.bmemo;
 

                var rows = await _appdbcontext.SaveChangesAsync();

                return rows > 0 ? "success" : "fail";



            }
            catch
            {

                // DB는 롤백됨. 하지만 트래커엔 변경 흔적이 남아있을 수 있어요.
                _appdbcontext.ChangeTracker.Clear();      // 선택: 메모리 상태 초기화
                return "fail";
            }


        }

        public async Task<string> BannerTypeCatInsert(BannerSetSettingModel item, CancellationToken ct = default)
        {
            try
            {

                var entity = new TB_BANNER_TYPE_CAT
                {
                    Code = item.bbcode,
                    BannerCnt = 3,
                    BannerPrice = item.bprice,
                    BannerMonths = Convert.ToInt16(item.bmonths),
                    BannerSizeX = Convert.ToInt16(item.bsizex),
                    BannerSizeY = Convert.ToInt16(item.bsizey),
                    BannerMode = item.bmode,
                    Memo = item.bmemo

                };

                await _appdbcontext.TB_BANNER_TYPE_CAT.AddAsync(entity, ct);
                var rows = await _appdbcontext.SaveChangesAsync(ct);

                return rows > 0 ? "success" : "fail";
            }
            catch (Exception ex)
            {
                _appdbcontext.ChangeTracker.Clear();
                return "fail";
            }

        }
    }

}
