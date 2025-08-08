using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class TbAdminLog
{
    public int Idx { get; set; }

    public string MemberId { get; set; } = null!;

    public string Domain { get; set; } = null!;

    public string UserAgent { get; set; } = null!;

    public string? Referer { get; set; }

    public string LoginStatus { get; set; } = null!;

    public string RegIp { get; set; } = null!;

    public DateTime RegDate { get; set; }
}
