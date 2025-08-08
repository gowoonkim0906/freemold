using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class TbBannerType
{
    public int Idx { get; set; }

    public string BannerPosition { get; set; } = null!;

    public string BannerType { get; set; } = null!;

    public short BannerCnt { get; set; }

    public short BannerSizeX { get; set; }

    public short BannerSizeY { get; set; }

    public string? BannerSize { get; set; }

    public int BannerPrice { get; set; }

    public string? BannerName1 { get; set; }

    public string? BannerName2 { get; set; }

    public string? Memo { get; set; }

    public int Ord1 { get; set; }

    public int Ord2 { get; set; }

    public string RegIp { get; set; } = null!;

    public DateTime RegDate { get; set; }
}
