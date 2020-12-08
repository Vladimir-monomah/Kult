namespace Kult
{
    partial class ProvForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProvForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lData = new System.Windows.Forms.Label();
            this.bSend = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bDel = new System.Windows.Forms.Button();
            this.bEdit = new System.Windows.Forms.Button();
            this.bAdd = new System.Windows.Forms.Button();
            this.tC1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dGVZ = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lSum = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDost = new System.Windows.Forms.TextBox();
            this.dGVU = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtRez = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dGV1 = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.tC1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVZ)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVU)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Beige;
            this.panel1.Controls.Add(this.lData);
            this.panel1.Controls.Add(this.bSend);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.bDel);
            this.panel1.Controls.Add(this.bEdit);
            this.panel1.Controls.Add(this.bAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(894, 93);
            this.panel1.TabIndex = 19;
            // 
            // lData
            // 
            this.lData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lData.Font = new System.Drawing.Font("Cambria", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lData.Location = new System.Drawing.Point(0, 64);
            this.lData.Name = "lData";
            this.lData.Size = new System.Drawing.Size(894, 29);
            this.lData.TabIndex = 31;
            this.lData.Text = "12.12.2012";
            this.lData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bSend
            // 
            this.bSend.Image = ((System.Drawing.Image)(resources.GetObject("bSend.Image")));
            this.bSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bSend.Location = new System.Drawing.Point(652, 5);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(231, 28);
            this.bSend.TabIndex = 26;
            this.bSend.Text = "   Отправка уведомлений";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(650, 37);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(234, 28);
            this.button4.TabIndex = 25;
            this.button4.Text = "   Достижения участников";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(435, 37);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(209, 28);
            this.button3.TabIndex = 24;
            this.button3.Text = "   Отметка о проведении";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(12, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(191, 28);
            this.button2.TabIndex = 23;
            this.button2.Text = "   Список участников";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(209, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(220, 28);
            this.button1.TabIndex = 22;
            this.button1.Text = "   Затраты на проведение";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bDel
            // 
            this.bDel.Image = ((System.Drawing.Image)(resources.GetObject("bDel.Image")));
            this.bDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bDel.Location = new System.Drawing.Point(435, 5);
            this.bDel.Name = "bDel";
            this.bDel.Size = new System.Drawing.Size(209, 28);
            this.bDel.TabIndex = 21;
            this.bDel.Text = "   Удалить мероприятие";
            this.bDel.UseVisualStyleBackColor = true;
            this.bDel.Click += new System.EventHandler(this.bDel_Click);
            // 
            // bEdit
            // 
            this.bEdit.Image = ((System.Drawing.Image)(resources.GetObject("bEdit.Image")));
            this.bEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bEdit.Location = new System.Drawing.Point(209, 5);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(220, 28);
            this.bEdit.TabIndex = 20;
            this.bEdit.Text = "   Изменить параметры";
            this.bEdit.UseVisualStyleBackColor = true;
            this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
            // 
            // bAdd
            // 
            this.bAdd.Image = ((System.Drawing.Image)(resources.GetObject("bAdd.Image")));
            this.bAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bAdd.Location = new System.Drawing.Point(12, 3);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(191, 28);
            this.bAdd.TabIndex = 19;
            this.bAdd.Text = "   Новое мероприятие";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // tC1
            // 
            this.tC1.Controls.Add(this.tabPage1);
            this.tC1.Controls.Add(this.tabPage2);
            this.tC1.Controls.Add(this.tabPage3);
            this.tC1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tC1.Location = new System.Drawing.Point(0, 345);
            this.tC1.Name = "tC1";
            this.tC1.SelectedIndex = 0;
            this.tC1.Size = new System.Drawing.Size(894, 251);
            this.tC1.TabIndex = 20;
            this.tC1.SelectedIndexChanged += new System.EventHandler(this.tC1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dGVZ);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(886, 219);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Затраты на проведение";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dGVZ
            // 
            this.dGVZ.AllowUserToAddRows = false;
            this.dGVZ.AllowUserToDeleteRows = false;
            this.dGVZ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVZ.Location = new System.Drawing.Point(3, 3);
            this.dGVZ.Margin = new System.Windows.Forms.Padding(4);
            this.dGVZ.MultiSelect = false;
            this.dGVZ.Name = "dGVZ";
            this.dGVZ.ReadOnly = true;
            this.dGVZ.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dGVZ.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVZ.ShowEditingIcon = false;
            this.dGVZ.Size = new System.Drawing.Size(638, 213);
            this.dGVZ.TabIndex = 26;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Beige;
            this.groupBox2.Controls.Add(this.lSum);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Font = new System.Drawing.Font("Cambria", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(641, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(242, 213);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Итого:";
            // 
            // lSum
            // 
            this.lSum.AutoSize = true;
            this.lSum.Font = new System.Drawing.Font("Cambria", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lSum.ForeColor = System.Drawing.Color.Blue;
            this.lSum.Location = new System.Drawing.Point(7, 31);
            this.lSum.Name = "lSum";
            this.lSum.Size = new System.Drawing.Size(74, 19);
            this.lSum.TabIndex = 0;
            this.lSum.Text = "0,00 руб.";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.dGVU);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(886, 219);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Участники мероприятия";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Beige;
            this.groupBox1.Controls.Add(this.txtDost);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Font = new System.Drawing.Font("Cambria", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(556, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 213);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Достижение участника";
            // 
            // txtDost
            // 
            this.txtDost.BackColor = System.Drawing.Color.Beige;
            this.txtDost.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtDost.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtDost.Location = new System.Drawing.Point(3, 25);
            this.txtDost.Multiline = true;
            this.txtDost.Name = "txtDost";
            this.txtDost.ReadOnly = true;
            this.txtDost.Size = new System.Drawing.Size(321, 185);
            this.txtDost.TabIndex = 0;
            // 
            // dGVU
            // 
            this.dGVU.AllowUserToAddRows = false;
            this.dGVU.AllowUserToDeleteRows = false;
            this.dGVU.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVU.Location = new System.Drawing.Point(3, 3);
            this.dGVU.Margin = new System.Windows.Forms.Padding(4);
            this.dGVU.MultiSelect = false;
            this.dGVU.Name = "dGVU";
            this.dGVU.ReadOnly = true;
            this.dGVU.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dGVU.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVU.ShowEditingIcon = false;
            this.dGVU.Size = new System.Drawing.Size(880, 213);
            this.dGVU.TabIndex = 23;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtRez);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(886, 219);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Результаты проведения мероприятия";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtRez
            // 
            this.txtRez.BackColor = System.Drawing.Color.Beige;
            this.txtRez.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRez.Location = new System.Drawing.Point(3, 3);
            this.txtRez.Multiline = true;
            this.txtRez.Name = "txtRez";
            this.txtRez.ReadOnly = true;
            this.txtRez.Size = new System.Drawing.Size(880, 213);
            this.txtRez.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Beige;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 310);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(894, 35);
            this.panel2.TabIndex = 22;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Red;
            this.panel4.Location = new System.Drawing.Point(419, 7);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(65, 22);
            this.panel4.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(490, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(400, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "- нет данных о результатах проведения мероприятия";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Yellow;
            this.panel3.Location = new System.Drawing.Point(13, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(65, 22);
            this.panel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "- до мероприятия осталось менее недели";
            // 
            // dGV1
            // 
            this.dGV1.AllowUserToAddRows = false;
            this.dGV1.AllowUserToDeleteRows = false;
            this.dGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGV1.Location = new System.Drawing.Point(0, 93);
            this.dGV1.Margin = new System.Windows.Forms.Padding(4);
            this.dGV1.MultiSelect = false;
            this.dGV1.Name = "dGV1";
            this.dGV1.ReadOnly = true;
            this.dGV1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dGV1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGV1.ShowEditingIcon = false;
            this.dGV1.Size = new System.Drawing.Size(894, 217);
            this.dGV1.TabIndex = 23;
            this.dGV1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dGV1_RowPostPaint);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ProvForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 596);
            this.Controls.Add(this.dGV1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tC1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.Name = "ProvForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Проведение мероприятий";
            this.Load += new System.EventHandler(this.ProvForm_Load);
            this.panel1.ResumeLayout(false);
            this.tC1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVZ)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVU)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bDel;
        private System.Windows.Forms.Button bEdit;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.TabControl tC1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dGVU;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtRez;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dGVZ;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDost;
        private System.Windows.Forms.Label lSum;
        private System.Windows.Forms.Button bSend;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dGV1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lData;
        private System.Windows.Forms.Timer timer1;
    }
}