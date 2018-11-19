using System;
using System.Collections.Generic;
using System.Text;

namespace MeituanApi.Data.External.Submit
{
    public class SFoodList:BaseSubmit
    {
        public string app_poi_code { get; set; }

        public int offset { get; set; } = 0;

        public int limit { get; set; } = 199;
    }
}
