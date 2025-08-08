using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class BakMember4
{
    public int? Uid { get; set; }

    public string? MemberName { get; set; }

    public string? NickName { get; set; }

    public string? Birthday { get; set; }

    public string? Sex { get; set; }

    public string? Lunar { get; set; }

    public string? Email { get; set; }

    public string? Homepage { get; set; }

    public string? Mobile { get; set; }

    public string? Tel { get; set; }

    public string? Zipcode { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? CompName { get; set; }

    public string? CompDept { get; set; }

    public string? Mailing { get; set; }

    public string? Sms { get; set; }

    public string? Approval { get; set; }

    public string? Memo { get; set; }

    public DateTime? RegDate { get; set; }

    public DateTime? ModDate { get; set; }

    public int? MemberLevel { get; set; }

    public int? Point { get; set; }

    public DateTime? EndLoginDate { get; set; }

    public string? EndLoginIp { get; set; }

    public int? VisitCnt { get; set; }

    public string? RegIp { get; set; }

    public string? MemberOpen { get; set; }

    public DateTime? MemberOpenDate { get; set; }

    public string? Country { get; set; }

    public string? FirstName { get; set; }

    public string? Fax { get; set; }

    public string? MemberClass { get; set; }

    public string? MemberType { get; set; }

    public string? LeaveDate { get; set; }

    public string? InterceptDate { get; set; }

    public string? FavoriteBusiness { get; set; }

    public string? MobileAuth { get; set; }

    public DateTime? MobileAuthDate { get; set; }

    public string? EmailAuth { get; set; }

    public DateTime? EmailAuthDate { get; set; }

    public string? MarketingAgree { get; set; }

    public string? AttrId { get; set; }

    public string? Deleted { get; set; }

    public string BregType { get; set; } = null!;

    public string BregId { get; set; } = null!;

    public string BregIp { get; set; } = null!;

    public DateTime BregDate { get; set; }

    public int Bidx { get; set; }
}
