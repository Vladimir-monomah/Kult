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

namespace Kult
{
    public partial class MakeDocForm : Form
    {
        public SQLiteConnection sqlConnection;
        public int num;

        public MakeDocForm()
        {
            InitializeComponent();
        }

        /*определяем специальность сотрудника*/
        private string GetSpec(string id)
        {
            string s = "";
            sqlConnection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT Спец FROM Специальности,Сотрудники where (Код_сотр=" + id +
                ") and (Сотрудники.Код_спец=Специальности.Код_спец)", sqlConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                s = reader.GetString(0);
            }
            reader.Close();
            sqlConnection.Close();
            return s;
        }

        /*формирование командировочного удостоверения*/
        private void bMake1_Click(object sender, EventArgs e)
        {
            if ((s1txt2.Text.Equals("")) ||(s1txt3.Text.Equals("")) ||(s1txt4.Text.Equals("")) ||(s1txt5.Text.Equals("")) || 
                (s1txt6.Text.Equals("")) || (s1txt7.Text.Equals("")) || (s1txt8.Text.Equals("")))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (s1dt2.Value > s1dt3.Value)
            {
                MessageBox.Show("Неверно задан период", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            
            string namefile = Application.StartupPath + "\\Шаблоны\\" + s1txt8.Text;
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();
            doc = word.Documents.Add(namefile);
            doc.Activate();
            foreach (Microsoft.Office.Interop.Word.FormField field in doc.FormFields)
            {
                switch (field.Name)
                {
                    case "Дата":
                        field.Range.Text = s1dt1.Value.ToShortDateString();
                        break;
                    case "ФИО":
                        field.Range.Text = s1txt2.Text;
                        break;
                    case "ТабНомер":
                        field.Range.Text = s1txt2.Tag.ToString();
                        break;
                    case "Спец":
                        field.Range.Text = GetSpec(s1txt2.Tag.ToString());
                        break;
                    case "Место":
                        field.Range.Text = s1txt3.Text;
                        break;
                    case "Цель":
                        field.Range.Text = s1txt4.Text;
                        break;
                    case "серия":
                        field.Range.Text = s1txt5.Text;
                        break;
                    case "ПаспНомер":
                        field.Range.Text = s1txt6.Text;
                        break;
                    case "кем":
                        field.Range.Text = s1txt7.Text;
                        break;
                    case "когда":
                        field.Range.Text = s1dt4.Value.ToShortDateString();
                        break;
                    case "Кол":
                        field.Range.Text = (s1dt3.Value - s1dt2.Value).Days.ToString();
                        break;
                    case "д1":
                        field.Range.Text = s1dt2.Value.ToShortDateString().Substring(0, 2);
                        break;
                    case "м1":
                        field.Range.Text = GetMonth(int.Parse(s1dt2.Value.ToShortDateString().Substring(3, 2)));
                        break;
                    case "г1":
                        field.Range.Text = s1dt2.Value.ToShortDateString().Substring(8, 2);
                        break;
                    case "д2":
                        field.Range.Text = s1dt3.Value.ToShortDateString().Substring(0, 2);
                        break;
                    case "м2":
                        field.Range.Text = GetMonth(int.Parse(s1dt3.Value.ToShortDateString().Substring(3, 2)));
                        break;
                    case "г2":
                        field.Range.Text = s1dt3.Value.ToShortDateString().Substring(8, 2);
                        break;
                    default: break;
                }
            }
            string s = DateTime.Now.ToString();
            s = s.Replace(".", "_");
            s = s.Replace(":", "-");
            doc.SaveAs2(Application.StartupPath + "\\Out\\D_" + s + ".doc");
            doc.Close();
            word.Quit();
            MessageBox.Show("Документ сохранен в директории " + Application.StartupPath + "\\Out\\D_" + s + ".doc", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /*месяц словами*/
        private string GetMonth(int i)
        {
            string s = "";
            switch (i)
            {
                case 1:s = "января";break;
                case 2: s = "февраля"; break;
                case 3: s = "марта"; break;
                case 4: s = "апреля"; break;
                case 5: s = "мая"; break;
                case 6: s = "июня"; break;
                case 7: s = "июля"; break;
                case 8: s = "августа"; break;
                case 9: s = "сентября"; break;
                case 10: s = "октября"; break;
                case 11: s = "ноября"; break;
                case 12: s = "декабря"; break;
                default: break;
            }
            return s;
        }

        /*открытие формы*/
        private void MakeDocForm_Load(object sender, EventArgs e)
        {
            /*скрываем шапку у TabControl*/
            tC1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tC1.Appearance = TabAppearance.Buttons;
            tC1.ItemSize = new System.Drawing.Size(0, 1);
            tC1.SizeMode = TabSizeMode.Fixed;
            tC1.TabStop = false;
            tC1.SelectedIndex = num;
        }

        /*выбор сотрудника*/
        private void bCh_Sotr_Click(object sender, EventArgs e)
        {
            SotrForm f = new SotrForm();
            f.sqlConnection = sqlConnection;
            f.b = true;
            f.ShowDialog();
            s1txt2.Tag = f.id;
            s1txt2.Text = f.dataS2;
        }

        /*выбор шаблона*/
        private void bCh_Sh_Click(object sender, EventArgs e)
        {
            DocForm f = new DocForm();
            f.sqlConnection = sqlConnection;
            f.b = true;
            f.ShowDialog();
            s1txt8.Tag = f.id;
            s1txt8.Text = f.dataS;
        }

        /*формирование служебного задания*/
        private void bMake2_Click(object sender, EventArgs e)
        {
            if ((s2txt2.Text.Equals("")) || (s2txt0.Text.Equals("")) || (s2txt3.Text.Equals("")) || (s2txt4.Text.Equals("")) || (s2txt5.Text.Equals("")))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (s2dt2.Value > s2dt3.Value)
            {
                MessageBox.Show("Неверно задан период", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string namefile = Application.StartupPath + "\\Шаблоны\\" + s2txt5.Text;
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();
            doc = word.Documents.Add(namefile);
            doc.Activate();
            foreach (Microsoft.Office.Interop.Word.FormField field in doc.FormFields)
            {
                switch (field.Name)
                {
                    case "Дата":
                        field.Range.Text = s2dt1.Value.ToShortDateString();
                        break;
                    case "ФИО":
                        field.Range.Text = s2txt2.Text;
                        break;
                    case "ТабНомер":
                        field.Range.Text = s2txt2.Tag.ToString();
                        break;
                    case "Структура":
                        field.Range.Text = s2txt0.Text;
                        break;
                    case "Спец":
                        field.Range.Text = GetSpec(s2txt2.Tag.ToString());
                        break;
                    case "Место":
                        field.Range.Text = s2txt3.Text;
                        break;
                    case "Цель":
                        field.Range.Text = s2txt4.Text;
                        break;                    
                    case "Кол":
                        field.Range.Text = (s2dt3.Value - s2dt2.Value).Days.ToString();
                        break;
                    case "Дата1":
                        field.Range.Text = s2dt2.Value.ToShortDateString();
                        break;
                    case "Дата2":
                        field.Range.Text = s2dt3.Value.ToShortDateString();
                        break;                    
                    default: break;
                }
            }
            string s = DateTime.Now.ToString();
            s = s.Replace(".", "_");
            s = s.Replace(":", "-");
            doc.SaveAs2(Application.StartupPath + "\\Out\\D_" + s + ".doc");
            doc.Close();
            word.Quit();
            MessageBox.Show("Документ сохранен в директории " + Application.StartupPath + "\\Out\\D_" + s + ".doc", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /*выбор сотрудника*/
        private void bCh_Sotr2_Click(object sender, EventArgs e)
        {
            SotrForm f = new SotrForm();
            f.sqlConnection = sqlConnection;
            f.b = true;
            f.ShowDialog();
            s2txt2.Tag = f.id;
            s2txt2.Text = f.dataS2;
        }

        /*выбор шаблона*/
        private void bCh_Sh2_Click(object sender, EventArgs e)
        {
            DocForm f = new DocForm();
            f.sqlConnection = sqlConnection;
            f.b = true;
            f.ShowDialog();
            s2txt5.Tag = f.id;
            s2txt5.Text = f.dataS;
        }

        /*очистка полей командировочного удостоверения*/
        private void bClear1_Click(object sender, EventArgs e)
        {
            s1dt1.Value = DateTime.Today;
            s1dt2.Value = DateTime.Today;
            s1dt3.Value = DateTime.Today;
            s1txt2.Clear();
            s1txt3.Clear();
            s1txt4.Clear();
            s1txt5.Clear();
            s1txt6.Clear();
            s1txt7.Clear();
            s1txt8.Clear();
        }

        /*очистка полей служебного задания*/
        private void bClear2_Click(object sender, EventArgs e)
        {
            s2dt1.Value = DateTime.Today;
            s2dt2.Value = DateTime.Today;
            s2dt3.Value = DateTime.Today;
            s2txt2.Clear();
            s2txt3.Clear();
            s2txt4.Clear();
            s2txt5.Clear();
            s2txt0.Clear();
        }

        /*выбор сотрудника*/
        private void bCh_Sotr3_Click(object sender, EventArgs e)
        {
            SotrForm f = new SotrForm();
            f.sqlConnection = sqlConnection;
            f.b = true;
            f.ShowDialog();
            s3txt2.Tag = f.id;
            s3txt2.Text = f.dataS2;
        }

        /*выбор шаблона*/
        private void bCh_Sh3_Click(object sender, EventArgs e)
        {
            DocForm f = new DocForm();
            f.sqlConnection = sqlConnection;
            f.b = true;
            f.ShowDialog();
            s3txt8.Tag = f.id;
            s3txt8.Text = f.dataS;
        }

        /*формирование приказа*/
        private void bMake3_Click(object sender, EventArgs e)
        {
            if ((s3txt2.Text.Equals("")) || (s3txt3.Text.Equals("")) || (s3txt4.Text.Equals("")) || (s3txt5.Text.Equals("")) ||
            (s3txt6.Text.Equals("")) || (s3txt7.Text.Equals("")) || (s3txt8.Text.Equals("")))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (s3dt2.Value > s3dt3.Value)
            {
                MessageBox.Show("Неверно задан период", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string namefile = Application.StartupPath + "\\Шаблоны\\" + s3txt8.Text;
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();
            doc = word.Documents.Add(namefile);
            doc.Activate();
            foreach (Microsoft.Office.Interop.Word.FormField field in doc.FormFields)
            {
                switch (field.Name)
                {
                    case "Дата":
                        field.Range.Text = s3dt1.Value.ToShortDateString();
                        break;
                    case "ФИО":
                        field.Range.Text = s3txt2.Text;
                        break;
                    case "ТабНомер":
                        field.Range.Text = s3txt2.Tag.ToString();
                        break;
                    case "Структура":
                        field.Range.Text = s3txt3.Text;
                        break;
                    case "Спец":
                        field.Range.Text = GetSpec(s3txt2.Tag.ToString());
                        break;
                    case "Место":
                        field.Range.Text = s3txt4.Text;
                        break;
                    case "Цель":
                        field.Range.Text = s3txt5.Text;
                        break;
                    case "Кол":
                        field.Range.Text = (s3dt3.Value - s3dt2.Value).Days.ToString();
                        break;
                    case "д1":
                        field.Range.Text = s3dt2.Value.ToShortDateString().Substring(0, 2);
                        break;
                    case "м1":
                        field.Range.Text = GetMonth(int.Parse(s3dt2.Value.ToShortDateString().Substring(3, 2)));
                        break;
                    case "г1":
                        field.Range.Text = s3dt2.Value.ToShortDateString().Substring(8, 2);
                        break;
                    case "д2":
                        field.Range.Text = s3dt3.Value.ToShortDateString().Substring(0, 2);
                        break;
                    case "м2":
                        field.Range.Text = GetMonth(int.Parse(s3dt3.Value.ToShortDateString().Substring(3, 2)));
                        break;
                    case "г2":
                        field.Range.Text = s3dt3.Value.ToShortDateString().Substring(8, 2);
                        break;
                    case "Расходы":
                        field.Range.Text = s3txt6.Text;
                        break;
                    case "Основание":
                        field.Range.Text = s3txt7.Text;
                        break;
                    default: break;
                }
            }
            string s = DateTime.Now.ToString();
            s = s.Replace(".", "_");
            s = s.Replace(":", "-");
            doc.SaveAs2(Application.StartupPath + "\\Out\\D_" + s + ".doc");
            doc.Close();
            word.Quit();
            MessageBox.Show("Документ сохранен в директории " + Application.StartupPath + "\\Out\\D_" + s + ".doc", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        /*очистка полей приказа*/
        private void bClear3_Click(object sender, EventArgs e)
        {
            s3dt1.Value = DateTime.Today;
            s3dt2.Value = DateTime.Today;
            s3dt3.Value = DateTime.Today;
            s3txt2.Clear();
            s3txt3.Clear();
            s3txt4.Clear();
            s3txt5.Clear();
            s3txt6.Clear();
            s3txt7.Clear();
            s3txt8.Clear();
        }

        private void s1txt5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
                e.Handled = true;
        }

        private void s1txt6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
                e.Handled = true;
        }
    }
}
