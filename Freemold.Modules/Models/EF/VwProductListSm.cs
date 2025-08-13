using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class VwProductListSm
{
    public long ProdUid { get; set; }

    public string ItId { get; set; } = null!;

    public string CoId { get; set; } = null!;

    public string MemberGubun { get; set; } = null!;

    public int MemberUid { get; set; }

    public string PCategory { get; set; } = null!;

    public string PName { get; set; } = null!;

    public string PName2 { get; set; } = null!;

    public string PCode { get; set; } = null!;

    public int PMoq { get; set; }

    public string PMoqDeal { get; set; } = null!;

    public string PImg1 { get; set; } = null!;

    public string PImg2 { get; set; } = null!;

    public string PImg3 { get; set; } = null!;

    public string PImg4 { get; set; } = null!;

    public string PImg5 { get; set; } = null!;

    public string PImg6 { get; set; } = null!;

    public double PCapacity { get; set; }

    public string PCapUnit { get; set; } = null!;

    public string PSize { get; set; } = null!;

    public string POrigin { get; set; } = null!;

    public string PMemo { get; set; } = null!;

    public string PMemo2 { get; set; } = null!;

    public DateTime PRegdate { get; set; }

    public DateTime? PModdate { get; set; }

    public DateTime? PAppdate { get; set; }

    public string PUse { get; set; } = null!;

    public string PUseSt { get; set; } = null!;

    public string PNew { get; set; } = null!;

    public string PHot { get; set; } = null!;

    public string PQuality { get; set; } = null!;

    public int PSeq { get; set; }

    public int PHit { get; set; }

    public string IsRefill { get; set; } = null!;

    public string IsPcr { get; set; } = null!;

    public int Visit { get; set; }

    public string PApproval { get; set; } = null!;

    public string ProdType { get; set; } = null!;

    public string Deleted { get; set; } = null!;

    public string UpCat { get; set; } = null!;

    public string Cat { get; set; } = null!;
}
