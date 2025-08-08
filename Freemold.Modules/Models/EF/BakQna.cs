using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class BakQna
{
    public int? QnaUid { get; set; }

    public int? Grp { get; set; }

    public short? Depth { get; set; }

    public string? Gubun { get; set; }

    public int? MemberUid { get; set; }

    public string? MemberGubun { get; set; }

    public string? MemberName { get; set; }

    public string? ReadId { get; set; }

    public int? CompUid { get; set; }

    public string? PCode { get; set; }

    public int? PQty { get; set; }

    public string? Memo { get; set; }

    public string? Upfile { get; set; }

    public string? Upfilename { get; set; }

    public string? Upfile2 { get; set; }

    public string? Upfilename2 { get; set; }

    public string? Upfile3 { get; set; }

    public string? Upfilename3 { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? CompName { get; set; }

    public string? SampleYn { get; set; }

    public string? SampleFee { get; set; }

    public string? EstiRequest { get; set; }

    public string? DlvWay { get; set; }

    public string? DlvCond { get; set; }

    public string? DlvDate { get; set; }

    public string? PaySunsu { get; set; }

    public string? PayJan { get; set; }

    public string? DamdangName { get; set; }

    public string? DamdangTel { get; set; }

    public int? Hits { get; set; }

    public string? Reply { get; set; }

    public string? RecvZip { get; set; }

    public string? RecvAddr1 { get; set; }

    public string? RecvAddr2 { get; set; }

    public string? NameCard { get; set; }

    public int? PIdx { get; set; }

    public string? WriterRead { get; set; }

    public string? Appr { get; set; }

    public string? Smssend { get; set; }

    public string? Deleted { get; set; }

    public DateTime? Regdate { get; set; }

    public string? ComContact { get; set; }

    public string BregType { get; set; } = null!;

    public string BregId { get; set; } = null!;

    public string BregIp { get; set; } = null!;

    public string BregDate { get; set; } = null!;

    public int Bidx { get; set; }
}
