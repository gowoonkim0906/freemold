using Freemold.Modules.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Services
{
    public interface IBannerService
    {
        Task<List<TbBanner>> BannerList(List<string> bannerIds);
    }
}
