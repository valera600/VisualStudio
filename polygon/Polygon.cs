using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace polygon
{
    /// <summary>
    /// Данный класс представляет полигон, который описан коллекцией точек
    /// </summary>
    class Polygon
    {
        public Collection<Point> pointCollection { get; set; }

        public Polygon() 
        {
            pointCollection = new Collection<Point>();
        }

        public Polygon(Collection<Point> _pointCollection)
        {
            pointCollection = _pointCollection;
        }

        /// <summary>Данный метод добавляет точку к полигону</summary>
        /// <param name="_point">Точка, которая добавляется к полигону</param>
        public bool addPoint(Point _point)
        {
            Boolean success = false;
            if (!pointCollection.Contains(_point))  //новой точки ещё нет в полигоне
            {
                int countPoints = pointCollection.Count;
                Boolean badPoint = false;   //даёт ли новая точка самопересечение полигона
                if (countPoints > 2)
                {
                    Point[] points = pointCollection.ToArray();
                    Line newLine = new Line(points[countPoints - 1], _point);
                    for (int i = 0; i < pointCollection.Count - 2; i++)
                    {
                        if (newLine.intersect(points[i], points[i + 1]))
                        {
                            badPoint = true;
                            break;
                        }
                    }
                }
                if (!badPoint)
                {
                    pointCollection.Add(_point);
                    success = true;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Данная точка даёт самопересечение!");
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Полигон уже содержит такую точку!");
            }
            return success;
        }
    }
}
