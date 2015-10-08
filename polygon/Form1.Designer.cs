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
            this.workSpace = new System.Windows.Forms.PictureBox();
            this.btStartPolygonA = new System.Windows.Forms.Button();
            this.btStopPolygonA = new System.Windows.Forms.Button();
            this.tbPointsPolygonA = new System.Windows.Forms.TextBox();
            this.cbFillPolygon = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.workSpace)).BeginInit();
            this.SuspendLayout();
            // 
            // workSpace
            // 
            this.workSpace.BackColor = System.Drawing.Color.White;
            this.workSpace.Cursor = System.Windows.Forms.Cursors.Cross;
            this.workSpace.Enabled = false;
            this.workSpace.Location = new System.Drawing.Point(130, 86);
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
            // btStopPolygonA
            // 
            this.btStopPolygonA.Enabled = false;
            this.btStopPolygonA.Location = new System.Drawing.Point(12, 49);
            this.btStopPolygonA.Name = "btStopPolygonA";
            this.btStopPolygonA.Size = new System.Drawing.Size(222, 31);
            this.btStopPolygonA.TabIndex = 2;
            this.btStopPolygonA.Text = "Закончить рисование первого полигона";
            this.btStopPolygonA.UseVisualStyleBackColor = true;
            this.btStopPolygonA.Click += new System.EventHandler(this.btStopPolygonA_Click);
            // 
            // tbPointsPolygonA
            // 
            this.tbPointsPolygonA.Location = new System.Drawing.Point(18, 93);
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
            this.cbFillPolygon.Location = new System.Drawing.Point(240, 37);
            this.cbFillPolygon.Name = "cbFillPolygon";
            this.cbFillPolygon.Size = new System.Drawing.Size(146, 17);
            this.cbFillPolygon.TabIndex = 4;
            this.cbFillPolygon.Text = "Закрашивать полигоны";
            this.cbFillPolygon.UseVisualStyleBackColor = true;
            this.cbFillPolygon.CheckedChanged += new System.EventHandler(this.cbFillPolygon_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 468);
            this.Controls.Add(this.cbFillPolygon);
            this.Controls.Add(this.tbPointsPolygonA);
            this.Controls.Add(this.btStopPolygonA);
            this.Controls.Add(this.btStartPolygonA);
            this.Controls.Add(this.workSpace);
            this.Name = "Form1";
            this.Text = "Polygon";
            ((System.ComponentModel.ISupportInitialize)(this.workSpace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox workSpace;
        private System.Windows.Forms.Button btStartPolygonA;
        private System.Windows.Forms.Button btStopPolygonA;
        private System.Windows.Forms.TextBox tbPointsPolygonA;
        private System.Windows.Forms.CheckBox cbFillPolygon;
    }
}

