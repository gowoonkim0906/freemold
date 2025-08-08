using Freemold.Modules.Common;
using Freemold.Modules.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Services
{
    public class Test : ITest
    {
        private readonly AppDbContext _appdbcontext;

        public Test(AppDbContext appdbcontext)
        {

            this._appdbcontext = appdbcontext;
        }
        public List<BakBanner> tt() { 
        
            var list = _appdbcontext.BakBanners.ToList();

            return list;

        }


    }
}
