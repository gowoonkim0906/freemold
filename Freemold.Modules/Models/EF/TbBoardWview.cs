using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class TbBoardWview
{
    public int Idx { get; set; }

    public int BoardIdx { get; set; }

    public string MemberId { get; set; } = null!;

    public string RegIp { get; set; } = null!;

    public DateTime RegDate { get; set; }
}
