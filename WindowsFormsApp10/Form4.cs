using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp10
{
    public partial class Form4 : Form
    {

        private bool closed = false;

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login_users = textBox1.Text;
            string password_users = textBox2.Text;

            if(closed)
            {
                return;
            }
            else if (CheckUser(login_users, password_users))
            {
                ShowRoleUser(login_users);
            }
        }

        string connectionSt = "Server = localhost; port = 5432; DataBase = application_test; User Id = postgres; Password = 123";

        private bool CheckUser(string login_users, string password_users)
        {
            using(NpgsqlConnection  conn = new NpgsqlConnection(connectionSt))
            {
                string query = $"SELECT COUNT(*) FROM users where login_users = @login_users and password_users = @password_users";
                using(NpgsqlCommand command = new NpgsqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("login_users", login_users);
                    command.Parameters.AddWithValue("password_users", password_users);

                    conn.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        private void ShowRoleUser( string login_users)
        {
            string role = GetRoleUser(login_users);

            if(role == "работник")
            {
                Form5 form5 = new Form5();
                this.Hide();
                form5.ShowDialog();
                this.Close();
            }
            else if(role == "пользователь")
            {
                Form2 form2 = new Form2();
                this.Hide();
                form2.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("роль не найдена");
            }
        }

        public string GetRoleUser(string login_users)
        {
            string role = "";
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionSt))
            {
                string query = "select roles from users where login_users = @login_users";

                using(NpgsqlCommand command = new NpgsqlCommand(query,conn))
                {
                    command.Parameters.AddWithValue("@login_users", login_users);

                    try
                    {
                        conn.Open();

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            role = result.ToString();
                        }
                        else
                        {
                            MessageBox.Show("ошибка при получекнии роли");
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show($"ошибка:{ex.Message}");
                    }
                  
                }
            }
            return role;
        }
    }
}
