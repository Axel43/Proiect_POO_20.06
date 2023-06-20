using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Proiect_Final_POO
{
    class StudentClass
    {
        DBconnect connect = new DBconnect();

        
        public bool insertStudent(string fname,string lname,DateTime bdate,string gender,string phone,string adress, byte[] img)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `student`(`Nume`, `Prenume`, `DataInscriere`, `CNP`, `Gen`, `Media`,`Poza`) VALUES(@fn, @ln, @bd, @ph, @gd, @adr, @img)", connect.GetConnection);

            //     @fn, @ln, @bd, @ph, @gd, @adr, @img, @in

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bd", MySqlDbType.Date).Value = bdate;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@gd", MySqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@adr", MySqlDbType.Double).Value = adress;
            command.Parameters.Add("@img", MySqlDbType.Blob).Value = img;

            connect.openConnect();
            if(command.ExecuteNonQuery()==1)
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

        //get student table

        public DataTable getStudentlist(MySqlCommand command)
        {
            command.Connection= connect.GetConnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        //Cream o functie pentru a inumara studentii(total,fete,baieti)
        public string exeCount(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connect.GetConnection);
            connect.openConnect();
            string count = command.ExecuteScalar().ToString();
            connect.CloseConnect();
            return count;
        }
        //to get total students
        public string totalStudent()
        {
            return exeCount("SELECT COUNT(*) FROM student");
        }

        //pentru a afla baietii

        public string maleStudent()
        {
            return exeCount("SELECT COUNT(*) FROM student WHERE`Gen`='Male'");
        }

        // pentru a aflat numarul de fete

        public string femaletudent()
        {
            return exeCount("SELECT COUNT(*) FROM student WHERE`Gen`='Female'");
        }

        //create a function search for student
        public DataTable searchStudent(string searchdata)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `student` WHERE CONCAT(`Nume`,`Prenume`,`CNP`) LIKE'%"+searchdata+"%'", connect.GetConnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        //create a function for update student
        public bool updateStudent(int id,string fname, string lname, DateTime bdate, string gender, string phone, string adress, byte[] img)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `student` SET `Nume`=@fn,`Prenume`=@ln,`DataInscriere`=@bd,`CNP`=@ph,`Gen`=@gd,`Media`=@adr,`Poza`=@img WHERE `StudentID`=@id", connect.GetConnection);

            //     @fn, @ln, @bd, @ph, @gd, @adr, @img, @in
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bd", MySqlDbType.Date).Value = bdate;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@gd", MySqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@adr", MySqlDbType.VarChar).Value = adress;
            command.Parameters.Add("@img", MySqlDbType.Blob).Value = img;


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

        //create a functon for any comand in StudnetDB
        public DataTable getList(MySqlCommand command)
        {
            command.Connection = connect.GetConnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        internal bool deleteStudent(int id, object fname, object lname, object bdate, object gender, object phone, object address, object img)
        {
            throw new NotImplementedException();
        }

        internal bool deleteStudent(int id)
        {
            throw new NotImplementedException();
        }
    }
}
