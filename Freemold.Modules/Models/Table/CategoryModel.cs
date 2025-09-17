using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Models
{
    public class CategoryModel
    {
        public string Code { get; set; } = null!;

        public string UpCode { get; set; } = null!;

        public string Acode { get; set; } = null!;

        public string Bcode { get; set; } = null!;

        public string Ccode { get; set; } = null!;

        public string Akor { get; set; } = null!;

        public string Bkor { get; set; } = null!;

        public string Ckor { get; set; } = null!;

        public string Aeng { get; set; } = null!;

        public string Beng { get; set; } = null!;

        public string Ceng { get; set; } = null!;

        public string? CatName { get; set; }

        public string StdMld { get; set; } = null!;

        public byte Depth { get; set; }

        public byte Ord { get; set; }

        public byte Aord { get; set; }

        public byte Bord { get; set; }

        public byte Cord { get; set; }

        public string CheckYN { get; set; } = "N";  
    }
}
