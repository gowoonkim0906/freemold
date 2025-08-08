using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Models
{
    public class StatisticsModel
    {
        public string? InDate { get; set; }
        public int TotalCnt { get; set; }
        public int PC { get; set; } = 0;
        public int Mobile { get; set; }
    }
}
