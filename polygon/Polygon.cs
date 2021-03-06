﻿using System;
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
                
                if (!isBadPoint(_point))
                {
                    pointCollection.Add(_point);
                    success = true;
                }
                else
                    System.Windows.Forms.MessageBox.Show("Данная точка даёт самопересечение!");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Полигон уже содержит такую точку!");
            }
            return success;
        }

        /// <summary>
        /// Данный метод проверяет даст ли точка самопересечение в полигоне
        /// </summary>
        /// <param name="_point"></param>
        /// <returns>True - точка даёт самопересечение, false - нет</returns>
        public bool isBadPoint(Point _point)
        {
            int countPoints = pointCollection.Count;
            Boolean badPoint = false;   //даёт ли точка самопересечение полигона
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
            return badPoint;
        }

        /// <summary>
        /// Возвращает последнюю точку полигона
        /// </summary>
        /// <returns>Последнюю точку, если она есть или точку {0;0}</returns>
        public Point getLastPoint()
        {
            Point point = new Point(0,0);
            if(pointCollection.Count > 0)
                point = pointCollection.ToArray()[pointCollection.Count - 1];
            return point;
        }

        /// <summary>
        /// Возвращает первую точку полигона
        /// </summary>
        /// <returns>Первую точку, если она есть или точку {0;0}</returns>
        public Point getFirstPoint()
        {
            Point point = new Point(0,0);
            if(pointCollection.Count > 0)
                point = pointCollection.ToArray()[0];
            return point;
        }

        /// <summary>
        /// Возвращает количество точек в полигоне
        /// </summary>
        /// <returns>Количество точек (int)</returns>
        public int getCountPoints()
        {
            return pointCollection.Count;
        }

        public void Clear()
        {
            this.pointCollection.Clear();
        }


        /// <summary>
        /// Возвращает коллекцию линий из которых состоит полигон
        /// </summary>
        /// <returns>Collection<Line></returns>
        public Collection<Line> getLinesCollection()
        {
            Point a = new Point();
            Point b = new Point();
            Collection<Line> lines = new Collection<Line>();
            for (int i = 0; i < pointCollection.Count; i++)
            {
                a = pointCollection[i];
                if (i < pointCollection.Count - 1)
                    b = pointCollection[i + 1];
                else
                    b = pointCollection[0];
                lines.Add(new Line(a, b));
            }
            return lines;
        }
    }
}
