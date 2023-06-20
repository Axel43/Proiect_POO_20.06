using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Proiect_Final_POO
{

    /*
     * 
     * In Aceasta clasa facem Conexiunea cu Baza de Date
     * 
     */
    class DBconnect
    {
        MySqlConnection connect = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=studentdb");

        public MySqlConnection GetConnection
        {
            get
            {
                return connect;
            }
        }

        public void openConnect()
        {
            if (connect.State == System.Data.ConnectionState.Closed)
                connect.Open();
        }
        public void CloseConnect()
        {
            if (connect.State == System.Data.ConnectionState.Open)
                connect.Close();
        }
    }
}
