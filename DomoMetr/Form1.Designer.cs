namespace DomoMetr
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
            this.Calendar = new System.Windows.Forms.MonthCalendar();
            this.lCurDate = new System.Windows.Forms.Label();
            this.tbLight = new System.Windows.Forms.TextBox();
            this.numericTextBox1 = new NumericTextBox.NumericTextBox();
            this.SuspendLayout();
            // 
            // Calendar
            // 
            this.Calendar.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.Calendar.Location = new System.Drawing.Point(18, 18);
            this.Calendar.Name = "Calendar";
            this.Calendar.TabIndex = 0;
            this.Calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.Calendar_DateChanged);
            // 
            // lCurDate
            // 
            this.lCurDate.AutoSize = true;
            this.lCurDate.Location = new System.Drawing.Point(195, 18);
            this.lCurDate.Name = "lCurDate";
            this.lCurDate.Size = new System.Drawing.Size(48, 13);
            this.lCurDate.TabIndex = 1;
            this.lCurDate.Text = "lCurDate";
            // 
            // tbLight
            // 
            this.tbLight.Location = new System.Drawing.Point(198, 47);
            this.tbLight.Name = "tbLight";
            this.tbLight.Size = new System.Drawing.Size(100, 20);
            this.tbLight.TabIndex = 2;
            this.tbLight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLight_KeyPress);
            this.tbLight.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbLight_KeyUp);
            // 
            // numericTextBox1
            // 
            this.numericTextBox1.Location = new System.Drawing.Point(198, 102);
            this.numericTextBox1.Name = "numericTextBox1";
            this.numericTextBox1.Size = new System.Drawing.Size(100, 20);
            this.numericTextBox1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 406);
            this.Controls.Add(this.numericTextBox1);
            this.Controls.Add(this.tbLight);
            this.Controls.Add(this.lCurDate);
            this.Controls.Add(this.Calendar);
            this.Name = "Form1";
            this.Text = "DomoMetr";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar Calendar;
        private System.Windows.Forms.Label lCurDate;
        private System.Windows.Forms.TextBox tbLight;
        private NumericTextBox.NumericTextBox numericTextBox1;
    }
}

