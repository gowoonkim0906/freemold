using Freemold.Modules.Models;
using Freemold.Modules.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Services
{
    public class BeautyService : IBeautyService
    {
        private readonly BeautyRepository _beautyRepository;
        private readonly CodeRepository _codeRepository;

        public BeautyService(BeautyRepository beautyRepository , CodeRepository codeRepository)
        {
            this._beautyRepository = beautyRepository;
            this._codeRepository = codeRepository;
        }

        //용량 검색 sort = "용량"
        public async Task<List<TbCode>> GetCodeList(string sort)
        {
            try
            {
                var query = _codeRepository.GetCodeList().AsNoTracking();
                var list = await query.Where(x => x.Sort == sort && x.IsUse == "Y").OrderBy(x => x.Ord).ToListAsync();
                return list;
            }
            catch
            {
                throw;
            }
        }

        //카테고리 검색  
        /*
        A001	프리몰드
        A002	OEM/ODM
        A003	패키징/포장재
        A004	후가공/임가공
        A006	원료
        A007	인증/임상기관
        A008	금형/기계/시공
        A009	디자인/마케팅
        */
        public async Task<List<TbCategory>> GetCategoryList(string UpCode, string StdMld = "")
        {
            try
            {
                var query = _codeRepository.GetCategoryList().AsNoTracking();


                if (!string.IsNullOrEmpty(UpCode))
                {
                    query = query.Where(x => x.UpCode == UpCode);
                }

                if (!string.IsNullOrEmpty(StdMld))
                {
                    query = query.Where(x => x.StdMld == StdMld);
                }

                var list = await query.OrderBy(x => x.Ord).ToListAsync();

                return list;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ProductModel>> GetProductList(string pageorderby)
        {
            try
            {
                var today = DateTime.Today;
                var tenDaysAgo = today.AddDays(-10);

                var query = _beautyRepository.GetProductList()
                            .Where(x => x.Deleted == "N" && 
                                        x.PApproval == "Y" && 
                                        x.PUse == "1" && 
                                        x.Approval == "Y" && 
                                        x.ApprovalView == "Y" &&
                                        x.StartDate <= DateOnly.FromDateTime(today) &&
                                        x.EndDate >= DateOnly.FromDateTime(tenDaysAgo)
                                   )
                            .AsNoTracking();

                if (pageorderby == "hit")
                {
                    query = query.OrderByDescending(x => x.Visit).ThenByDescending(x => x.PHit);
                }
                else if (pageorderby == "caH") {

                    query = query.OrderByDescending(x => x.PCapacity);
                }
                else if (pageorderby == "caL")
                {
                    query = query.OrderBy(x => x.PCapacity == 0 ? 99999 : x.PCapacity);
                }
                else if (pageorderby == "reg")
                {
                    query = query.OrderByDescending(x => x.PRegdate);
                }
                else
                {
                    query = query.OrderByDescending(x => x.Visit);
                }


                var list = await query.OrderByDescending(x => x.PHit).ToListAsync();

                return list;
            }
            catch
            {
                throw;
            }
        }
    }
}
