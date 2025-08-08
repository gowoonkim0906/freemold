using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class BakFavorite
{
    public int? Idx { get; set; }

    public string? MemberId { get; set; }

    public byte? MType { get; set; }

    public int? FavoriteFolder { get; set; }

    public string? FavoriteType { get; set; }

    public int? PIdx { get; set; }

    public string? Deleted { get; set; }

    public string? RegIp { get; set; }

    public DateTime? RegDate { get; set; }

    public string BregId { get; set; } = null!;

    public string BregIp { get; set; } = null!;

    public DateTime BregDate { get; set; }

    public int Bidx { get; set; }
}
