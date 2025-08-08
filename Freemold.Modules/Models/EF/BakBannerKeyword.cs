using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class BakBannerKeyword
{
    public int? Uid { get; set; }

    public string? MemberGubun { get; set; }

    public int? MemberUid { get; set; }

    public string? Gubun { get; set; }

    public string? KeyWord1 { get; set; }

    public string? KeyWord2 { get; set; }

    public string? KeyWord3 { get; set; }

    public string? KeyWord4 { get; set; }

    public string? WordsLink { get; set; }

    public string? Amount { get; set; }

    public DateOnly? WordsStart { get; set; }

    public DateOnly? WordsEnd { get; set; }

    public string? Memo { get; set; }

    public DateOnly? ChargeDate { get; set; }

    public string? Deleted { get; set; }

    public string? RegId { get; set; }

    public string? RegIp { get; set; }

    public DateTime? RegDate { get; set; }

    public string BregType { get; set; } = null!;

    public string BregId { get; set; } = null!;

    public string BregIp { get; set; } = null!;

    public DateTime BregDate { get; set; }

    public int Bidx { get; set; }
}
