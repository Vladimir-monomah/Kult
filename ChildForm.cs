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
    public partial class ChildForm : Form
    {
        public SQLiteConnection sqlConnection;

        public ChildForm()
        {
            InitializeComponent();
        }

        /*открытие формы*/
        private void ChildForm_Load(object sender, EventArgs e)
        {
            OpenTable();
            pDop.Visible = false;
        }

        /*При редактировании и добавлении кнопки и грид неактивны*/
        private void Buts(bool b)
        {
            bAdd.Enabled = b;
            bEdit.Enabled = b;
            bDel.Enabled = b;
            dGV1.Enabled = b;
        }

        /*Добавить*/
        private void bAdd_Click(object sender, EventArgs e)
        {
            Buts(false);
            lCapt.Text = "Добавление записи";
            txt1.Clear();
            txt2.Clear();
            txt3.Clear();
            txt4.Clear();
            dt1.Value = DateTime.Today;
            pDop.Visible = true;
        }

        /*выполняем запрос на выборку, отображаем рузультаты в гриде*/
        private void OpenTable()
        {
            string sqlQuery = "";
            if (txtF.Text!="")
                sqlQuery = "SELECT '',Дети.Код_дети,Дети.Код_сотр,Дети.Фамилия,Дети.Имя,Дети.Отчество,Дети.ДатаРождения," +
                "(Сотрудники.Фамилия || ' ' || substr(Сотрудники.Имя,1,1) || '.' || substr(Сотрудники.Отчество,1,1)  || '.') as ФИО from Сотрудники,Дети " +
                "where (Сотрудники.Код_сотр=Дети.Код_сотр) and (Дети.Фамилия like '" + txtF.Text + "%') ORDER BY ФИО;";
            else
                sqlQuery = "SELECT '',Дети.Код_дети,Дети.Код_сотр,Дети.Фамилия,Дети.Имя,Дети.Отчество,Дети.ДатаРождения," +
                "(Сотрудники.Фамилия || ' ' || substr(Сотрудники.Имя,1,1) || '.' || substr(Сотрудники.Отчество,1,1)  || '.') as ФИО from Сотрудники,Дети " +
                "where (Сотрудники.Код_сотр=Дети.Код_сотр) ORDER BY ФИО;";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, sqlConnection);
            DataTable myD = new DataTable();
            adapter.Fill(myD);
            dGV1.DataSource = myD;
            dGV1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            /*устанавливаем ширину колонок и название заголовков грида*/
            dGV1.Columns[0].Width = 80;
            dGV1.Columns[1].Visible = false;
            dGV1.Columns[2].Visible = false;
            dGV1.Columns[3].Width = 110;
            dGV1.Columns[4].Width = 110;
            dGV1.Columns[5].Width = 110;
            dGV1.Columns[6].Width = 120;
            dGV1.Columns[7].Width = 150;
            dGV1.Columns[0].HeaderText = "№ п/п";
            dGV1.Columns[3].HeaderText = "Фамилия";
            dGV1.Columns[4].HeaderText = "Имя";
            dGV1.Columns[5].HeaderText = "Отчество";
            dGV1.Columns[6].HeaderText = "Дата рожд.";
            dGV1.Columns[7].HeaderText = "Сотрудник";
            for (int i = 0; i < dGV1.Rows.Count; i++)
                dGV1.Rows[i].Cells[0].Value = (i + 1).ToString();
        }

        /*Отмена*/
        private void bCancel_Click(object sender, EventArgs e)
        {
            Buts(true);
            pDop.Visible = false;
        }

        /*Удалить*/
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

        /*Изменить*/
        private void bEdit_Click(object sender, EventArgs e)
        {
            if (dGV1.CurrentRow != null)
            {
                Buts(false);
                int i = dGV1.CurrentRow.Index;
                txt1.Text = dGV1.Rows[i].Cells[3].Value.ToString();
                txt2.Text = dGV1.Rows[i].Cells[4].Value.ToString();
                txt3.Text = dGV1.Rows[i].Cells[5].Value.ToString();
                txt4.Text = dGV1.Rows[i].Cells[7].Value.ToString();
                txt4.Tag = dGV1.Rows[i].Cells[2].Value.ToString();
                dt1.Value = Convert.ToDateTime(dGV1.Rows[i].Cells[6].Value.ToString());
                lCapt.Text = "Редактирование записи";
                pDop.Visible = true;
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
            string sqlQuery = "DELETE FROM Дети where Код_дети =" + id.ToString() + ";";
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
                    pDop.Visible = false;
                }
            }
        }

        /*OK*/
        private void bOk_Click(object sender, EventArgs e)
        {
            if ((txt1.Text.Equals("")) || (txt2.Text.Equals("")) || (txt3.Text.Equals("")) || (txt4.Equals("")))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dt1.Value>DateTime.Today)
            {
                MessageBox.Show("Неверно указана дата", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Buts(true);
            if (lCapt.Text.Equals("Добавление записи"))
                Add();
            else
                Edit();
        }

        /*Запрос на вставку*/
        private void Add()
        {
            string sqlQuery = "INSERT INTO Дети (Код_сотр,Фамилия,Имя,Отчество,ДатаРождения) Values (" +
                txt4.Tag + ",'" + txt1.Text+"','"+txt2.Text+"','"+txt3.Text+"','"+
                dt1.Value.ToString("yyyy-MM-dd") +"'); ";
            bool good = false;
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
                    pDop.Visible = false;
                }
            }
        }

        /*Запрос на изменение*/
        private void Edit()
        {
            bool good = false;
            int i = dGV1.CurrentRow.Index;
            int id = int.Parse(dGV1.Rows[i].Cells[1].Value.ToString());
            string sqlQuery = "Update Дети set Код_сотр=" + txt4.Tag + ",Фамилия='" + txt1.Text + "',Имя='" + txt2.Text + 
                "',Отчество='" + txt3.Text + "',ДатаРождения='" + dt1.Value.ToString("yyyy-MM-dd") + "' where Код_дети=" + id.ToString();
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
                    pDop.Visible = false;
                }
            }
        }

        /*выбор сотрудника*/
        private void bCh_Sotr_Click(object sender, EventArgs e)
        {
            SotrForm f = new SotrForm();
            f.sqlConnection = sqlConnection;
            f.b = true;
            f.ShowDialog();
            txt4.Tag = f.id;
            txt4.Text = f.dataS;
        }

        private void txt1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            e.Handled = !((c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я') || c == 'Ё' || c == 'ё' || c == 8 || c == 46 || c == '-' || c == ' ');
        }

        private void txt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            e.Handled = !((c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я') || c == 'Ё' || c == 'ё' || c == 8 || c == 46 || c == '-' || c == ' ');
        }

        private void txt3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            e.Handled = !((c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я') || c == 'Ё' || c == 'ё' || c == 8 || c == 46 || c == '-' || c == ' ');
        }

        private void txtF_TextChanged(object sender, EventArgs e)
        {
            OpenTable();
        }
    }
}
