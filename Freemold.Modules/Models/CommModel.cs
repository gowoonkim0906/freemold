using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Models
{
    public class CommModel
    {

    }

    public sealed class StorageOptions { public string RootPath { get; init; } = ""; }


    public class PagedResult<T>
    {
        public List<T> items { get; set; } = new();

        public int totalcount { get; set; }
    }


}
