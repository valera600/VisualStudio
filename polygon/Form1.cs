using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        const int n = 3; //используем в программе 3 полигона (2 рисует юзер и объединение этих полигонов)
        Graphics g;
        Polygon[] polygons = new Polygon[n];
        int currentPolygon = -1;    //хранит номер редактируемого полигона в данный момент {-1 - ни один, 0 - первый, 1 - второй,}
        public Form1()
        {
            InitializeComponent();
            g = workSpace.CreateGraphics();
            for (int i = 0; i < n; i++)
                polygons[i] = new Polygon();
        }

        private void btStartPolygonA_Click(object sender, EventArgs e)
        {
            if (currentPolygon == -1)
            {
                polygons[0].Clear();
                tbPointsPolygonA.Text = "Точки полигона А:";
                ReDraw();
                btStartPolygonA.Enabled = false;    //отключаем кнопки запуска рисования
                btStartPolygonB.Enabled = false;    // полигонов
                btStopPolygon.Enabled = true;  //включаем кнопку остановки рисования полигонов
                currentPolygon = 0; //на данный момент рисуется первый полигон
            }
        }

        private void btStartPolygonB_Click(object sender, EventArgs e)
        {
            if (currentPolygon == -1)
            {
                polygons[1].Clear();
                tbPointsPolygonB.Text = "Точки полигона Б:";
                ReDraw();
                btStartPolygonA.Enabled = false;    //отключаем кнопки запуска рисования 
                btStartPolygonB.Enabled = false;    // полигонов
                btStopPolygon.Enabled = true;  //включаем кнопку остановки рисования полигонов
                currentPolygon = 1; //на данный момент рисуется второй полигон
            }
        }

        private void workSpace_MouseUp(object sender, MouseEventArgs e)
        {
            if (currentPolygon != -1)
            {
                Point newPoint = new Point(e.X, e.Y);  //точка, которую добавил пользователь
                Point lastPoint = polygons[currentPolygon].getLastPoint();
                if (polygons[currentPolygon].addPoint(newPoint))
                {
                    if (currentPolygon == 0)
                        tbPointsPolygonA.Text += (Environment.NewLine + newPoint.ToString());
                    else
                        tbPointsPolygonB.Text += (Environment.NewLine + newPoint.ToString());
                    if (polygons[currentPolygon].getCountPoints() > 1)
                    {
                        g.DrawLine(Pens.Black, lastPoint, newPoint);    //рисуем отрезок к новой точке
                    }
                    else
                    {
                        g.FillRectangle(Brushes.Black, newPoint.X, newPoint.Y, 1, 1);   //рисуем первую точку
                    }
                }
            }
            else
            {
                MessageBox.Show("На данный момент не активировано рисование полигонов!");
                Line line = new Line(new Point(124, 98), new Point(123, 228));
                line.hasPoint(new Point(124, 147));
            }
        }

        /// <summary>
        /// Закрашивание полигонов по активации чекбокса на форме
        /// </summary>
        private void cbFillPolygon_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbFillPolygon.Checked)
                {
                    for (int i = 0; i < 2; i++)
                        if (polygons[i].getCountPoints() > 0)
                            g.FillPolygon(Brushes.Red, polygons[i].pointCollection.ToArray());

                }
                else
                {
                    ReDraw();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point intersect = new Point();
            Collection<Line> one, two, newOne, newTwo;
            newOne = new Collection<Line>();
            newTwo = new Collection<Line>();
            one = polygons[0].getLinesCollection(); //линии первого полигона
            two = polygons[1].getLinesCollection(); //линии второго полигона
            int N = one.Count; //число линий в первом полигоне
            int M = two.Count; //число линий во втором полигоне

            for(int i = 0; i < N;i++)
            {
                newOne.Add(one[i]);
                for (int j = 0; j < M; j++)
                {
                    if(i == 0)
                        newTwo.Add(two[j]); //добавляем линии второго полигона только один раз
                    intersect = one[i].getIntersectPoint(two[j]);
                    if (!intersect.IsEmpty)
                    {
                        tbLog.Text += ("Точка пересечения " + intersect.ToString()) + Environment.NewLine;
                        //для первого полигона
                        foreach(Line line in newOne)
                        {
                            if(line.hasPoint(intersect))
                            {
                                tbLog.Text += ("Точка есть в А") + Environment.NewLine;
                                //запоминаем точки отрезка с точкой пересечения 
                                Point a = new Point(line.a.X, line.a.Y);
                                Point b = new Point(line.b.X, line.b.Y);
                                //удаляем этот отрезок
                                newOne.Remove(line);
                                //добавляем два новых
                                newOne.Add(new Line(a, intersect));
                                newOne.Add(new Line(intersect, b));
                                break;
                            }
                        }
                        //для второго полигона
                        foreach (Line line in newTwo)
                        {
                            if (line.hasPoint(intersect))
                            {
                                tbLog.Text += ("Точка есть в Б") + Environment.NewLine;
                                //запоминаем точки отрезка с точкой пересечения 
                                Point a = new Point(line.a.X, line.a.Y);
                                Point b = new Point(line.b.X, line.b.Y);
                                //удаляем этот отрезок
                                newTwo.Remove(line);
                                //добавляем два новых
                                newTwo.Add(new Line(a, intersect));
                                newTwo.Add(new Line(intersect, b));
                                break;
                            }
                        }
                    }
                }
            }

            foreach(Line line in newTwo)
            {
                tbPointsPolygonA.Text += (line.a.ToString() + " " + line.b.ToString()+Environment.NewLine);
                g.DrawRectangle(Pens.Red, line.a.X, line.a.Y, 2, 2);
                g.DrawRectangle(Pens.Red, line.b.X, line.b.Y, 2, 2);

            }
        }

        /// <summary>
        /// Пользователь закончил рисование полигона
        /// </summary>
        private void btStopPolygon_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentPolygon != -1)
                {
                    if (polygons[currentPolygon].getCountPoints() >= 3)
                    {
                        if (!polygons[currentPolygon].isBadPoint(polygons[currentPolygon].getFirstPoint()))
                        {
                            btStartPolygonA.Enabled = true;    //включаем кнопки запуска рисования 
                            btStartPolygonB.Enabled = true;    //полигонов
                            btStopPolygon.Enabled = false;  //выключаем кнопку остановки рисования полигонов
                            g.DrawPolygon(Pens.Black, polygons[currentPolygon].pointCollection.ToArray());
                            currentPolygon = -1; //на данный момент ни какой полигон не рисуется
                            cbFillPolygon.Enabled = true;   //активируем функцию закраски полигонов
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("Отрезок из последней точки в первую даёт самопересечение!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Полигон имеет меньше 3 точек!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ReDraw()
        {
            g.Clear(Color.White);
            for (int i = 0; i < 2; i++)
                if (polygons[i].getCountPoints() > 0)
                    g.DrawPolygon(Pens.Black, polygons[i].pointCollection.ToArray());
        }
    }
}
