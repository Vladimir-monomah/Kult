namespace Kult
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bLoginCancel = new System.Windows.Forms.Button();
            this.bLogin = new System.Windows.Forms.Button();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lData = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отделыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.специальностиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сотрудникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.детиСотрудниковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.видыМероприятийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.мероприятияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.организацииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.затратыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.документыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.работаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.учетМероприятийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поМероприятиюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сравнительныйАнализToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.документыToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.командировочноеУдостоверениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.служебеноеЗаданиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.приказОНаправленииВКомандировкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.копияБазыДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.восстановлениеБазыДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.руководствоПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tMain
            // 
            this.tMain.Controls.Add(this.tabPage1);
            this.tMain.Controls.Add(this.tabPage2);
            this.tMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tMain.Location = new System.Drawing.Point(0, 0);
            this.tMain.Name = "tMain";
            this.tMain.SelectedIndex = 0;
            this.tMain.Size = new System.Drawing.Size(465, 255);
            this.tMain.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(457, 223);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.SkyBlue;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.bLoginCancel);
            this.groupBox1.Controls.Add(this.bLogin);
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Cambria", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 217);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вход в систему";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Cambria", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(171, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Восстановление пароля";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // bLoginCancel
            // 
            this.bLoginCancel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bLoginCancel.Image = ((System.Drawing.Image)(resources.GetObject("bLoginCancel.Image")));
            this.bLoginCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bLoginCancel.Location = new System.Drawing.Point(253, 145);
            this.bLoginCancel.Name = "bLoginCancel";
            this.bLoginCancel.Size = new System.Drawing.Size(87, 28);
            this.bLoginCancel.TabIndex = 15;
            this.bLoginCancel.Text = "   Отмена";
            this.bLoginCancel.UseVisualStyleBackColor = true;
            this.bLoginCancel.Click += new System.EventHandler(this.bLoginCancel_Click);
            // 
            // bLogin
            // 
            this.bLogin.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bLogin.Image = ((System.Drawing.Image)(resources.GetObject("bLogin.Image")));
            this.bLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bLogin.Location = new System.Drawing.Point(162, 145);
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(87, 28);
            this.bLogin.TabIndex = 14;
            this.bLogin.Text = "Вход";
            this.bLogin.UseVisualStyleBackColor = true;
            this.bLogin.Click += new System.EventHandler(this.bLogin_Click);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(162, 79);
            this.txtPass.MaxLength = 10;
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(178, 26);
            this.txtPass.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(93, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Пароль";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.menuStrip1);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(457, 223);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(451, 164);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.Beige;
            this.panel1.Controls.Add(this.lData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(451, 29);
            this.panel1.TabIndex = 3;
            // 
            // lData
            // 
            this.lData.Dock = System.Windows.Forms.DockStyle.Right;
            this.lData.Font = new System.Drawing.Font("Cambria", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lData.Location = new System.Drawing.Point(123, 0);
            this.lData.Name = "lData";
            this.lData.Size = new System.Drawing.Size(328, 29);
            this.lData.TabIndex = 30;
            this.lData.Text = "12.12.2012";
            this.lData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.работаToolStripMenuItem,
            this.документыToolStripMenuItem1,
            this.настройкаToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(451, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отделыToolStripMenuItem,
            this.специальностиToolStripMenuItem,
            this.сотрудникиToolStripMenuItem,
            this.детиСотрудниковToolStripMenuItem,
            this.toolStripMenuItem1,
            this.видыМероприятийToolStripMenuItem,
            this.мероприятияToolStripMenuItem,
            this.toolStripMenuItem6,
            this.организацииToolStripMenuItem,
            this.toolStripMenuItem3,
            this.затратыToolStripMenuItem,
            this.toolStripMenuItem2,
            this.документыToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // отделыToolStripMenuItem
            // 
            this.отделыToolStripMenuItem.Name = "отделыToolStripMenuItem";
            this.отделыToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.отделыToolStripMenuItem.Text = "Отделы";
            this.отделыToolStripMenuItem.Click += new System.EventHandler(this.отделыToolStripMenuItem_Click);
            // 
            // специальностиToolStripMenuItem
            // 
            this.специальностиToolStripMenuItem.Name = "специальностиToolStripMenuItem";
            this.специальностиToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.специальностиToolStripMenuItem.Text = "Специальности";
            this.специальностиToolStripMenuItem.Click += new System.EventHandler(this.специальностиToolStripMenuItem_Click);
            // 
            // сотрудникиToolStripMenuItem
            // 
            this.сотрудникиToolStripMenuItem.Name = "сотрудникиToolStripMenuItem";
            this.сотрудникиToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.сотрудникиToolStripMenuItem.Text = "Сотрудники";
            this.сотрудникиToolStripMenuItem.Click += new System.EventHandler(this.сотрудникиToolStripMenuItem_Click);
            // 
            // детиСотрудниковToolStripMenuItem
            // 
            this.детиСотрудниковToolStripMenuItem.Name = "детиСотрудниковToolStripMenuItem";
            this.детиСотрудниковToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.детиСотрудниковToolStripMenuItem.Text = "Дети сотрудников";
            this.детиСотрудниковToolStripMenuItem.Click += new System.EventHandler(this.детиСотрудниковToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(193, 6);
            // 
            // видыМероприятийToolStripMenuItem
            // 
            this.видыМероприятийToolStripMenuItem.Name = "видыМероприятийToolStripMenuItem";
            this.видыМероприятийToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.видыМероприятийToolStripMenuItem.Text = "Виды мероприятий";
            this.видыМероприятийToolStripMenuItem.Click += new System.EventHandler(this.видыМероприятийToolStripMenuItem_Click);
            // 
            // мероприятияToolStripMenuItem
            // 
            this.мероприятияToolStripMenuItem.Name = "мероприятияToolStripMenuItem";
            this.мероприятияToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.мероприятияToolStripMenuItem.Text = "Мероприятия";
            this.мероприятияToolStripMenuItem.Click += new System.EventHandler(this.мероприятияToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(193, 6);
            // 
            // организацииToolStripMenuItem
            // 
            this.организацииToolStripMenuItem.Name = "организацииToolStripMenuItem";
            this.организацииToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.организацииToolStripMenuItem.Text = "Организации";
            this.организацииToolStripMenuItem.Click += new System.EventHandler(this.организацииToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(193, 6);
            // 
            // затратыToolStripMenuItem
            // 
            this.затратыToolStripMenuItem.Name = "затратыToolStripMenuItem";
            this.затратыToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.затратыToolStripMenuItem.Text = "Затраты";
            this.затратыToolStripMenuItem.Click += new System.EventHandler(this.затратыToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(193, 6);
            // 
            // документыToolStripMenuItem
            // 
            this.документыToolStripMenuItem.Name = "документыToolStripMenuItem";
            this.документыToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.документыToolStripMenuItem.Text = "Шаблоны документов";
            this.документыToolStripMenuItem.Click += new System.EventHandler(this.документыToolStripMenuItem_Click);
            // 
            // работаToolStripMenuItem
            // 
            this.работаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.учетМероприятийToolStripMenuItem,
            this.toolStripMenuItem4,
            this.отчетыToolStripMenuItem});
            this.работаToolStripMenuItem.Name = "работаToolStripMenuItem";
            this.работаToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.работаToolStripMenuItem.Text = "Отчеты";
            // 
            // учетМероприятийToolStripMenuItem
            // 
            this.учетМероприятийToolStripMenuItem.Name = "учетМероприятийToolStripMenuItem";
            this.учетМероприятийToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.учетМероприятийToolStripMenuItem.Text = "Учет мероприятий";
            this.учетМероприятийToolStripMenuItem.Click += new System.EventHandler(this.учетМероприятийToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(195, 6);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поМероприятиюToolStripMenuItem,
            this.сравнительныйАнализToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.отчетыToolStripMenuItem.Text = "Формирование отчета";
            // 
            // поМероприятиюToolStripMenuItem
            // 
            this.поМероприятиюToolStripMenuItem.Name = "поМероприятиюToolStripMenuItem";
            this.поМероприятиюToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.поМероприятиюToolStripMenuItem.Text = "По мероприятию";
            this.поМероприятиюToolStripMenuItem.Click += new System.EventHandler(this.поМероприятиюToolStripMenuItem_Click);
            // 
            // сравнительныйАнализToolStripMenuItem
            // 
            this.сравнительныйАнализToolStripMenuItem.Name = "сравнительныйАнализToolStripMenuItem";
            this.сравнительныйАнализToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.сравнительныйАнализToolStripMenuItem.Text = "Сравнительный анализ";
            this.сравнительныйАнализToolStripMenuItem.Click += new System.EventHandler(this.сравнительныйАнализToolStripMenuItem_Click);
            // 
            // документыToolStripMenuItem1
            // 
            this.документыToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.командировочноеУдостоверениеToolStripMenuItem,
            this.служебеноеЗаданиеToolStripMenuItem,
            this.приказОНаправленииВКомандировкуToolStripMenuItem});
            this.документыToolStripMenuItem1.Name = "документыToolStripMenuItem1";
            this.документыToolStripMenuItem1.Size = new System.Drawing.Size(82, 20);
            this.документыToolStripMenuItem1.Text = "Документы";
            // 
            // командировочноеУдостоверениеToolStripMenuItem
            // 
            this.командировочноеУдостоверениеToolStripMenuItem.Name = "командировочноеУдостоверениеToolStripMenuItem";
            this.командировочноеУдостоверениеToolStripMenuItem.Size = new System.Drawing.Size(292, 22);
            this.командировочноеУдостоверениеToolStripMenuItem.Text = "Командировочное удостоверение";
            this.командировочноеУдостоверениеToolStripMenuItem.Click += new System.EventHandler(this.командировочноеУдостоверениеToolStripMenuItem_Click);
            // 
            // служебеноеЗаданиеToolStripMenuItem
            // 
            this.служебеноеЗаданиеToolStripMenuItem.Name = "служебеноеЗаданиеToolStripMenuItem";
            this.служебеноеЗаданиеToolStripMenuItem.Size = new System.Drawing.Size(292, 22);
            this.служебеноеЗаданиеToolStripMenuItem.Text = "Служебеное задание";
            this.служебеноеЗаданиеToolStripMenuItem.Click += new System.EventHandler(this.служебеноеЗаданиеToolStripMenuItem_Click);
            // 
            // приказОНаправленииВКомандировкуToolStripMenuItem
            // 
            this.приказОНаправленииВКомандировкуToolStripMenuItem.Name = "приказОНаправленииВКомандировкуToolStripMenuItem";
            this.приказОНаправленииВКомандировкуToolStripMenuItem.Size = new System.Drawing.Size(292, 22);
            this.приказОНаправленииВКомандировкуToolStripMenuItem.Text = "Приказ о направлении в командировку";
            this.приказОНаправленииВКомандировкуToolStripMenuItem.Click += new System.EventHandler(this.приказОНаправленииВКомандировкуToolStripMenuItem_Click);
            // 
            // настройкаToolStripMenuItem
            // 
            this.настройкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьToolStripMenuItem,
            this.toolStripMenuItem5,
            this.копияБазыДанныхToolStripMenuItem,
            this.toolStripMenuItem7,
            this.восстановлениеБазыДанныхToolStripMenuItem});
            this.настройкаToolStripMenuItem.Name = "настройкаToolStripMenuItem";
            this.настройкаToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.настройкаToolStripMenuItem.Text = "Настройка";
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.изменитьToolStripMenuItem.Text = "Изменить параметры";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(234, 6);
            // 
            // копияБазыДанныхToolStripMenuItem
            // 
            this.копияБазыДанныхToolStripMenuItem.Name = "копияБазыДанныхToolStripMenuItem";
            this.копияБазыДанныхToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.копияБазыДанныхToolStripMenuItem.Text = "Копия базы данных";
            this.копияБазыДанныхToolStripMenuItem.Click += new System.EventHandler(this.копияБазыДанныхToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(234, 6);
            // 
            // восстановлениеБазыДанныхToolStripMenuItem
            // 
            this.восстановлениеБазыДанныхToolStripMenuItem.Name = "восстановлениеБазыДанныхToolStripMenuItem";
            this.восстановлениеБазыДанныхToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.восстановлениеБазыДанныхToolStripMenuItem.Text = "Восстановление базы данных";
            this.восстановлениеБазыДанныхToolStripMenuItem.Click += new System.EventHandler(this.восстановлениеБазыДанныхToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справкаToolStripMenuItem,
            this.руководствоПользователяToolStripMenuItem});
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.оПрограммеToolStripMenuItem.Text = "Справка";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.справкаToolStripMenuItem.Text = "О программе";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
            // 
            // руководствоПользователяToolStripMenuItem
            // 
            this.руководствоПользователяToolStripMenuItem.Name = "руководствоПользователяToolStripMenuItem";
            this.руководствоПользователяToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.руководствоПользователяToolStripMenuItem.Text = "Руководство пользователя";
            this.руководствоПользователяToolStripMenuItem.Click += new System.EventHandler(this.руководствоПользователяToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 255);
            this.Controls.Add(this.tMain);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "АИС по работе с молодёжью ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem настройкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отделыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem специальностиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сотрудникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem детиСотрудниковToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem организацииToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem затратыToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem документыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem работаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem учетМероприятийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.Button bLoginCancel;
        private System.Windows.Forms.Button bLogin;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem копияБазыДанныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видыМероприятийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem мероприятияToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem поМероприятиюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сравнительныйАнализToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem документыToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem руководствоПользователяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem командировочноеУдостоверениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem служебеноеЗаданиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem приказОНаправленииВКомандировкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem восстановлениеБазыДанныхToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lData;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
    }
}

