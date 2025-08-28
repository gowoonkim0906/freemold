using Freemold.Modules.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _appdbcontext;

        protected BaseRepository(AppDbContext appdbcontext)
        {
            this._appdbcontext = appdbcontext;
        }
    }
}
