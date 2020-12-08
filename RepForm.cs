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
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace Kult
{
    public partial class RepForm : Form
    {
        public SQLiteConnection sqlConnection;

        public RepForm()
        {
            InitializeComponent();
        }

        /*открытие формы*/
        private void RepForm_Load(object sender, EventArgs e)
        {
            rB1.Checked = true;
            numYear.Value = DateTime.Now.Year;
            OpenTable();
        }

        /*выполняем запрос на выборку, отображаем рузультаты в гриде*/
        private void OpenTable()
        {
            string str1 = "", str2="";
            if (rB1.Checked) str1 = " and (Cast(strftime('%m', date(Дата)) as int)>=1) and (Cast(strftime('%m', date(Дата)) as int)<=3)";
            if (rB2.Checked) str1 = " and (Cast(strftime('%m', date(Дата)) as int)>=4) and (Cast(strftime('%m', date(Дата)) as int)<=6)";
            if (rB3.Checked) str1 = " and (Cast(strftime('%m', date(Дата)) as int)>=7) and (Cast(strftime('%m', date(Дата)) as int)<=9)";
            if (rB4.Checked) str1 = " and (Cast(strftime('%m', date(Дата)) as int)>=10) and (Cast(strftime('%m', date(Дата)) as int)<=12)";
            str2 = " and (Cast(strftime('%Y',date(Дата)) as int)=" + numYear.Value.ToString()+")";
            string sqlQuery = "SELECT '',Проведение.Код_пров,Проведение.Код_мер,Проведение.Код_орг,Мероприятия.Наим," +
                "Организации.Наим,Дата,Результат " +
                "from Проведение,Мероприятия,Организации " +
                "where (Проведение.Код_мер=Мероприятия.Код_мер) and (Проведение.Код_орг=Организации.Код_орг) and "+
                "(Результат<>'')" + str1 + str2 + " ORDER BY Дата DESC;";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, sqlConnection);
            System.Data.DataTable myD = new System.Data.DataTable();
            adapter.Fill(myD);
            dGV1.DataSource = myD;
            dGV1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            /*устанавливаем ширину колонок и название заголовков грида*/
            dGV1.Columns[0].Width = 80;
            dGV1.Columns[1].Visible = false;
            dGV1.Columns[2].Visible = false;
            dGV1.Columns[3].Visible = false;
            dGV1.Columns[4].Width = 260;
            dGV1.Columns[5].Width = 220;
            dGV1.Columns[6].Width = 100;
            dGV1.Columns[7].Visible = false;
            dGV1.Columns[0].HeaderText = "№ п/п";
            dGV1.Columns[4].HeaderText = "Мероприятие";
            dGV1.Columns[5].HeaderText = "Организация";
            dGV1.Columns[6].HeaderText = "Дата";
            for (int i = 0; i < dGV1.Rows.Count; i++)
                dGV1.Rows[i].Cells[0].Value = (i + 1).ToString();
        }

        /*2 квартал*/
        private void rB2_CheckedChanged(object sender, EventArgs e)
        {
            OpenTable();
        }

        /*3 квартал*/
        private void rB3_CheckedChanged(object sender, EventArgs e)
        {
            OpenTable();
        }

        /*4 квартал*/
        private void rB4_CheckedChanged(object sender, EventArgs e)
        {
            OpenTable();
        }

        /*1 квартал*/
        private void rB1_CheckedChanged(object sender, EventArgs e)
        {
            OpenTable();
        }

        /*меняем год*/
        private void numYear_ValueChanged(object sender, EventArgs e)
        {
            OpenTable();
        }

        /*выгрузить*/
        private void bOut_Click(object sender, EventArgs e)
        {
            if (dGV1.CurrentRow != null)
                MakeExcel();
        }

        /*выгрузка данных в Эксель*/
        private void MakeExcel()
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Range excelcells;
            Excel.Worksheet xlSheet;
            string s1;
            int i = dGV1.CurrentRow.Index;
            int id = int.Parse(dGV1.Rows[i].Cells[1].Value.ToString());
            //добавляем книгу
            Excel.Workbook xlDoc = xlApp.Workbooks.Add();
            try
            {
                //делаем временно неактивным документ
                xlApp.Interactive = false;
                xlApp.EnableEvents = false;
                //выбираем лист на котором будем работать (Лист 1)
                xlSheet = xlApp.Sheets[1];
                xlSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                //Название листа
                xlSheet.Name = "Данные";
                xlSheet.Cells[1, 1].ColumnWidth = 7;
                xlSheet.Cells[1, 2].ColumnWidth = 30;
                xlSheet.Cells[1, 3].ColumnWidth = 15;
                xlSheet.Cells[1, 4].ColumnWidth = 21;
                xlSheet.Cells[1, 5].ColumnWidth = 53;

                excelcells = xlSheet.get_Range("A2", "E2");
                excelcells.Merge(Type.Missing);
                excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                excelcells.EntireRow.Font.Size = 14;
                excelcells.EntireRow.Font.Bold = true;
                xlSheet.Cells[2, 1] = "Мероприятие";

                //название мероприятия и дата
                excelcells = xlSheet.get_Range("A3", "E3");
                excelcells.Merge(Type.Missing);
                excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                excelcells.Font.Size = 14;
                excelcells.Font.Bold = true;
                s1 = dGV1.Rows[i].Cells[4].Value.ToString() + " от " + dGV1.Rows[i].Cells[6].Value.ToString().Substring(0,10);
                xlSheet.Cells[3, 1] = s1;

                //место проведения
                excelcells = xlSheet.get_Range("A5", "B5");
                excelcells.Merge(Type.Missing);
                excelcells.HorizontalAlignment = Excel.Constants.xlLeft;
                excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                excelcells.Font.Size = 12;
                excelcells.Font.Bold = false;
                excelcells.Font.Underline = true;
                xlSheet.Cells[5, 1] = "Место проведения: ";
                excelcells = xlSheet.get_Range("C5", "C5");
                excelcells.Font.Underline = false;
                xlSheet.Cells[5, 3] = dGV1.Rows[i].Cells[5].Value.ToString();

                //результаты
                excelcells = xlSheet.get_Range("A7", "B7");
                excelcells.Merge(Type.Missing);
                excelcells.HorizontalAlignment = Excel.Constants.xlLeft;
                excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                excelcells.Font.Size = 12;
                excelcells.Font.Bold = false;
                excelcells.Font.Underline = true;
                xlSheet.Cells[7, 1] = "Результаты: ";
                excelcells = xlSheet.get_Range("C7", "C7");
                excelcells.Font.Underline = false;
                xlSheet.Cells[7, 3] = dGV1.Rows[i].Cells[7].Value.ToString();

                //участники
                excelcells = xlSheet.get_Range("A9", "B9");
                excelcells.Merge(Type.Missing);
                excelcells.HorizontalAlignment = Excel.Constants.xlLeft;
                excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                excelcells.Font.Size = 12;
                excelcells.Font.Bold = false;
                excelcells.Font.Underline = true;
                xlSheet.Cells[9, 1] = "Участники мероприятия: ";

                int rowN = 10;
                /*делаем шапку таблицы*/
                xlSheet.Cells[rowN, 1] = "№ п/п";
                xlSheet.Cells[rowN, 2] = "ФИО";
                xlSheet.Cells[rowN, 3] = "Отдел";
                xlSheet.Cells[rowN, 4] = "Специальность";
                xlSheet.Cells[rowN, 5] = "Достижения";
                //отображаем данные участников
                string sQuery = String.Format(@"SELECT " +
                @"(Сотрудники.Фамилия || ' ' || substr(Сотрудники.Имя,1,1) || '.' || substr(Сотрудники.Отчество,1,1)  || '.') as ФИО," +
                @"ОтделСокр,Спец,(case when exists(select * from Достижения where (Достижения.Код_сотр=Сотрудники.Код_сотр) and " +
                @"(Достижения.Код_пров={0})) then (select Описание from Достижения where (Достижения.Код_сотр=Сотрудники.Код_сотр) and " +
                @"(Достижения.Код_пров={0})) else '' end) as Dost from Сотрудники,Отделы,Специальности,ПроведениеСотрудники " +
                @"where (Сотрудники.Код_отдел=Отделы.Код_отдел) and (Сотрудники.Код_спец=Специальности.Код_спец) and " +
                @"(ПроведениеСотрудники.Код_пров={0}) and (ПроведениеСотрудники.Код_сотр=Сотрудники.Код_сотр) ORDER BY Фамилия, Имя, Отчество;", id);
                sqlConnection.Open();
                SQLiteCommand command = new SQLiteCommand(sQuery, sqlConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                int k = 1;
                while (reader.Read())
                {
                    xlSheet.Cells[rowN + k, 1] = k.ToString();
                    xlSheet.Cells[rowN + k, 2] = reader.GetString(0);
                    xlSheet.Cells[rowN + k, 3] = reader.GetString(1);
                    xlSheet.Cells[rowN + k, 4] = reader.GetString(2);
                    xlSheet.Cells[rowN + k, 5] = reader.GetString(3);
                    k++;
                }
                reader.Close();
                sqlConnection.Close();
                //рисуем границы
                k--;
                excelcells = xlSheet.get_Range("A" + rowN, "E" + (k + rowN));
                excelcells.Font.Size = 12;
                excelcells.Font.Bold = false;
                excelcells.Font.Italic = false;
                excelcells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;                
                excelcells.HorizontalAlignment = Excel.Constants.xlLeft;
                excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                excelcells.WrapText = true;
                //форматируем шапку
                excelcells = xlSheet.get_Range("A10", "E10");
                excelcells.Font.Size = 12;
                excelcells.Font.Bold = true;
                excelcells.Font.Italic = true;
                excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                excelcells = xlSheet.get_Range("A11", "E" + (k + rowN));
                excelcells.HorizontalAlignment = Excel.Constants.xlLeft;
                excelcells = xlSheet.get_Range("A11", "A" + (k + rowN));
                excelcells.HorizontalAlignment = Excel.Constants.xlCenter;

                rowN = k + rowN + 2;
                excelcells = xlSheet.get_Range("A" + rowN, "A" + rowN);
                excelcells.Merge(Type.Missing);
                excelcells.HorizontalAlignment = Excel.Constants.xlLeft;
                excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                excelcells.Font.Bold = false;
                excelcells.Font.Underline = true;
                xlSheet.Cells[rowN, 1] = "Затраты: ";
                //затраты
                rowN++;
                //делаем шапку таблицы
                xlSheet.Cells[rowN, 1] = "№ п/п";
                xlSheet.Cells[rowN, 2] = "Вид затрат";
                xlSheet.Cells[rowN, 3] = "Сумма, руб.";

                sQuery = String.Format(@"SELECT Наим,Сумма " +
                @"from ПроведениеЗатраты,Затраты where (ПроведениеЗатраты.Код_затраты=Затраты.Код_затраты) and " +
                @"(ПроведениеЗатраты.Код_пров={0}) ORDER BY Наим;", id);
                sqlConnection.Open();
                command = new SQLiteCommand(sQuery, sqlConnection);
                reader = command.ExecuteReader();
                k = 1;
                int sum = 0;
                while (reader.Read())
                {
                    xlSheet.Cells[rowN + k, 1] = k.ToString();
                    xlSheet.Cells[rowN + k, 2] = reader.GetString(0);
                    xlSheet.Cells[rowN + k, 3] = reader.GetInt32(1);
                    sum += reader.GetInt32(1);
                    k++;
                }
                reader.Close();
                sqlConnection.Close();
                //рисуем границы
                k--;
                excelcells = xlSheet.get_Range("A" + rowN, "C" + (k + rowN));
                excelcells.Font.Bold = false;
                excelcells.Font.Italic = false;
                excelcells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                excelcells.HorizontalAlignment = Excel.Constants.xlLeft;
                excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                excelcells.WrapText = true;
                //форматируем шапку
                excelcells = xlSheet.get_Range("A" + rowN, "C" + rowN);
                excelcells.Font.Bold = true;
                excelcells.Font.Italic = true;
                excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                excelcells.VerticalAlignment = Excel.Constants.xlCenter;
                excelcells = xlSheet.get_Range("A" + (rowN+1), "C" + (k + rowN));
                excelcells.HorizontalAlignment = Excel.Constants.xlLeft;
                excelcells = xlSheet.get_Range("A" + rowN, "A" + (k + rowN));
                excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                excelcells = xlSheet.get_Range("C" + rowN, "C" + (k + rowN));
                excelcells.HorizontalAlignment = Excel.Constants.xlCenter;
                rowN = k + rowN + 1;
                xlSheet.Cells[rowN, 2] = "ИТОГО:";
                xlSheet.Cells[rowN, 2].HorizontalAlignment = Excel.Constants.xlLeft;
                xlSheet.Cells[rowN, 3] = sum.ToString()+" руб.";
                xlSheet.Cells[rowN, 3].HorizontalAlignment = Excel.Constants.xlCenter;
                //выравниваем строки и колонки по их содержимому
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                xlApp.Visible = false;
                xlApp.Interactive = true;
                xlApp.ScreenUpdating = true;
                xlApp.UserControl = true;
                string dd = DateTime.Today.ToShortDateString();
                dd = dd.Replace(".", "_");
                string fullpath = System.Windows.Forms.Application.StartupPath + "\\Out\\Отчет_" + id.ToString() + ".pdf";
                xlSheet = xlApp.Sheets[1];
                XlFixedFormatType paramExportFormat = XlFixedFormatType.xlTypePDF;
                XlFixedFormatQuality paramExportQuality = XlFixedFormatQuality.xlQualityStandard;
                bool paramOpenAfterPublish = true;
                xlSheet.ExportAsFixedFormat(paramExportFormat, fullpath, paramExportQuality, paramOpenAfterPublish);
                xlDoc.Close(false);
                xlApp.Quit();
                MessageBox.Show("Отчет сохранен как " + fullpath, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Отсоединяемся от Excel               
                releaseObject(xlApp);
            }
        }      

        /*Освобождаем ресуры (закрываем Excel)*/
        void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
