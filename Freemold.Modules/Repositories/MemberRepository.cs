using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Freemold.Modules.Common;

namespace Freemold.Modules.Repositories
{
    public class MemberRepository : BaseRepository
    {
        public MemberRepository(AppDbContext _appdbcontext) : base(_appdbcontext)
        {}

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
    }
}
