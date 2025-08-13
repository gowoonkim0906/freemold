using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class BakProductUser
{
    public int Idx { get; set; }

    public string ProdName { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int Price { get; set; }

    public string? PImg1 { get; set; }

    public string? PImg2 { get; set; }

    public string? PImg3 { get; set; }

    public string? PImg4 { get; set; }

    public string? PImg5 { get; set; }

    public string? PImg6 { get; set; }

    public string? Contents { get; set; }

    public string Approval { get; set; } = null!;

    public string MemberId { get; set; } = null!;

    public int Visit { get; set; }

    public string Deleted { get; set; } = null!;

    public string RegIp { get; set; } = null!;

    public DateTime RegDate { get; set; }

    public string BregId { get; set; } = null!;

    public string BregIp { get; set; } = null!;

    public DateTime BregDate { get; set; }

    public int Bidx { get; set; }
}
