using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // Objective: Find the two Taco Bells that are the farthest apart from one another.
            // Some of the TODO's are done for you to get you started. 

            logger.LogInfo("Log initialized.......");

            // Use File.ReadAllLines(path) to grab all the lines from your csv file. DONE
            // Optional: Log an error if you get 0 lines and a warning if you get 1 line DONE
            var lines = File.ReadAllLines(csvPath);
            if (lines.Length == 0)
            {
                logger.LogError("file has no input");
            }
            if (lines.Length == 1)
            {
                logger.LogWarning("not enough input");
            }

            // This will display the first item in your lines array
            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Use the Select LINQ method to parse every line in lines collection
            ITrackable[] locations = lines.Select(line => parser.Parse(line)).ToArray();

            // Complete the Parse method in TacoParser class first and then START BELOW ---------- DONE

            // TODO: Create two `ITrackable` variables with initial values of `null`. 
            // These will be used to store your two Taco Bells that are the farthest from each other. DONE
            // TODO: Create a `double` variable to store the distance DONE
            ITrackable furthestTacoBellOne = null;
            ITrackable furthestTacoBellTwo = null;
            double distance = 0;

            // TODO: Add the Geolocation library to enable location comparisons: using GeoCoordinatePortable;
            // Look up what methods you have access to within this library. DONE

            // NESTED LOOPS SECTION----------------------------

            // FIRST FOR LOOP -
            // TODO: Create a loop to go through each item in your collection of locations.
            // This loop will let you select one location at a time to act as the "starting point" or "origin" location.
            // Naming suggestion for variable: `locA`
            // TODO: Once you have locA, create a new Coordinate object called `corA` with your locA's latitude and longitude. DONE
            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                //locA is what location we are on
                //i goes from 0 to 237
                var coordinateA = new GeoCoordinate();
                coordinateA.Latitude = locA.Location.Latitude;
                coordinateA.Longitude = locA.Location.Longitude;

                // SECOND FOR LOOP -
                // TODO: Now, Inside the scope of your first loop, create another loop to iterate through locations again.
                // This allows you to pick a "destination" location for each "origin" location from the first loop. 
                // Naming suggestion for variable: `locB`

                // TODO: Once you have locB, create a new Coordinate object called `corB` with your locB's latitude and longitude.
                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    var coordinateB = new GeoCoordinate();
                    coordinateB.Latitude = locB.Location.Latitude;
                    coordinateB.Longitude = locB.Location.Longitude;

                    if (coordinateA.GetDistanceTo(coordinateB) > distance)
                    {
                        distance = coordinateA.GetDistanceTo(coordinateB);
                        furthestTacoBellOne = locA;
                        furthestTacoBellTwo = locB;
                    }
                }
            }

            // TODO: Now, still being inside the scope of the second for loop, compare the two locations using `.GetDistanceTo()` method, which returns a double.
            // If the distance is greater than the currently saved distance, update the distance variable and the two `ITrackable` variables you set above.

            // NESTED LOOPS SECTION COMPLETE ---------------------

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.
            // Display these two Taco Bell locations to the console. DONE
            logger.LogWarning($"{furthestTacoBellOne.Name} and {furthestTacoBellTwo.Name} are the furthest apart.");




        }
    }
}
