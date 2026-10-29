using Freemold.Modules.Models;
using Freemold.Modules.Models.Table;
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
        private readonly CommonRepository _commonRepository;

        public FreemoldService(MemberRepository memberRepository, CommonRepository commonRepository)
        {
            this._memberRepository = memberRepository;
            _commonRepository = commonRepository;
        }


        public async Task<JoinAuthModel> JoinAuth(int conidx, string mobile, string email, string authtype, string regip, string memberid)
        {
            var result = _memberRepository.JoinAuth(conidx, mobile, email, authtype, regip, memberid);
            return await result;
        }


        public async Task<DupCheckResponse> DuplicateCheck(DuplicateCheckRequest duplicatecheckrequest)
        {
            var result = _memberRepository.DuplicateCheck(duplicatecheckrequest);
            return await result;
        }

        public async Task<bool> DirectimportVisitorSave(DirectimportVisitorRequest item)
        {

            try
            {
                await _commonRepository.SaveDirectImportVisitor(item);

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }


        public async Task<dynamic> GetDbInfo()
        {
            return await _commonRepository.GetDbInfo();
        }
    }
}
