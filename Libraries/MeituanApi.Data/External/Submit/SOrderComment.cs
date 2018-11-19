using System;
using System.Collections.Generic;
using System.Text;

namespace MeituanApi.Data.External.Submit
{
    public class SOrderComment:BaseSubmit
    {
        public string app_poi_code { get; set; }

        public string start_time { get; set; }

        public string end_time { get; set; }

        public int pageoffset { get; set; }

        public int pagesize { get; set; }

        public int replyStatus { get; set; }
    }
}
