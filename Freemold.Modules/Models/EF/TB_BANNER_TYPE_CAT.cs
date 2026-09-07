using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class TB_BANNER_TYPE_CAT
{
    public int Idx { get; set; }

    public string CatName { get; set; } = null!;

    public string Cat { get; set; } = null!;

    public string? Code { get; set; }

    public int BannerCnt { get; set; }

    public int BannerPrice { get; set; }

    public short? BannerSizeX { get; set; }

    public short? BannerSizeY { get; set; }

    /// <summary>
    /// 노출방식(fixed:고정 , rolling:롤링)
    /// </summary>
    public string? BannerMode { get; set; }

    public short? BannerMonths { get; set; }

    public string? Memo { get; set; }
}
