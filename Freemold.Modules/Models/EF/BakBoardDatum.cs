using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class BakBoardDatum
{
    public long? Uid { get; set; }

    public long? Grp { get; set; }

    public string? BoardCode { get; set; }

    public int? Seq { get; set; }

    public int? Depth { get; set; }

    public string? Notice { get; set; }

    public string? NDate1 { get; set; }

    public string? NDate2 { get; set; }

    public string? RegId { get; set; }

    public string? RegName { get; set; }

    public string? RegEmail { get; set; }

    public string? RegHp { get; set; }

    public string? RegPw { get; set; }

    public string? RegSubject { get; set; }

    public string? RegContent { get; set; }

    public string? RegFileName { get; set; }

    public string? RegFileRename { get; set; }

    public string? ListImageName { get; set; }

    public string? ListImageRename { get; set; }

    public int? HitCounts { get; set; }

    public string? Secret { get; set; }

    public DateTime? RegDate { get; set; }

    public string? Link1 { get; set; }

    public string? Link2 { get; set; }

    public int? Link1Hit { get; set; }

    public int? Link2Hit { get; set; }

    public string? YoutubeUrl { get; set; }

    public DateTime? ModDate { get; set; }

    public string? RegIp { get; set; }

    public string? Appr { get; set; }

    public string? FirstWord { get; set; }

    public int? PIdx { get; set; }

    public string? DName { get; set; }

    public string? DPhone { get; set; }

    public string? DEmail { get; set; }

    public string? ReadId { get; set; }

    public string? Deleted { get; set; }

    public string? UpCat { get; set; }

    public string? Cat { get; set; }

    public string? WName { get; set; }

    public string? WPhone { get; set; }

    public string? WEmail { get; set; }

    public string? WKakaoId { get; set; }

    public string? WType { get; set; }

    public string? Tag0 { get; set; }

    public string? Tag1 { get; set; }

    public string? Tag2 { get; set; }

    public string Btype { get; set; } = null!;

    public string BregId { get; set; } = null!;

    public string BregIp { get; set; } = null!;

    public DateTime BregDate { get; set; }

    public int Bidx { get; set; }
}
