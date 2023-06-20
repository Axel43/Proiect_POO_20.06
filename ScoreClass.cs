using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_Final_POO
{
    class ScoreClass
    {
        DBconnect connect = new DBconnect();

        public bool insertScore(int stdid,string CoursName,double scor, string desc)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `score`(`StudentID`, `CourseName`, `Score`, `Description`) VALUES (@stid,@cn,@sco,@desc)", connect.GetConnection);

            //@stid,@cn,@sco,@desc

            command.Parameters.Add("@stid", MySqlDbType.Int32).Value = stdid;
            command.Parameters.Add("@cn", MySqlDbType.VarChar).Value = CoursName;
            command.Parameters.Add("@sco", MySqlDbType.Double).Value = scor;
            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = desc;
            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.CloseConnect();
                return true;
            }
            else
            {
                connect.CloseConnect();
                return false;
            }
        }
        //Create a function to edit score
        public bool updateScore(int stdid,string scn, double scor, string desc)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `score` SET `Score`=@sco,`Description`=@desc WHERE `StudentID`=@stid AND `CourseName`=@scn", connect.GetConnection);

            //@stid,@sco,@desc,@scn
            command.Parameters.Add("@scn", MySqlDbType.VarChar).Value = scn;
            command.Parameters.Add("@sco", MySqlDbType.Double).Value = scor;
            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = desc;
            command.Parameters.Add("@stid", MySqlDbType.Int32).Value = stdid;
            
            
            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.CloseConnect();
                return true;
            }
            else
            {
                connect.CloseConnect();
                return false;
            }
        }

        // insert function to get list

        public DataTable getList(MySqlCommand command)
        {
            command.Connection = connect.GetConnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        //Cream o functie pentru a verifica scorul existent
        public bool checkScore(int stdid,string cName)
        {
            DataTable table = getList(new MySqlCommand("SELECT * FROM `score` WHERE `StudentID`= '" + stdid + "' AND `CourseName`= '" + cName +"'"));
            if(table.Rows.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Creare functie pentru stergerea notei

        public bool DeleteScore(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `score` WHERE `StudentID`=@id", connect.GetConnection);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.CloseConnect();
                return true;
            }
            else
            {
                connect.CloseConnect();
                return false;
            }
        }
    }
}
