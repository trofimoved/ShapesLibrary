using System;
using Xunit;

namespace ShapeLibrary.Tests
{
    public class ShapeMathTests
    {
        private const int _precision = 5;

        [Theory]
        [InlineData(Math.PI, 1)]
        [InlineData(28.27433, 3)]
        [InlineData(153.93804, 7)]
        public void TestCircleAreaCalculation(double expectedArea, double r)
        {
            Assert.Equal(expectedArea, ShapeMath.CircleArea(r), _precision);
        }

        [Theory]
        [InlineData(6, 3, 4, 5)]
        [InlineData(6, 5, 3, 4)]
        [InlineData(1.92, 3.2, 2, 2)]
        [InlineData(0.43301, 1, 1, 1)]
        public void TestTriangleAreaCalculation(double expectedArea, double a, double b, double c)
        {
            Assert.Equal(expectedArea, ShapeMath.TriangleArea(a, b, c), _precision);
        }

        [Theory]
        [InlineData(6, 3, 2)]
        [InlineData(1, 1, 1)]
        [InlineData(6, 4, 1.5)]

        public void TestRectangleAreaCalculation(double expectedArea, double a, double b)
        {
            Assert.Equal(expectedArea, ShapeMath.RectangleArea(a, b), _precision);
        }

        [Theory]
        [InlineData(9, 3)]
        [InlineData(1, 1)]

        public void TestSquareAreaCalculation(double expectedArea, double a)
        {
            Assert.Equal(expectedArea, ShapeMath.SquareArea(a), _precision);
        }
    }
}
