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
    public partial class DepForm : Form
    {
        public SQLiteConnection sqlConnection;
        public bool b;
        public string id, dataS;
        
        public DepForm()
        {
            InitializeComponent();
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

        /*открытие формы*/
        private void OtdelForm_Load(object sender, EventArgs e)
        {
            OpenTable();
            pDop.Visible = false;
        }

        /*выполняем запрос на выборку, отображаем рузультаты в гриде*/
        private void OpenTable()
        {
            string sqlQuery = "";
            if (txtF.Text!="")
                sqlQuery = "SELECT '',Код_отдел,ОтделПолн,ОтделСокр from Отделы where (ОтделПолн like '" + txtF.Text + "%') ORDER BY ОтделПолн;";
            else
                sqlQuery = "SELECT '',Код_отдел,ОтделПолн,ОтделСокр from Отделы ORDER BY ОтделПолн;";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, sqlConnection);
            DataTable myD = new DataTable();
            adapter.Fill(myD);
            dGV1.DataSource = myD;
            dGV1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            /*устанавливаем ширину колонок и название заголовков грида*/
            dGV1.Columns[0].Width = 80;
            dGV1.Columns[1].Visible = false;
            dGV1.Columns[2].Width = 420;
            dGV1.Columns[3].Width = 150;
            dGV1.Columns[0].HeaderText = "№ п/п";
            dGV1.Columns[1].HeaderText = "ID";
            dGV1.Columns[2].HeaderText = "Полное название";
            dGV1.Columns[3].HeaderText = "Сокр. название";
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
                txt1.Text = dGV1.Rows[i].Cells[2].Value.ToString();
                txt2.Text = dGV1.Rows[i].Cells[3].Value.ToString();
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
            string sqlQuery = "DELETE FROM Отделы where Код_отдел =" + id.ToString() + ";";
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
            string sqlQuery = "INSERT INTO Отделы (ОтделПолн,ОтделСокр) Values ('" + txt1.Text + "','"+txt2.Text+"');";
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

        /*дабл клик по записи грида*/
        private void dGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (b)
            {
                if (dGV1.CurrentRow!=null)
                {
                    int i = dGV1.CurrentRow.Index;
                    id = dGV1.Rows[i].Cells[1].Value.ToString();
                    dataS = dGV1.Rows[i].Cells[3].Value.ToString();
                    Close();
                }
            }
        }

        private void txt1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            e.Handled = !((c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я') || c == 'Ё' || c == 'ё' || c == 8 || c == 46 || c =='-' || c == ' ');
        }

        private void txt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            e.Handled = !((c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я') || c == 'Ё' || c == 'ё' || c == 8 || c == 46 || c == '-' || c == ' ');
        }

        private void txtF_TextChanged(object sender, EventArgs e)
        {
            OpenTable();
        }

        /*Запрос на изменение*/
        private void Edit()
        {
            bool good = false;
            int i = dGV1.CurrentRow.Index;
            int id = int.Parse(dGV1.Rows[i].Cells[1].Value.ToString());
            string sqlQuery = "Update Отделы set ОтделПолн='" + txt1.Text + "',ОтделСокр='"+
                txt2.Text + "' where Код_отдел=" + id.ToString();
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
