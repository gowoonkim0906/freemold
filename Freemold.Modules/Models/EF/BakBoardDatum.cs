using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class BakBoardDatum
{
    public long? UID { get; set; }

    public long? GRP { get; set; }

    public string? BOARD_CODE { get; set; }

    public int? SEQ { get; set; }

    public int? DEPTH { get; set; }

    public string? NOTICE { get; set; }

    public string? N_DATE1 { get; set; }

    public string? N_DATE2 { get; set; }

    public string? REG_ID { get; set; }

    public string? REG_NAME { get; set; }

    public string? REG_EMAIL { get; set; }

    public string? REG_HP { get; set; }

    public string? REG_PW { get; set; }

    public string? REG_SUBJECT { get; set; }

    public string? REG_CONTENT { get; set; }

    public string? REG_FILE_NAME { get; set; }

    public string? REG_FILE_RENAME { get; set; }

    public string? LIST_IMAGE_NAME { get; set; }

    public string? LIST_IMAGE_RENAME { get; set; }

    public int? HIT_COUNTS { get; set; }

    public string? SECRET { get; set; }

    public DateTime? REG_DATE { get; set; }

    public string? LINK1 { get; set; }

    public string? LINK2 { get; set; }

    public int? LINK1_HIT { get; set; }

    public int? LINK2_HIT { get; set; }

    public string? YOUTUBE_URL { get; set; }

    public DateTime? MOD_DATE { get; set; }

    public string? MOD_ID { get; set; }

    public string? REG_IP { get; set; }

    public string? APPR { get; set; }

    public string? FIRST_WORD { get; set; }

    public int? pIdx { get; set; }

    public string? dName { get; set; }

    public string? dPhone { get; set; }

    public string? dEmail { get; set; }

    public string? Read_ID { get; set; }

    public string? Deleted { get; set; }

    public string? UpCat { get; set; }

    public string? Cat { get; set; }

    public string? wName { get; set; }

    public string? wPhone { get; set; }

    public string? wEmail { get; set; }

    public string? wKakaoID { get; set; }

    public string? wType { get; set; }

    public string? Tag0 { get; set; }

    public string? Tag1 { get; set; }

    public string? Tag2 { get; set; }

    public string BType { get; set; } = null!;

    public string BRegID { get; set; } = null!;

    public string BRegIP { get; set; } = null!;

    public DateTime BRegDate { get; set; }

    public int BIdx { get; set; }
}
