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
    public class CodeRepository : BaseRepository
    {

        private readonly IDbContextFactory<AppDbContext> _factory;
        public CodeRepository(AppDbContext _appdbcontext, IDbContextFactory<AppDbContext> factory) : base(_appdbcontext)
        {
            _factory = factory;
        }

        //용량 목록 조회
        public IQueryable<TbCode> GetCodeList()
        {
            try
            {
                return _appdbcontext.TbCodes;
            }
            catch 
            {
                throw;
            }
        }

        //카테고리 목록 조회
        public IQueryable<TbCategory> GetCategoryList()
        {
            try
            {
                return _appdbcontext.TbCategories;
            }
            catch
            {
                throw;
            }
        }

        public IQueryable<VwNcategoryList> GetVwNcategoryList()
        {
            try
            {
                return _appdbcontext.VwNcategoryLists;
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> GetCategoryFullname(string category)
        {

            await using var db = await _factory.CreateDbContextAsync();


            var result = await db.Database
            .SqlQuery<string>($@"
                SELECT STRING_AGG(dbo.FN_NCATEGORY_FULLNAME(value), '|') AS Value
                FROM STRING_SPLIT({category}, ',')
            ")
            .SingleOrDefaultAsync();

            return result ?? string.Empty;

        }

        public async Task<List<CategoryFullnameModel>> GetCategoryFullnameList(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
                return new List<CategoryFullnameModel>();

            await using var db = await _factory.CreateDbContextAsync();


            var list = await db.Database.SqlQuery<CategoryFullnameModel>($@"
                SELECT 
                    LTRIM(RTRIM(s.[value])) AS Code,
                    dbo.FN_NCATEGORY_FULLNAME(LTRIM(RTRIM(s.[value]))) AS FullName
                FROM STRING_SPLIT({category}, ',') AS s
            ").ToListAsync();

            return list;

        }
    }
}
