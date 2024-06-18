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
    public partial class Form1 : Form
    {

        DataBase dataBase = new DataBase();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.ConnectionOpen();

            string fio = textBox1.Text;
            string pribor = textBox2.Text;
            string polomka = comboBox1.Text;
            string status = "в обработке";
            string coment = "-";

            string query = $"insert into application_tbl (fio,pribor,polomka,status_appli,comment) values ('{fio}','{pribor}','{polomka}','{status}','{coment}')";

            NpgsqlCommand command = new NpgsqlCommand(query,dataBase.GetConnection());

            command.ExecuteNonQuery();

            MessageBox.Show("заявка отпарвлена");

            dataBase.ConnectionClose();
        }
    }
}
