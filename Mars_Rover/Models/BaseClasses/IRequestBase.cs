using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Models.BaseClasses
{
    public interface IRequestBase
    {
        string CurrentLocationAndFacing { get; set; }
        int CurrentXCoordinate { get; set; }
        int CurrentYCoordinate { get; set; }
        string InstantFacing { get; set; }
        string MovementCommands { get; set; }
    }
}
