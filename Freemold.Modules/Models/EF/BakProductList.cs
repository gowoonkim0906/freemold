using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class BakProductList
{
    public long? ProdUid { get; set; }

    public string? ItId { get; set; }

    public string? CoId { get; set; }

    public string? MemberGubun { get; set; }

    public int? MemberUid { get; set; }

    public string? PCategory { get; set; }

    public string? PName { get; set; }

    public string? PName2 { get; set; }

    public string? PCode { get; set; }

    public int? PMoq { get; set; }

    public string? PMoqDeal { get; set; }

    public string? PImg1 { get; set; }

    public string? PImg2 { get; set; }

    public string? PImg3 { get; set; }

    public string? PImg4 { get; set; }

    public string? PImg5 { get; set; }

    public string? PImg6 { get; set; }

    public string? PCapacity { get; set; }

    public string? PCapUnit { get; set; }

    public string? PSize { get; set; }

    public string? POrigin { get; set; }

    public string? PMemo { get; set; }

    public string? PMemo2 { get; set; }

    public DateTime? PRegdate { get; set; }

    public DateTime? PModdate { get; set; }

    public DateTime? PAppdate { get; set; }

    public string? PUse { get; set; }

    public string? PUseSt { get; set; }

    public string? PNew { get; set; }

    public string? PHot { get; set; }

    public string? PQuality { get; set; }

    public int? PSeq { get; set; }

    public int? PHit { get; set; }

    public string? IsRefill { get; set; }

    public string? IsPcr { get; set; }

    public string? IsMove { get; set; }

    public int? Visit { get; set; }

    public string? PApproval { get; set; }

    public string? ProdType { get; set; }

    public string? Deleted { get; set; }

    public string? UpCat { get; set; }

    public string? Cat { get; set; }

    public string? Tag0 { get; set; }

    public string? Tag1 { get; set; }

    public string? Tag2 { get; set; }

    public string? Tag3 { get; set; }

    public string? Tag4 { get; set; }

    public string? Tag5 { get; set; }

    public string? Tag6 { get; set; }

    public string? Tag7 { get; set; }

    public string? Tag8 { get; set; }

    public string? Tag9 { get; set; }

    public string BregType { get; set; } = null!;

    public string BregId { get; set; } = null!;

    public string BregIp { get; set; } = null!;

    public DateTime BregDate { get; set; }

    public int Bidx { get; set; }
}
