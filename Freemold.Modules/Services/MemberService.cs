using Freemold.Modules.Common;
using Freemold.Modules.Models;
using Freemold.Modules.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Freemold.Modules.Services
{
    public class MemberService : IMemberService
    {
        private readonly MemberRepository _memberRepository;
        public MemberService(MemberRepository memberRepository)
        {
            this._memberRepository = memberRepository;
        }


        public async Task<PagedResult<CompanyMemberModel>> CompanyList(string companyname)
        {
            var query = _memberRepository.GetCompanySearchList(companyname).AsNoTracking();

            int totalCount = await query.CountAsync();


            var items = await query
            .OrderBy(x => x.companyname)  //내림차순
            .ToListAsync();


            return new PagedResult<CompanyMemberModel>
            {
                items = items,
                totalcount = totalCount
            };

        }
    }
}
