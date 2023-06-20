using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Proiect_Final_POO
{
    class ProfClass
    {
        DBconnect connect = new DBconnect();

        //Cream o functie pentru a insera profesori

        public bool insertProf(string pNume, string pPren, string pMarc, string pTit, string pPost)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `profesori`(`Nume`, `Prenume`, `Marca`, `Titlu`, `Post`) VALUES (@pn,@pp,@marc,@tit,@post)", connect.GetConnection);

            //@cn,@ch,@desc

            command.Parameters.Add("@pn", MySqlDbType.VarChar).Value = pNume;
            command.Parameters.Add("@pp", MySqlDbType.VarChar).Value = pPren;
            command.Parameters.Add("@marc", MySqlDbType.VarChar).Value = pMarc;
            command.Parameters.Add("@tit", MySqlDbType.VarChar).Value = pTit;
            command.Parameters.Add("@post", MySqlDbType.VarChar).Value = pPost;

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

        // Create a function to get course list
        public DataTable getProf(MySqlCommand command)
        {
            command.Connection = connect.GetConnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        // create an update function
        public bool updateProf(int pId, string pNume, string pPren, string pMarc, string pTit, string pPost)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `profesori` SET `Nume`=@pn,`Prenume`=@pp,`Marca`=@marc,`Titlu`=@tit,`Post`=@post WHERE `ProfesorId`=@pid", connect.GetConnection);

            //@id,@cn,@ch,@desc
            command.Parameters.Add("@pid", MySqlDbType.Int32).Value = pId;
            command.Parameters.Add("@pn", MySqlDbType.VarChar).Value = pNume;
            command.Parameters.Add("@pp", MySqlDbType.VarChar).Value = pPren;
            command.Parameters.Add("@marc", MySqlDbType.VarChar).Value = pMarc;
            command.Parameters.Add("@tit", MySqlDbType.VarChar).Value = pTit;
            command.Parameters.Add("@post", MySqlDbType.VarChar).Value = pPost;

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

        // Create a function to Delete a course
        public bool deleteProf(int pId)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `profesori` WHERE `ProfesorId`=@id", connect.GetConnection);
            command.Parameters.Add("@pid", MySqlDbType.Int32).Value = pId;
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
