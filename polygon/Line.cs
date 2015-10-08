using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace polygon
{
    class Line
    {
        public Point a { get; set; }
        public Point b { get; set; }

        public Line()
        {
            a = new Point();
            b = new Point();
        }

        public Line(Point _a, Point _b)
        {
            a = _a;
            b = _b;
        }

        /// <summary>
        /// Метод находящий ориентированную площадь треугольника заданного тремя точками
        /// </summary>
        /// <param name="a">Первая точка треугольника</param>
        /// <param name="b">Вторая точка треугольника</param>
        /// <param name="c">Третья точка треугольника</param>
        /// <returns>Целочесленная площадь треугольника</returns>
        int area (Point a, Point b, Point c) {
	        return (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
        }

        /// <summary>
        /// Функция обмена значений двух переменных одного типа
        /// </summary>
        /// <typeparam name="T">Тип переменных, значения которых обмениваются</typeparam>
        /// <param name="lhs">Первая переменная</param>
        /// <param name="rhs">Вторая переменная</param>
        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        bool intersect_1 (int a, int b, int c, int d) {
	        if (a > b)  Swap (ref a, ref b);
	        if (c > d)  Swap (ref c, ref d);
	      return (Math.Max(a,c) < Math.Min(b,d)) || (a==b && b==c && c==d);
        }

        public bool intresect(Line line)
        {
            return intersect(line.a, line.b);
        }

        public bool intersect (Point c, Point d) {
	        return intersect_1 (a.X, b.X, c.X, d.X)
		&& intersect_1 (a.Y, b.Y, c.Y, d.Y)
		&& area(a,b,c) * area(a,b,d) <= 0
		&& area(c,d,a) * area(c,d,b) <= 0;
        }
    }
}
