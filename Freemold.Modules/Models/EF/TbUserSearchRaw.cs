using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class TbUserSearchRaw
{
    public int Idx { get; set; }

    public string RegIp { get; set; } = null!;

    public string RegId { get; set; } = null!;

    public DateTime RegDate { get; set; }

    public string Url { get; set; } = null!;

    public string? UserAgent { get; set; }
}
