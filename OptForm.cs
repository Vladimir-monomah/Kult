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
using System.IO;

namespace Kult
{
    public partial class OptForm : Form
    {
        public SQLiteConnection sqlConnection;
        public string pass;
        private bool empt;

        public OptForm()
        {
            InitializeComponent();
        }

        /*открытие формы*/
        private void OptForm_Load(object sender, EventArgs e)
        {
            string s1 = "", s2 = "", s3 = "",s4="";
            sqlConnection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM Настройка", sqlConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            empt = true;
            if (reader.Read())
            {
                s1 = reader.GetString(0);
                s2 = reader.GetString(1);
                s3 = reader.GetString(2);
                s4 = reader.GetString(3);
                empt = false;
            }
            reader.Close();
            sqlConnection.Close();
            txtEmail.Text = s1;
            txtEmailPass.Text = s2;
            txtQ.Text = s3;
            txtA.Text = s4;
            txtPass.Text = GetPass();
        }

        /*Получаем пароль из файла*/
        private string GetPass()
        {
            /*Считываем пароль*/
            StreamReader SW = new StreamReader(Application.StartupPath + "\\pass.txt", System.Text.Encoding.Default);
            string s = SW.ReadLine();
            SW.Close();
            string s1 = Shifr.DeShifrovka(s, pass);
            return s1;
        }

        /*Отмена*/
        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void WritePass(string s)
        {
            StreamWriter SW = new StreamWriter(Application.StartupPath + "\\pass.txt", false, System.Text.Encoding.Default);
            s = Shifr.Shifrovka(s, pass);
            SW.WriteLine(s);
            SW.Close();
        }

        /*Ок*/
        private void bOk_Click(object sender, EventArgs e)
        {
            WritePass(txtPass.Text);
            string sqlQuery = "";
            if (empt)
            {
                sqlQuery = "INSERT INTO Настройка (Почта,ПарольПочта,КВопрос,КОтвет) Values ('" + txtEmail.Text + "', '" + txtEmailPass.Text + "','" +
                txtQ.Text + "','"+txtA.Text+"');";
            }
            else
            {
                sqlQuery = "UPDATE Настройка Set Почта='" + txtEmail.Text + "',ПарольПочта='" + txtEmailPass.Text + "',КВопрос='" +
                txtQ.Text + "',КОтвет='" + txtA.Text+ "';";
            }
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
                    MessageBox.Show("Настройки сохранены","Запись изменений", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sqlConnection.Close();
                    Close();
                }
            }
        }
    }
}
