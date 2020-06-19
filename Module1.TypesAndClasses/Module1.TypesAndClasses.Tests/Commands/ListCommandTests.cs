using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Module1.TypesAndClasses.Commands;
using Mentoring.Shapes.Interfaces;
using Module1.TypesAndClasses.Factories;

namespace Module1.TypesAndClasses.Tests.Commands
{
    
    public class ListCommandTests
    {

        [Theory]
        [InlineData("r", "\r\nShape: 'Rectangle'. Square = 120 Meter,perimeter = 44 Meter, SideA = 10, SideB = 12 \r\n")]
        [InlineData("c", "\r\nShape: 'Circle'. Square = 0,031415926535897934, perimeter = 0,6283185307179586, radius = 0,1 \r\n")]
        [InlineData("e", "\r\nShape: 'Ellipse'. Square = 157, perimeter = 24,83647066449025 \r\n")]
        [InlineData("t", "\r\nShape: 'EquilateralTriangle'. Square = 10,825317547305483 Meters, perimeter = 15 Meters. Side = 5 Meters. \r\n")]

        public void TestListExecute(string shape, string shapeToString)
        {
            string[] _instruction = { "list", "jsonexample", shape};
            var listCommand = new ListCommand(_instruction);
            Assert.Equal(listCommand.Execute(), shapeToString);
        }

    }
}

