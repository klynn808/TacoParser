using System.ComponentModel.Design;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array's Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log error message and return null
                logger.LogWarning("Less than three location items, incomplete data");
            }
            // TODO: Grab the latitude from your array at index 0 DONE
            // You're going to need to parse your string as a `double` DONE
            // TODO: Grab the longitude from your array at index 1 DONE
            // You're going to need to parse your string as a `double` DONE      
            // TODO: Grab the name from your array at index 2 DONE 

            var latitude = double.Parse(cells[0]);
            var longitude = double.Parse(cells[1]);
            var address = cells[2];

            // TODO: Create a TacoBell class
            // that conforms to ITrackable DONE

            // TODO: Create an instance of the Point StructDONE
            // TODO: Set the values of the point correctly (Latitude and Longitude) DONE
            var point = new Point();
            point.Latitude = latitude;
            point.Longitude = longitude;

            // TODO: Create an instance of the TacoBell class
            // TODO: Set the values of the class correctly (Name and Location)

            var tacoBell = new TacoBell();
            tacoBell.Name = address;
            tacoBell.Location = point;


            // TODO: Then, return the instance of your TacoBell class,
            // since it conforms to ITrackable

            return tacoBell;
        }
    }
}
