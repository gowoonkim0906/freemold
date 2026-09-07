using System;
using System.Collections.Generic;

namespace Freemold.Modules;

public partial class TB_BANNER
{
    public int Idx { get; set; }

    /// <summary>
    /// 회원구분(기업:1)
    /// </summary>
    public string mType { get; set; } = null!;

    /// <summary>
    /// 회원UID
    /// </summary>
    public int mIdx { get; set; }

    /// <summary>
    /// 배너타입(N:일반, C:카테고리)
    /// </summary>
    public string bType { get; set; } = null!;

    public string? bCode { get; set; }

    /// <summary>
    /// 배너타입Idx
    /// </summary>
    public string bIdx { get; set; } = null!;

    /// <summary>
    /// 배너이미지
    /// </summary>
    public string BannerImage { get; set; } = null!;

    /// <summary>
    /// 메인배너종류(A,B)-메인O형, 메인A형에만 적용
    /// </summary>
    public string BannerType { get; set; } = null!;

    /// <summary>
    /// 배너링크(입력시에만)
    /// </summary>
    public string BannerLink { get; set; } = null!;

    /// <summary>
    /// 간단설명
    /// </summary>
    public string BannerSubject { get; set; } = null!;

    public DateTime? sDate { get; set; }

    public DateTime? eDate { get; set; }

    /// <summary>
    /// 무제한
    /// </summary>
    public string BannerUnlimit { get; set; } = null!;

    public DateTime? StartDateWithUse { get; set; }

    public string isUse { get; set; } = null!;

    public int Ord { get; set; }

    public string Deleted { get; set; } = null!;

    public short PosX { get; set; }

    public short PosY { get; set; }

    public string RegID { get; set; } = null!;

    public string RegIP { get; set; } = null!;

    public DateTime RegDate { get; set; }
}
