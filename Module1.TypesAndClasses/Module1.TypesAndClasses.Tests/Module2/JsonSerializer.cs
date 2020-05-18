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
        private static string shapeCircle = @"{"
                      + "\"Unit\": \"Centimeter\","
                      + "\"Radius\": 10"
                      + "}";
        private CircleModel circleModel = JsonConvert.DeserializeObject<CircleModel>(shapeCircle);

        [Fact]
        public void TestCircle()
        {
            Assert.True(circleModel.Unit == Units.Centimeter);
            Assert.True(circleModel.Radius == 10);
            Assert.False(circleModel.Unit == Units.Meter);
            Assert.False(circleModel.Radius == 11);
        }

        private static string shapeRectangle = @"{"
                      + "\"Unit\": \"Centimeter\","
                      + "\"SideA\": 10,"
                      + "\"SideB\": 12"
                      + "}";
        private RectangleModel rectangleModel = JsonConvert.DeserializeObject<RectangleModel>(shapeRectangle);
        
        [Fact]
        public void TestRectangle()
        {
            Assert.True(rectangleModel.Unit == Units.Centimeter);
            Assert.True(rectangleModel.SideA == 10);
            Assert.False(rectangleModel.Unit == Units.Meter);
            Assert.False(rectangleModel.SideB == 10);
        }

        private static string shapeEllipse = @"{"
                      + "\"Unit\": \"Centimeter\","
                      + "\"Radius1\": 10,"
                      + "\"Radius2\": 12"
                      + "}";
        private EllipseModel ellipseModel = JsonConvert.DeserializeObject<EllipseModel>(shapeEllipse);

        [Fact]
        public void TestEllipse()
        {
            Assert.True(ellipseModel.Unit == Units.Centimeter);
            Assert.True(ellipseModel.Radius1 == 10);
            Assert.False(ellipseModel.Unit == Units.Meter);
            Assert.False(ellipseModel.Radius2 == 10);
        }
    }
}
