using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Common
{
    public partial class AppDbContext
    {
        [DbFunction("FN_IMAGECOUNT", "dbo")]
        public static int FnImageCount(long prodUid)
        => throw new NotSupportedException();

    }
}
