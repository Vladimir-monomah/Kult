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
using System.Threading;
using System.Net;
using System.Net.Mail;

namespace Kult
{
    public partial class SendForm : Form
    {
        public SQLiteConnection sqlConnection;
        public int id;

        public SendForm()
        {
            InitializeComponent();
        }

        /*открытие формы*/
        private void SendForm_Load(object sender, EventArgs e)
        {
            lB1.Items.Clear();
            lB2.Items.Clear();
            sqlConnection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT Сотрудники.Код_сотр," +
                "(Сотрудники.Фамилия || ' ' || substr(Сотрудники.Имя,1,1) || '.' || substr(Сотрудники.Отчество,1,1)  || '.') as ФИО " +
                "FROM ПроведениеСотрудники,Сотрудники where (Код_пров=" + id + ") and " +
                "(Сотрудники.Код_сотр=ПроведениеСотрудники.Код_сотр) order by ФИО", sqlConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lB1.Items.Add(reader.GetString(1));
                lB2.Items.Add(reader.GetInt32(0).ToString());
            }
            reader.Close();
            sqlConnection.Close();
        }

        /*получаем почту*/
        private string GetMail(string id_sotr)
        {
            string str = "";
            sqlConnection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT Почта FROM Сотрудники where (Код_сотр=" + id_sotr + ")", sqlConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                str=reader.GetString(0);
            }
            reader.Close();
            sqlConnection.Close();
            return str;
        }

        /*получаем почту отправителя*/
        private string GetAdminMail()
        {
            string str = "";
            sqlConnection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT Почта FROM Настройка", sqlConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                str = reader.GetString(0);
            }
            reader.Close();
            sqlConnection.Close();
            return str;
        }

        /*получаем почту отправителя*/
        private string GetAdminMailPass()
        {
            string str = "";
            sqlConnection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT ПарольПочта FROM Настройка", sqlConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                str = reader.GetString(0);
            }
            reader.Close();
            sqlConnection.Close();
            return str;
        }

        /*отправка почты участникам*/
        private void sendMessage()
        {
            string email1 = GetAdminMail();
            string pass = GetAdminMailPass();
            string theme = txtTheme.Text;
            string mess = txtMess.Text;
            string filepath = txtFile.Text;
            for (int i = 0; i < lB1.Items.Count; i++)
            {
                string email2 = GetMail(lB2.Items[i].ToString());
                if ((email1.Equals("")) | (email2.Equals("")) | (theme.Equals("")) | (pass.Equals("")))
                    MessageBox.Show("Заполните обязательные поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    string s = lB1.Items[i].ToString();
                    string pp = "";
                    int ii = 0;

                    if (email1.IndexOf("@yandex.ru") > 0)
                    {
                        pp = "smtp.yandex.ru";
                        ii =25;
                    }
                    if (email1.IndexOf("@mail.ru") > 0)
                    {
                        pp = "smtp.mail.ru";
                        ii = 465;
                    }
                    if (email1.IndexOf("@gmail.com") > 0)
                    {
                        pp = "smtp.gmail.com";
                        ii = 587;
                    }
                    if (SendMail(""+pp+"", ii, email1, pass, email2, theme, mess, filepath)) s = s + " - отправлено"; else s = s + " - не отправлено";
                    Action action = () => lB1.Items.RemoveAt(i);
                    lB1.Invoke(action);
                    action = () => lB1.Items.Insert(i, s);
                    lB1.Invoke(action);
                    Thread.Sleep(500);
                }
            }
        }

        /*отправить*/
        private void bSend_Click(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(this.sendMessage);
            thread1.IsBackground = true;
            thread1.Start();
        }                        

        /*отправка почты
         если используем gmail, то "smtp.gmail.com", порт 587 
         если используем yandex, то "smtp.yandex.ru", порт 25 
         если используем mail, то "smtp.mail.ru", порт 465*/
        private bool SendMail(string smtpServer, int port, string from, string password, string mailto, string caption, string message, string attachFile = null)
        {
            bool b = true;
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(mailto));
                mail.Subject = caption;
                mail.Body = message;
                if (!string.IsNullOrEmpty(attachFile))
                    mail.Attachments.Add(new Attachment(attachFile));
                SmtpClient client = new SmtpClient();
                client.Host = smtpServer;
                client.Port = port;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from.Split('@')[0], password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                mail.Dispose();
            }
            catch (Exception)
            {
                b = false;
            }
            return b;
        }

        /*Выбрать файл*/
        private void bCh_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Filter = "Файлы|*.*";
            OPF.InitialDirectory = Application.StartupPath;
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = String.Format(@OPF.FileName.ToString());
            }
        }
    }
}
