﻿namespace polygon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.workSpace = new System.Windows.Forms.PictureBox();
            this.btStartPolygonA = new System.Windows.Forms.Button();
            this.btStopPolygon = new System.Windows.Forms.Button();
            this.tbPointsPolygonA = new System.Windows.Forms.TextBox();
            this.cbFillPolygon = new System.Windows.Forms.CheckBox();
            this.btUnion = new System.Windows.Forms.Button();
            this.btStartPolygonB = new System.Windows.Forms.Button();
            this.tbPointsPolygonB = new System.Windows.Forms.TextBox();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.pbUnion = new System.Windows.Forms.PictureBox();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.button2 = new System.Windows.Forms.Button();
            this.printPrevDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialogSetting = new System.Windows.Forms.PrintDialog();
            ((System.ComponentModel.ISupportInitialize)(this.workSpace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnion)).BeginInit();
            this.SuspendLayout();
            // 
            // workSpace
            // 
            this.workSpace.BackColor = System.Drawing.Color.White;
            this.workSpace.Cursor = System.Windows.Forms.Cursors.Cross;
            this.workSpace.Location = new System.Drawing.Point(144, 131);
            this.workSpace.Name = "workSpace";
            this.workSpace.Size = new System.Drawing.Size(429, 370);
            this.workSpace.TabIndex = 0;
            this.workSpace.TabStop = false;
            this.workSpace.MouseUp += new System.Windows.Forms.MouseEventHandler(this.workSpace_MouseUp);
            // 
            // btStartPolygonA
            // 
            this.btStartPolygonA.Location = new System.Drawing.Point(12, 12);
            this.btStartPolygonA.Name = "btStartPolygonA";
            this.btStartPolygonA.Size = new System.Drawing.Size(222, 31);
            this.btStartPolygonA.TabIndex = 1;
            this.btStartPolygonA.Text = "Начать рисовать первый полигон";
            this.btStartPolygonA.UseVisualStyleBackColor = true;
            this.btStartPolygonA.Click += new System.EventHandler(this.btStartPolygonA_Click);
            // 
            // btStopPolygon
            // 
            this.btStopPolygon.Enabled = false;
            this.btStopPolygon.Location = new System.Drawing.Point(12, 94);
            this.btStopPolygon.Name = "btStopPolygon";
            this.btStopPolygon.Size = new System.Drawing.Size(222, 31);
            this.btStopPolygon.TabIndex = 2;
            this.btStopPolygon.Text = "Закончить рисование полигонов";
            this.btStopPolygon.UseVisualStyleBackColor = true;
            this.btStopPolygon.Click += new System.EventHandler(this.btStopPolygon_Click);
            // 
            // tbPointsPolygonA
            // 
            this.tbPointsPolygonA.Location = new System.Drawing.Point(12, 138);
            this.tbPointsPolygonA.Multiline = true;
            this.tbPointsPolygonA.Name = "tbPointsPolygonA";
            this.tbPointsPolygonA.ReadOnly = true;
            this.tbPointsPolygonA.Size = new System.Drawing.Size(106, 363);
            this.tbPointsPolygonA.TabIndex = 3;
            this.tbPointsPolygonA.TabStop = false;
            this.tbPointsPolygonA.Text = "Точки полигона А:";
            // 
            // cbFillPolygon
            // 
            this.cbFillPolygon.AutoSize = true;
            this.cbFillPolygon.Enabled = false;
            this.cbFillPolygon.Location = new System.Drawing.Point(261, 12);
            this.cbFillPolygon.Name = "cbFillPolygon";
            this.cbFillPolygon.Size = new System.Drawing.Size(146, 17);
            this.cbFillPolygon.TabIndex = 4;
            this.cbFillPolygon.Text = "Закрашивать полигоны";
            this.cbFillPolygon.UseVisualStyleBackColor = true;
            this.cbFillPolygon.CheckedChanged += new System.EventHandler(this.cbFillPolygon_CheckedChanged);
            // 
            // btUnion
            // 
            this.btUnion.Location = new System.Drawing.Point(251, 49);
            this.btUnion.Name = "btUnion";
            this.btUnion.Size = new System.Drawing.Size(97, 23);
            this.btUnion.TabIndex = 5;
            this.btUnion.Text = "Объединение";
            this.btUnion.UseVisualStyleBackColor = true;
            this.btUnion.Click += new System.EventHandler(this.btUnion_Click);
            // 
            // btStartPolygonB
            // 
            this.btStartPolygonB.Location = new System.Drawing.Point(12, 49);
            this.btStartPolygonB.Name = "btStartPolygonB";
            this.btStartPolygonB.Size = new System.Drawing.Size(224, 31);
            this.btStartPolygonB.TabIndex = 6;
            this.btStartPolygonB.Text = "Начать рисовать второй полигон";
            this.btStartPolygonB.UseVisualStyleBackColor = true;
            this.btStartPolygonB.Click += new System.EventHandler(this.btStartPolygonB_Click);
            // 
            // tbPointsPolygonB
            // 
            this.tbPointsPolygonB.Location = new System.Drawing.Point(1017, 131);
            this.tbPointsPolygonB.Multiline = true;
            this.tbPointsPolygonB.Name = "tbPointsPolygonB";
            this.tbPointsPolygonB.ReadOnly = true;
            this.tbPointsPolygonB.Size = new System.Drawing.Size(106, 363);
            this.tbPointsPolygonB.TabIndex = 7;
            this.tbPointsPolygonB.TabStop = false;
            this.tbPointsPolygonB.Text = "Точки полигона Б:";
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(364, 38);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.Size = new System.Drawing.Size(310, 86);
            this.tbLog.TabIndex = 8;
            // 
            // pbUnion
            // 
            this.pbUnion.BackColor = System.Drawing.Color.White;
            this.pbUnion.Location = new System.Drawing.Point(579, 130);
            this.pbUnion.Name = "pbUnion";
            this.pbUnion.Size = new System.Drawing.Size(432, 371);
            this.pbUnion.TabIndex = 9;
            this.pbUnion.TabStop = false;
            // 
            // printDoc
            // 
            this.printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDoc_PrintPage);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(261, 94);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 514);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pbUnion);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.tbPointsPolygonB);
            this.Controls.Add(this.btStartPolygonB);
            this.Controls.Add(this.btUnion);
            this.Controls.Add(this.cbFillPolygon);
            this.Controls.Add(this.tbPointsPolygonA);
            this.Controls.Add(this.btStopPolygon);
            this.Controls.Add(this.btStartPolygonA);
            this.Controls.Add(this.workSpace);
            this.Name = "Form1";
            this.Text = "Polygon";
            ((System.ComponentModel.ISupportInitialize)(this.workSpace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox workSpace;
        private System.Windows.Forms.Button btStartPolygonA;
        private System.Windows.Forms.Button btStopPolygon;
        private System.Windows.Forms.TextBox tbPointsPolygonA;
        private System.Windows.Forms.CheckBox cbFillPolygon;
        private System.Windows.Forms.Button btUnion;
        private System.Windows.Forms.Button btStartPolygonB;
        private System.Windows.Forms.TextBox tbPointsPolygonB;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.PictureBox pbUnion;
        private System.Drawing.Printing.PrintDocument printDoc;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PrintPreviewDialog printPrevDialog;
        private System.Windows.Forms.PrintDialog printDialogSetting;
    }
}

