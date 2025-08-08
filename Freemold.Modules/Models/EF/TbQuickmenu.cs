using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class TbQuickmenu
{
    public int Idx { get; set; }

    public string MType { get; set; } = null!;

    public int MIdx { get; set; }

    public string MemberId { get; set; } = null!;

    public string QuickName { get; set; } = null!;

    public string QuickUrl { get; set; } = null!;

    public int Visit { get; set; }

    public string Deleted { get; set; } = null!;

    public string RegIp { get; set; } = null!;

    public DateTime RegDate { get; set; }
}
