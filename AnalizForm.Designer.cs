namespace Kult
{
    partial class AnalizForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalizForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rB2 = new System.Windows.Forms.RadioButton();
            this.rB1 = new System.Windows.Forms.RadioButton();
            this.cbMer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bOut = new System.Windows.Forms.Button();
            this.ch1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ch1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Beige;
            this.panel1.Controls.Add(this.rB2);
            this.panel1.Controls.Add(this.rB1);
            this.panel1.Controls.Add(this.cbMer);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(711, 65);
            this.panel1.TabIndex = 21;
            // 
            // rB2
            // 
            this.rB2.AutoSize = true;
            this.rB2.Location = new System.Drawing.Point(402, 36);
            this.rB2.Name = "rB2";
            this.rB2.Size = new System.Drawing.Size(159, 23);
            this.rB2.TabIndex = 26;
            this.rB2.TabStop = true;
            this.rB2.Text = "Число участников";
            this.rB2.UseVisualStyleBackColor = true;
            // 
            // rB1
            // 
            this.rB1.AutoSize = true;
            this.rB1.Location = new System.Drawing.Point(246, 36);
            this.rB1.Name = "rB1";
            this.rB1.Size = new System.Drawing.Size(120, 23);
            this.rB1.TabIndex = 25;
            this.rB1.TabStop = true;
            this.rB1.Text = "затраты, руб";
            this.rB1.UseVisualStyleBackColor = true;
            this.rB1.CheckedChanged += new System.EventHandler(this.rB1_CheckedChanged);
            // 
            // cbMer
            // 
            this.cbMer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMer.FormattingEnabled = true;
            this.cbMer.Location = new System.Drawing.Point(213, 5);
            this.cbMer.Name = "cbMer";
            this.cbMer.Size = new System.Drawing.Size(374, 27);
            this.cbMer.TabIndex = 23;
            this.cbMer.SelectedIndexChanged += new System.EventHandler(this.cbMer_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 19);
            this.label1.TabIndex = 22;
            this.label1.Text = "Мероприятие";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Beige;
            this.panel2.Controls.Add(this.bOut);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 429);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(711, 35);
            this.panel2.TabIndex = 23;
            // 
            // bOut
            // 
            this.bOut.Image = ((System.Drawing.Image)(resources.GetObject("bOut.Image")));
            this.bOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bOut.Location = new System.Drawing.Point(302, 4);
            this.bOut.Name = "bOut";
            this.bOut.Size = new System.Drawing.Size(121, 28);
            this.bOut.TabIndex = 22;
            this.bOut.Text = "   Сохранить";
            this.bOut.UseVisualStyleBackColor = true;
            this.bOut.Click += new System.EventHandler(this.bOut_Click);
            // 
            // ch1
            // 
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Cambria", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Cambria", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.Name = "ChartArea1";
            this.ch1.ChartAreas.Add(chartArea1);
            this.ch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ch1.Location = new System.Drawing.Point(0, 65);
            this.ch1.Name = "ch1";
            series1.ChartArea = "ChartArea1";
            series1.Font = new System.Drawing.Font("Cambria", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series1.LabelForeColor = System.Drawing.Color.Red;
            series1.Name = "Затраты, руб.";
            this.ch1.Series.Add(series1);
            this.ch1.Size = new System.Drawing.Size(711, 364);
            this.ch1.TabIndex = 24;
            this.ch1.Text = "chart1";
            title1.Font = new System.Drawing.Font("Cambria", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title1.Name = "Title1";
            title1.Text = "Отчет по мероприятиям";
            this.ch1.Titles.Add(title1);
            // 
            // AnalizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 464);
            this.Controls.Add(this.ch1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AnalizForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сравнительный анализ";
            this.Load += new System.EventHandler(this.AnalizForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ch1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bOut;
        private System.Windows.Forms.DataVisualization.Charting.Chart ch1;
        private System.Windows.Forms.ComboBox cbMer;
        private System.Windows.Forms.RadioButton rB2;
        private System.Windows.Forms.RadioButton rB1;
    }
}