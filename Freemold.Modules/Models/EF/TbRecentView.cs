using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class TbRecentView
{
    public int Idx { get; set; }

    /// <summary>
    /// 회원ID
    /// </summary>
    public string MemberId { get; set; } = null!;

    /// <summary>
    /// 회원UID
    /// </summary>
    public int MIdx { get; set; }

    /// <summary>
    /// 회원구분
    /// </summary>
    public byte MType { get; set; }

    /// <summary>
    /// Session TimeStamp
    /// </summary>
    public int MTimeStamp { get; set; }

    public string ViewType { get; set; } = null!;

    /// <summary>
    /// 상품UID
    /// </summary>
    public int PIdx { get; set; }

    public int ViewCnt { get; set; }

    public string Deleted { get; set; } = null!;

    /// <summary>
    /// 접속IP
    /// </summary>
    public string RegIp { get; set; } = null!;

    /// <summary>
    /// 방문일시
    /// </summary>
    public DateTime RegDate { get; set; }
}
