namespace Kult
{
    partial class AddProvForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProvForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bCancel = new System.Windows.Forms.Button();
            this.bOk = new System.Windows.Forms.Button();
            this.bCh_Mer = new System.Windows.Forms.Button();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.bCh_Org = new System.Windows.Forms.Button();
            this.dt1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Наименование";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Организация";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Дата проведения";
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Image = ((System.Drawing.Image)(resources.GetObject("bCancel.Image")));
            this.bCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bCancel.Location = new System.Drawing.Point(274, 157);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(85, 28);
            this.bCancel.TabIndex = 20;
            this.bCancel.Text = "   Отмена";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bOk
            // 
            this.bOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOk.Image = ((System.Drawing.Image)(resources.GetObject("bOk.Image")));
            this.bOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bOk.Location = new System.Drawing.Point(199, 157);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(69, 28);
            this.bOk.TabIndex = 19;
            this.bOk.Text = "ОК";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // bCh_Mer
            // 
            this.bCh_Mer.Location = new System.Drawing.Point(502, 19);
            this.bCh_Mer.Name = "bCh_Mer";
            this.bCh_Mer.Size = new System.Drawing.Size(32, 27);
            this.bCh_Mer.TabIndex = 35;
            this.bCh_Mer.Text = "...";
            this.bCh_Mer.UseVisualStyleBackColor = true;
            this.bCh_Mer.Click += new System.EventHandler(this.bCh_Prov_Click);
            // 
            // txt1
            // 
            this.txt1.BackColor = System.Drawing.Color.SkyBlue;
            this.txt1.Location = new System.Drawing.Point(164, 20);
            this.txt1.MaxLength = 10;
            this.txt1.Name = "txt1";
            this.txt1.ReadOnly = true;
            this.txt1.Size = new System.Drawing.Size(332, 26);
            this.txt1.TabIndex = 34;
            // 
            // txt2
            // 
            this.txt2.BackColor = System.Drawing.Color.SkyBlue;
            this.txt2.Location = new System.Drawing.Point(164, 64);
            this.txt2.MaxLength = 10;
            this.txt2.Name = "txt2";
            this.txt2.ReadOnly = true;
            this.txt2.Size = new System.Drawing.Size(332, 26);
            this.txt2.TabIndex = 36;
            // 
            // bCh_Org
            // 
            this.bCh_Org.Location = new System.Drawing.Point(502, 64);
            this.bCh_Org.Name = "bCh_Org";
            this.bCh_Org.Size = new System.Drawing.Size(32, 27);
            this.bCh_Org.TabIndex = 37;
            this.bCh_Org.Text = "...";
            this.bCh_Org.UseVisualStyleBackColor = true;
            this.bCh_Org.Click += new System.EventHandler(this.bCh_Org_Click);
            // 
            // dt1
            // 
            this.dt1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt1.Location = new System.Drawing.Point(164, 109);
            this.dt1.Name = "dt1";
            this.dt1.Size = new System.Drawing.Size(131, 26);
            this.dt1.TabIndex = 38;
            // 
            // AddProvForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 197);
            this.Controls.Add(this.dt1);
            this.Controls.Add(this.bCh_Org);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.bCh_Mer);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddProvForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Новое мероприятие";
            this.Load += new System.EventHandler(this.AddProvForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.Button bCh_Mer;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.Button bCh_Org;
        private System.Windows.Forms.DateTimePicker dt1;
    }
}