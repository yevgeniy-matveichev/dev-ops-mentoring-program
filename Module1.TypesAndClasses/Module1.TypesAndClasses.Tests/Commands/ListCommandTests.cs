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
       private ShapeServiceFactory _shapeServiceFactory;

        [Theory]
        [InlineData("c", ShapeTypes.Circle)]
        [InlineData("r", ShapeTypes.Rectangle)]
        [InlineData("e", ShapeTypes.Ellipse)]

        public void TestListExecute(string shape, ShapeTypes shapeType)
        {
            string[] _instruction = { "list", "jsonexample", shape };
            var listCommand = new ListCommand(_instruction);

            _shapeServiceFactory = new ShapeServiceFactory();
            Assert.Equal(listCommand.Execute(), $"\r\n{_shapeServiceFactory.Create(shapeType).ReadShapeExample()} \r\n");
        }

    }
}

