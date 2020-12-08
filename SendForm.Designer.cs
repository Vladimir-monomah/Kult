namespace Kult
{
    partial class SendForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendForm));
            this.lB1 = new System.Windows.Forms.ListBox();
            this.lB2 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTheme = new System.Windows.Forms.TextBox();
            this.txtMess = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.bCh = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lB1
            // 
            this.lB1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lB1.FormattingEnabled = true;
            this.lB1.ItemHeight = 19;
            this.lB1.Location = new System.Drawing.Point(0, 0);
            this.lB1.Name = "lB1";
            this.lB1.Size = new System.Drawing.Size(432, 156);
            this.lB1.TabIndex = 1;
            // 
            // lB2
            // 
            this.lB2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lB2.FormattingEnabled = true;
            this.lB2.ItemHeight = 19;
            this.lB2.Location = new System.Drawing.Point(0, 156);
            this.lB2.Name = "lB2";
            this.lB2.Size = new System.Drawing.Size(432, 4);
            this.lB2.TabIndex = 3;
            this.lB2.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bCh);
            this.panel1.Controls.Add(this.txtFile);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtMess);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTheme);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.bSend);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 160);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 200);
            this.panel1.TabIndex = 4;
            // 
            // bSend
            // 
            this.bSend.Image = ((System.Drawing.Image)(resources.GetObject("bSend.Image")));
            this.bSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bSend.Location = new System.Drawing.Point(155, 163);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(137, 31);
            this.bSend.TabIndex = 3;
            this.bSend.Text = "   Отправить";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Тема письма";
            // 
            // txtTheme
            // 
            this.txtTheme.Location = new System.Drawing.Point(116, 9);
            this.txtTheme.Name = "txtTheme";
            this.txtTheme.Size = new System.Drawing.Size(304, 26);
            this.txtTheme.TabIndex = 5;
            this.txtTheme.Text = "Приглашение";
            // 
            // txtMess
            // 
            this.txtMess.Location = new System.Drawing.Point(116, 41);
            this.txtMess.Multiline = true;
            this.txtMess.Name = "txtMess";
            this.txtMess.Size = new System.Drawing.Size(304, 84);
            this.txtMess.TabIndex = 7;
            this.txtMess.Text = "Приглашаем Вас принять участие в мероприятии";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Сообщение";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Прикрепить";
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(116, 131);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(268, 26);
            this.txtFile.TabIndex = 9;
            // 
            // bCh
            // 
            this.bCh.Location = new System.Drawing.Point(389, 134);
            this.bCh.Name = "bCh";
            this.bCh.Size = new System.Drawing.Size(31, 23);
            this.bCh.TabIndex = 10;
            this.bCh.Text = "...";
            this.bCh.UseVisualStyleBackColor = true;
            this.bCh.Click += new System.EventHandler(this.bCh_Click);
            // 
            // SendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 360);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lB2);
            this.Controls.Add(this.lB1);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SendForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отправка уведомлений";
            this.Load += new System.EventHandler(this.SendForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lB1;
        private System.Windows.Forms.ListBox lB2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bCh;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTheme;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bSend;
    }
}