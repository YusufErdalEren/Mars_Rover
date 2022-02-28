using Mars_Rover.Models.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Models.SubClasses
{
    public class GetLocationRequest : IRequestBase
    {
        public string CurrentLocationAndFacing { get; set; }
        public int CurrentXCoordinate { get; set; }
        public int CurrentYCoordinate { get; set; }
        public string InstantFacing { get; set; }
        public string MovementCommands { get; set; }
    }
}
