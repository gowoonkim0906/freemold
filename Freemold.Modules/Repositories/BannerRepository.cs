using Dapper;
using Freemold.Modules.Common;
using Freemold.Modules.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.RegularExpressions;
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
            var today = DateTime.Today;
            var deadline = today.AddDays(30);

            try
            {
                var query = from p in _appdbcontext.TB_BANNER_CATEGORY
                            join c in _appdbcontext.TB_BANNER_TYPE on p.BCCode equals c.BCCode
                            join t in _appdbcontext.TB_BANNER
                                      .Where(x => x.Deleted == "N" && x.bType == "N")
                                      on c.Idx equals t.bIdx into tg
                            from d in tg.DefaultIfEmpty()
                            where c.BannerPosition != "Menu"
                            group d by new
                            {
                                p.BCCode,
                                p.BCName,
                                p.BCOrd,
                                c.Idx,
                                c.BannerType,
                                c.BannerName2,
                                c.BannerCnt,
                                c.BannerSize,
                                c.BannerSizeX,
                                c.BannerSizeY,
                                c.BannerPrice,
                                c.BannerMode,
                                c.BannerMonths,
                                c.Memo,
                                c.Ord1,
                                c.Ord2

                            } into g
                            select new BannerSettingModel
                            {
                                bccode = g.Key.BCCode,
                                bcname = g.Key.BCName,
                                bcord = g.Key.BCOrd ?? 0,
                                banneridx = g.Key.Idx,
                                bannertype = g.Key.BannerType,
                                bannername = g.Key.BannerName2,
                                bannercnt = g.Key.BannerCnt,
                                bannersize = g.Key.BannerSize,
                                bannersizex = g.Key.BannerSizeX,
                                bannersizey = g.Key.BannerSizeY,
                                bannerprice = g.Key.BannerPrice,
                                bannermode = g.Key.BannerMode,
                                bannermonths = g.Key.BannerMonths ?? 0,
                                memo = g.Key.Memo,
                                ord1 = g.Key.Ord1,
                                ord2 = g.Key.Ord2,

                                bwaiting = g.Count(x => x != null && x.BannerWaiting == "Y"),
                                breservation = g.Count(x => x != null && x.isUse == "Y" && x.sDate > today),
                                bdeadline = g.Count(x => x != null && x.isUse == "Y" && x.sDate <= today && x.eDate >= today && x.eDate <= deadline),
                                bing = g.Count(x => x != null && x.isUse == "Y" && x.sDate <= today && x.eDate >= today),
                                bfree = g.Count(x => x != null && x.BannerPrice == 0 && x.mIdx != 19 && x.isUse == "Y" && x.sDate <= today && x.eDate >= today),
                                bcompanyfree = g.Count(x => x != null && x.BannerPrice == 0 && x.mIdx == 19 && x.isUse == "Y" && x.sDate <= today && x.eDate >= today)
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
                            // join b in _appdbcontext.TB_BANNER on c.Idx equals b.bIdx into banners
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
                                bannerprice = c.BannerPrice,
                                ord1 = c.Ord1,
                                ord2 = c.Ord2,
                                bannersizex = c.BannerSizeX,
                                bannersizey = c.BannerSizeY,
                            };

                return query;
            }
            catch
            {
                throw;
            }
        }


        public IQueryable<BannerResponseModel> GetTypeBannerList(int bidx)
        {
            try
            {
                var query = from p in _appdbcontext.TB_BANNER
                            join c in _appdbcontext.member1 on p.mIdx equals c.UID
                            where p.Deleted == "N" && p.bType == "N" && p.bIdx == bidx
                            select new BannerResponseModel
                            {
                                company_name = c.COMPANY_NAME,
                                uid = c.UID,
                                idx = p.Idx,
                                midx = p.mIdx,
                                bidx = p.bIdx,
                                bannerimage = p.BannerImage,
                                bannerlink = p.BannerLink,
                                bannersubject = p.BannerSubject,
                                sdate = p.sDate,
                                edate = p.eDate,
                                isuse = p.isUse,
                                ord = p.Ord,
                                regdate = p.RegDate,
                                bannerprice = p.BannerPrice,
                                bannerwaiting = p.BannerWaiting,
                                remaindays = EF.Functions.DateDiffDay(
                                    DateTime.Today,
                                    p.eDate
                                )
                            };

                return query;
            }
            catch
            {
                throw;
            }
        }

        public IQueryable<BannerCntModel> GetTypeBannerCntList(int bidx)
        {
            try
            {
                var today = DateTime.Today;
                var deadline = today.AddDays(30);


                var query = from p in _appdbcontext.TB_BANNER
                            join c in _appdbcontext.TB_BANNER_TYPE
                            on p.bIdx equals c.Idx
                            where p.Deleted == "N" && p.bType == "N" && p.bIdx == bidx
                            group p by new { p.bIdx, c.BannerCnt, c.BannerSizeX, c.BannerSizeY } into g
                            select new BannerCntModel
                            {
                                bannercnt = g.Key.BannerCnt,
                                bannersizex = g.Key.BannerSizeX,
                                bannersizey = g.Key.BannerSizeY,
                                btotal = g.Count(),
                                bwaiting = g.Count(x => x.BannerWaiting == "Y"),
                                breservation = g.Count(x => x.isUse == "Y" && x.sDate > today),
                                bend = g.Count(x => x.eDate < today),
                                bdeadline = g.Count(x => x.isUse == "Y" && x.sDate <= today && x.eDate >= today && x.eDate <= deadline),
                                bstop = g.Count(x => x.isUse == "N" && x.sDate <= today && x.eDate >= today),
                                bing = g.Count(x => x.isUse == "Y" && x.sDate <= today && x.eDate >= today)
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


        public async Task<List<BannerSearchDataModel>> GetBannerSearchList(BannerSearchModel item)
        {

            var param = new
            {
                Page = item.page,
                PageSize = item.pagesize
            };

            var result = await _connection.QueryAsync<BannerSearchDataModel>(
                "dbo.USP_BANNER_LIST",
                param,
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
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


        public async Task<string> BannerDelete(BannerDeleteRequestModel item)
        {
            var ids = item.idx
            .Where(x => x > 0)
            .Distinct()
            .ToList();

            if (ids.Count == 0) return "fail";


            await using var transaction = await _appdbcontext.Database.BeginTransactionAsync();

            try
            {
                const string sql = @"
                    INSERT INTO BAK_BANNER
                    SELECT
                        *,
                        '관리자삭제',
                        @MemberId,
                        @RegIp,
                        GETDATE()
                    FROM TB_BANNER
                    WHERE Idx IN @Ids
                ";

                await _connection.ExecuteAsync(
                    sql,
                    new
                    {
                        Ids = ids,
                        MemberId = item.memberId,
                        RegIp = item.regIp
                    },
                    transaction: transaction.GetDbTransaction()
                );


                var banners = await _appdbcontext.TB_BANNER.Where(x => ids.Contains(x.Idx) ).ToListAsync();

                foreach (var p in banners)
                {
                    p.Deleted = item.deleteyn ?? "N";
                    p.StartDateWithUse = DateTime.Today;
                }

                int rows = await _appdbcontext.SaveChangesAsync();

                if (rows > 0)
                {
                    await transaction.CommitAsync();
                    return "success";
                }

                return "fail";

            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                _appdbcontext.ChangeTracker.Clear();

                // 디버깅용
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.ToString());

                return "fail";
            }



        }


        public async Task<string> BannerInsert(BannerSetRequestModel item, CancellationToken ct = default)
        {
            try
            {

                var entity = new TB_BANNER
                {
                    mIdx = item.midx,
                    bType = item.btype,
                    BannerLink = item.bannerlink ?? "",
                    BannerSubject = item.bannersubject ?? "",
                    BannerImage = item.savebannerimage,
                    sDate = item.sdate,
                    eDate = item.edate,
                    Ord = item.ord,
                    Deleted = item.deleted,
                    isUse = item.isuse,
                    bIdx = item.bidx,
                    BannerPrice = item.bannerprice,
                    BannerWaiting = item.bannerwaiting,
                    RegID = item.regid,
                    RegIP = item.regip

                };

                await _appdbcontext.TB_BANNER.AddAsync(entity, ct);
                var rows = await _appdbcontext.SaveChangesAsync(ct);

                return rows > 0 ? "success" : "fail";
            }
            catch (Exception ex)
            {
                _appdbcontext.ChangeTracker.Clear();
                return "fail";
            }

        }

        public async Task<string> BannerUpdate(BannerSetRequestModel item, CancellationToken ct = default)
        {
            await using var transaction = await _appdbcontext.Database.BeginTransactionAsync();
            try
            {

                const string sql = @"
                    INSERT INTO BAK_BANNER
                    SELECT
                        *,
                        '배너수정',
                        @BRegID,
                        @BRegIP,
                        GETDATE()
                    FROM TB_BANNER
                    WHERE Idx = @Idx
                ";

                await _connection.ExecuteAsync(
                    sql,
                    new
                    {
                        Idx = item.idx,
                        BRegID = item.bregid,
                        BRegIP = item.bregip
                    },
                    transaction: transaction.GetDbTransaction()
                );


                var p = await _appdbcontext.TB_BANNER.FirstAsync(x => x.Idx == item.idx);

                p.mIdx = item.midx;
                p.bType = item.btype;
                p.BannerLink = item.bannerlink ?? "";
                p.BannerSubject = item.bannersubject ?? "";
                p.BannerImage = item.savebannerimage;
                p.sDate = item.sdate;
                p.eDate = item.edate;
                p.Ord = item.ord;
                p.Deleted = item.deleted;
                p.isUse = item.isuse;
                p.bIdx = item.bidx;
                p.BannerPrice = item.bannerprice;
                p.BannerWaiting = item.bannerwaiting;
                p.RegID = item.regid;
                p.RegIP = item.regip;


                var rows = await _appdbcontext.SaveChangesAsync(ct);

                await transaction.CommitAsync();

                return rows > 0 ? "success" : "fail";
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                _appdbcontext.ChangeTracker.Clear();

                return "fail";
            }
        }
    }

}
