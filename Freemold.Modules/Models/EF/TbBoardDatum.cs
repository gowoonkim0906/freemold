using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class TbBoardDatum
{
    public long Uid { get; set; }

    public long Grp { get; set; }

    public string BoardCode { get; set; } = null!;

    public int Seq { get; set; }

    public int Depth { get; set; }

    public string Notice { get; set; } = null!;

    public string NDate1 { get; set; } = null!;

    public string NDate2 { get; set; } = null!;

    public string RegId { get; set; } = null!;

    public string RegName { get; set; } = null!;

    public string RegEmail { get; set; } = null!;

    public string RegHp { get; set; } = null!;

    public string RegPw { get; set; } = null!;

    public string RegSubject { get; set; } = null!;

    public string RegContent { get; set; } = null!;

    public string RegFileName { get; set; } = null!;

    public string RegFileRename { get; set; } = null!;

    public string ListImageName { get; set; } = null!;

    public string ListImageRename { get; set; } = null!;

    public int HitCounts { get; set; }

    public string Secret { get; set; } = null!;

    public DateTime? RegDate { get; set; }

    public string Link1 { get; set; } = null!;

    public string Link2 { get; set; } = null!;

    public int Link1Hit { get; set; }

    public int Link2Hit { get; set; }

    public string YoutubeUrl { get; set; } = null!;

    public DateTime? ModDate { get; set; }

    public string RegIp { get; set; } = null!;

    public string Appr { get; set; } = null!;

    public string FirstWord { get; set; } = null!;

    public int? PIdx { get; set; }

    /// <summary>
    /// 리플_담당자이름
    /// </summary>
    public string? DName { get; set; }

    /// <summary>
    /// 리플_담당자연락처
    /// </summary>
    public string? DPhone { get; set; }

    /// <summary>
    /// 리플_담당자이메일
    /// </summary>
    public string? DEmail { get; set; }

    public string? ReadId { get; set; }

    public string Deleted { get; set; } = null!;

    public string? UpCat { get; set; }

    public string? Cat { get; set; }

    public string? WName { get; set; }

    public string? WPhone { get; set; }

    public string? WEmail { get; set; }

    public string? WKakaoId { get; set; }

    public string WType { get; set; } = null!;

    public string Tag0 { get; set; } = null!;

    public string Tag1 { get; set; } = null!;

    public string Tag2 { get; set; } = null!;
}
