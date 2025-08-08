using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class MemberLogin
{
    public int Uid { get; set; }

    public string MemberId { get; set; } = null!;

    public string MemberPw { get; set; } = null!;

    public string MemberApproval { get; set; } = null!;

    public string MemberGubun { get; set; } = null!;

    public int MemberUid { get; set; }

    public string HomeApproval { get; set; } = null!;

    public string HomeUrl { get; set; } = null!;

    public string HomeLevel { get; set; } = null!;

    public string HomeType { get; set; } = null!;

    public string HomeColor { get; set; } = null!;

    public string HomeLayout { get; set; } = null!;

    public string? TmpData { get; set; }

    public string ChkPassword { get; set; } = null!;

    public DateTime? ChkPasswordDate { get; set; }

    public int Visit { get; set; }

    public DateTime? LastDate { get; set; }

    public string? AdminYn { get; set; }
}
