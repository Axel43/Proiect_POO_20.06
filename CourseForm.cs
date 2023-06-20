using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Proiect_Final_POO
{
    public partial class CourseForm : Form
    {
        CourseClass course = new CourseClass();
        public CourseForm()
        {
            InitializeComponent();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (textBox_CursName.Text == "" || textBox_Ora.Text == "")
            {
                MessageBox.Show("Trebuie sa adaugati datele cursului", "field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string cName = textBox_CursName.Text;
                int chr = Convert.ToInt32(textBox_Ora.Text);
                string desc = textBox_Descriere.Text;

                if (course.insertCourse(cName, chr, desc))
                {
                    showData();
                    button_clear.PerformClick();
                    MessageBox.Show("Ati adaugat curs nou", "Adaugati Curs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cursul nu a fost adaugat", "Adaugati Curs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_CursName.Clear();
            textBox_Ora.Clear();
            textBox_Descriere.Clear();
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {
            showData();
        }
        private void showData()
        {
            // to show curs list in data grid view

            DataGridView_Curs.DataSource = course.getCourse(new MySqlCommand("SELECT * FROM `course`"));
        }
    }
}
