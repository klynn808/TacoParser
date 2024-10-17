using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("32.92496, -85.961342, Taco Bell Alexander Cit...", -85.961342)]
        [InlineData("34.992219,-86.841402,Taco Bell Ardmore...", -86.841402)]
        public void ShouldParseLongitude(string line, double expected)
        {
            //Arrange
            var tacoParserTester = new TacoParser();

            //Act
            var actual = tacoParserTester.Parse(line).Location.Longitude;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("30.903723,-84.556037,Taco Bell Bainbridg...", 30.903723)]
        [InlineData("34.888408,-85.267909,Taco Bell Chickamaug...", 34.888408)]
        public void ShouldParseLatitude(string line, double expected)
        {
            //Arrange
            var tacoParserTester = new TacoParser();

            //Act
            var actual = tacoParserTester.Parse(line);

            //Assert
            Assert.Equal(expected, actual.Location.Latitude);
        }

    }
}
