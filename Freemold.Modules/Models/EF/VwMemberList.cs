using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class VwMemberList
{
    public int Uid { get; set; }

    public string MemberId { get; set; } = null!;

    public int Gubun { get; set; }

    public string Name { get; set; } = null!;

    public string ArrName { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? RegDate { get; set; }

    public string Approval { get; set; } = null!;

    public string ApprovalView { get; set; } = null!;

    public int VisitCnt { get; set; }

    public DateTime? EndLoginDate { get; set; }
}
