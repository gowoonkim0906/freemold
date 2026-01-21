using Freemold.Modules.Models;
using Freemold.Modules.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Freemold.Modules.Services
{
    public class FreemoldService : IFreemoldService
    {
        private readonly MemberRepository _memberRepository;

        public FreemoldService(MemberRepository memberRepository)
        {
            this._memberRepository = memberRepository;
        }


        public async Task<JoinAuthModel> JoinAuth(int conidx, string mobile, string email, string authtype, string regip)
        {
            var result = _memberRepository.JoinAuth(conidx, mobile, email, authtype, regip);
            return await result;
        }


        public async Task<DupCheckResponse> DuplicateCheck(DuplicateCheckRequest duplicatecheckrequest)
        {
            var result = _memberRepository.DuplicateCheck(duplicatecheckrequest);
            return await result;
        }
    }
}
