using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class Qna
{
    public int QnaUid { get; set; }

    public int Grp { get; set; }

    public short Depth { get; set; }

    public string Gubun { get; set; } = null!;

    public int MemberUid { get; set; }

    public string MemberGubun { get; set; } = null!;

    public string MemberName { get; set; } = null!;

    public string ReadId { get; set; } = null!;

    public int CompUid { get; set; }

    public string PCode { get; set; } = null!;

    public int PQty { get; set; }

    public string Memo { get; set; } = null!;

    public string? Upfile { get; set; }

    public string? Upfilename { get; set; }

    public string? Upfile2 { get; set; }

    public string? Upfilename2 { get; set; }

    public string? Upfile3 { get; set; }

    public string? Upfilename3 { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string CompName { get; set; } = null!;

    public string SampleYn { get; set; } = null!;

    public string SampleFee { get; set; } = null!;

    public string EstiRequest { get; set; } = null!;

    public string DlvWay { get; set; } = null!;

    public string DlvCond { get; set; } = null!;

    public string DlvDate { get; set; } = null!;

    public string PaySunsu { get; set; } = null!;

    public string PayJan { get; set; } = null!;

    public string DamdangName { get; set; } = null!;

    public string DamdangTel { get; set; } = null!;

    public int Hits { get; set; }

    public string Reply { get; set; } = null!;

    public string? RecvZip { get; set; }

    public string? RecvAddr1 { get; set; }

    public string? RecvAddr2 { get; set; }

    public string? NameCard { get; set; }

    public int? PIdx { get; set; }

    public string WriterRead { get; set; } = null!;

    public string Appr { get; set; } = null!;

    public string Smssend { get; set; } = null!;

    public string Deleted { get; set; } = null!;

    public DateTime Regdate { get; set; }

    public string ComContact { get; set; } = null!;
}
