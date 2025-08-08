using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class TbFavoriteUser
{
    public int Idx { get; set; }

    public string MemberId { get; set; } = null!;

    public byte MType { get; set; }

    public int FavoriteFolder { get; set; }

    public string FavoriteType { get; set; } = null!;

    public int PIdx { get; set; }

    public string Deleted { get; set; } = null!;

    public string RegIp { get; set; } = null!;

    public DateTime RegDate { get; set; }
}
