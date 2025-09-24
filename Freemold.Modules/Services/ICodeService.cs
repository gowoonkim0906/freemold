using Freemold.Modules.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Services
{
    public interface ICodeService
    {
        Task<List<TbCode>> GetCodeList(string sort);
        Task<List<TbCategory>> GetCategoryList(string UpCode, string StdMld = "");
        Task<List<VwNcategoryList>> GetVwNcategoryList(string[] ACode, string StdMld = "");
        Task<List<CategoryModel>> GetModalVwNcategoryList(string ACode, string StdMld = "", string[] Selectval = null);
        Task<string> GetCategoryFullname(string catagory);
        Task<List<CategoryFullnameModel>> GetCategoryFullnameLIst(string catagory);
    }
}
