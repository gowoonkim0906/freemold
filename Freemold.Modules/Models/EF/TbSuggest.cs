using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class TbSuggest
{
    public int Idx { get; set; }

    public string Suggest { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string MType { get; set; } = null!;

    public int MIdx { get; set; }

    public string MemberId { get; set; } = null!;

    public string Deleted { get; set; } = null!;

    public string RegIp { get; set; } = null!;

    public DateTime RegDate { get; set; }
}
