using System;

namespace ShapeLibrary.BasicShapes
{
    public sealed class Triangle : IShape
    {
        private readonly Lazy<bool> _isRightTriangle;
        private readonly Lazy<double> _area;
        private readonly double _precision;

        /// <summary>
        /// Сторона a
        /// </summary>
        public double SideA { get; }

        /// <summary>
        /// Сторона a
        /// </summary>
        public double SideB { get; }

        /// <summary>
        /// Сторона a
        /// </summary>
        public double SideC { get; }

        public double Area => _area.Value;

        /// <summary>
        /// Является правильным треугольником
        /// </summary>
        public bool IsRightTriangle => _isRightTriangle.Value;

        /// <summary>
        /// Треугольник
        /// </summary>
        /// <param name="a">Длина стороны a</param>
        /// <param name="b">Длина стороны b</param>
        /// <param name="c">Длина стороны c</param>
        /// <param name="precision">Точность вычислений. Используется при определения наличия прямого угла</param>
        /// <exception cref="ArgumentOutOfRangeException">Если длина стороны меньше 0</exception>
        /// <exception cref="ArgumentException">Если сумма длин двух сторон меньше третей</exception>
        public Triangle(double a, double b, double c, double precision = 1E-10)
        {
            if (a < 0 || b < 0 || c < 0)
                throw new ArgumentOutOfRangeException("Длина стороны не может быть отрицательной");
            if (a + b < c || a + c < b || b + c < a)
                throw new ArgumentException("Сумма любых двух сторон должна быть больше третьей");

            SideA = a;
            SideB = b;
            SideC = c;
            _precision = precision;
            _area = new Lazy<double>(() => CalculateArea(SideA, SideB, SideC));
            _isRightTriangle = new Lazy<bool>(() => CheckIsRightTriangle(SideA, SideB, SideC, _precision));
        }

        private static double CalculateArea(double a, double b, double c)
        {
            double p = (a + b + c) * 0.5;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        private static bool CheckIsRightTriangle(double a, double b, double c, double precision)
        {
            var longestSide = GetLongestSide(a, b, c);
            return Math.Abs((longestSide * longestSide * 2) - (a * a + b * b + c * c)) <= precision;
        }

        private static double GetLongestSide(double a, double b, double c)
        {
            if (a >= b && a >= c)
            {
                return a;
            }
            if (b >= a && b >= c)
            {
                return b;
            }
            return c;
        }
    }
}
