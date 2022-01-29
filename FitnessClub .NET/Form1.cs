using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FitnessClubLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessClub_.NET
{
    public partial class FitnessClub_Form : Form
    {
        public FitnessClub_Form()
        {
            InitializeComponent();

            using (FitnessClubContext db = new FitnessClubContext())
            {
                var dataCl = from cl in db.Clients
                             join ch in db.Coaches
                              on cl.Coach equals ch.Id
                             select new {Id = cl.Id, FIO_Client=cl.Fio, PHONE = cl.Phone, Adress = cl.Adress, NameCoach = ch.Fio, PhoneCoach=ch.Phone};
                dataGridViewClient.DataSource = dataCl.ToList();

                var dataCoach = (from ch in db.Coaches select new { ch.Id,ch.Fio, ch.Phone, ch.WorkLevel, ch.Rank });
                dataGridViewCoach.DataSource = dataCoach.ToList();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FitnessClub_Form_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox3.Text == null)
            {
                MessageBox.Show("Ввведите значение для поиска!!!!");
            }

            using (FitnessClubContext db = new FitnessClubContext())
            {
                var coaches = (from c in db.Coaches
                            where c.Fio.Contains(Convert.ToString(textBox3.Text))
                               //EF.Functions.Like(cl.Fio.ToString(),"%'"+ Convert.ToString(textBox3.Text) + "'%")
                               select c).ToList();

                dataGridViewCoach.DataSource = coaches.ToList();
            }
            //try
            //{
            //    SqlConnection connect = new SqlConnection(connStr);
            //    SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
            //    connect.Open();
            //    DataTable dt = new DataTable();
            //    adapter.Fill(dt);
            //    dataGridViewCl.DataSource = dt;
            //    connect.Close();
            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show(ex.Message, "Ошибка работы с БД");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Ошибка");
            //}
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (FitnessClubContext db = new FitnessClubContext())
            {
                var dataCl = (from d in db.Clients select d);
                dataGridViewClient.DataSource = dataCl.ToList();

                var dataCoach = (from d in db.Coaches select d);
                dataGridViewCoach.DataSource = dataCoach.ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox3.Text == null)
            {
                MessageBox.Show("Ввведите значение для поиска!!!!");
            }

            using (FitnessClubContext db = new FitnessClubContext())
            {
                var clients = (from cl in db.Coaches
                               where cl.Fio.Contains(Convert.ToString(textBox2.Text))
                               //EF.Functions.Like(cl.Fio.ToString(),"%'"+ Convert.ToString(textBox3.Text) + "'%")
                               select cl).ToList();

                dataGridViewClient.DataSource = clients.ToList();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (FitnessClubContext db = new FitnessClubContext())
            {
                var dataCl = (from d in db.Clients select d);
                dataGridViewClient.DataSource = dataCl.ToList();

                var dataCoach = (from d in db.Coaches select d);
                dataGridViewCoach.DataSource = dataCoach.ToList();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox2.Text == null)
            {
                MessageBox.Show("Ввведите значение для поиска!!!!");
            }
                using (FitnessClubContext db = new FitnessClubContext())
                {
                    var clients = (from cl in db.Clients
                                   join ch in db.Coaches 
                                   on cl.Coach equals ch.Id
                                   where cl.Fio.Contains(Convert.ToString(textBox2.Text))
                                   //EF.Functions.Like(cl.Fio.ToString(),"%'"+ Convert.ToString(textBox3.Text) + "'%")
                                   select new { Id = cl.Id, FIO_Client = cl.Fio, PHONE = cl.Phone, Adress = cl.Adress, NameCoach = ch.Fio, PhoneCoach = ch.Phone }).ToList();

                    dataGridViewClient.DataSource = clients.ToList();
                }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

            using (FitnessClubContext db = new FitnessClubContext())
            {
                var dataCl = from cl in db.Clients
                             join ch in db.Coaches
                              on cl.Coach equals ch.Id
                             select new { Id = cl.Id, FIO_Client = cl.Fio, PHONE = cl.Phone, Adress = cl.Adress, NameCoach = ch.Fio, PhoneCoach = ch.Phone };
                dataGridViewClient.DataSource = dataCl.ToList();

                var dataCoach = (from ch in db.Coaches select new { ch.Id, ch.Fio, ch.Phone, ch.WorkLevel, ch.Rank });
                dataGridViewCoach.DataSource = dataCoach.ToList();
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == null)
            {
                MessageBox.Show("Ввведите значение для поиска!!!!");
            }
            
            using (FitnessClubContext db = new FitnessClubContext())
                {
                var coach = (from ch in db.Coaches
                             join cl in db.Clients
                             on ch.Id equals cl.Coach
                             where ch.Fio.Contains(Convert.ToString(textBox1.Text))
                             //EF.Functions.Like(cl.Fio.ToString(),"%'"+ Convert.ToString(textBox3.Text) + "'%")
                             select new { Id=ch.Id, FIO_Coach=ch.Fio, Phone=ch.Phone, WLevel=ch.WorkLevel, Rank=ch.Rank, FIO_Clients=cl.Fio }).ToList();

                    dataGridViewCoach.DataSource = coach.ToList();
                }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
