using System;

namespace ShapeLibrary.BasicShapes
{
    public sealed class Circle : IShape
    {
        private readonly Lazy<double> _area;

        public double Radius { get; }

        public double Area => _area.Value;

        /// <summary>
        /// Круг
        /// </summary>
        /// <param name="r">Длина радиуса</param>
        /// <exception cref="ArgumentOutOfRangeException">Если длина радиуса меньше 0</exception>
        public Circle(double r)
        {
            if (r < 0)
                throw new ArgumentOutOfRangeException("Значение радиуса не может быть отрицательным", nameof(r));
            Radius = r;
            _area = new Lazy<double>(() => CalculateArea(Radius));
        }

        private static double CalculateArea(double r) => Math.PI * r * r;
    }
}
