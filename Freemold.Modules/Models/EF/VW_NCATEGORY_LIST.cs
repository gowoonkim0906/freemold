using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class VW_NCATEGORY_LIST
{
    public string Code { get; set; } = null!;

    public string UpCode { get; set; } = null!;

    public string ACode { get; set; } = null!;

    public string BCode { get; set; } = null!;

    public string CCode { get; set; } = null!;

    public string AKor { get; set; } = null!;

    public string BKor { get; set; } = null!;

    public string CKor { get; set; } = null!;

    public string AEng { get; set; } = null!;

    public string BEng { get; set; } = null!;

    public string CEng { get; set; } = null!;

    public string? CatName { get; set; }

    public string? CatNameEng { get; set; }

    public string StdMld { get; set; } = null!;

    public byte Depth { get; set; }

    public byte Ord { get; set; }

    public byte AOrd { get; set; }

    public byte BOrd { get; set; }

    public byte COrd { get; set; }
}
