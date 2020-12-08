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
    public partial class AddResultForm : Form
    {
        public SQLiteConnection sqlConnection;
        public int id;

        public AddResultForm()
        {
            InitializeComponent();
        }

        /*открытие формы*/
        private void AddResultForm_Load(object sender, EventArgs e)
        {
            string str = "";
            sqlConnection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT Результат FROM Проведение where Код_пров=" + id.ToString(), sqlConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                str = reader.GetString(0);
            }
            reader.Close();
            sqlConnection.Close();
            txt1.Text = str;
        }

        /*Сохранить*/
        private void bSave_Click(object sender, EventArgs e)
        {
            string sqlQuery = "Update Проведение set Результат='" + txt1.Text + "' where Код_пров=" + id.ToString();
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
                    Close();
                }
            }
        }
    }
}
