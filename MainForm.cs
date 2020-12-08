using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;

namespace Kult
{
    public partial class MainForm : Form
    {
        private string sDB = "DB_Kult.db";
        private SQLiteConnection sqlConnection;
        /*пароль для шифровки/дешифровки*/
        private string pass = "qwerty";

        public MainForm()
        {
            InitializeComponent();
        }

        /*открытие формы*/
        private void MainForm_Load(object sender, EventArgs e)
        {
            /*скрываем шапку у TabControl*/
            tMain.DrawMode = TabDrawMode.OwnerDrawFixed;
            tMain.Appearance = TabAppearance.Buttons;
            tMain.ItemSize = new System.Drawing.Size(0, 1);
            tMain.SizeMode = TabSizeMode.Fixed;
            tMain.TabStop = false;
            tMain.SelectedIndex = 0;
            /*подключаемся к БД*/
            string connectionTemp = "Data Source=" + sDB + ";";
            sqlConnection = new SQLiteConnection(connectionTemp);
            if (File.Exists(sDB))
            {
                try
                {
                    sqlConnection.Open();
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                    {
                        sqlConnection.Close();
                        MessageBox.Show("Подключение к БД установлено", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        tMain.SelectedIndex = 0;
                    }
                }
            }
            else
                MessageBox.Show("Файл базы данных " + sDB + " не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /*Получаем пароль из файла*/
        private string GetPass()
        {
            /*Считываем пароль*/
            StreamReader SW = new StreamReader(Application.StartupPath + "\\pass.txt", System.Text.Encoding.Default);
            string s = SW.ReadLine();
            SW.Close();
            string s1 = Shifr.DeShifrovka(s, pass);
            return s1;
        }

        /*Отмена при вводе пароля*/
        private void bLoginCancel_Click(object sender, EventArgs e)
        {
            txtPass.Clear();
        }

        /*Вход в систему*/
        private void bLogin_Click(object sender, EventArgs e)
        {
            if (txtPass.Text.Equals(GetPass()))
            {
                tMain.SelectedIndex = 1;
                lData.Text = "Сегодня: " + DateTime.Today.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                timer1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Неверный пароль", "Вход не выполнен!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPass.Clear();
            }
        }

        /*Подтверждение выхода из системы*/
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Выйти из программы?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        /*Настройка-Копия БД*/
        private void копияБазыДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Создать копию базы данных?", "Резервное копирование", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string dd = DateTime.Today.ToShortDateString();
                    dd = dd.Replace(".", "_");
                    CopyFile(Application.StartupPath + "\\DB_Kult.db", Application.StartupPath + "\\DB_Kult_" + dd + ".db");
                    MessageBox.Show("Файл базы данных сохранен как " + Application.StartupPath + "\\DB_Kult_" + dd + ".db",
                        "Резервное копирование!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("При выполнении копирования произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /*копирование файла*/
        private void CopyFile(string sourcefn, string destinfn)
        {
            FileInfo fn = new FileInfo(sourcefn);
            fn.CopyTo(destinfn, true);
        }

        /*Настройка-Изменить параметры*/
        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptForm frm = new OptForm();
            frm.sqlConnection = sqlConnection;
            frm.pass = pass;
            frm.ShowDialog();
        }

        /*Справочники-Отделы*/
        private void отделыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DepForm frm = new DepForm();
            frm.b = false;
            frm.sqlConnection = sqlConnection;
            frm.ShowDialog();
        }

        /*Справочники-Специальности*/
        private void специальностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpecForm frm = new SpecForm();
            frm.sqlConnection = sqlConnection;
            frm.b = false;
            frm.ShowDialog();
        }

        /*Справочники-Организации*/
        private void организацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrgForm frm = new OrgForm();
            frm.sqlConnection = sqlConnection;
            frm.b = false;
            frm.ShowDialog();
        }

        /*Справочники-Затраты*/
        private void затратыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZatrForm frm = new ZatrForm();
            frm.sqlConnection = sqlConnection;
            frm.b = false;
            frm.ShowDialog();
        }

        /*Справочники-Шаблоны документов*/
        private void документыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocForm frm = new DocForm();
            frm.sqlConnection = sqlConnection;
            frm.ShowDialog();
        }

        /*Справочники-Сотрудники*/
        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SotrForm frm = new SotrForm();
            frm.b = false;
            frm.sqlConnection = sqlConnection;
            frm.b = false;
            frm.ShowDialog();
        }

        /*Справочники-Дети*/
        private void детиСотрудниковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm frm = new ChildForm();
            frm.sqlConnection = sqlConnection;
            frm.ShowDialog();
        }

        /*Работа-Учет мероприятий*/
        private void учетМероприятийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProvForm frm = new ProvForm();
            frm.sqlConnection = sqlConnection;
            frm.ShowDialog();
        }

        /*Справочники-Виды мероприятий*/
        private void видыМероприятийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VidForm frm = new VidForm();
            frm.sqlConnection = sqlConnection;
            frm.b = false;
            frm.ShowDialog();
        }

        /*Справочники-Мероприятия*/
        private void мероприятияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MerForm frm = new MerForm();
            frm.sqlConnection = sqlConnection;
            frm.b = false;
            frm.ShowDialog();
        }

        /*Справка-О программе*/
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm f = new AboutForm();
            f.ShowDialog();
        }

        /*Отчеты-По мероприятию*/
        private void поМероприятиюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RepForm frm = new RepForm();
            frm.sqlConnection = sqlConnection;
            frm.ShowDialog();
        }

        /*Отчеты-Сравнительный анализ*/
        private void сравнительныйАнализToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnalizForm frm = new AnalizForm();
            frm.sqlConnection = sqlConnection;
            frm.ShowDialog();
        }

        private void командировочноеУдостоверениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeDocForm frm = new MakeDocForm();
            frm.sqlConnection = sqlConnection;
            frm.num = 0;
            frm.ShowDialog();
        }

        private void служебеноеЗаданиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeDocForm frm = new MakeDocForm();
            frm.sqlConnection = sqlConnection;
            frm.num = 1;
            frm.ShowDialog();
        }

        private void приказОНаправленииВКомандировкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeDocForm frm = new MakeDocForm();
            frm.sqlConnection = sqlConnection;
            frm.num = 2;
            frm.ShowDialog();
        }

        private void восстановлениеБазыДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Filter = "Файл базы данных(*.db)|*.db";
            OPF.InitialDirectory = Application.StartupPath;
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string p1, p2;
                    p1 = String.Format(@System.IO.Path.GetFileName(OPF.FileName.ToString()));
                    p2= String.Format(@Application.StartupPath+ "\\DB_Kult.db");
                    File.Copy(p1,p2, true);
                    MessageBox.Show("Файл базы данных восстановлен","Восстановление БД", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("При выполнении восстановления произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lData.Text = "Сегодня: " + DateTime.Today.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
        }

        private void руководствоПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(String.Format(@Application.StartupPath + "\\Readme.chm"));
        }

        /*Восстановление пароля*/
        private void label2_Click(object sender, EventArgs e)
        {
            VForm frm = new VForm();
            frm.sqlConnection = sqlConnection;
            frm.pass = pass;
            frm.ShowDialog();
        }
    }
}
