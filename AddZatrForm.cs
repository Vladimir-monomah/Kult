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
    public partial class AddZatrForm : Form
    {
        public SQLiteConnection sqlConnection;
        public int id;

        public AddZatrForm()
        {
            InitializeComponent();
        }

        /*выбор вида затрат*/
        private void bCh_Zatr_Click(object sender, EventArgs e)
        {
            ZatrForm f = new ZatrForm();
            f.sqlConnection = sqlConnection;
            f.b = true;
            f.ShowDialog();
            txt1.Tag = f.id;
            txt1.Text = f.dataS;
        }

        /*открытие формы*/
        private void AddZatrForm_Load(object sender, EventArgs e)
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
            pDop.Visible = true;
        }

        /*выполняем запрос на выборку, отображаем рузультаты в гриде*/
        private void OpenTable()
        {
            string sqlQuery = "SELECT '',ПроведениеЗатраты.Код_пров_затр,ПроведениеЗатраты.Код_затраты,Наим,Сумма " +
                "from ПроведениеЗатраты,Затраты where (ПроведениеЗатраты.Код_затраты=Затраты.Код_затраты) and " +
                "(ПроведениеЗатраты.Код_пров="+id+") ORDER BY Наим;";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, sqlConnection);
            DataTable myD = new DataTable();
            adapter.Fill(myD);
            dGV1.DataSource = myD;
            dGV1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            /*устанавливаем ширину колонок и название заголовков грида*/
            dGV1.Columns[0].Width = 80;
            dGV1.Columns[1].Visible = false;
            dGV1.Columns[2].Visible = false;
            dGV1.Columns[3].Width = 200;
            dGV1.Columns[4].Width = 150;
            dGV1.Columns[0].HeaderText = "№ п/п";
            dGV1.Columns[3].HeaderText = "Вид затрат";
            dGV1.Columns[4].HeaderText = "Сумма, руб.";
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
                txt1.Tag = dGV1.Rows[i].Cells[2].Value.ToString();
                txt1.Text = dGV1.Rows[i].Cells[3].Value.ToString();
                txt2.Text = dGV1.Rows[i].Cells[4].Value.ToString();
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
            string sqlQuery = "DELETE FROM ПроведениеЗатраты where Код_пров_затр =" + id.ToString() + ";";
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
            if ((txt1.Text.Equals("")) || (txt2.Text.Equals("")))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string sqlQuery = "INSERT INTO ПроведениеЗатраты (Код_пров,Код_затраты,Сумма) Values (" +id+","+
                txt1.Tag + "," + txt2.Text + "); ";
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
            string sqlQuery = "Update ПроведениеЗатраты set Код_затраты=" + txt1.Tag + ",Сумма=" + txt2.Text +
                " where Код_пров_затр=" + id.ToString();
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
    }
}
