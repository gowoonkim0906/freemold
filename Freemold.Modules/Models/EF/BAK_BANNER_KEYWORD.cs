using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class BAK_BANNER_KEYWORD
{
    public int? UID { get; set; }

    public string? MEMBER_GUBUN { get; set; }

    public int? MEMBER_UID { get; set; }

    public string? GUBUN { get; set; }

    public string? KEY_WORD1 { get; set; }

    public string? KEY_WORD2 { get; set; }

    public string? KEY_WORD3 { get; set; }

    public string? KEY_WORD4 { get; set; }

    public string? WORDS_LINK { get; set; }

    public string? AMOUNT { get; set; }

    public DateOnly? WORDS_START { get; set; }

    public DateOnly? WORDS_END { get; set; }

    public string? MEMO { get; set; }

    public DateOnly? CHARGE_DATE { get; set; }

    public string? Deleted { get; set; }

    public string? RegID { get; set; }

    public string? RegIP { get; set; }

    public DateTime? RegDate { get; set; }

    public string BRegType { get; set; } = null!;

    public string BRegID { get; set; } = null!;

    public string BRegIP { get; set; } = null!;

    public DateTime BRegDate { get; set; }

    public int BIdx { get; set; }
}
