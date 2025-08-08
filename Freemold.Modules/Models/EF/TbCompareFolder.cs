using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class TbCompareFolder
{
    public int Idx { get; set; }

    public string MemberId { get; set; } = null!;

    public string CompareType { get; set; } = null!;

    public string FolderName { get; set; } = null!;

    public string Deleted { get; set; } = null!;

    public string RegIp { get; set; } = null!;

    public DateTime UpdateDate { get; set; }

    public DateTime RegDate { get; set; }
}
