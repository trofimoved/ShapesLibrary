using System;

namespace ShapeLibrary
{
    /// <summary>
    /// Математические операции над фигурами
    /// </summary>
    public static class ShapeMath
    {
        /// <summary>
        /// Вычислить площадь треугольника
        /// <para/>Не проверяет валидность входных значений. Если необходима валидация значений фигуры, следует использовать класс <see cref="BasicShapes.Circle"/>
        /// </summary>
        /// <param name="r">Рудиус</param>
        /// <returns></returns>
        public static double CircleArea(double r)
            => Math.PI * r * r;

        /// <summary>
        /// Вычислить площадь треугольника
        /// <para/>Не проверяет валидность входных значений. Если необходима валидация значений фигуры, следует использовать класс <see cref="BasicShapes.Triangle"/>
        /// </summary>
        /// <param name="a">Сторона a</param>
        /// <param name="b">Сторона b</param>
        /// <param name="c">Сторона c</param>
        /// <returns></returns>
        public static double TriangleArea(double a, double b, double c)
        {
            double p = (a + b + c) * 0.5;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        /// <summary>
        /// Вычислить площадь квадрата
        /// <para/>Не проверяет валидность входных значений.
        /// </summary>
        /// <param name="a">Сторона</param>
        /// <returns></returns>
        public static double SquareArea(double a)
            => a * a;

        /// <summary>
        /// Вычислить площадь прямоугольника
        /// <para/>Не проверяет валидность входных значений.
        /// </summary>
        /// <param name="a">Сторона a</param>
        /// <param name="b">Сторона b</param>
        /// <returns></returns>
        public static double RectangleArea(double a, double b)
            => a * b;
    }
}
