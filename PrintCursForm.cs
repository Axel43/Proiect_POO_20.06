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
using DGVPrinterHelper;

namespace Proiect_Final_POO
{
    public partial class PrintCursForm : Form
    {
        CourseClass course = new CourseClass();
        DGVPrinter printer = new DGVPrinter();
        public PrintCursForm()
        {
            InitializeComponent();
        }

        private void button_srch_Click(object sender, EventArgs e)
        {
            DataGridView_student.DataSource = course.getCourse(new MySqlCommand("SELECT * FROM `course` WHERE CONCAT(`CourseName`)LIKE '%" + textBox_search.Text + "%'"));
            textBox_search.Clear();
        }

        private void button_Print_Click(object sender, EventArgs e)
        {
            printer.Title = "Cursuri";
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Learn";
            printer.FooterSpacing = 15;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(DataGridView_student);
        }

        private void PrintCursForm_Load(object sender, EventArgs e)
        {
            DataGridView_student.DataSource = course.getCourse(new MySqlCommand("SELECT * FROM `course`"));
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
