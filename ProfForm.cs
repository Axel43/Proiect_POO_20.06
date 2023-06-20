using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Proiect_Final_POO
{
    public partial class ProfForm : Form
    {
        ProfClass profesori = new ProfClass();
        public ProfForm()
        {
            InitializeComponent();
        }

        bool verify()
        {
            if ((textBox_pNume.Text == "") || (textBox_pPren.Text == "") || (textBox_pMarc.Text == "") || (comboBox1.Text == "") || (comboBox2.Text == ""))
            {
                return false;
            }
            else
                return true;
        }



        

        //to show student list in datagridview
        public void showTable()
        {
            DataGridView_profesori.DataSource = profesori.getProf(new MySqlCommand("SELECT * FROM `profesori`"));
         
        }

        
       

      

        private void ProfForm_Load(object sender, EventArgs e)
        {
            showTable();
        }

        private void button_add_Click_1(object sender, EventArgs e)
        
            {
                //add new student
                string pNume = textBox_pNume.Text;
                string pPren = textBox_pPren.Text;
                string pMarca = textBox_pMarc.Text;
                string pTit = comboBox1.Text;
                string pPost = comboBox2.Text;



                if (verify())
                {
                    try
                    {
                        // To get photo from picture box

                        MemoryStream ms = new MemoryStream();

                        if (profesori.insertProf(pNume, pPren, pMarca, pTit, pPost))
                        {
                            showTable();
                            MessageBox.Show("Profesor nou adaugat", "Adauga profesor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)

                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Field", "Add Profesor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        private void button_clear_Click_1(object sender, EventArgs e)
        {
            textBox_pNume.Clear();
            textBox_pPren.Clear();
            textBox_pMarc.Clear();
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
        }
    }
}
