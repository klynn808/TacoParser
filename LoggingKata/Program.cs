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
            logger.LogInfo("Log initialized.......");

            var lines = File.ReadAllLines(csvPath);
            if (lines.Length == 0)
            {
                logger.LogError("file has no input");
            }
            if (lines.Length == 1)
            {
                logger.LogWarning("not enough input");
            }

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            ITrackable[] locations = lines.Select(line => parser.Parse(line)).ToArray();

            ITrackable furthestTacoBellOne = null;
            ITrackable furthestTacoBellTwo = null;
            double distance = 0;

            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var coordinateA = new GeoCoordinate();
                coordinateA.Latitude = locA.Location.Latitude;
                coordinateA.Longitude = locA.Location.Longitude;

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

            logger.LogWarning($"{furthestTacoBellOne.Name} and {furthestTacoBellTwo.Name} are the furthest apart.");
        }
    }
}
