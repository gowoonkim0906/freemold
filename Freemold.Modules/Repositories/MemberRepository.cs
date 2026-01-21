using Freemold.Modules.Common;
using Freemold.Modules.Models;
using Freemold.Modules.Models.Table;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
                var AuthKey = new SqlParameter("@AuthKey", SqlDbType.Char,6)
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
            catch(Exception ex)
            {
                return new JoinAuthModel();
            }
        }


        public Task<bool> ExistsByEmailAsync(string email) {

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
    }
}
