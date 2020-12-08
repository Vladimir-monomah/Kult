namespace Kult
{
    partial class AddZatrForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddZatrForm));
            this.bCh_Zatr = new System.Windows.Forms.Button();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bCancel = new System.Windows.Forms.Button();
            this.bOk = new System.Windows.Forms.Button();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lCapt = new System.Windows.Forms.Label();
            this.bDel = new System.Windows.Forms.Button();
            this.bEdit = new System.Windows.Forms.Button();
            this.bAdd = new System.Windows.Forms.Button();
            this.dGV1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pDop = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dGV1)).BeginInit();
            this.panel1.SuspendLayout();
            this.pDop.SuspendLayout();
            this.SuspendLayout();
            // 
            // bCh_Zatr
            // 
            this.bCh_Zatr.Location = new System.Drawing.Point(403, 25);
            this.bCh_Zatr.Name = "bCh_Zatr";
            this.bCh_Zatr.Size = new System.Drawing.Size(32, 27);
            this.bCh_Zatr.TabIndex = 33;
            this.bCh_Zatr.Text = "...";
            this.bCh_Zatr.UseVisualStyleBackColor = true;
            this.bCh_Zatr.Click += new System.EventHandler(this.bCh_Zatr_Click);
            // 
            // txt1
            // 
            this.txt1.BackColor = System.Drawing.Color.SkyBlue;
            this.txt1.Location = new System.Drawing.Point(110, 25);
            this.txt1.MaxLength = 100;
            this.txt1.Name = "txt1";
            this.txt1.ReadOnly = true;
            this.txt1.Size = new System.Drawing.Size(287, 26);
            this.txt1.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 19);
            this.label7.TabIndex = 29;
            this.label7.Text = "Вид затрат";
            // 
            // bCancel
            // 
            this.bCancel.Image = ((System.Drawing.Image)(resources.GetObject("bCancel.Image")));
            this.bCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bCancel.Location = new System.Drawing.Point(350, 90);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(85, 28);
            this.bCancel.TabIndex = 18;
            this.bCancel.Text = "   Отмена";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bOk
            // 
            this.bOk.Image = ((System.Drawing.Image)(resources.GetObject("bOk.Image")));
            this.bOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bOk.Location = new System.Drawing.Point(275, 90);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(69, 28);
            this.bOk.TabIndex = 17;
            this.bOk.Text = "ОК";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(110, 57);
            this.txt2.MaxLength = 100;
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(157, 26);
            this.txt2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Сумма, руб.";
            // 
            // lCapt
            // 
            this.lCapt.Dock = System.Windows.Forms.DockStyle.Top;
            this.lCapt.Font = new System.Drawing.Font("Cambria", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lCapt.Location = new System.Drawing.Point(0, 0);
            this.lCapt.Name = "lCapt";
            this.lCapt.Size = new System.Drawing.Size(444, 19);
            this.lCapt.TabIndex = 0;
            this.lCapt.Text = "label1";
            this.lCapt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bDel
            // 
            this.bDel.Image = ((System.Drawing.Image)(resources.GetObject("bDel.Image")));
            this.bDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bDel.Location = new System.Drawing.Point(226, 5);
            this.bDel.Name = "bDel";
            this.bDel.Size = new System.Drawing.Size(90, 28);
            this.bDel.TabIndex = 21;
            this.bDel.Text = "   Удалить";
            this.bDel.UseVisualStyleBackColor = true;
            this.bDel.Click += new System.EventHandler(this.bDel_Click);
            // 
            // bEdit
            // 
            this.bEdit.Image = ((System.Drawing.Image)(resources.GetObject("bEdit.Image")));
            this.bEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bEdit.Location = new System.Drawing.Point(116, 5);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(104, 28);
            this.bEdit.TabIndex = 20;
            this.bEdit.Text = "   Изменить";
            this.bEdit.UseVisualStyleBackColor = true;
            this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
            // 
            // bAdd
            // 
            this.bAdd.Image = ((System.Drawing.Image)(resources.GetObject("bAdd.Image")));
            this.bAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bAdd.Location = new System.Drawing.Point(9, 5);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(101, 28);
            this.bAdd.TabIndex = 19;
            this.bAdd.Text = "   Добавить";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
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
            this.dGV1.Size = new System.Drawing.Size(444, 243);
            this.dGV1.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Beige;
            this.panel1.Controls.Add(this.bDel);
            this.panel1.Controls.Add(this.bEdit);
            this.panel1.Controls.Add(this.bAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 40);
            this.panel1.TabIndex = 21;
            // 
            // pDop
            // 
            this.pDop.Controls.Add(this.bCh_Zatr);
            this.pDop.Controls.Add(this.txt1);
            this.pDop.Controls.Add(this.label7);
            this.pDop.Controls.Add(this.bCancel);
            this.pDop.Controls.Add(this.bOk);
            this.pDop.Controls.Add(this.txt2);
            this.pDop.Controls.Add(this.label1);
            this.pDop.Controls.Add(this.lCapt);
            this.pDop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pDop.Location = new System.Drawing.Point(0, 283);
            this.pDop.Margin = new System.Windows.Forms.Padding(4);
            this.pDop.Name = "pDop";
            this.pDop.Size = new System.Drawing.Size(444, 123);
            this.pDop.TabIndex = 20;
            // 
            // AddZatrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 406);
            this.Controls.Add(this.dGV1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pDop);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddZatrForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Затраты на проведение мероприятия";
            this.Load += new System.EventHandler(this.AddZatrForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGV1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pDop.ResumeLayout(false);
            this.pDop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bCh_Zatr;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lCapt;
        private System.Windows.Forms.Button bDel;
        private System.Windows.Forms.Button bEdit;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.DataGridView dGV1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pDop;
    }
}