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
    public partial class ProvForm : Form
    {
        public SQLiteConnection sqlConnection;

        public ProvForm()
        {
            InitializeComponent();
        }

        /*открытие формы*/
        private void ProvForm_Load(object sender, EventArgs e)
        {
            OpenTable();
            tC1.SelectedIndex = 0;
            lData.Text = "Сегодня: " + DateTime.Today.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            timer1.Enabled = true;
        }

        /*выполняем запрос на выборку, отображаем рузультаты в гриде*/
        private void OpenTable()
        {
            string sqlQuery = "SELECT '',Проведение.Код_пров,Проведение.Код_мер,Проведение.Код_орг,Мероприятия.Наим,"+
                "Организации.Наим,Дата,Результат,(case when Результат<>'' then 'проведено' else 'не проведено' end) as Проведено,"+
                "(julianday(Дата)-julianday('now')) as DD " +
                "from Проведение,Мероприятия,Организации " +
                "where (Проведение.Код_мер=Мероприятия.Код_мер) and (Проведение.Код_орг=Организации.Код_орг) ORDER BY Дата DESC;";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, sqlConnection);
            BindingSource bs = new BindingSource();
            
            DataTable myD = new DataTable();
            adapter.Fill(myD);
            bs.DataSource = myD;
            dGV1.DataSource = bs;
            /*события для обработки перемещения по записям*/
            dGV1.SelectionChanged+= bs_CurrentChanged;
            dGV1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            /*устанавливаем ширину колонок и название заголовков грида*/
            dGV1.Columns[0].Width = 80;
            dGV1.Columns[1].Visible = false;
            dGV1.Columns[2].Visible = false;
            dGV1.Columns[3].Visible = false;
            dGV1.Columns[4].Width = 260;
            dGV1.Columns[5].Width = 260;
            dGV1.Columns[6].Width = 120;
            dGV1.Columns[7].Visible = false;
            dGV1.Columns[8].Width = 120;
            dGV1.Columns[9].Visible = false;
            dGV1.Columns[0].HeaderText = "№ п/п";
            dGV1.Columns[4].HeaderText = "Мероприятие";
            dGV1.Columns[5].HeaderText = "Организация";
            dGV1.Columns[6].HeaderText = "Дата";
            dGV1.Columns[7].HeaderText = "Результат";
            dGV1.Columns[8].HeaderText = "Статус";
            for (int i = 0; i < dGV1.Rows.Count; i++)
                dGV1.Rows[i].Cells[0].Value = (i + 1).ToString();
            foreach (DataGridViewRow row in dGV1.SelectedRows)
            {
                GetData1();
                GetData2();
                GetData3();
            }
        }

        /*При переходе по записям грида*/
        private void bs_CurrentChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dGV1.SelectedRows)
            {
                GetData1();
                GetData2();
                GetData3();
            }
        }

        /*отображаем затраты*/
        private void GetData1()
        {
            if (dGV1.CurrentRow != null)
                OpenTableZatr();
        }

        /*отображаем затраты*/
        private void OpenTableZatr()
        {
            int i = dGV1.CurrentRow.Index;
            string id = dGV1.Rows[i].Cells[1].Value.ToString();
            string sqlQuery = "SELECT Наим,Сумма " +
                "from ПроведениеЗатраты,Затраты where (ПроведениеЗатраты.Код_затраты=Затраты.Код_затраты) and " +
                "(ПроведениеЗатраты.Код_пров="+id+") ORDER BY Наим;";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, sqlConnection);
            DataTable myD = new DataTable();
            adapter.Fill(myD);
            dGVZ.DataSource = myD;
            dGVZ.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            /*устанавливаем ширину колонок и название заголовков грида*/
            dGVZ.Columns[0].Width = 340;
            dGVZ.Columns[1].Width = 220;
            dGVZ.Columns[0].HeaderText = "Вид затрат";
            dGVZ.Columns[1].HeaderText = "Сумма, руб.";
            lSum.Text= GetSum(id)+",00 руб.";
        }

        /*итоговая сумма затрат*/
        private string GetSum(string id)
        {
            string str = "0";
            sqlConnection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT Sum(Сумма) FROM ПроведениеЗатраты where Код_пров=" +
                id.ToString()+" Group by Код_пров", sqlConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                str = reader.GetInt32(0).ToString();
            }
            reader.Close();
            sqlConnection.Close();
            return str;
        }

        /*отображаем участников и их достижения*/
        private void GetData2()
        {
            if (dGV1.CurrentRow != null)
                OpenTableUch();
        }

        /*отображаем участников и их достижения*/
        private void OpenTableUch()
        {
            int i = dGV1.CurrentRow.Index;
            string id = dGV1.Rows[i].Cells[1].Value.ToString();
            string sqlQuery = "SELECT ПроведениеСотрудники.Код_сотр,"+
                "(Сотрудники.Фамилия || ' ' || substr(Сотрудники.Имя,1,1) || '.' || substr(Сотрудники.Отчество,1,1)  || '.') as ФИО,"+
                "ОтделСокр,Спец from Сотрудники,Отделы,Специальности,ПроведениеСотрудники " +
                "where (Сотрудники.Код_отдел=Отделы.Код_отдел) and (Сотрудники.Код_спец=Специальности.Код_спец) and " +
                "(ПроведениеСотрудники.Код_пров="+id+ ") and (ПроведениеСотрудники.Код_сотр=Сотрудники.Код_сотр) ORDER BY Фамилия, Имя, Отчество;";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, sqlConnection);
            BindingSource bs = new BindingSource();
            DataTable myD = new DataTable();
            adapter.Fill(myD);
            bs.DataSource = myD;
            dGVU.DataSource = bs;
            /*события для обработки перемещения по записям*/
            dGVU.SelectionChanged += bs_CurrentChanged2;
            dGVU.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            /*устанавливаем ширину колонок и название заголовков грида*/
            dGVU.Columns[0].Visible = false;
            dGVU.Columns[1].Width = 180;
            dGVU.Columns[2].Width = 120;
            dGVU.Columns[3].Width = 200;
            dGVU.Columns[1].HeaderText = "ФИО";
            dGVU.Columns[2].HeaderText = "Отдел";
            dGVU.Columns[3].HeaderText = "Специальность";
            foreach (DataGridViewRow row in dGVU.SelectedRows)
            {
                GetDost(row.Cells["Код_сотр"].Value.ToString());                
            }
        }

        /*При переходе по записям грида*/
        private void bs_CurrentChanged2(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dGVU.SelectedRows)
                GetDost(row.Cells["Код_сотр"].Value.ToString());
        }

        /*отображаем достижения*/
        private void GetDost(string id_sotr)
        {
            string str = "";
            int i = dGV1.CurrentRow.Index;
            string id = dGV1.Rows[i].Cells[1].Value.ToString();
            sqlConnection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT Описание FROM Достижения where (Код_сотр=" + id_sotr+
                ") and (Код_пров="+id+")", sqlConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                str = reader.GetString(0);
            }
            reader.Close();
            sqlConnection.Close();
            txtDost.Text = str;
        }

        /*отображаем результаты*/
        private void GetData3()
        {
            if (dGV1.CurrentRow != null)
            {
                int i = dGV1.CurrentRow.Index;
                txtRez.Text = dGV1.Rows[i].Cells[7].Value.ToString();
            }
        }

        /*Новое мероприятие*/
        private void bAdd_Click(object sender, EventArgs e)
        {
            AddProvForm f = new AddProvForm();
            f.sqlConnection = sqlConnection;
            f.id = 0;
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK) OpenTable();
        }

        /*Изменить параметры*/
        private void bEdit_Click(object sender, EventArgs e)
        {
            if (dGV1.CurrentRow != null)
            {
                AddProvForm f = new AddProvForm();
                f.sqlConnection = sqlConnection;
                int i = dGV1.CurrentRow.Index;
                f.id = int.Parse(dGV1.Rows[i].Cells[1].Value.ToString());
                f.ShowDialog();
                if (f.DialogResult == DialogResult.OK) OpenTable();
            }
            else
                MessageBox.Show("Выберите нужную запись", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /*Удалить мероприятие*/
        private void bDel_Click(object sender, EventArgs e)
        {
            if (dGV1.CurrentRow != null)
            {
                if (MessageBox.Show(this, "Подтверждаете удаление?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    Del();
            }
            else
                MessageBox.Show("Выберите нужную запись", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /*Запрос на удаление*/
        private void Del()
        {
            bool good = false;
            int i = dGV1.CurrentRow.Index;
            int id = int.Parse(dGV1.Rows[i].Cells[1].Value.ToString());
            string sqlQuery = "DELETE FROM Проведение where Код_пров =" + id.ToString() + ";";
            /*Создаем транзакцию */
            sqlConnection.Open();
            SQLiteCommand command = new SQLiteCommand(sqlQuery);
            command.Transaction = sqlConnection.BeginTransaction(System.Data.IsolationLevel.Serializable);
            try
            {
                command.ExecuteNonQuery();
                /*Подтверждаем транзакцию */
                command.Transaction.Commit();
                good = true;
            }
            catch (Exception ex)
            {
                /*Отклоняем транзакцию */
                command.Transaction.Rollback();
                MessageBox.Show("При выполнении запроса произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sqlConnection.Close();
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed && good)
                {
                    OpenTable();
                    sqlConnection.Close();
                }
            }
        }

        /*Отметка о проведении*/
        private void button3_Click(object sender, EventArgs e)
        {
            if (dGV1.CurrentRow != null)
            {
                AddResultForm f = new AddResultForm();
                f.sqlConnection = sqlConnection;
                int i = dGV1.CurrentRow.Index;
                f.id = int.Parse(dGV1.Rows[i].Cells[1].Value.ToString());
                f.ShowDialog();
                if (f.DialogResult == DialogResult.OK) OpenTable();
            }
            else
                MessageBox.Show("Выберите нужную запись", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /*меняем вкладки*/
        private void tC1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dGV1.CurrentRow != null)
            {
                if (tC1.SelectedIndex == 0) GetData1();
                else
                    if (tC1.SelectedIndex == 1) GetData2();
                    else
                        if (tC1.SelectedIndex == 2) GetData3();
            }
        }

        /*Затраты на проведение*/
        private void button1_Click(object sender, EventArgs e)
        {
            if (dGV1.CurrentRow != null)
            {
                AddZatrForm f = new AddZatrForm();
                f.sqlConnection = sqlConnection;
                int i = dGV1.CurrentRow.Index;
                f.id = int.Parse(dGV1.Rows[i].Cells[1].Value.ToString());
                f.ShowDialog();
                GetData1();
            }
            else
                MessageBox.Show("Выберите нужную запись", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /*Достижения участников*/
        private void button4_Click(object sender, EventArgs e)
        {
            if (dGVU.Rows.Count==0)
            {
                MessageBox.Show("Список участников не определен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                AddDostForm f = new AddDostForm();
                f.sqlConnection = sqlConnection;
                int i = dGV1.CurrentRow.Index;
                f.id = int.Parse(dGV1.Rows[i].Cells[1].Value.ToString());
                f.ShowDialog();
                GetData2();
            }
        }

        /*Отправка уведомлений*/
        private void bSend_Click(object sender, EventArgs e)
        {
            if (dGVU.Rows.Count == 0)
            {
                MessageBox.Show("Список участников не определен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SendForm f = new SendForm();
                f.sqlConnection = sqlConnection;
                int i = dGV1.CurrentRow.Index;
                f.id = int.Parse(dGV1.Rows[i].Cells[1].Value.ToString());
                f.ShowDialog();
            }
        }

        /*Список участников*/
        private void button2_Click(object sender, EventArgs e)
        {
            if (dGV1.CurrentRow != null)
            {
                UchForm f = new UchForm();
                f.sqlConnection = sqlConnection;
                int i = dGV1.CurrentRow.Index;
                f.id = int.Parse(dGV1.Rows[i].Cells[1].Value.ToString());
                f.ShowDialog();
                GetData2();
            }
            else
                MessageBox.Show("Выберите нужную запись", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /*красим строки грида*/
        private void dGV1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            for (int i = 0; i <= dGV1.RowCount - 1; i++)
            {
                if (dGV1.Rows[i].Cells[7].Value.ToString().Equals(""))
                    if ((double.Parse(dGV1.Rows[i].Cells[9].Value.ToString()) <= 7.0) && (double.Parse(dGV1.Rows[i].Cells[9].Value.ToString()) > 0.0))
                        ((DataGridView)sender).Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    else
                        if (double.Parse(dGV1.Rows[i].Cells[9].Value.ToString()) < 0.0)
                        ((DataGridView)sender).Rows[i].DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lData.Text = "Сегодня: " + DateTime.Today.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
        }
    }
}
