using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class TB_BANNER_KEYWORD
{
    public int UID { get; set; }

    public string MEMBER_GUBUN { get; set; } = null!;

    public int MEMBER_UID { get; set; }

    public string GUBUN { get; set; } = null!;

    public string? KEY_WORD1 { get; set; }

    public string? KEY_WORD2 { get; set; }

    public string? KEY_WORD3 { get; set; }

    public string? KEY_WORD4 { get; set; }

    public string WORDS_LINK { get; set; } = null!;

    public string AMOUNT { get; set; } = null!;

    public DateOnly? WORDS_START { get; set; }

    public DateOnly? WORDS_END { get; set; }

    public string MEMO { get; set; } = null!;

    public DateOnly CHARGE_DATE { get; set; }

    public string Deleted { get; set; } = null!;

    public string RegID { get; set; } = null!;

    public string RegIP { get; set; } = null!;

    public DateTime RegDate { get; set; }
}
