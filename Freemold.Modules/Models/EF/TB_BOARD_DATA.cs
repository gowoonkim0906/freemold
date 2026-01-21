using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class TB_BOARD_DATA
{
    public long UID { get; set; }

    public long GRP { get; set; }

    public string BOARD_CODE { get; set; } = null!;

    public int SEQ { get; set; }

    public int DEPTH { get; set; }

    public string NOTICE { get; set; } = null!;

    public string N_DATE1 { get; set; } = null!;

    public string N_DATE2 { get; set; } = null!;

    public string REG_ID { get; set; } = null!;

    public string REG_NAME { get; set; } = null!;

    public string REG_EMAIL { get; set; } = null!;

    public string REG_HP { get; set; } = null!;

    public string REG_PW { get; set; } = null!;

    public string REG_SUBJECT { get; set; } = null!;

    public string REG_CONTENT { get; set; } = null!;

    public string REG_FILE_NAME { get; set; } = null!;

    public string REG_FILE_RENAME { get; set; } = null!;

    public string LIST_IMAGE_NAME { get; set; } = null!;

    public string LIST_IMAGE_RENAME { get; set; } = null!;

    public int HIT_COUNTS { get; set; }

    public string SECRET { get; set; } = null!;

    public DateTime? REG_DATE { get; set; }

    public string LINK1 { get; set; } = null!;

    public string LINK2 { get; set; } = null!;

    public int LINK1_HIT { get; set; }

    public int LINK2_HIT { get; set; }

    public string YOUTUBE_URL { get; set; } = null!;

    public DateTime? MOD_DATE { get; set; }

    public string? MOD_ID { get; set; }

    public string REG_IP { get; set; } = null!;

    public string APPR { get; set; } = null!;

    public string? APPR_USER { get; set; }

    public string FIRST_WORD { get; set; } = null!;

    public int? pIdx { get; set; }

    /// <summary>
    /// 리플_담당자이름
    /// </summary>
    public string? dName { get; set; }

    /// <summary>
    /// 리플_담당자연락처
    /// </summary>
    public string? dPhone { get; set; }

    /// <summary>
    /// 리플_담당자이메일
    /// </summary>
    public string? dEmail { get; set; }

    public string? Read_ID { get; set; }

    public string? Admin_YN { get; set; }

    public string Deleted { get; set; } = null!;

    public string? UpCat { get; set; }

    public string? Cat { get; set; }

    public string? wName { get; set; }

    public string? wPhone { get; set; }

    public string? wEmail { get; set; }

    public string? wKakaoID { get; set; }

    public string wType { get; set; } = null!;

    public string Tag0 { get; set; } = null!;

    public string Tag1 { get; set; } = null!;

    public string Tag2 { get; set; } = null!;
}
