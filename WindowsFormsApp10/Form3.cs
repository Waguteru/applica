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
    public partial class Form3 : Form
    {

        DataBase dataBase = new DataBase();

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.ConnectionOpen();

            string login = textBox1.Text;
            string password = textBox2.Text;
            string role = "пользователь";

            string query = $"insert into users (login_users,password_users,roles) values ('{login}','{password}','{role}')";

            NpgsqlCommand command = new NpgsqlCommand(query,dataBase.GetConnection());

            command.ExecuteNonQuery();

            Form4 form4 = new Form4();
            this.Hide();
            form4.ShowDialog(); 
            this.Close();

            dataBase.ConnectionClose();
        }
    }
}
