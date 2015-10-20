﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using System.Data.SqlTypes;
using Microsoft.VisualBasic;
using System.Data.SqlClient;

namespace polygon
{
    public partial class Form1 : Form
    {
        const int n = 2; //используем в программе 2 полигона
        bool isAddPoint = false;
        Graphics g;
        Graphics gUnion;
        Collection<Line> unionLines = new Collection<Line>();   //линии полигона объединения
        Polygon[] polygons = new Polygon[n];
        int currentPolygon = 0;    //хранит номер редактируемого полигона в данный момент {0 - первый, 1 - второй,}
        public Form1()
        {
            InitializeComponent();
            g = workSpace.CreateGraphics();
            gUnion = pbUnion.CreateGraphics();
            for (int i = 0; i < n; i++)
                polygons[i] = new Polygon();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bindingSourcePolygon1;
            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = bindingSourcePolygon2;
        }

        private void btDrawPolygon_Click(object sender, EventArgs e)
        {
            workSpace.Enabled = true;
            polygons[currentPolygon].pointCollection.Clear();
            updateGrid(currentPolygon);
            ReDraw();
            btDrawPolygon.Enabled = false;    //отключаем кнопки запуска рисования
            cbFillPolygon.Enabled = false;
            btStopPolygon.Enabled = true;  //включаем кнопку остановки рисования полигонов
            btAddPoint.Enabled = false;
            gbRadioButton.Enabled = false;
            dataGridView1.Enabled = false;
            cbFillPolygon.Checked = false;
        }

