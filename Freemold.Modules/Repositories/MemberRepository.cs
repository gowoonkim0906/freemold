using Freemold.Modules.Common;
using Freemold.Modules.Models;
using Freemold.Modules.Models.Table;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Freemold.Modules.Repositories
{
    public class MemberRepository : BaseRepository
    {
        public MemberRepository(AppDbContext _appdbcontext) : base(_appdbcontext)
        { }


        public async Task<JoinAuthModel> JoinAuth(int conidx, string mobile, string email, string authtype, string regip)
        {
            try
            {
                var MobileChk = new SqlParameter("@MobileChk", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                var EmailChk = new SqlParameter("@EmailChk", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                var AuthKey = new SqlParameter("@AuthKey", SqlDbType.Char, 6)
                {
                    Direction = ParameterDirection.Output
                };

                await _appdbcontext.Database.ExecuteSqlRawAsync(@"
            EXEC dbo.USP_AUTH 
                @ConIdx = @p0, 
                @Mobile = @p1, 
                @Email = @p2, 
                @AuthType = @p3, 
                @RegIP = @p4, 
                @MobileChk = @MobileChk OUTPUT, 
                @EmailChk = @EmailChk OUTPUT,
                @AuthKey = @AuthKey OUTPUT",
                    conidx,
                    mobile,
                    email,
                    authtype,
                    regip,
                    MobileChk,
                    EmailChk,
                    AuthKey
                );


                return new JoinAuthModel
                {
                    mobilechk = (int)(MobileChk.Value ?? 0),
                    emailchk = (int)(EmailChk.Value ?? 0),
                    authkey = (string)(AuthKey.Value?.ToString() ?? "")
                };

            }
            catch (Exception ex)
            {
                return new JoinAuthModel();
            }
        }

        public Task<bool> ExistsByEmailAsync(string email)
        {

            var q =
                from m in _appdbcontext.Member4.AsNoTracking()
                join t in _appdbcontext.MemberLogins.AsNoTracking()
                    on m.Uid equals t.MemberUid
                where m.Email == email && m.Approval == "Y" && t.MemberApproval != "N"
                select m;

            return q.AnyAsync();
        }

        public Task<bool> ExistsByMobileAsync(string mobile)
        {
            var q =
                from m in _appdbcontext.Member4.AsNoTracking()
                join t in _appdbcontext.MemberLogins.AsNoTracking()
                    on m.Uid equals t.MemberUid
                where m.Mobile == mobile && m.Approval == "Y" && t.MemberApproval != "N"
                select m;

            return q.AnyAsync();
        }


        public IQueryable<MemberInfo> MemberInfo()
        {
            var query =
                from m in _appdbcontext.Member4.AsNoTracking()
                join t in _appdbcontext.MemberLogins.AsNoTracking()
                    on m.Uid equals t.MemberUid
                where  m.Approval == "Y" && t.MemberApproval != "N"
                select new MemberInfo {
                    memberuid = m.Uid,
                    memberid = t.MemberId,
                    membername = m.MemberName,
                    memberemail = m.Email,
                    membermobile = m.Mobile,
                    membergubun = t.MemberGubun
                };

            return query;
        }

        public async Task<DupCheckResponse> DuplicateCheck(DuplicateCheckRequest duplicatecheckrequest)
        {
            try
            {
                var emailExists = false;
                var mobileExists = false;


                if (!string.IsNullOrWhiteSpace(duplicatecheckrequest.email))
                    emailExists = await ExistsByEmailAsync(duplicatecheckrequest.email);

                if (!string.IsNullOrWhiteSpace(duplicatecheckrequest.mobile))
                    mobileExists = await ExistsByMobileAsync(duplicatecheckrequest.mobile);

                return new DupCheckResponse { emailexists = emailExists, mobileexists = mobileExists };
            }
            catch (Exception ex)
            {
                return new DupCheckResponse();
            }
        }

        public async Task<string> FindidqwLogInsert(TbFindidpwLog input, CancellationToken ct = default)
        {
            try
            {
                var entity = new TbFindidpwLog
                {
                    ConIdx = input.ConIdx,
                    FindType = input.FindType,
                    MName = input.MName,
                    MId = input.MId,
                    AddInfo = input.AddInfo,
                    RegIp = input.RegIp,
                    RegDate = DateTime.Now
                };

                await _appdbcontext.TbFindidpwLogs.AddAsync(entity, ct);
                var rows = await _appdbcontext.SaveChangesAsync(ct);

                return rows > 0 ? "success" : "fail";
            }
            catch (Exception ex)
            {
                _appdbcontext.ChangeTracker.Clear();
                return "fail";
            }

            
        }

        public async Task<string> PasswordUpdate(int memberuid, string pwd)
        {

            string result = "success";

            try
            {
                var p = await _appdbcontext.MemberLogins.FirstAsync(x => x.MemberGubun == "4" && x.MemberUid == memberuid);

                //패스워드 수정
                p.MemberPw = pwd;
                p.TmpData = pwd;
                p.ChkPassword = "Y";
                p.ChkPasswordDate = DateTime.Now;

                var rows = await _appdbcontext.SaveChangesAsync();

                if (rows <= 0) result = "fail";
            }
            catch (Exception ex)
            {
                result = "fail";

                _appdbcontext.ChangeTracker.Clear();      // 선택: 메모리 상태 초기화
                throw;
            }


            return result;
        }

    }
}
