using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Models
{
    public class FreemoldModel
    {
    }

    public class FileInsertVectorRequest
    {
        public int[] uid { get; set; } = Array.Empty<int>();
    }


    public class FileDeleteVectorRequest
    {
        public int[] prod_uid { get; set; } = Array.Empty<int>();
    }

    public class FileSearchVectionRequest 
    {
        public IFormFile searchfile { get; set; }
        public string userId { get; set; } = "";
        public int topK { get; set; } = 50;
        public string search_mode { get; set; } = "fast";
        public bool remove_bg { get; set; } = false;
    }
}
