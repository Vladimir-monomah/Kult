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
    public partial class AddDostForm : Form
    {
        public SQLiteConnection sqlConnection;
        public int id;

        public AddDostForm()
        {
            InitializeComponent();
        }

        /*открытие формы*/
        private void AddDostForm_Load(object sender, EventArgs e)
        {
            OpenTable();
        }

        /*выполняем запрос на выборку, отображаем рузультаты в гриде*/
        private void OpenTable()
        {
            string sqlQuery = "SELECT Сотрудники.Код_сотр," +
                "(Сотрудники.Фамилия || ' ' || substr(Сотрудники.Имя,1,1) || '.' || substr(Сотрудники.Отчество,1,1)  || '.') as ФИО " +
                "from Сотрудники,ПроведениеСотрудники " +
                "where (Сотрудники.Код_сотр=ПроведениеСотрудники.Код_сотр) and (Код_пров=" + id + ") ORDER BY ФИО;";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, sqlConnection);
            BindingSource bs = new BindingSource();
            DataTable myD = new DataTable();
            adapter.Fill(myD);
            bs.DataSource = myD;
            dGV1.DataSource = bs;
            /*события для обработки перемещения по записям*/
            dGV1.SelectionChanged += bs_CurrentChanged;
            dGV1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            /*устанавливаем ширину колонок и название заголовков грида*/
            dGV1.Columns[0].Width = 60;
            dGV1.Columns[1].Width = 190;
            dGV1.Columns[0].HeaderText = "Таб.№";
            dGV1.Columns[1].HeaderText = "ФИО";
        }

        /*При переходе по записям грида*/
        private void bs_CurrentChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dGV1.SelectedRows)
                GetDost(row.Cells["Код_сотр"].Value.ToString());
        }

        /*отображаем достижения*/
        private void GetDost(string id_sotr)
        {
            string str = "";
            sqlConnection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT Описание FROM Достижения where (Код_сотр=" + id_sotr +
                ") and (Код_пров=" + id + ")", sqlConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                str = reader.GetString(0);
            }
            reader.Close();
            sqlConnection.Close();
            txtDost.Text = str;
        }

        /*Сохранить*/
        private void bSave_Click(object sender, EventArgs e)
        {
            if ((dGV1.CurrentRow != null) && (txtDost.Text != ""))
            {
                int i = dGV1.CurrentRow.Index;
                int id_sotr = int.Parse(dGV1.Rows[i].Cells[0].Value.ToString());
                string sqlQuery = "";
                if (CheckSotrEdit(id_sotr))
                {
                    sqlQuery = "Update Достижения set Описание='" + txtDost.Text + "' where (Код_сотр=" + id_sotr.ToString() + ") and " +
                        "(Код_пров="+id+");";
                }
                else
                    sqlQuery = "INSERT INTO Достижения (Код_пров, Код_сотр, Описание) Values (" + id+","+
                        id_sotr.ToString() + ",'"+ txtDost.Text + "');";               
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
                        sqlConnection.Close();
                    }
                }
            }
        }

        /*проверка сотрудника*/
        private bool CheckSotrEdit(int id_sotr)
        {
            bool b =false;
            sqlConnection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM Достижения where (Код_пров=" + id + ") and " +
                "(Код_сотр=" + id_sotr.ToString() + ")", sqlConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
                b = true;
            reader.Close();
            sqlConnection.Close();
            return b;
        }
    }
}
