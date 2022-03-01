using Mars_Rover.Models.SubClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover
{
    class Program
    {
        static void Main(string[] args)
        {
            int currentXCoordinate = 0, currentYCoordinate = 0, plateauAreaXCoordinate, plateauAreaYCoordinate; 
            string plateauAreaCoordinate = string.Empty, currentLocationAndFacing = string.Empty, instantFacing = string.Empty, movementCommands = string.Empty;

            Console.WriteLine("Please enter the upper-right coordinates..");
            plateauAreaCoordinate = Console.ReadLine().Replace(" ", "");
            plateauAreaXCoordinate = int.Parse(plateauAreaCoordinate[0].ToString());
            plateauAreaYCoordinate = int.Parse(plateauAreaCoordinate[1].ToString());

            var plateauArea = Tuple.Create(plateauAreaXCoordinate, plateauAreaYCoordinate);

            Start_Again:
            var request = new GetLocationRequest
            {
                CurrentLocationAndFacing = currentLocationAndFacing,
                CurrentXCoordinate = currentXCoordinate,
                CurrentYCoordinate = currentYCoordinate,
                InstantFacing = instantFacing,
                MovementCommands = movementCommands,
                PlateauAreaCoordinate = plateauArea
            };
            var lastLocation = GetCurrentLocation(request);

            Console.WriteLine($"\nOutput: {lastLocation.Item1} {lastLocation.Item2} {lastLocation.Item3}\n");
            goto Start_Again;
        }

        private static Tuple<int, int, string> GetCurrentLocation(GetLocationRequest model)
        {
            Console.WriteLine("\nPlease enter current location and facing..");
            model.CurrentLocationAndFacing = Console.ReadLine().Replace(" ", "");

            model.CurrentXCoordinate = int.Parse(model.CurrentLocationAndFacing[0].ToString());
            model.CurrentYCoordinate = int.Parse(model.CurrentLocationAndFacing[1].ToString());
            model.InstantFacing = model.CurrentLocationAndFacing[2].ToString();

            var currentLocation = Tuple.Create(model.CurrentXCoordinate, model.CurrentYCoordinate, model.InstantFacing);

            Console.WriteLine("\nPlease enter movement commands..");
            model.MovementCommands = Console.ReadLine().Replace(" ", "");

            foreach (var character in model.MovementCommands)
            {
                currentLocation = SetCurrentLocation(character, currentLocation);
            }
            return currentLocation;
        }

        private static Tuple<int, int, string> SetCurrentLocation(char character, Tuple<int, int, string> currentLocation)
        {
            if (character != 'M')
            {
                if (currentLocation.Item3 == "N")
                {
                    if (character == 'L')
                        currentLocation = new Tuple<int, int, string>(currentLocation.Item1, currentLocation.Item2, "W");
                    if (character == 'R')
                        currentLocation = new Tuple<int, int, string>(currentLocation.Item1, currentLocation.Item2, "E");
                }
                else if (currentLocation.Item3 == "S")
                {
                    if (character == 'L')
                        currentLocation = new Tuple<int, int, string>(currentLocation.Item1, currentLocation.Item2, "E");
                    if (character == 'R')
                        currentLocation = new Tuple<int, int, string>(currentLocation.Item1, currentLocation.Item2, "W");
                }
                else if (currentLocation.Item3 == "E")
                {
                    if (character == 'L')
                        currentLocation = new Tuple<int, int, string>(currentLocation.Item1, currentLocation.Item2, "N");
                    if (character == 'R')
                        currentLocation = new Tuple<int, int, string>(currentLocation.Item1, currentLocation.Item2, "S");
                }
                else if (currentLocation.Item3 == "W")
                {
                    if (character == 'L')
                        currentLocation = new Tuple<int, int, string>(currentLocation.Item1, currentLocation.Item2, "S");
                    if (character == 'R')
                        currentLocation = new Tuple<int, int, string>(currentLocation.Item1, currentLocation.Item2, "N");
                }
            }
            else
            {
                if (currentLocation.Item3 == "N")
                    currentLocation = new Tuple<int, int, string>(currentLocation.Item1, currentLocation.Item2 + 1, currentLocation.Item3);
                if (currentLocation.Item3 == "S")
                    currentLocation = new Tuple<int, int, string>(currentLocation.Item1, currentLocation.Item2 - 1, currentLocation.Item3);
                if (currentLocation.Item3 == "E")
                    currentLocation = new Tuple<int, int, string>(currentLocation.Item1 + 1, currentLocation.Item2, currentLocation.Item3);
                if (currentLocation.Item3 == "W")
                    currentLocation = new Tuple<int, int, string>(currentLocation.Item1 - 1, currentLocation.Item2, currentLocation.Item3); ;
            }

            return currentLocation;
        }
    }
}
