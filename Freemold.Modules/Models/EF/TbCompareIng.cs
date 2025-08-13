using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class TbCompareIng
{
    public int Idx { get; set; }

    public string MemberId { get; set; } = null!;

    public int MIdx { get; set; }

    public byte MType { get; set; }

    public int MTimeStamp { get; set; }

    public string ViewType { get; set; } = null!;

    public int PIdx { get; set; }

    public string Deleted { get; set; } = null!;

    public string RegIp { get; set; } = null!;

    public DateTime RegDate { get; set; }
}
