using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class TbConnectionSm
{
    public long Idx { get; set; }

    public int MTimeStamp { get; set; }

    public string Domain { get; set; } = null!;

    public string UserAgent { get; set; } = null!;

    public string RegIp { get; set; } = null!;

    public DateTime RegDate { get; set; }

    public string? HttpReferer { get; set; }

    public DateOnly InDate { get; set; }

    public long Ipnum { get; set; }

    public string CCode { get; set; } = null!;
}
