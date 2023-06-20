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
using static System.Windows.Forms.AxHost;
using System.Net;
using System.Xml.Linq;

namespace Proiect_Final_POO
{
    public partial class ManageProfesori : Form
    {
        ProfClass profesor = new ProfClass();
        public ManageProfesori()
        {
            InitializeComponent();
        }

        private void ManageProfesori_Load(object sender, EventArgs e)
        {
            showTable();
        }


        //to show student list in datagridview
        public void showTable()
        {
            DataGridView_profesori.DataSource = profesor.getProf(new MySqlCommand("SELECT * FROM `profesori`"));
            
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


        private void button_delete_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView_profesori_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox_Id.Text = DataGridView_profesori.CurrentRow.Cells[0].Value.ToString();
            textBox_pNume.Text = DataGridView_profesori.CurrentRow.Cells[1].Value.ToString();
            textBox_pPren.Text = DataGridView_profesori.CurrentRow.Cells[2].Value.ToString();
            textBox_pMarc.Text = DataGridView_profesori.CurrentRow.Cells[4].Value.ToString();
            comboBox1.Text = DataGridView_profesori.CurrentRow.Cells[4].Value.ToString();
            comboBox2.Text = DataGridView_profesori.CurrentRow.Cells[4].Value.ToString();
        }

        private void button1_clear_Click(object sender, EventArgs e)
        {
            textBox_Id.Clear();
            textBox_pNume.Clear();
            textBox_pPren.Clear();
            textBox_pMarc.Clear();
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
        }

        private void button_search_Click_1(object sender, EventArgs e)
        {
            DataGridView_profesori.DataSource = profesor.getProf(new MySqlCommand("SELECT * FROM `profesori` WHERE CONCAT(`Nume`)LIKE '%" + textBox_search.Text + "%'"));
            textBox_search.Clear();
        }

        private void button3_update_Click(object sender, EventArgs e)
        {
            //update prof
            int id = Convert.ToInt32(textBox_Id.Text);
            string pNume = textBox_pNume.Text;
            string pPren = textBox_pPren.Text;
            string pMarca = textBox_pMarc.Text;
            string pTit = comboBox1.Text;
            string pPost = comboBox2.Text;

            if (verify())
            {
                try
                {
                    if (profesor.updateProf(id, pNume, pPren, pMarca, pTit, pPost))
                    {
                        showTable();
                        MessageBox.Show("Profesor modificat", "Update profesor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Field", "Update Profesor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
