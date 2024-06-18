using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp10
{
    public partial class Form5 : Form
    {
        DataBase dataBase = new DataBase();

        int selected;

        public Form5()
        {
            InitializeComponent();
        }


        public void CreateColumns()
        {
            dataGridView1.Columns.Add("id_appli", "номер");
            dataGridView1.Columns.Add("fio", "фамилия");
            dataGridView1.Columns.Add("pribor", "прибор");
            dataGridView1.Columns.Add("polomka", "поломка");
            dataGridView1.Columns.Add("status_appli", "статус");
            dataGridView1.Columns.Add("comment", "комментарий");
        }

        public void ReadSingleRow(DataGridView gridView, IDataRecord record)
        {
            gridView.Rows.Add(record.GetInt64(0),record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5));
        }

        public void RefreshData(DataGridView gridView)
        {
            gridView.Rows.Clear();

            dataBase.ConnectionOpen();

            string query = "select * from application_tbl";

            NpgsqlCommand command = new NpgsqlCommand(query, dataBase.GetConnection());

            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(gridView, reader);
            }
            reader.Close();
            dataBase.ConnectionClose();

        }

        private void button1_Click(object sender, EventArgs e)
        {
           dataBase.ConnectionOpen();

            string status = comboBox1.Text;
            string comment = textBox1.Text;
            var id = textBox2.Text;

            string query = $"update application_tbl set status_appli = '{status}',comment = '{comment}' where id_appli = " + id;

            NpgsqlCommand command = new NpgsqlCommand(query,dataBase.GetConnection());

            command.ExecuteNonQuery();

            MessageBox.Show("заявка обновлена");

            RefreshData(dataGridView1);

            dataBase.ConnectionClose();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshData(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selected = e.RowIndex;

            if(selected >= 0)
            {
                DataGridViewRow viewRow = dataGridView1.Rows[selected];
                comboBox1.Text = viewRow.Cells[4].Value.ToString();
                textBox1.Text = viewRow.Cells[5].Value.ToString();
                textBox2.Text = viewRow.Cells[0].Value.ToString();
                textBox3.Text = viewRow.Cells[1].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataBase.ConnectionOpen();

           
            var id = textBox2.Text;

            string query = $"DELETE FROM application_tbl where id_appli = " + id;

            NpgsqlCommand command = new NpgsqlCommand(query, dataBase.GetConnection());

            command.ExecuteNonQuery();

            MessageBox.Show("заявка УДАЛЕНА");

            RefreshData(dataGridView1);

            dataBase.ConnectionClose();
        }
    }
}
