using System;
using System.Collections.Generic;
using Xunit;
using ShapeLibrary.BasicShapes;

namespace ShapeLibrary.Tests
{
    public class BasicShapesTests
    {
        private const int _precision = 5;

        [Theory]
        [MemberData(nameof(TestInvalidTriangleValdationData))]
        public void TestInvalidCircleValidation(Type expectedExceptionType, double r)
        {
            Assert.Throws(expectedExceptionType, () => new Circle(r));
        }

        public static IEnumerable<object[]> TestInvalidCircleValdationData()
        {
            yield return new object[] { typeof(ArgumentOutOfRangeException), -1 };
            yield return new object[] { typeof(ArgumentOutOfRangeException), -double.Epsilon };
            yield return new object[] { typeof(ArgumentOutOfRangeException), double.NegativeInfinity };
        }

        [Theory]
        [InlineData(Math.PI, 1)]
        [InlineData(28.27433, 3)]
        [InlineData(153.93804, 7)]
        public void TestCircleAreaCalculation(double expectedArea, double r)
        {
            var circle = new Circle(r);
            Assert.Equal(expectedArea, circle.Area, _precision);
        }

        [Theory]
        [MemberData(nameof(TestInvalidTriangleValdationData))]
        public void TestInvalidTriangleValidation(Type expectedExceptionType, double a, double b, double c)
        {
            Assert.Throws(expectedExceptionType, () => new Triangle(a, b, c));
        }

        public static IEnumerable<object[]> TestInvalidTriangleValdationData()
        {
            yield return new object[] { typeof(ArgumentOutOfRangeException), -1, 1, 1 };
            yield return new object[] { typeof(ArgumentOutOfRangeException), 1, -double.Epsilon, 1 };
            yield return new object[] { typeof(ArgumentOutOfRangeException), double.NegativeInfinity, 1, 1 };
            yield return new object[] { typeof(ArgumentException), 1, 1, 10 };
            yield return new object[] { typeof(ArgumentException), 5, 1, 1 };
            yield return new object[] { typeof(ArgumentException), 0.1, 4, 0.2 };
        }

        [Theory]
        [InlineData(6, 3, 4, 5)]
        [InlineData(6, 5, 3, 4)]
        [InlineData(1.92, 3.2, 2, 2)]
        [InlineData(0.43301, 1, 1, 1)]
        public void TestTriangleAreaCalculation(double expectedArea, double a, double b, double c)
        {
            var triangle = new Triangle(a, b, c);
            Assert.Equal(expectedArea, triangle.Area, _precision);
        }

        [Theory]
        [InlineData(true, 3, 4, 5)]
        [InlineData(true, 2.5, 1.5, 2)]
        [InlineData(true, 3d / 7, 4d / 7, 5d / 7)]
        [InlineData(false, 3, 3, 5)]
        [InlineData(false, 1, 1, 1)]
        public void TestTriangleRightCheck(bool expectedResult, double a, double b, double c)
        {
            var triangle = new Triangle(a, b, c);
            Assert.Equal(expectedResult, triangle.IsRightTriangle);
        }

        [Theory]
        [InlineData(10, 2, 5)]
        [InlineData(1, 1, 1)]
        [InlineData(0.25, 0.5, 0.5)]
        public void TestCustomRectangleAreaCalculation(double expectedArea, double a, double b)
        {
            var rectangle = new CustomRect(a, b);
            Assert.Equal(expectedArea, rectangle.Area, _precision);
        }

        [Theory]
        [MemberData(nameof(TestDifferentShapesAreaCalculationData))]
        public void TestDifferentShapesAreaCalculation(double expectedArea, IShape shape)
        {
            Assert.Equal(expectedArea, shape.Area, _precision);
        }

        public static IEnumerable<object[]> TestDifferentShapesAreaCalculationData()
        {
            yield return new object[] { 6, new Triangle(3, 4, 5) };
            yield return new object[] { 3.14159, new Circle(1) };
            yield return new object[] { 9, new CustomRect(1.5, 6) };
        }

        class CustomRect : IShape
        {
            public CustomRect(double sideA, double sideB)
            {
                SideA = sideA;
                SideB = sideB;
            }

            public double SideA { get; }
            public double SideB { get; }
            public double Area => ShapeMath.RectangleArea(SideA, SideB);
        }
    }
}
