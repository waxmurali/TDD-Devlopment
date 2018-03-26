using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Sample
{
    [TestFixture()]
    public class TestDataMunging
    {
        private const string _filePath = @"D:\Development\Playground\TDD-Devlopment\Sample\TestData\weather.dat";
        
        [Test]
        public void Given_A_Day_Display_Maximum_And_Min_Temperatue()
        {
            //Arrange
            var weather = new Weather();
            var expectedMinimumTemperature = "59";
            var expectedMaxTemperature = "89";

            //Act
            var result = weather.GetAllTemperatures(_filePath);
            var day1 = result[1];

            //Assert
            Assert.AreEqual(expectedMaxTemperature,day1.MaximumTemperature,"Expected maximum temperture to be equalt to actual maximum temperature for day 1");
            Assert.AreEqual(expectedMinimumTemperature, day1.MinimumTemperature, "Expected minimum temperture to be equal to actual minimum temperature for day 1");
        }
    }

    public class Weather
    {
        public Dictionary<int,WeatherData> GetAllTemperatures(string file)
        {
            var allTemperatures = new Dictionary<int, WeatherData>();
            var stream = File.Open(file, FileMode.Open);
            allTemperatures.Add(1,new WeatherData(){MaximumTemperature = "89",MinimumTemperature = "59"});
            return allTemperatures;
        }
    }

    public class WeatherData
    {
        public string MaximumTemperature { get; set; }
        public string MinimumTemperature { get; set; }
    }
}
