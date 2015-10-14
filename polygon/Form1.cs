﻿using System;
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
            Point lastPoint = a.getLastPoint();
            switch (currentPolygon)
            {
                case 1:
                    if (a.addPoint(newPoint))
                    {                     
                        tbPointsPolygonA.Text += (Environment.NewLine + newPoint.ToString());
                        if (a.getCountPoints() > 1)
                        {
                            g.DrawLine(Pens.Black, lastPoint, newPoint);    //рисуем отрезок к новой точке
                        }
                        else
                        {
                            g.FillRectangle(Brushes.Black, newPoint.X, newPoint.Y, 1, 1);   //рисуем первую точку
                        }
                    }
                    break;
                case 2:
                    break;
                default:
                    break;
            }
            
        }

        /// <summary>
        /// Пользователь закончил рисование полигона
        /// </summary>
        private void btStopPolygonA_Click(object sender, EventArgs e)
        {
            //текущий полигон!
            if (!a.isBadPoint(a.getFirstPoint()))
            {
                btStartPolygonA.Enabled = true;    //включаем кнопку запуска рисования полигона А
                btStopPolygonA.Enabled = false;  //выключаем кнопку остановки рисования полигона А
                workSpace.Enabled = false;   //выключаем область для рисования         
                g.DrawPolygon(Pens.Red, a.pointCollection.ToArray());
                currentPolygon = 0; //на данный момент ни какой полигон не рисуется
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Отрезок из последней точки в первую даёт самопересечение!");
            }
        }

        /// <summary>
        /// Закрашивание полигонов по активации чекбокса на форме
        /// </summary>
        private void cbFillPolygon_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFillPolygon.Checked)
                g.FillPolygon(Brushes.Red, a.pointCollection.ToArray());
            else
            {
                g.FillPolygon(Brushes.White, a.pointCollection.ToArray());
                g.DrawPolygon(Pens.Black, a.pointCollection.ToArray());
            }
        }

    }
}
