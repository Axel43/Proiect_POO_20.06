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
using DGVPrinterHelper;

namespace Proiect_Final_POO
{
    public partial class PrintStudentForm : Form
    {
        StudentClass student = new StudentClass();
        DGVPrinter printer = new DGVPrinter();
        public PrintStudentForm()
        {
            InitializeComponent();
        }

        private void PrintStudentForm_Load(object sender, EventArgs e)
        {
            showData(new MySqlCommand("SELECT * FROM `student`"));
        }

        //show the student list in data grid view
        public void showData(MySqlCommand command)
        {
            DataGridView_student.ReadOnly = true;
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            DataGridView_student.DataSource = student.getList(command);

            imageColumn = (DataGridViewImageColumn)DataGridView_student.Columns[7];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            //check the radio button
            string selectQuery;
            if(radioButton_all.Checked)
            {
                selectQuery = "SELECT * FROM `student`";
            }
            else if(radioButton_male.Checked)
            {
                selectQuery = "SELECT * FROM `student` WHERE `Sex`= 'Male'";

            }
            else
            {
                selectQuery = "SELECT * FROM `student` WHERE `Sex`= 'Female'";
            }
            showData(new MySqlCommand(selectQuery));
        }

        private void button_Print_Click(object sender, EventArgs e)
        {
            printer.Title = "Studenti UNITBV";
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
    }
}
