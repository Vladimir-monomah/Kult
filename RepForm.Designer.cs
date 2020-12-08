namespace Kult
{
    partial class RepForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepForm));
            this.dGV1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bOut = new System.Windows.Forms.Button();
            this.rB1 = new System.Windows.Forms.RadioButton();
            this.rB2 = new System.Windows.Forms.RadioButton();
            this.rB3 = new System.Windows.Forms.RadioButton();
            this.rB4 = new System.Windows.Forms.RadioButton();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dGV1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            this.SuspendLayout();
            // 
            // dGV1
            // 
            this.dGV1.AllowUserToAddRows = false;
            this.dGV1.AllowUserToDeleteRows = false;
            this.dGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGV1.Location = new System.Drawing.Point(0, 40);
            this.dGV1.Margin = new System.Windows.Forms.Padding(4);
            this.dGV1.MultiSelect = false;
            this.dGV1.Name = "dGV1";
            this.dGV1.ReadOnly = true;
            this.dGV1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dGV1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGV1.ShowEditingIcon = false;
            this.dGV1.Size = new System.Drawing.Size(724, 384);
            this.dGV1.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Beige;
            this.panel1.Controls.Add(this.numYear);
            this.panel1.Controls.Add(this.rB4);
            this.panel1.Controls.Add(this.rB3);
            this.panel1.Controls.Add(this.rB2);
            this.panel1.Controls.Add(this.rB1);
            this.panel1.Controls.Add(this.bOut);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 40);
            this.panel1.TabIndex = 20;
            // 
            // bOut
            // 
            this.bOut.Image = ((System.Drawing.Image)(resources.GetObject("bOut.Image")));
            this.bOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bOut.Location = new System.Drawing.Point(591, 5);
            this.bOut.Name = "bOut";
            this.bOut.Size = new System.Drawing.Size(121, 28);
            this.bOut.TabIndex = 21;
            this.bOut.Text = "   Выгрузить";
            this.bOut.UseVisualStyleBackColor = true;
            this.bOut.Click += new System.EventHandler(this.bOut_Click);
            // 
            // rB1
            // 
            this.rB1.AutoSize = true;
            this.rB1.Checked = true;
            this.rB1.Location = new System.Drawing.Point(12, 10);
            this.rB1.Name = "rB1";
            this.rB1.Size = new System.Drawing.Size(56, 23);
            this.rB1.TabIndex = 22;
            this.rB1.TabStop = true;
            this.rB1.Text = "I кв.";
            this.rB1.UseVisualStyleBackColor = true;
            this.rB1.CheckedChanged += new System.EventHandler(this.rB1_CheckedChanged);
            // 
            // rB2
            // 
            this.rB2.AutoSize = true;
            this.rB2.Location = new System.Drawing.Point(74, 10);
            this.rB2.Name = "rB2";
            this.rB2.Size = new System.Drawing.Size(61, 23);
            this.rB2.TabIndex = 23;
            this.rB2.Text = "II кв.";
            this.rB2.UseVisualStyleBackColor = true;
            this.rB2.CheckedChanged += new System.EventHandler(this.rB2_CheckedChanged);
            // 
            // rB3
            // 
            this.rB3.AutoSize = true;
            this.rB3.Location = new System.Drawing.Point(141, 10);
            this.rB3.Name = "rB3";
            this.rB3.Size = new System.Drawing.Size(66, 23);
            this.rB3.TabIndex = 24;
            this.rB3.Text = "III кв.";
            this.rB3.UseVisualStyleBackColor = true;
            this.rB3.CheckedChanged += new System.EventHandler(this.rB3_CheckedChanged);
            // 
            // rB4
            // 
            this.rB4.AutoSize = true;
            this.rB4.Location = new System.Drawing.Point(213, 10);
            this.rB4.Name = "rB4";
            this.rB4.Size = new System.Drawing.Size(66, 23);
            this.rB4.TabIndex = 25;
            this.rB4.Text = "IV кв.";
            this.rB4.UseVisualStyleBackColor = true;
            this.rB4.CheckedChanged += new System.EventHandler(this.rB4_CheckedChanged);
            // 
            // numYear
            // 
            this.numYear.Location = new System.Drawing.Point(285, 7);
            this.numYear.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.numYear.Minimum = new decimal(new int[] {
            2015,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(67, 26);
            this.numYear.TabIndex = 26;
            this.numYear.Value = new decimal(new int[] {
            2015,
            0,
            0,
            0});
            this.numYear.ValueChanged += new System.EventHandler(this.numYear_ValueChanged);
            // 
            // RepForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 424);
            this.Controls.Add(this.dGV1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RepForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание отчета по прошедшим мероприятиям";
            this.Load += new System.EventHandler(this.RepForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGV1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dGV1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.RadioButton rB4;
        private System.Windows.Forms.RadioButton rB3;
        private System.Windows.Forms.RadioButton rB2;
        private System.Windows.Forms.RadioButton rB1;
        private System.Windows.Forms.Button bOut;
    }
}