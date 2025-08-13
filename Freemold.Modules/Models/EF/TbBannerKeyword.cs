using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class TbBannerKeyword
{
    public int Uid { get; set; }

    public string MemberGubun { get; set; } = null!;

    public int MemberUid { get; set; }

    public string Gubun { get; set; } = null!;

    public string? KeyWord1 { get; set; }

    public string? KeyWord2 { get; set; }

    public string? KeyWord3 { get; set; }

    public string? KeyWord4 { get; set; }

    public string WordsLink { get; set; } = null!;

    public string Amount { get; set; } = null!;

    public DateOnly? WordsStart { get; set; }

    public DateOnly? WordsEnd { get; set; }

    public string Memo { get; set; } = null!;

    public DateOnly ChargeDate { get; set; }

    public string Deleted { get; set; } = null!;

    public string RegId { get; set; } = null!;

    public string RegIp { get; set; } = null!;

    public DateTime RegDate { get; set; }
}
