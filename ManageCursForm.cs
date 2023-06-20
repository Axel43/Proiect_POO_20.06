using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Proiect_Final_POO
{
    public partial class ManageCursForm : Form
    {
        CourseClass course = new CourseClass();
        public ManageCursForm()
        {
            InitializeComponent();
        }

        private void ManageCursForm_Load(object sender, EventArgs e)
        {
            showData();
        }

        // Show cuurse data
        private void showData()
        {
            // to show curs list in data grid view

            DataGridView_Curs.DataSource = course.getCourse(new MySqlCommand("SELECT * FROM `course`"));
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_Id.Clear();
            textBox_CursName.Clear();
            textBox_Ora.Clear();
            textBox_Descriere.Clear();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if (textBox_CursName.Text == "" || textBox_Ora.Text == ""|| textBox_Id.Text.Equals(""))
            {
                MessageBox.Show("Trebuie sa adaugati datele cursului", "field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int id = Convert.ToInt32(textBox_Id.Text);
                string cName = textBox_CursName.Text;
                int chr = Convert.ToInt32(textBox_Ora.Text);
                string desc = textBox_Descriere.Text;

                if (course.updateCourse(id,cName, chr, desc))
                {
                    showData();
                    button_clear.PerformClick();
                    MessageBox.Show("Cursul a fost modificat", "Update Curs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cursul nu a fost modificat", "Update Curs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (textBox_Id.Text.Equals(""))
            {
                MessageBox.Show("Trebuie sa adaugati Id curs now", "field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int id = Convert.ToInt32(textBox_Id.Text);
                    if (course.deleteCourse(id))
                    {
                        showData();
                        button_clear.PerformClick();
                        MessageBox.Show("Cursul a fost sters cu succes!", "Delete Curs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)


                {
                    MessageBox.Show(ex.Message, "Stergere Curs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DataGridView_Curs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_Id.Text = DataGridView_Curs.CurrentRow.Cells[0].Value.ToString();
            textBox_CursName.Text= DataGridView_Curs.CurrentRow.Cells[1].Value.ToString();
            textBox_Ora.Text= DataGridView_Curs.CurrentRow.Cells[2].Value.ToString();
            textBox_Descriere.Text= DataGridView_Curs.CurrentRow.Cells[3].Value.ToString();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            DataGridView_Curs.DataSource = course.getCourse(new MySqlCommand("SELECT * FROM `course` WHERE CONCAT(`CourseName`)LIKE '%" + textBox_search.Text + "%'"));
            textBox_search.Clear();
        }

        private void DataGridView_Curs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
