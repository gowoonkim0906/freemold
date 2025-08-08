using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class TbHomepage
{
    public int Idx { get; set; }

    public string MemberId { get; set; } = null!;

    public string MemberGubun { get; set; } = null!;

    public int MemberUid { get; set; }

    public string HomeUrl { get; set; } = null!;

    public string? HomeLogo { get; set; }

    public string? HomeCenterTel { get; set; }

    public string? HomeCenterMemo { get; set; }

    public string? HomeMainImage { get; set; }

    public string? HomeSubImage { get; set; }

    public string? HomeSimpleIntro { get; set; }

    public string? HomeCompanyIntro { get; set; }

    public string IsUse { get; set; } = null!;

    public int Visit { get; set; }

    public string Deleted { get; set; } = null!;

    public string RegId { get; set; } = null!;

    public string RegIp { get; set; } = null!;

    public DateTime RegDate { get; set; }
}
