using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class TbBannerTypeCat
{
    public int Idx { get; set; }

    public string CatName { get; set; } = null!;

    public string Cat { get; set; } = null!;

    public string? Code { get; set; }

    public int BannerCnt { get; set; }

    public int BannerPrice { get; set; }
}
