namespace polygon
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.workSpace = new System.Windows.Forms.PictureBox();
            this.btDrawPolygon = new System.Windows.Forms.Button();
            this.btStopPolygon = new System.Windows.Forms.Button();
            this.cbFillPolygon = new System.Windows.Forms.CheckBox();
            this.btUnion = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.pbUnion = new System.Windows.Forms.PictureBox();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.btPrint = new System.Windows.Forms.Button();
            this.printPrevDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialogSetting = new System.Windows.Forms.PrintDialog();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.gbRadioButton = new System.Windows.Forms.GroupBox();
            this.btPreview = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSourcePolygon1 = new System.Windows.Forms.BindingSource(this.components);
            this.btAddPoint = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.bindingSourcePolygon2 = new System.Windows.Forms.BindingSource(this.components);
            this.btSaveToFile = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btLoadFromFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.workSpace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnion)).BeginInit();
            this.gbRadioButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePolygon1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePolygon2)).BeginInit();
            this.SuspendLayout();
            // 
            // workSpace
            // 
            this.workSpace.BackColor = System.Drawing.Color.White;
            this.workSpace.Cursor = System.Windows.Forms.Cursors.Cross;
            this.workSpace.Enabled = false;
            this.workSpace.Location = new System.Drawing.Point(145, 131);
            this.workSpace.Name = "workSpace";
            this.workSpace.Size = new System.Drawing.Size(358, 350);
            this.workSpace.TabIndex = 0;
            this.workSpace.TabStop = false;
            this.workSpace.MouseUp += new System.Windows.Forms.MouseEventHandler(this.workSpace_MouseUp);
            // 
            // btDrawPolygon
            // 
            this.btDrawPolygon.Location = new System.Drawing.Point(12, 12);
            this.btDrawPolygon.Name = "btDrawPolygon";
            this.btDrawPolygon.Size = new System.Drawing.Size(222, 31);
            this.btDrawPolygon.TabIndex = 1;
            this.btDrawPolygon.Text = "Начать рисовать полигон";
            this.btDrawPolygon.UseVisualStyleBackColor = true;
            this.btDrawPolygon.Click += new System.EventHandler(this.btDrawPolygon_Click);
            // 
            // btStopPolygon
            // 
            this.btStopPolygon.Enabled = false;
            this.btStopPolygon.Location = new System.Drawing.Point(14, 49);
            this.btStopPolygon.Name = "btStopPolygon";
            this.btStopPolygon.Size = new System.Drawing.Size(222, 31);
            this.btStopPolygon.TabIndex = 2;
            this.btStopPolygon.Text = "Закончить рисование полигонов";
            this.btStopPolygon.UseVisualStyleBackColor = true;
            this.btStopPolygon.Click += new System.EventHandler(this.btStopPolygon_Click);
            // 
            // cbFillPolygon
            // 
            this.cbFillPolygon.AutoSize = true;
            this.cbFillPolygon.Enabled = false;
            this.cbFillPolygon.Location = new System.Drawing.Point(240, 12);
            this.cbFillPolygon.Name = "cbFillPolygon";
            this.cbFillPolygon.Size = new System.Drawing.Size(146, 17);
            this.cbFillPolygon.TabIndex = 4;
            this.cbFillPolygon.Text = "Закрашивать полигоны";
            this.cbFillPolygon.UseVisualStyleBackColor = true;
            this.cbFillPolygon.CheckedChanged += new System.EventHandler(this.cbFillPolygon_CheckedChanged);
            // 
            // btUnion
            // 
            this.btUnion.Location = new System.Drawing.Point(392, 9);
            this.btUnion.Name = "btUnion";
            this.btUnion.Size = new System.Drawing.Size(97, 23);
            this.btUnion.TabIndex = 5;
            this.btUnion.Text = "Объединение";
            this.btUnion.UseVisualStyleBackColor = true;
            this.btUnion.Click += new System.EventHandler(this.btUnion_Click);
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(569, 39);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.Size = new System.Drawing.Size(361, 86);
            this.tbLog.TabIndex = 8;
            // 
            // pbUnion
            // 
            this.pbUnion.BackColor = System.Drawing.Color.White;
            this.pbUnion.Location = new System.Drawing.Point(642, 130);
            this.pbUnion.Name = "pbUnion";
            this.pbUnion.Size = new System.Drawing.Size(388, 351);
            this.pbUnion.TabIndex = 9;
            this.pbUnion.TabStop = false;
            // 
            // printDoc
            // 
            this.printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDoc_PrintPage);
            // 
            // btPrint
            // 
            this.btPrint.Location = new System.Drawing.Point(498, 9);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(75, 23);
            this.btPrint.TabIndex = 10;
            this.btPrint.Text = "Печать";
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // printPrevDialog
            // 
            this.printPrevDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPrevDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPrevDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPrevDialog.Document = this.printDoc;
            this.printPrevDialog.Enabled = true;
            this.printPrevDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPrevDialog.Icon")));
            this.printPrevDialog.Name = "printPrevDialog";
            this.printPrevDialog.Visible = false;
            // 
            // printDialogSetting
            // 
            this.printDialogSetting.Document = this.printDoc;
            this.printDialogSetting.UseEXDialog = true;
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(6, 28);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(65, 17);
            this.rb1.TabIndex = 11;
            this.rb1.TabStop = true;
            this.rb1.Text = "Первый";
            this.rb1.UseVisualStyleBackColor = true;
            this.rb1.CheckedChanged += new System.EventHandler(this.rbChange);
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Location = new System.Drawing.Point(6, 59);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(61, 17);
            this.rb2.TabIndex = 12;
            this.rb2.Text = "Второй";
            this.rb2.UseVisualStyleBackColor = true;
            this.rb2.CheckedChanged += new System.EventHandler(this.rbChange);
            // 
            // gbRadioButton
            // 
            this.gbRadioButton.Controls.Add(this.rb2);
            this.gbRadioButton.Controls.Add(this.rb1);
            this.gbRadioButton.Location = new System.Drawing.Point(242, 35);
            this.gbRadioButton.Name = "gbRadioButton";
            this.gbRadioButton.Size = new System.Drawing.Size(114, 89);
            this.gbRadioButton.TabIndex = 13;
            this.gbRadioButton.TabStop = false;
            this.gbRadioButton.Text = "Текущий полигон";
            // 
            // btPreview
            // 
            this.btPreview.Location = new System.Drawing.Point(579, 9);
            this.btPreview.Name = "btPreview";
            this.btPreview.Size = new System.Drawing.Size(174, 23);
            this.btPreview.TabIndex = 14;
            this.btPreview.Text = "Предварительный просмотр";
            this.btPreview.UseVisualStyleBackColor = true;
            this.btPreview.Click += new System.EventHandler(this.btPreview_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 130);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(127, 351);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_UserDeletedRow);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView_UserDeletingRow);
            // 
            // bindingSourcePolygon1
            // 
            this.bindingSourcePolygon1.AllowNew = true;
            // 
            // btAddPoint
            // 
            this.btAddPoint.Enabled = false;
            this.btAddPoint.Location = new System.Drawing.Point(14, 91);
            this.btAddPoint.Name = "btAddPoint";
            this.btAddPoint.Size = new System.Drawing.Size(220, 30);
            this.btAddPoint.TabIndex = 16;
            this.btAddPoint.Text = "Добавить точку";
            this.btAddPoint.UseVisualStyleBackColor = true;
            this.btAddPoint.Click += new System.EventHandler(this.btAddPoint_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(509, 131);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(127, 350);
            this.dataGridView2.TabIndex = 17;
            this.dataGridView2.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_UserDeletedRow);
            this.dataGridView2.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView_UserDeletingRow);
            // 
            // bindingSourcePolygon2
            // 
            this.bindingSourcePolygon2.AllowNew = true;
            // 
            // btSaveToFile
            // 
            this.btSaveToFile.Location = new System.Drawing.Point(375, 49);
            this.btSaveToFile.Name = "btSaveToFile";
            this.btSaveToFile.Size = new System.Drawing.Size(128, 23);
            this.btSaveToFile.TabIndex = 18;
            this.btSaveToFile.Text = "Сохранить в файл";
            this.btSaveToFile.UseVisualStyleBackColor = true;
            this.btSaveToFile.Click += new System.EventHandler(this.btSaveToFile_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Xml файлы|*.xml|Все файлы|*.*";
            // 
            // btLoadFromFile
            // 
            this.btLoadFromFile.Location = new System.Drawing.Point(375, 88);
            this.btLoadFromFile.Name = "btLoadFromFile";
            this.btLoadFromFile.Size = new System.Drawing.Size(128, 23);
            this.btLoadFromFile.TabIndex = 19;
            this.btLoadFromFile.Text = "Загрузить из файла";
            this.btLoadFromFile.UseVisualStyleBackColor = true;
            this.btLoadFromFile.Click += new System.EventHandler(this.btLoadFromFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Xml файлы|*.xml|Все файлы|*.*";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 514);
            this.Controls.Add(this.btLoadFromFile);
            this.Controls.Add(this.btSaveToFile);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btAddPoint);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btPreview);
            this.Controls.Add(this.gbRadioButton);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.pbUnion);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.btUnion);
            this.Controls.Add(this.cbFillPolygon);
            this.Controls.Add(this.btStopPolygon);
            this.Controls.Add(this.btDrawPolygon);
            this.Controls.Add(this.workSpace);
            this.Name = "Form1";
            this.Text = "Polygon";
            ((System.ComponentModel.ISupportInitialize)(this.workSpace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnion)).EndInit();
            this.gbRadioButton.ResumeLayout(false);
            this.gbRadioButton.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePolygon1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePolygon2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox workSpace;
        private System.Windows.Forms.Button btDrawPolygon;
        private System.Windows.Forms.Button btStopPolygon;
        private System.Windows.Forms.CheckBox cbFillPolygon;
        private System.Windows.Forms.Button btUnion;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.PictureBox pbUnion;
        private System.Drawing.Printing.PrintDocument printDoc;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.PrintPreviewDialog printPrevDialog;
        private System.Windows.Forms.PrintDialog printDialogSetting;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.GroupBox gbRadioButton;
        private System.Windows.Forms.Button btPreview;
        private System.Windows.Forms.BindingSource bindingSourcePolygon1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btAddPoint;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource bindingSourcePolygon2;
        private System.Windows.Forms.Button btSaveToFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btLoadFromFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

