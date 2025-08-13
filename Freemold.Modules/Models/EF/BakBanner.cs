using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class BakBanner
{
    public int? Idx { get; set; }

    public string? MType { get; set; }

    public int? MIdx { get; set; }

    public string? BType { get; set; }

    public string? BIdx { get; set; }

    public string? BCode { get; set; }

    public string? BannerImage { get; set; }

    public string? BannerType { get; set; }

    public string? BannerLink { get; set; }

    public string? BannerSubject { get; set; }

    public DateTime? SDate { get; set; }

    public DateTime? EDate { get; set; }

    public string? BannerUnlimit { get; set; }

    public DateTime? StartDateWithUse { get; set; }

    public string? IsUse { get; set; }

    public int? Ord { get; set; }

    public string? Deleted { get; set; }

    public short? PosX { get; set; }

    public short? PosY { get; set; }

    public string? RegId { get; set; }

    public string? RegIp { get; set; }

    public DateTime? RegDate { get; set; }

    public string BregType { get; set; } = null!;

    public string BregId { get; set; } = null!;

    public string BregIp { get; set; } = null!;

    public DateTime BregDate { get; set; }

    public int BakIdx { get; set; }
}
