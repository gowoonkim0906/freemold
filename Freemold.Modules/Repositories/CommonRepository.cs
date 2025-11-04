using Freemold.Modules.Common;
using Freemold.Modules.Models;
using Freemold.Modules.Models.Table;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;


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
                @Domain = @p0, 
                @UserAgent = @p1, 
                @Referer = @p2, 
                @RegIP = @p3, 
                @Idx = @Idx OUTPUT, 
                @mTimeStamp = @mTimeStamp OUTPUT",
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
    }
}
