using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class TB_BOARD_WVIEW
{
    public int Idx { get; set; }

    public int BoardIdx { get; set; }

    public string MemberID { get; set; } = null!;

    public string RegIP { get; set; } = null!;

    public DateTime RegDate { get; set; }
}
