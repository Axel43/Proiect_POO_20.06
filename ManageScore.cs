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
    public partial class ManageScore : Form
    {
        CourseClass course = new CourseClass();
        ScoreClass score = new ScoreClass();
        public ManageScore()
        {
            InitializeComponent();
        }

        private void ManageScore_Load(object sender, EventArgs e)
        {
            //adaugam cursurile in combobox
            comboBox_SelectCurs.DataSource = course.getCourse(new MySqlCommand("SELECT * FROM `course`"));
            comboBox_SelectCurs.DisplayMember = "CourseName";
            comboBox_SelectCurs.ValueMember = "CourseName";
            ShowScore();
        }
        public void ShowScore()
        {
            DataGridView_Curs.DataSource = score.getList(new MySqlCommand("SELECT score.StudentID,student.Nume,student.Prenume,score.CourseName,score.Score,score.Description FROM student INNER JOIN score ON score.StudentID=student.StudentID"));
        }

        private void button_update_Click(object sender, EventArgs e)
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
                
                    if (score.updateScore(stdId,cName,scor, desc))
                    {
                        ShowScore();
                        button_clear.PerformClick();
                        MessageBox.Show("Nota a fost modificata", "Modificati Nota", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Nota nu a fost modificata", "Modificati Nota", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
               
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            
            if(textBox_Studentid.Text=="")
            {
                MessageBox.Show("Avem nevoie de ID student", "Stergere Nota", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int id = Convert.ToInt32(textBox_Studentid.Text);
                if(MessageBox.Show("Esti sigur ca vrei sa stergi nota?","Sterge nota",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    if(score.DeleteScore(id))
                    {
                        ShowScore();
                        MessageBox.Show("Nota Stearsa", "Stergere Nota", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        button_clear.PerformClick();
                    }
                }
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_Studentid.Clear();
            textBox_Nota.Clear();
            textBox_Descriere.Clear();
            textBox_search.Clear();
        }

        private void DataGridView_Curs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_Studentid.Text = DataGridView_Curs.CurrentRow.Cells[0].Value.ToString();
            comboBox_SelectCurs.Text= DataGridView_Curs.CurrentRow.Cells[3].Value.ToString();
            textBox_Nota.Text = DataGridView_Curs.CurrentRow.Cells[4].Value.ToString();
            textBox_Descriere.Text = DataGridView_Curs.CurrentRow.Cells[3].Value.ToString();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            DataGridView_Curs.DataSource = score.getList(new MySqlCommand("SELECT score.StudentID,student.StudentNume,student.StudentPrenume,score.CourseName,score.Score,score.Description FROM student INNER JOIN score ON score.StudentID=student.StudentID WHERE CONCAT(student.StudentNume,student.StudentPrenume,score.CourseName)LIKE  '%" + textBox_search.Text + "%'"));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
