using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace polygon
{
    public partial class Form1 : Form
    {
        Graphics g;
        Polygon a, b;
        Byte currentPolygon = 0;    //хранит номер редактируемого полигона в данный момент {0 - ни один, 1 - первый, 2 - второй}
        public Form1()
        {
            InitializeComponent();
            g = workSpace.CreateGraphics();
            a = new Polygon();
            b = new Polygon();
        }

        private void btStartPolygonA_Click(object sender, EventArgs e)
        {
            btStartPolygonA.Enabled = false;    //отключаем кнопку запуска рисования полигона А
            btStopPolygonA.Enabled = true;  //включаем кнопку остановки рисования полигона А
            workSpace.Enabled = true;   //включаем область для рисования
            currentPolygon = 1; //на данный момент рисуется первый полигон
        }

        private void workSpace_MouseUp(object sender, MouseEventArgs e)
        {
            Point newPoint = new Point(e.X, e.Y);  //точка, которую добавил пользователь
            switch (currentPolygon)
            {
                case 1:
                    int countPoints = a.pointCollection.Count;
                    Boolean badPoint = false;
                    if(countPoints >= 2)
                    {
                        Point[] points = a.pointCollection.ToArray();
                        Line newLine = new Line(points[countPoints-1], newPoint);
                        for(int i = 0; i < a.pointCollection.Count-1; i++)
                        {
                            if(newLine.intersect(points[i], points[i+1]))
                            {
                                badPoint = true;
                                break;
                            }
                        }
                    }
                    if (!badPoint)
                    {
                        a.addPoint(newPoint);
                        tbPointsPolygonA.Text += (Environment.NewLine + newPoint.ToString());
                        g.FillRectangle(Brushes.Black, newPoint.X, newPoint.Y, 1, 1);   //рисуем выбранную пользователем точку
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Данная точка даёт самопересечение!");
                    }
                    break;
                case 2:
                    break;
                default:
                    break;
            }
            
        }

        private void btStopPolygonA_Click(object sender, EventArgs e)
        {
            btStartPolygonA.Enabled = true;    //включаем кнопку запуска рисования полигона А
            btStopPolygonA.Enabled = false;  //выключаем кнопку остановки рисования полигона А
            workSpace.Enabled = false;   //выключаем область для рисования
            currentPolygon = 0; //на данный момент ни какой полигон не рисуется
            g.DrawPolygon(Pens.Red, a.pointCollection.ToArray());
        }

        private void cbFillPolygon_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFillPolygon.Checked)
                g.FillPolygon(Brushes.Red, a.pointCollection.ToArray());
            else
            {
                g.FillPolygon(Brushes.White, a.pointCollection.ToArray());
                g.DrawPolygon(Pens.Red, a.pointCollection.ToArray());
            }
        }

    }
}
