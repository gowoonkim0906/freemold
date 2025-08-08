using System;
using System.Collections.Generic;

namespace Freemold.Modules.Models.EF;

public partial class TbUserSearch
{
    public long LogIdx { get; set; }

    public int? Idx { get; set; }

    public string? Location { get; set; }

    public string? LocationName { get; set; }

    public string? Tp { get; set; }

    public string? TpName { get; set; }

    public short? Cat1 { get; set; }

    public string? Cat1Name { get; set; }

    public short? Cat2 { get; set; }

    public string? Cat2Name { get; set; }

    public string? Origin { get; set; }

    public double? Capa1 { get; set; }

    public double? Capa2 { get; set; }

    public double? CapaTxt { get; set; }

    public string? InCompany { get; set; }

    public string? FactoryLoc { get; set; }

    public short? ComSort { get; set; }

    public string? ComSortName { get; set; }

    public string? SMyArticle { get; set; }

    public string? SKeyword { get; set; }

    public string? SKeywordName { get; set; }

    public string? SItem { get; set; }

    public string? SItemName { get; set; }

    public string? InSearch { get; set; }

    public string? SearchTopKeyword { get; set; }

    public int? Page { get; set; }

    public short? PageSize { get; set; }

    public string? PageOrderBy { get; set; }

    public int? PIdx { get; set; }

    public string? ProductCode { get; set; }

    public int? MIdx { get; set; }

    public string? CompanyName { get; set; }

    public string FullUrl { get; set; } = null!;

    public DateOnly InDate { get; set; }

    public string? ErrNum { get; set; }

    public string? ErrDesc { get; set; }

    public int RegmIdx { get; set; }

    public string RegmType { get; set; } = null!;

    public string RegId { get; set; } = null!;

    public string RegIp { get; set; } = null!;

    public DateTime RegDate { get; set; }

    public string? CatA { get; set; }

    public string? CatB { get; set; }

    public string? CatC { get; set; }

    public string? Cat { get; set; }

    public string? UpCat { get; set; }
}
