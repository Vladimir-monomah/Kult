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
    public partial class DocForm : Form
    {
        public SQLiteConnection sqlConnection;
        public bool b;
        public string id, dataS;

        public DocForm()
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
        private void DocForm_Load(object sender, EventArgs e)
        {
            OpenTable();
            pDop.Visible = false;
        }

        /*выполняем запрос на выборку, отображаем рузультаты в гриде*/
        private void OpenTable()
        {
            string sqlQuery = "";
            if (txtF.Text != "")
                sqlQuery = "SELECT '',Код_документ,Название,Шаблон from Документы where (Название like '" + txtF.Text + "%') ORDER BY Название;";
            else
                sqlQuery = "SELECT '',Код_документ,Название,Шаблон from Документы ORDER BY Название;";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, sqlConnection);
            DataTable myD = new DataTable();
            adapter.Fill(myD);
            dGV1.DataSource = myD;
            dGV1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            /*устанавливаем ширину колонок и название заголовков грида*/
            dGV1.Columns[0].Width = 80;
            dGV1.Columns[1].Visible = false;
            dGV1.Columns[2].Width = 320;
            dGV1.Columns[3].Width = 300;
            dGV1.Columns[0].HeaderText = "№ п/п";
            dGV1.Columns[2].HeaderText = "Название";
            dGV1.Columns[3].HeaderText = "Шаблон";
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
            string sqlQuery = "DELETE FROM Документы where Код_документ =" + id.ToString() + ";";
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
            string sqlQuery = "INSERT INTO Документы (Название,Шаблон) Values ('" + txt1.Text + "','" + txt2.Text + "');";
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
            string sqlQuery = "Update Документы set Название='" + txt1.Text + "',Шаблон='" +
                txt2.Text + "' where Код_документ=" + id.ToString();
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

        /*выбор файла*/
        private void bCh_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Filter = "Файлы Word(*.dot;*dotx)|*.dot;*dotx";
            OPF.InitialDirectory = Application.StartupPath + "\\Шаблоны";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                txt2.Text = String.Format(@System.IO.Path.GetFileName(OPF.FileName.ToString()));
            }
        }

        private void txtF_TextChanged(object sender, EventArgs e)
        {
            OpenTable();
        }

        /*дабл клик по записи грида*/
        private void dGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (b)
            {
                if (dGV1.CurrentRow != null)
                {
                    int i = dGV1.CurrentRow.Index;
                    id = dGV1.Rows[i].Cells[1].Value.ToString();
                    dataS = dGV1.Rows[i].Cells[3].Value.ToString();
                    Close();
                }
            }
        }
    }
}
