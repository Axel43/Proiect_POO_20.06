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
    public partial class LoginForm : Form
    {
        StudentClass student = new StudentClass();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_username.Text == "" || textBox_password.Text == "")
            {
                MessageBox.Show("Introduceti datele.", "Datele contului sunt gresite.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string uname = textBox_username.Text;
                string pass = textBox_password.Text;
                DataTable table = student.getList(new MySqlCommand("SELECT * FROM `user` WHERE `username`= '" + uname + "' AND `password`= '" + pass + "'"));
                if (table.Rows.Count > 0)
                {
                    MainForm main = new MainForm();
                    this.Hide();
                    main.Show();

                }
                else
                {
                    MessageBox.Show("Contul nu exista!", "Datele contului sunt gresite.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
