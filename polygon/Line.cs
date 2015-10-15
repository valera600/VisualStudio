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
	      return (Math.Max(a,c) <= Math.Min(b,d));
        }

        public bool intersect(Line line)
        {
            return intersect(line.a, line.b);
        }

        public bool intersect (Point c, Point d) {
            Boolean intersect;
            if (a == c || a == d || b == c || b == d)
                intersect = false;
	        else 
                intersect = intersect_1 (a.X, b.X, c.X, d.X)
		&& intersect_1 (a.Y, b.Y, c.Y, d.Y)
		&& area(a,b,c) * area(a,b,d) <= 0
		&& area(c,d,a) * area(c,d,b) <= 0;
            return intersect;
        }

        public Point getIntersectPoint(Line line)
        {
            Point intersectPoint = new Point();
            if(this.intersect(line))
            {
                Point a = this.a;
                Point b = this.b;
                Point c = line.a;
                Point d = line.b;
                double denominator = ((d.Y - c.Y) * (b.X - a.X)) - ((d.X - c.X) * (b.Y - a.Y));
                double Ua = (((d.X - c.X) * (a.Y - c.Y)) - ((d.Y - c.Y) * (a.X - c.X))) / (denominator);
                double Ub = (((b.X - a.X) * (a.Y - c.Y)) - ((b.Y - a.Y) * (a.X - c.X))) / denominator;
                if(Ua >= 0 && Ua <= 1 && Ub >= 0 && Ub <= 1)
                {
                    double x = a.X + Ua * (b.X - a.X);
                    double y = a.Y + Ua * (b.Y - a.Y);
                    intersectPoint.X = Convert.ToInt32(x);
                    intersectPoint.Y = Convert.ToInt32(y);
                }
            }
            return intersectPoint;
        }

        public bool hasPoint(Point point)
        {
            bool hasPoint;
            double eps = 0.05;
            double p = (point.X - this.b.X) / Convert.ToDouble((this.a.X - this.b.X));
            if(p >= 0 && p <= 1)
            {
                double p2 = ((point.Y - this.b.Y) / Convert.ToDouble((this.a.Y - this.b.Y)));
                if (p >= (p2-eps) && p <= (p2+eps))
                    hasPoint = true;
                else
                    hasPoint = false;
            }
            else
            {
                hasPoint = false;
            }
            return hasPoint;
        }
    }
}
