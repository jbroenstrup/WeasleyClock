using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeaslyWatch.Model.Data
{
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double MaxDistance { get; set; }
        public double[] SpeedRange { get; set; }
        public string LocationName { get; set; }
        public string UserName { get; set; }
    }
}
