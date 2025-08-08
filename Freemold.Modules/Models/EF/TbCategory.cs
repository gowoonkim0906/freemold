using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class TbCategory
{
    public int Idx { get; set; }

    public string UpCode { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string NameKor { get; set; } = null!;

    public string? NameEng { get; set; }

    public byte Depth { get; set; }

    public string StdMld { get; set; } = null!;

    public byte Ord { get; set; }

    public short OldCode { get; set; }

    public string? Memo { get; set; }
}