        private void workSpace_MouseUp(object sender, MouseEventArgs e)
        {
            if (workSpace.Enabled)
            {
                Point newPoint = new Point(e.X, e.Y);  //точка, которую добавил пользователь
                Point lastPoint = polygons[currentPolygon].getLastPoint();
                if (polygons[currentPolygon].addPoint(newPoint))
                {
                    updateGrid(currentPolygon);
                    
                    if (polygons[currentPolygon].getCountPoints() > 1)
                    {
                        g.DrawLine(Pens.Black, lastPoint, newPoint);    //рисуем отрезок к новой точке
                    }
                    else
                    {
                        g.FillRectangle(Brushes.Black, newPoint.X, newPoint.Y, 1, 1);   //рисуем первую точку
                    }
                }
                if(isAddPoint)
                {
                    isAddPoint = false;
                    if(polygons[currentPolygon].isBadLine(newPoint, polygons[currentPolygon].getFirstPoint()))
                    {
                        MessageBox.Show("Добавление этой точки даст самопересечение для отрезка из новой точки в первую!");
                        polygons[currentPolygon].pointCollection.Remove(newPoint);
                        updateGrid(currentPolygon);
                    }
                    btStopPolygon_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("На данный момент не активировано рисование полигонов!");
                Line line = new Line(new Point(30, 30), new Point(70, 30));
                Line line2 = new Line(new Point(25, 30), new Point(75, 30));
                MessageBox.Show(line.intersect(line2).ToString());
            }
        }

        /// <summary>
        /// Закрашивание полигонов по активации чекбокса на форме
        /// </summary>
        private void cbFillPolygon_CheckedChanged(object sender, EventArgs e)
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

        private void btUnion_Click(object sender, EventArgs e)
        {
            Collection<Line> one, two, newOne, newTwo, union;
            one = polygons[0].getLinesCollection(); //линии первого полигона
            two = polygons[1].getLinesCollection(); //линии второго полигона
            int N = one.Count; //число линий в первом полигоне
            int M = two.Count; //число линий во втором полигоне
            if (N > 2 && M > 2)
            {
                Point intersect = new Point();  //точка пересечения
                Collection<Point> intersectPoints = new Collection<Point>(); //запомним какие из точек - точки пересечения
                newOne = new Collection<Line>(); //первый полигон, дополненный точками пересечения
                newTwo = new Collection<Line>(); //второй с точками пересечения
                union = new Collection<Line>();

                //добавляем в полигоны точки пересечений
                for (int i = 0; i < N; i++)
                {
                    newOne.Add(one[i]);
                    for (int j = 0; j < M; j++)
                    {
                        if (i == 0)
                            newTwo.Add(two[j]); //добавляем линии второго полигона только один раз
                        intersect = one[i].getIntersectPoint(two[j]); //находим точку пересечения
                        if (one[i].a == intersect || one[i].b == intersect || two[j].a == intersect || two[j].b == intersect)
                            intersect = new Point();
                        if (!intersect.IsEmpty)
                        {
                            intersectPoints.Add(intersect);
                            //для первого полигона
                            foreach (Line line in newOne)
                            {
                                if (line.hasPoint(intersect))
                                {
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

                Boolean pointOneInsideTwo, pointTwoInsideOne; //находится ли точка данного полигона внутри другого полигона

                //проверка на то, что на трассировочный луч попала вершина полигона

                Line ray = new Line(one[0].a, new Point(0, 0)); //трассировочный отрезок(луч) из проверяемой точки в 0,0
                /*Collection<Point> twoPolygon = polygons[1].pointCollection;
                foreach (Point point in twoPolygon)
                {
                    if(ray.hasPoint(point))
                    {
                    }
                }*/

                int countIntersect = 0; //счетчик пересечений с контуром полигона
                foreach (Line line in two)
                {
                    if (ray.intersect(line))
                    {
                        countIntersect++;
                    }
                }
                //если чётное количество пересечений с трассировочным лучом, то точка лежит вне проверяемого полигона
                if (countIntersect % 2 == 0)
                {
                    pointOneInsideTwo = false;
                }
                else
                {
                    pointOneInsideTwo = true;
                }

                //проверяем находится ли точка второго полигона внутри контура первого
                countIntersect = 0;
                ray = new Line(two[0].a, new Point(0, 0));
                foreach (Line line in one)
                {
                    if (ray.intersect(line))
                    {
                        countIntersect++;
                    }
                }
                //если чётное количество пересечений с трассировочным лучом, то точка лежит вне проверяемого полигона
                if (countIntersect % 2 == 0)
                {
                    pointTwoInsideOne = false;
                }
                else
                {
                    pointTwoInsideOne = true;
                }

                //составляем объединение
                Point newA = new Point();
                Point newB = new Point();

                newOne = Line.normalizeCollection(newOne, one[0].a);
                newTwo = Line.normalizeCollection(newTwo, two[0].a);

                //обходим линии первого полигона
                foreach (Line line in newOne)
                {
                    if (!pointOneInsideTwo)
                    {
                        if (newA.IsEmpty)
                            newA = line.a;
                        else
                            newB = line.a;
                    }

                    if (!pointOneInsideTwo)
                    {
                        if (newA.IsEmpty)
                            newA = line.b;
                        else
                            newB = line.b;
                    }
                    if (intersectPoints.Contains(line.b))
                        pointOneInsideTwo = !pointOneInsideTwo;

                    if ((!newA.IsEmpty) && (!newB.IsEmpty))
                    {
                        union.Add(new Line(newA, newB));
                        newA = new Point();
                        newB = new Point();
                    }
                }

                newA = new Point();
                newB = new Point();
                //обходим линии второго полигона
                foreach (Line line in newTwo)
                {
                    if (!pointTwoInsideOne)
                    {
                        if (newA.IsEmpty)
                            newA = line.a;
                        else
                            newB = line.a;
                    }
                    /*if (intersectPoints.Contains(line.a))
                        pointTwoInsideOne = !pointTwoInsideOne;*/

                    if (!pointTwoInsideOne)
                    {
                        if (newA.IsEmpty)
                            newA = line.b;
                        else
                            newB = line.b;
                    }
                    if (intersectPoints.Contains(line.b))
                        pointTwoInsideOne = !pointTwoInsideOne;


                    if ((!newA.IsEmpty) && (!newB.IsEmpty))
                    {
                        union.Add(new Line(newA, newB));
                        newA = new Point();
                        newB = new Point();
                    }
                }

                unionLines = union;
                gUnion.Clear(Color.White);
                foreach (Line line in union)
                {
                    gUnion.DrawLine(Pens.Red, line.a, line.b);
                }
            }
            else
            {
                MessageBox.Show("Нет данных для нахождения объединения!");
            }
        }

        /// <summary>
        /// Пользователь закончил рисование полигона
        /// </summary>
        private void btStopPolygon_Click(object sender, EventArgs e)
        {
            try
            {
                if (polygons[currentPolygon].getCountPoints() > 2)
                {
                    if (!polygons[currentPolygon].isBadLine(polygons[currentPolygon].getLastPoint(),polygons[currentPolygon].getFirstPoint()))
                    {
                        btDrawPolygon.Enabled = true;    //включаем кнопки запуска рисования 
                        btStopPolygon.Enabled = false;  //выключаем кнопку остановки рисования полигонов
                        workSpace.Enabled = false;
                        gbRadioButton.Enabled = true;
                        ReDraw();
                        cbFillPolygon.Enabled = true;   //активируем функцию закраски полигонов
                        dataGridView1.Enabled = true;
                        updateGrid(currentPolygon);
                        btAddPoint.Enabled = true;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ReDraw()
        {
            g.Clear(Color.White);
            for (int i = 0; i < n; i++)
                if (polygons[i].getCountPoints() > 0)
                    g.DrawPolygon(Pens.Black, polygons[i].pointCollection.ToArray());
            if (unionLines.Count > 0)
                foreach (Line line in unionLines)
                    gUnion.DrawLine(Pens.Red, line.a, line.b);
        }

        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics gr = e.Graphics;
            try
            {
                for (int i = 0; i < n; i++ )
                    if (polygons[i].pointCollection.Count > 0)
                    {
                        gr.DrawPolygon(Pens.Black, polygons[i].pointCollection.ToArray());
                        if (cbFillPolygon.Checked)
                            gr.FillPolygon(Brushes.Red, polygons[i].pointCollection.ToArray());
                    }
                if (unionLines.Count > 0)
                    foreach (Line line in unionLines)
                        gr.DrawLine(Pens.Red, (new Point(line.a.X + workSpace.Width + 15, line.a.Y)), (new Point(line.b.X +workSpace.Width + 15, line.b.Y)));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            if (printDialogSetting.ShowDialog() == DialogResult.OK)
                printDoc.Print();
        }

        private void btPreview_Click(object sender, EventArgs e)
        {
            printPrevDialog.ShowDialog();
        }

        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int cur;
            DataGridView dgView = sender as DataGridView;
            if (dgView.Name == "dataGridView1")
                cur = 0;
            else
                cur = 1;
            if (polygons[cur].pointCollection.Count > 3)
            {
                Point deletingPoint = polygons[cur].pointCollection[e.Row.Index];
                Collection<Line> lines = polygons[cur].getLinesCollection();
                Line newLine = new Line();
                Line lineAB = new Line();
                Line lineCD = new Line();
                foreach (Line line in lines)
                {
                    if (line.b == deletingPoint)
                    {
                        newLine.a = line.a;
                        lineAB = line;
                    }
                    if (line.a == deletingPoint)
                    {
                        newLine.b = line.b;
                        lineCD = line;
                    }
                }
                lines.Remove(lineAB);
                lines.Remove(lineCD);

                if (!polygons[cur].isBadLine(newLine.a, newLine.b))
                {
                    MessageBox.Show("Точка " + deletingPoint.ToString() + " успешно удалена");
                }
                else
                {
                    MessageBox.Show("Удаление данной точки даст самопересечение полигона!");
                    e.Cancel = true;
                }
            }
            else
            {
                MessageBox.Show("Удаление невозможно! Полигон имеет всего 3 точки!");
                e.Cancel = true;
            }
            
        }

        private void rbChange(object sender, EventArgs e)
        {
            if (rb1.Checked)
            {
                currentPolygon = 0;
            }
            else
            {
                currentPolygon = 1;
            }
            if (polygons[currentPolygon].getCountPoints() > 2)
            {
                btAddPoint.Enabled = true;
            }
            else
            {
                btAddPoint.Enabled = false;
            }
        }

        private void dataGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            ReDraw();
        }

        private void updateGrid(int cur)
        {
            if(cur == 0)
            {
                bindingSourcePolygon1.DataSource = null;
                bindingSourcePolygon1.DataSource = polygons[0].pointCollection;
            }
            else
            {
                bindingSourcePolygon2.DataSource = null;
                bindingSourcePolygon2.DataSource = polygons[1].pointCollection;
            }
        }

        private void btAddPoint_Click(object sender, EventArgs e)
        {
            if (polygons[currentPolygon].getCountPoints() > 2)
            {
                isAddPoint = true;
                workSpace.Enabled = true;
                Line line = polygons[currentPolygon].getLinesCollection()[polygons[currentPolygon].getCountPoints() - 1];
                ReDraw();
                g.DrawLine(Pens.White, line.a, line.b);
                g.Flush();
                btDrawPolygon.Enabled = false;    //отключаем кнопки запуска рисования
                cbFillPolygon.Enabled = false;
                btStopPolygon.Enabled = true;  //включаем кнопку остановки рисования полигонов
                gbRadioButton.Enabled = false;
                dataGridView1.Enabled = false;
                cbFillPolygon.Checked = false;
            }
            else
            {
                MessageBox.Show("Полигон должен существовать!");
            }
        }

        private void btSaveToFile_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            TextWriter writer = null;
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        var serializer = new XmlSerializer(typeof(Polygon));
                        writer = new StreamWriter(myStream);
                        serializer.Serialize(writer, polygons[currentPolygon]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        private void btLoadFromFile_Click(object sender, EventArgs e)
        {
            TextReader reader = null;
            Stream myStream = null;
            try
            {
                if(openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        var serializer = new XmlSerializer(typeof(Polygon));
                        reader = new StreamReader(myStream);
                        Polygon newPolygon = (Polygon)serializer.Deserialize(reader);
                        if (!newPolygon.isBadPolygon())
                        {
                            polygons[currentPolygon] = newPolygon;
                            updateGrid(currentPolygon);
                            ReDraw();
                            btAddPoint.Enabled = true;
                            cbFillPolygon.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Файл содержит недопустимый полигон!");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        private void btSaveToDB_Click(object sender, EventArgs e)
        {
            TextWriter writer = null;
            MemoryStream myStream = null;
            try
            {
                DatabaseDataSetTableAdapters.PolygonsTableAdapter adapter = new DatabaseDataSetTableAdapters.PolygonsTableAdapter();
                
                if (!polygons[currentPolygon].isBadPolygon())
                {
                    myStream = new MemoryStream();
                    var serializer = new XmlSerializer(typeof(Polygon));
                    writer = new StreamWriter(myStream);
                    serializer.Serialize(writer, polygons[currentPolygon]);
                    SqlXml newXml = new SqlXml(myStream);
                    string name = null;
                    do
                    {
                        name = Interaction.InputBox("Введите имя полигона:", "Имя полигона", "Имя полигона не может быть пустым");
                    } while (name == "");
                    if (adapter.Insert(name, newXml) == 1)
                    {
                        updateListPolygons();
                        MessageBox.Show("Полигон добавлен в БД!");
                    }
                    else
                        MessageBox.Show("Ошибка добавления полигона!");
                }
                else
                {
                    MessageBox.Show("Текущий полигон не может быть добавлен в БД, т.к. содержит плохие точки!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateListPolygons();
        }

        private DatabaseDataSet.PolygonsDataTable getPolygons()
        {
            DatabaseDataSetTableAdapters.PolygonsTableAdapter adapter = new DatabaseDataSetTableAdapters.PolygonsTableAdapter();
            DatabaseDataSet.PolygonsDataTable table = new DatabaseDataSet.PolygonsDataTable();
            try
            {
                adapter.Fill(table);
                adapter.GetData();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return table;
        }

        private void updateListPolygons()
        {
            try
            {
                DatabaseDataSet.PolygonsDataTable table = getPolygons();
                cbPolygonsInBD.Items.Clear();
                foreach (DatabaseDataSet.PolygonsRow polygonRow in table)
                {
                    cbPolygonsInBD.Items.Add(polygonRow.Name);
                }
                if (cbPolygonsInBD.Items.Count > 0)
                    cbPolygonsInBD.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
        }

        private void btLoadFromDB_Click(object sender, EventArgs e)
        {
            String xmlPolygon;
            if (cbPolygonsInBD.SelectedItem != null)
            {
                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.DatabaseConnectionString))
                {
                    SqlCommand command = new SqlCommand("Select points from dbo.polygons where name=N'" + cbPolygonsInBD.SelectedItem + "'", connection);
                    command.Connection.Open();
                    xmlPolygon = (String)command.ExecuteScalar();
                }
                TextReader reader = null;
                try
                {
                    var serializer = new XmlSerializer(typeof(Polygon));
                    reader = new StringReader(xmlPolygon);
                    Polygon newPolygon = (Polygon)serializer.Deserialize(reader);
                    if (!newPolygon.isBadPolygon())
                    {
                        polygons[currentPolygon] = newPolygon;
                        updateGrid(currentPolygon);
                        ReDraw();
                        btAddPoint.Enabled = true;
                        cbFillPolygon.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Полигон имеет неверный формат и не будет загружен!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }
            }
            else
            {
                MessageBox.Show("Полигон для загрузки не выбран!");
            }
        }
    }
}
