using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class Member4
{
    public int Uid { get; set; }

    public string MemberName { get; set; } = null!;

    public string NickName { get; set; } = null!;

    public string Birthday { get; set; } = null!;

    public string Sex { get; set; } = null!;

    public string Lunar { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Homepage { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string Tel { get; set; } = null!;

    public string Zipcode { get; set; } = null!;

    public string Address1 { get; set; } = null!;

    public string Address2 { get; set; } = null!;

    public string CompName { get; set; } = null!;

    public string CompDept { get; set; } = null!;

    public string Mailing { get; set; } = null!;

    public string Sms { get; set; } = null!;

    public string Approval { get; set; } = null!;

    public string Memo { get; set; } = null!;

    public DateTime? RegDate { get; set; }

    public DateTime? ModDate { get; set; }

    public int MemberLevel { get; set; }

    public int Point { get; set; }

    public DateTime? EndLoginDate { get; set; }

    public string EndLoginIp { get; set; } = null!;

    public int VisitCnt { get; set; }

    public string RegIp { get; set; } = null!;

    public string MemberOpen { get; set; } = null!;

    public DateTime? MemberOpenDate { get; set; }

    public string Country { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Fax { get; set; } = null!;

    public string MemberClass { get; set; } = null!;

    public string MemberType { get; set; } = null!;

    public string LeaveDate { get; set; } = null!;

    public string InterceptDate { get; set; } = null!;

    public string FavoriteBusiness { get; set; } = null!;

    public string MobileAuth { get; set; } = null!;

    public DateTime? MobileAuthDate { get; set; }

    public string EmailAuth { get; set; } = null!;

    public DateTime? EmailAuthDate { get; set; }

    public string MarketingAgree { get; set; } = null!;

    public string? AttrId { get; set; }

    public string Deleted { get; set; } = null!;
}
