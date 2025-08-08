using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class TbBannerClick
{
    public int Idx { get; set; }

    public string? RegId { get; set; }

    public string RegIp { get; set; } = null!;

    public DateTime RegDate { get; set; }

    public int BannerIdx { get; set; }

    public int BannermIdx { get; set; }

    public string CompanyName { get; set; } = null!;

    public string BannerLink { get; set; } = null!;

    public string BannerLocationType { get; set; } = null!;

    public int BannerLocationIdx { get; set; }

    public string BannerName1 { get; set; } = null!;

    public string BannerName2 { get; set; } = null!;

    public DateOnly InDate { get; set; }
}
