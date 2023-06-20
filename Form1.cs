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
    public partial class MainForm : Form
    {
        StudentClass student = new StudentClass();
        public MainForm()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            studentCount();
        }

        //create a function to diplay student count

        private void studentCount()
        {
            //afisam razulatul de la studentcount
            label_totalstd.Text = "Total Studenti: " + student.totalStudent();
            label_famelestd.Text = "Fete: " + student.femaletudent();
            label_malestd.Text = "Baieti: " + student.maleStudent();
        }

        private void customizeDesign()
        {
            panel_StdSubmenu.Visible = false;
            panel_CourseSubmenu.Visible = false;
            panel_ScoreSubmenu.Visible = false;
            panel_ProfSubmenu.Visible = false;  
        }

        private void hideSubmenu()
        {
            if (panel_CourseSubmenu.Visible == true)
                panel_CourseSubmenu.Visible = false;
            if (panel_StdSubmenu.Visible == true)
                panel_StdSubmenu.Visible = false;
            if (panel_ScoreSubmenu.Visible == true)
                panel_ScoreSubmenu.Visible = false;
            if(panel_ProfSubmenu.Visible == true)
                panel_ProfSubmenu.Visible = false;  
        }

        private void showSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {   //// your code
                hideSubmenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }

        private void button_Student_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_StdSubmenu);
        }

        private void button_AddStudnet_Click(object sender, EventArgs e)
        {

            openChildForm(new RegisterForm());
            //// your code
            hideSubmenu();
        }

        private void button_ManageStudent_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageStudentForm());
            //// your code
            hideSubmenu();
        }

        private void button_Status_Click(object sender, EventArgs e)
        {
            //// your code
            hideSubmenu();
        }

        private void button_PrintStd_Click(object sender, EventArgs e)
        {
            openChildForm(new PrintStudentForm());
            //// your code
            hideSubmenu();
        }

        private void button_Course_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_CourseSubmenu);
        }

        private void button_AddCourse_Click(object sender, EventArgs e)
        {
            openChildForm(new CourseForm());
            //// your code
            hideSubmenu();
        }

        private void button_ManageCourse_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageCursForm());
            //// your code
            hideSubmenu();
        }

        private void button_PrintCourse_Click(object sender, EventArgs e)
        {
            openChildForm(new PrintCursForm());
            //// your code
            hideSubmenu();
        }

        private void button_Score_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_ScoreSubmenu);
        }

        private void button_AddScore_Click(object sender, EventArgs e)
        {
            openChildForm(new ScoreForm());
            //// your code
            hideSubmenu();
        }

        private void button_ManageScore_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageScore());
            //// your code
            hideSubmenu();
        }

        private void button_PrintScore_Click(object sender, EventArgs e)
        {
            //// your code
            hideSubmenu();
        }

        //to show register form in mainform
        private Form activeFrom = null;
        private void openChildForm(Form childForm)
        {
            if (activeFrom != null)
                activeFrom.Close();
            activeFrom = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_main.Controls.Add(childForm);
            panel_main.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button_Dashboard_Click(object sender, EventArgs e)
        {
            if (activeFrom != null)
                activeFrom.Close();
            panel_main.Controls.Add(panel_cover);
            studentCount();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new PrintStudentForm());
            //// your code
            hideSubmenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_ProfSubmenu);
        }

        private void button_AddProf_Click(object sender, EventArgs e)
        {
            openChildForm(new ProfForm());
            //// your code
            hideSubmenu();
        }

        private void button_ManageProf_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageProfesori());
            //// your code
            hideSubmenu();
        }


    }
}
