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
        public void addPoint(Point _point)
        {
            pointCollection.Add(_point);
        }
    }
}
