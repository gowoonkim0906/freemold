using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class BAK_BANNER
{
    public int? Idx { get; set; }

    public string? mType { get; set; }

    public int? mIdx { get; set; }

    public string? bType { get; set; }

    public string? bCode { get; set; }

    public string? bIdx { get; set; }

    public string? BannerImage { get; set; }

    public string? BannerType { get; set; }

    public string? BannerLink { get; set; }

    public string? BannerSubject { get; set; }

    public DateTime? sDate { get; set; }

    public DateTime? eDate { get; set; }

    public string? BannerUnlimit { get; set; }

    public DateTime? StartDateWithUse { get; set; }

    public string? isUse { get; set; }

    public int? Ord { get; set; }

    public string? Deleted { get; set; }

    public short? PosX { get; set; }

    public short? PosY { get; set; }

    public string? RegID { get; set; }

    public string? RegIP { get; set; }

    public DateTime? RegDate { get; set; }

    public decimal? BannerPrice { get; set; }

    public string? BannerWaiting { get; set; }

    public string BRegType { get; set; } = null!;

    public string BRegID { get; set; } = null!;

    public string BRegIP { get; set; } = null!;

    public DateTime BRegDate { get; set; }

    public int BakIdx { get; set; }
}
