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
    public partial class AnalizForm : Form
    {
        public SQLiteConnection sqlConnection;

        public AnalizForm()
        {
            InitializeComponent();
        }
        
        /*заполняем комбобокс отделов*/
        private void Make_cbMer(ComboBox cb)
        {
            string sqlQuery = "SELECT * From Мероприятия;";
            sqlConnection.Open();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, sqlConnection);
            System.Data.DataTable myD = new System.Data.DataTable();
            adapter.Fill(myD);
            cb.DataSource = myD;
            cb.DisplayMember = "Наим";// столбец для отображения
            cb.ValueMember = "Код_мер";//столбец с id 
            sqlConnection.Close();
        }

        /*открытие формы*/
        private void AnalizForm_Load(object sender, EventArgs e)
        {
            Make_cbMer(cbMer);
            ch1.ChartAreas[0].AxisX.Title ="Дата";
            ch1.ChartAreas[0].AxisY.Title = "Значение";
            ch1.Titles[0].Text = "";
            rB1.Checked = true;
            ch1.Series[0].Points.Clear();
        }

        /*Сохранить*/
        private void bOut_Click(object sender, EventArgs e)
        {
            Bitmap bmpSave = new Bitmap(ch1.Width, ch1.Height);
            ch1.DrawToBitmap(bmpSave, new Rectangle(new Point(), ch1.Size));
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = System.Windows.Forms.Application.StartupPath + "\\Out\\";
            sfd.DefaultExt = "bmp";
            sfd.Filter = "Image files (*.bmp)|*.bmp|All files (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
                bmpSave.Save(sfd.FileName);
        }

        /*Построение графика*/
        private void GetGraph()
        {
            ch1.Titles[0].Text = "";
            ch1.Series[0].Points.Clear();
            string sQuery = "";
            if ((cbMer.Text != "") && ((rB1.Checked) || (rB2.Checked)))
            {
                string id = cbMer.SelectedValue.ToString();                
                if (rB1.Checked)
                {
                    sQuery = String.Format(@"SELECT Дата, Sum(Сумма) as Sum" +
                    @" from Проведение,Мероприятия,ПроведениеЗатраты " +
                    @"where (Проведение.Код_мер=Мероприятия.Код_мер) and (Мероприятия.Код_мер={0}) and (Результат!='') and " +
                    @"(ПроведениеЗатраты.Код_пров=Проведение.Код_пров) group by Дата ORDER BY Дата DESC;", id);
                    ch1.Titles[0].Text = "Отчет по затратам мероприятия «" + cbMer.Text + "»";
                    ch1.ChartAreas[0].AxisY.Title = "Сумма, руб.";
                }
                else
                    if (rB2.Checked)
                {
                    sQuery = String.Format(@"SELECT Дата, " +
                    @"(select Count (*) from ПроведениеСотрудники where (ПроведениеСотрудники.Код_пров=Проведение.Код_пров) and " +
                    @"(Проведение.Код_мер={0})) as Kol from Проведение,Мероприятия,ПроведениеЗатраты " +
                    @"where (Проведение.Код_мер=Мероприятия.Код_мер) and (Мероприятия.Код_мер={0}) and (Результат!='') and " +
                    @"(ПроведениеЗатраты.Код_пров=Проведение.Код_пров) group by Дата ORDER BY Дата DESC;", id);
                    ch1.Titles[0].Text = "Отчет по участникам мероприятия «" + cbMer.Text + "»";
                    ch1.ChartAreas[0].AxisY.Title = "Кол-во участников";
                }
                sqlConnection.Open();
                SQLiteCommand command = new SQLiteCommand(sQuery, sqlConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                int k = 0;
                while (reader.Read())
                {
                    if (reader.GetValue(0).ToString() != "")
                    {
                        ch1.Series[0].Points.AddXY(reader.GetDateTime(0).ToShortDateString(), reader.GetInt32(1));
                        ch1.Series[0].Points[k].Label = reader.GetInt32(1).ToString();
                        k++;
                    }
                }
                reader.Close();
                sqlConnection.Close();
            }
        }

        /*меняем выбор мероприятия*/
        private void cbMer_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetGraph();
        }

        /*меняем выбор условий*/
        private void rB1_CheckedChanged(object sender, EventArgs e)
        {
            GetGraph();
        }
    }
}
