using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace polygon
{
    public class Line
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
        /// <returns>Целочисленная ориентированная площадь треугольника</returns>
        public int area (Point a, Point b, Point c) {
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
            bool intersect;
            if (a == c || a == d || b == c || b == d || (((d.Y - c.Y) * (b.X - a.X)) - ((d.X - c.X) * (b.Y - a.Y))) == 0)
                intersect = false;
            else
            {
                intersect = intersect_1(a.X, b.X, c.X, d.X) && intersect_1(a.Y, b.Y, c.Y, d.Y);
                Int64 areaA, areaB;
                areaA = area(a, b, c);
                areaB = area(a, b, d);
                if((areaA <= 0 && areaB >= 0) || (areaA >= 0 && areaB <= 0))
                    intersect = intersect && true;
                else
                    intersect = false;
                areaA = area(c, d, a);
                areaB = area(c, d, b);
                if ((areaA <= 0 && areaB >= 0) || (areaA >= 0 && areaB <= 0))
                    intersect = intersect && true;
                else
                    intersect = false;
            }
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
            double eps = 1.99;
            double p;
            bool forX;
            if (Math.Abs(this.a.X - this.b.X) >= Math.Abs(this.a.Y - this.b.Y))
            {
                p = (point.X - this.b.X) / Convert.ToDouble((this.a.X - this.b.X));
                forX = false;
            }
            else
            {
                p = (point.Y - this.b.Y) / Convert.ToDouble((this.a.Y - this.b.Y));
                forX = true;
            }
            if(p >= 0 && p <= 1)
            {
                double invP = 1 - p;
                if (forX)
                {
                    double x = (p * this.a.X + (invP * this.b.X));
                    if (x - eps <= point.X && x + eps >= point.X)
                        hasPoint = true;
                    else
                        hasPoint = false;
                }
                else
                {
                    double y = (p * this.a.Y + (invP * this.b.Y));
                    if (y - eps <= point.Y && y + eps >= point.Y)
                        hasPoint = true;
                    else
                        hasPoint = false;
                }
            }
            else
            {
                hasPoint = false;
            }
            return hasPoint;
        }

        static public Collection<Line> normalizeCollection(Collection<Line> collect, Point point)
        {
            Collection<Line> normCollect = new Collection<Line>();
            Line curLine = new Line();

            //ищем линию с точкой-вершиной полигона
            foreach (Line line in collect)
            {
                if (line.a == point)
                {
                    curLine = line;
                    normCollect.Add(curLine);
                    collect.Remove(curLine);
                    break;
                }
            }

            //присоединяем линии
            while(collect.Count > 0)
            {
                foreach(Line line in collect)
                {
                    if (curLine.b == line.a)
                    {
                        curLine = line;
                        normCollect.Add(curLine);
                        collect.Remove(curLine);
                        break;
                    }
                }
            }
            return normCollect;
        }
    }
}
