using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class BakMemberLogin
{
    public int? Uid { get; set; }

    public string? MemberId { get; set; }

    public string? MemberPw { get; set; }

    public string? MemberApproval { get; set; }

    public string? MemberGubun { get; set; }

    public int? MemberUid { get; set; }

    public string? HomeApproval { get; set; }

    public string? HomeUrl { get; set; }

    public string? HomeLevel { get; set; }

    public string? HomeType { get; set; }

    public string? HomeColor { get; set; }

    public string? HomeLayout { get; set; }

    public string? TmpData { get; set; }

    public string? ChkPassword { get; set; }

    public DateTime? ChkPasswordDate { get; set; }

    public int? Visit { get; set; }

    public DateTime? LastDate { get; set; }

    public string? AdminYn { get; set; }

    public string BregType { get; set; } = null!;

    public string BregId { get; set; } = null!;

    public string BregIp { get; set; } = null!;

    public DateTime BregDate { get; set; }

    public int Bidx { get; set; }
}
