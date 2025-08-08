using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class TbFavoriteChain
{
    public int Idx { get; set; }

    public string MemberId { get; set; } = null!;

    public int ItemIdx { get; set; }

    public int FolderIdx { get; set; }

    public string Deleted { get; set; } = null!;

    public string RegIp { get; set; } = null!;

    public DateTime RegDate { get; set; }
}
