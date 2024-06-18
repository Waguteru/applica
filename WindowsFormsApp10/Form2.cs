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
    public partial class Form2 : Form
    {
        DataBase dataBase = new DataBase();


        public Form2()
        {
            InitializeComponent();
        }

        public void CreateColumns()
        {
            dataGridView1.Columns.Add("fio", "фамилия");
            dataGridView1.Columns.Add("pribor", "прибор");
            dataGridView1.Columns.Add("polomka", "поломка");
            dataGridView1.Columns.Add("status_appli", "статус");
            dataGridView1.Columns.Add("comment", "комментарий");
        }

        public void ReadSingleRow(DataGridView gridView,IDataRecord record)
        {
            gridView.Rows.Add(record.GetString(0),record.GetString(1),record.GetString(2),record.GetString(3),record.GetString(4));
        }

        public void RefreshData(DataGridView gridView)
        {
            gridView.Rows.Clear();

            dataBase.ConnectionOpen();

            string query = "select fio,pribor,polomka,status_appli,comment from application_tbl";

            NpgsqlCommand command = new NpgsqlCommand(query,dataBase.GetConnection());

            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(gridView,reader);
            }
            reader.Close();
            dataBase.ConnectionClose();

        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshData(dataGridView1);
        }
    }
}
