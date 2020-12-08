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
    public partial class AddProvForm : Form
    {
        public SQLiteConnection sqlConnection;
        public int id;

        public AddProvForm()
        {
            InitializeComponent();
        }

        /*Отмена*/
        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*Ок*/
        private void bOk_Click(object sender, EventArgs e)
        {
            string sqlQuery = "";
            if (id==0)
                sqlQuery = "Insert into Проведение (Код_мер,Код_орг,Дата) Values ("+txt1.Tag+","+txt2.Tag+",'"+ dt1.Value.ToString("yyyy-MM-dd") + "');";
            else
                sqlQuery = "Update Проведение set Код_мер=" + txt1.Tag + ",Код_орг=" + txt2.Tag +
                                ",Дата='" + dt1.Value.ToString("yyyy-MM-dd") + "' where Код_пров=" + id.ToString();
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

        /*открытие формы*/
        private void AddProvForm_Load(object sender, EventArgs e)
        {
            if (id==0)
            {
                txt1.Clear();
                txt2.Clear();
                dt1.Value = DateTime.Today;
            }
            else
            {
                string str1 = "",str2="",str3="";
                int id1 = 0, id2 = 0;
                sqlConnection.Open();
                SQLiteCommand command = new SQLiteCommand("SELECT Проведение.Код_мер,Проведение.Код_орг,"+
                    "Мероприятия.Наим,Организации.Наим, Дата FROM Проведение,Мероприятия,Организации where Код_пров="+id.ToString(), sqlConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    id1 = reader.GetInt32(0);
                    id2 = reader.GetInt32(1);
                    str1 = reader.GetString(2);
                    str2 = reader.GetString(3);
                    str3 = reader.GetString(4);
                }
                reader.Close();
                sqlConnection.Close();
                txt1.Tag = id1;
                txt2.Tag = id2;
                txt1.Text = str1;
                txt2.Text = str2;
                dt1.Value = Convert.ToDateTime(str3);
            }
        }

        /*выбор мероприятия*/
        private void bCh_Prov_Click(object sender, EventArgs e)
        {
            MerForm f = new MerForm();
            f.sqlConnection = sqlConnection;
            f.b = true;
            f.ShowDialog();
            txt1.Tag = f.id;
            txt1.Text = f.dataS;
        }

        /*выбор организации*/
        private void bCh_Org_Click(object sender, EventArgs e)
        {
            OrgForm f = new OrgForm();
            f.sqlConnection = sqlConnection;
            f.b = true;
            f.ShowDialog();
            txt2.Tag = f.id;
            txt2.Text = f.dataS;
        }
    }
}
