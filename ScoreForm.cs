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
    public partial class ScoreForm : Form
    {
        CourseClass course = new CourseClass();
        StudentClass student = new StudentClass();
        ScoreClass score = new ScoreClass();
        public ScoreForm()
        {
            InitializeComponent();
        }

        //create a function to show data on datagridview score
        private void ShowScore()
        {
            DataGridView_Student.DataSource = score.getList(new MySqlCommand("SELECT score.StudentID,student.Nume,student.Prenume,score.CourseName,score.Score,score.Description FROM student INNER JOIN score ON score.StudentID=student.StudentID"));
        }


        private void ScoreForm_Load(object sender, EventArgs e)
        {
            //adaugam cursurile in combobox
            comboBox_SelectCurs.DataSource = course.getCourse(new MySqlCommand("SELECT * FROM `course`"));
            comboBox_SelectCurs.DisplayMember = "CourseName";
            comboBox_SelectCurs.ValueMember = "CourseName";

            
            //to display student list on datagridview
            DataGridView_Student.DataSource = student.getList(new MySqlCommand("SELECT `StudentID`,`Nume`,`Prenume` FROM `student`"));

        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (textBox_Studentid.Text == "" || textBox_Nota.Text == "")
            {
                MessageBox.Show("Trebuie sa adaugati Id student si nota", "field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int stdId = Convert.ToInt32(textBox_Studentid.Text);
                string cName = comboBox_SelectCurs.Text;
                double scor = Convert.ToInt32(textBox_Nota.Text);
                string desc = textBox_Descriere.Text;
                if (!score.checkScore(stdId, cName))
                {

                    if (score.insertScore(stdId, cName, scor, desc))
                    {
                        ShowScore();
                        button_clear.PerformClick();
                        MessageBox.Show("Ati adaugat nota noua", "Adaugati Nota", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Nota nu a fost adaugata", "Adaugati nota", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Nota deja exista", "Adauga Nota", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_Studentid.Clear();
            textBox_Nota.Clear();
            comboBox_SelectCurs.SelectedIndex = 0;
            textBox_Descriere.Clear();
        }

        private void DataGridView_Student_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_Studentid.Text = DataGridView_Student.CurrentRow.Cells[0].Value.ToString();
        }

        private void button_ListaStudenti_Click(object sender, EventArgs e)
        {
            DataGridView_Student.DataSource = student.getList(new MySqlCommand("SELECT `StudentID`,`Nume`,`Prenume` FROM `student`"));
        }

        private void button_ListaNote_Click(object sender, EventArgs e)
        {
            ShowScore();
        }
    }
}
