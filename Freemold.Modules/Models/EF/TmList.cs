using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class TmList
{
    public long Uid { get; set; }

    public string MemberGubun { get; set; } = null!;

    public int MemberUid { get; set; }

    public string CompanyName { get; set; } = null!;

    public DateTime TmDate { get; set; }

    public string Reservation { get; set; } = null!;

    public string Memo { get; set; } = null!;

    public string Contact { get; set; } = null!;

    public string RegManageId { get; set; } = null!;

    public DateTime RegDate { get; set; }

    public string ModManageId { get; set; } = null!;

    public DateTime ModDate { get; set; }

    public string RegIp { get; set; } = null!;

    public string Deleted { get; set; } = null!;
}
