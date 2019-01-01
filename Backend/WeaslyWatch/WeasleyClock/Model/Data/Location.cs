using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeasleyClock.Model.Data
{
    public class Location
    {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double MaxDistance { get; set; }
        public double SpeedMin { get; set; }
        public double SpeedMax { get; set; }
        public string LocationName { get; set; }
        public string UserName { get; set; }
    }
}
