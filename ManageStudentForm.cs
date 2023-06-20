using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace Proiect_Final_POO
{
    public partial class ManageStudentForm : Form
    {
        StudentClass student = new StudentClass();
        public ManageStudentForm()
        {
            InitializeComponent();
        }

        private void ManageStudentForm_Load(object sender, EventArgs e)
        {
            showTable();
        }

       
        //to show student list in datagridview
        public void showTable()
        {
            DataGridView_student.DataSource = student.getStudentlist(new MySqlCommand("SELECT * FROM `student`"));
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_student.Columns[7];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        //Display student data from student to textbox
        private void DataGridView_student_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_Id.Text = DataGridView_student.CurrentRow.Cells[0].Value.ToString();
            textBox_Fname.Text= DataGridView_student.CurrentRow.Cells[1].Value.ToString();
            textBox_Lname.Text= DataGridView_student.CurrentRow.Cells[2].Value.ToString();

            dateTimePicker1.Value=(DateTime)DataGridView_student.CurrentRow.Cells[3].Value;
            if (DataGridView_student.CurrentRow.Cells[5].Value.ToString() == "Male")
                radioButton_male.Checked = true;

            textBox_phone.Text= DataGridView_student.CurrentRow.Cells[4].Value.ToString();
            textBox_address.Text= DataGridView_student.CurrentRow.Cells[6].Value.ToString();
            byte[] img=(byte[])DataGridView_student.CurrentRow.Cells[7].Value;
            MemoryStream ms = new MemoryStream(img);
            pictureBox_student.Image = Image.FromStream(ms);
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_Id.Clear();
            textBox_Fname.Clear();
            textBox_Lname.Clear();
            textBox_phone.Clear();
            textBox_address.Clear();
            pictureBox_student.Image = null;
            dateTimePicker1.Value = DateTime.Now;
            radioButton_male.Checked = true;
        }

        private void button_upload_Click(object sender, EventArgs e)
        {
            //browse photo
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Photo(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
                pictureBox_student.Image = Image.FromFile(opf.FileName);
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            
                DataGridView_student.DataSource = student.getStudentlist(new MySqlCommand("SELECT * FROM `student` WHERE CONCAT(`Nume`)LIKE '%" + textBox_search.Text + "%'"));
                textBox_search.Clear();
            
            // DataGridView_student.DataSource = student.searchStudent(textBox_search.Text);
            // DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            //  imageColumn = (DataGridViewImageColumn)DataGridView_student.Columns[7];
            // imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
        bool verify()
        {
            if ((textBox_Fname.Text == "") || (textBox_Lname.Text == "") || (textBox_phone.Text == "") || (textBox_address.Text == "") || (pictureBox_student.Image == null))
            {
                return false;
            }
            else
                return true;
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            //update student
            int id = Convert.ToInt32(textBox_Id.Text);
            string fname = textBox_Fname.Text;
            string lname = textBox_Lname.Text;
            DateTime bdate = dateTimePicker1.Value;
            string phone = textBox_phone.Text;
            string address = textBox_address.Text;
            string gender = radioButton_male.Checked ? "Male" : "Female";



            //verificam daca varsta este intre 10 si 100 ani

            int born_year = dateTimePicker1.Value.Year;
            int this_year = DateTime.Now.Year;

            if ((this_year - born_year) < 10 || (this_year - born_year) > 100)
            {
                MessageBox.Show("studentul Nu se incadreaza in limta de varsta(10 ani-100 ani)", "Invalid Birthadte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verify())
            {
                try
                {
                    // To get photo from picture box

                    MemoryStream ms = new MemoryStream();
                    pictureBox_student.Image.Save(ms, pictureBox_student.Image.RawFormat);
                    byte[] img = ms.ToArray();

                    if (student.updateStudent(id,fname, lname, bdate, gender, phone, address, img))
                    {
                        showTable();
                        MessageBox.Show("Student modificat", "Update student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Field", "Update Studnet", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            //remove the select student
            if (textBox_Id.Text.Equals(""))
            {
                MessageBox.Show("Trebuie sa adaugati Id student", "field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int id = Convert.ToInt32(textBox_Id.Text);
                    if (student.deleteStudent(id))
                    {
                        showTable();
                        button_clear.PerformClick();
                        MessageBox.Show("Studentul a fost sters cu succes!", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)


                {
                    MessageBox.Show(ex.Message, "Stergere Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
    }

