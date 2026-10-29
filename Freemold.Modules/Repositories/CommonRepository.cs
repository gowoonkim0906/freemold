using Freemold.Modules.Common;
using Freemold.Modules.Models;
using Freemold.Modules.Models.Table;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Dapper;

namespace Freemold.Modules.Repositories
{
    public class CommonRepository : BaseRepository
    {
        public CommonRepository(AppDbContext _appdbcontext) : base(_appdbcontext)
        { }

        //차단아이피 목록
        public IQueryable<TbBlockIp> GetBlockIp()
        {
            try
            {
                return _appdbcontext.TbBlockIps;
            }
            catch
            {
                throw;
            }
        }

        //allinkbeauty 접속자 정보 등록
        public async Task<UspconnectionModel> AllinKVisitorInsert(TB_CONNECTION_ALLINKBEAUTY connection)
        {
            try
            {
                var idxParam = new SqlParameter("@Idx", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Output
                };
                var tsParam = new SqlParameter("@mTimeStamp", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                await _appdbcontext.Database.ExecuteSqlRawAsync(@"
            EXEC dbo.USP_CONNECTION_ALLINKBEAUTY 
                @SessionID = @p0, 
                @Domain = @p1, 
                @UserAgent = @p2, 
                @Referer = @p3, 
                @RegIP = @p4, 
                @Idx = @Idx OUTPUT, 
                @mTimeStamp = @mTimeStamp OUTPUT",
                    connection.sessionid,
                    connection.Domain,
                    connection.UserAgent,
                    connection.HttpReferer,
                    connection.RegIP,
                    idxParam,
                    tsParam
                );

                return new UspconnectionModel
                {
                    Idx = (long)(idxParam.Value ?? 0),
                    mTimeStamp = (int)(tsParam.Value ?? 0)
                };
            }
            catch (Exception ex)
            {
                return new UspconnectionModel();
            }
        }

        //직수입 접속 카운트
        public async Task SaveDirectImportVisitor(DirectimportVisitorRequest item)
        {
            var param = new
            {
                mTimeStamp = item.mtimestamp,
                MemberID = item.memberid,
                mType = item.mtype,
                MemberName = item.membername,
                RegIP = item.regip
            };

            await _connection.ExecuteAsync(
                "dbo.USP_DIRECTIMPORT_VISITOR",
                param,
                commandType: CommandType.StoredProcedure
            );
        }



        public async Task<dynamic> GetDbInfo()
        {
            const string sql = @"
            SELECT
                @@SERVERNAME AS ServerName,
                DB_NAME() AS DatabaseName
            ";

                return await _connection.QuerySingleAsync(sql);
        }
    }
}
