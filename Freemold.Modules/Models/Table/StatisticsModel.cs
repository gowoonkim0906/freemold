using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemold.Modules.Models
{
    public class StatisticsModel
    {
        public DateOnly? InDate { get; set; }
        public int TotalCnt { get; set; }
        public int PC { get; set; } = 0;
        public int Mobile { get; set; }
    }

    public class  StatisticsHourModel
    {
        public string? sHour { get; set; }
        public int TotalCnt { get; set; }

    }

    public class StatisticsRefererModel
    {
        public string? HttpReferer { get; set; }
        public int TotalCnt { get; set; }

    }


    public class StatisticsCountryModel
    {
        public string? CCode { get; set; }
        public string? CName { get; set; }

        public DateOnly? InDate { get; set; }
        public int TotalCnt { get; set; }

    }


}
