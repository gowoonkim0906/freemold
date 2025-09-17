using Freemold.Modules.Models;
using Freemold.Modules.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Freemold.Modules.Services
{
    public class CodeService : ICodeService
    {
        private readonly CodeRepository _codeRepository;

        public CodeService( CodeRepository codeRepository)
        {
            this._codeRepository = codeRepository;
        }

        //code 검색 sort = "용량" , sort "원산지"
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

        //카테고리 리스트
        public async Task<List<VwNcategoryList>> GetVwNcategoryList(string[] ACode, string StdMld = "")
        {
            try
            {
                var query = _codeRepository.GetVwNcategoryList().AsNoTracking();

                if (!string.IsNullOrEmpty(StdMld))
                {
                    query = query.Where(x => x.StdMld == StdMld);
                }

                var list = await query.Where(x => ACode.Contains(x.Acode) && x.Depth > 1)
                            .OrderBy(x => x.Aord)
                            .ThenBy(x => x.Acode)
                            .ThenBy(x => x.Bord)
                            .ThenBy(x => x.Bcode)
                            .ThenBy(x => x.Cord)
                            .ThenBy(x => x.Ccode)
                            .ToListAsync();

                return list;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<CategoryModel>> GetModalVwNcategoryList(string ACode, string StdMld = "" , string[] Selectval = null)
        {
            try
            {
                var query = _codeRepository.GetVwNcategoryList().AsNoTracking();

                query = query.Where(x => x.Bcode != null && x.Bcode.Trim() != "");

                if (!string.IsNullOrEmpty(ACode))
                {
                    query = query.Where(x => x.Acode == ACode );
                }

                if (!string.IsNullOrEmpty(StdMld))
                {
                    query = query.Where(x => x.StdMld == StdMld);
                }

                var list = await query
                            .Select(g => new CategoryModel
                            {
                                Code = g.Code,
                                UpCode = g.UpCode,
                                Acode = g.Acode,
                                Bcode = g.Bcode,
                                Ccode = g.Ccode,
                                Akor = g.Akor,
                                Bkor = g.Bkor,  
                                Ckor = g.Ckor,  
                                Aeng = g.Aeng,  
                                Beng = g.Beng,
                                Ceng = g.Ceng,
                                CatName = g.CatName,
                                StdMld = g.StdMld,
                                Depth = g.Depth,
                                Ord = g.Ord,
                                Aord = g.Aord,
                                Bord = g.Bord,
                                Cord = g.Cord,
                                CheckYN = (Selectval != null
                                           && Selectval.Contains(
                                               string.IsNullOrEmpty(g.Ccode) ? g.Bcode : g.Ccode
                                               ))
                                           ? "Y" : "N"
                            }) 
                            .OrderBy(x => x.Aord)
                            .ThenBy(x => x.Bcode)
                            .ThenBy(x => x.Ccode)
                            .ToListAsync();

                return list;
            }
            catch
            {
                throw;
            }
        }
    }
}
