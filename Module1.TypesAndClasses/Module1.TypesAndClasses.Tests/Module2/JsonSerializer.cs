using Mentoring.DataModel.Shapes;
using Mentoring.Shapes.Interfaces;
using Mentoring.Shapes.Shapes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Module1.TypesAndClasses.Tests.Module2
{
    public class JsonSerializer
    {
        public static string shape = @"{"
                      + "\"Unit\": \"Centimeters\","
                      + "\"Radius\": 10"
                      + "}";
        CircleModel circleModel = JsonConvert.DeserializeObject<CircleModel>(shape);

        [Fact]
        public void TestLinq()
        {
            Assert.True(circleModel.Unit.ToString() == "Centimeters");
            Assert.True(circleModel.Radius == 10);
        }

     }
}
