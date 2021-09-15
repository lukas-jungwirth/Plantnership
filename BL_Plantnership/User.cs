using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace BL_Plantnership
{
    public class User
    {
        private string _ID = "";
        private string _Name;
        private string _LastName;
        private string _Mail;
        private DateTime _DateOfEntrance;
        private string _Rank;

        private DateTime currentDate = DateTime.Today;

        //PROPERTIES
        public string ID
        {
            get { return _ID; }
            internal set { _ID = value; }
        }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Mail { get; set; }

        public string Rank
        {
            get
            {
                if((DateTime.Today - _DateOfEntrance).TotalDays < 7)
                {
                    return "Frisch gepflanzt";
                }else if((DateTime.Today - _DateOfEntrance).TotalDays < 31){
                    return "Sprössling";
                }else if((DateTime.Today - _DateOfEntrance).TotalDays < 183){
                    return "Jungpflanze";
                }else if((DateTime.Today - _DateOfEntrance).TotalDays < 365){
                    return "Ausgewachsener Baum";
                }else{
                    return "Alt und weise";
                }
            }
        }


        //CONSTRUCTOR
        internal User()
        {

        }

        //METHODS
        public bool Delete()
        {
            if (_ID != "")
            {
                //if object with id exsists in databse -> DELETE
                string SQL = "delete Plant where ID = @id";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Starter.GetConnection();
                cmd.Parameters.Add(new SqlParameter("id", _ID));
                if (cmd.ExecuteNonQuery() > 0)
                {
                    _ID = ""; //das Objekt existiert weiter - es verhält sich aber wieder wie ein neuer Kunde
                    return true;
                }
                else return false; //DELETE did not work
            }
            //if there is no elemente with id in the database it can be seen as deleted
            else return true;
        }//"Delete()"


        public bool Save()
        {

            if (_ID == "")
            {
                //if there is no existing element in the database INSERT new
                string SQL = "insert into User (ID, name , lastNam , mail, dateOfEntrance, username, password) values (@id, @name, @lstName, @gen, @mail, @doe, @user, @pw)";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Starter.GetConnection();
                //create unique guid
                _ID = Guid.NewGuid().ToString();

                cmd.Parameters.Add(new SqlParameter("id", _ID));
                cmd.Parameters.Add(new SqlParameter("name", Name));
                cmd.Parameters.Add(new SqlParameter("lstName", LastName));
                cmd.Parameters.Add(new SqlParameter("mail", Mail));
                cmd.Parameters.Add(new SqlParameter("doe", currentDate));
                cmd.Parameters.Add(new SqlParameter("user", currentDate));
                cmd.Parameters.Add(new SqlParameter("doe", currentDate));

                //return number of applied records
                //if insert worked return should be 1
                return (cmd.ExecuteNonQuery() > 0);
            }
            else
            {
                //if there is an existing element UPDATE fields
                string SQL = "update Plant set name=@name, lastName=@lstName, mail=@mail  where ID = @id";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Starter.GetConnection();
                cmd.Parameters.Add(new SqlParameter("id", _ID));
                cmd.Parameters.Add(new SqlParameter("name", Name));
                cmd.Parameters.Add(new SqlParameter("lstName", LastName));
                cmd.Parameters.Add(new SqlParameter("mail", Mail));
                cmd.Parameters.Add(new SqlParameter("doe", currentDate));
                return (cmd.ExecuteNonQuery() > 0);
            }
        }//"Save"


        //STATIC METHODS
        // Hilfsfunktion für die beiden unteren Methoden


        internal static int CheckUniqueUsername(string username)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select username from Kunden where username = @user", Starter.GetConnection());
                cmd.Parameters.Add(new SqlParameter("user", username));
                SqlDataReader reader = cmd.ExecuteReader();
                int result = reader.HasRows ? 1 : 0;
                return result;
            }
            catch
            {
                return -1;
            }
            
        }

        //entweder diese static register function oder als objektbasierte wie load
        internal static bool register(string username, string password, string name, string lastname, string mail)
        {
            //string hashedPw = BCrypt.Net.BCrypt.HashPassword(password);
            
            try
            {

                SqlCommand cmd = new SqlCommand("insert into User (Id, name , lastName , mail, username, password) values (@id, @name, @lstName, @mail, @user, @pw)", Starter.GetConnection());
                string ID = Guid.NewGuid().ToString();
                cmd.Parameters.Add(new SqlParameter("id", ID));
                cmd.Parameters.Add(new SqlParameter("user", username));
                cmd.Parameters.Add(new SqlParameter("pw", password));
                cmd.Parameters.Add(new SqlParameter("name", name));
                cmd.Parameters.Add(new SqlParameter("lstName", lastname));
                cmd.Parameters.Add(new SqlParameter("mail", mail));
                return (cmd.ExecuteNonQuery() > 0);
            }
            catch
            {
                return false;
            }

        }


        internal static string Login(string username, string password)
        {
            try
            {
                SqlCommand cmdName = new SqlCommand("select password, ID from Kunden where username = @user", Starter.GetConnection());
                cmdName.Parameters.Add(new SqlParameter("user", username));
                SqlDataReader reader = cmdName.ExecuteReader();           
                if (reader.HasRows)
                {
                    //if there is a user object with the insert username check password 
                    reader.Read();
                    string hash = reader.GetString(0);
                    string ID = reader.GetString(1);

                    bool verified = BCrypt.Net.BCrypt.Verify(password, hash);
                    if (verified)
                    {
                        return ID;
                    }
                    else
                    {
                        return "error_pw";
                    }
                    
                }
                else
                {
                    return "error_user";
                }
                
            }
            catch
            {
                return "error_db";
            }
        }


        // Laden eines Kundenobjekts - wird von BOMail.getKunde() aufgerufen
        internal static User Load(string id)
        {
            SqlCommand cmd = new SqlCommand("select ID, name, lastName, mail from Kunden where ID = @id" , Starter.GetConnection());
            cmd.Parameters.Add(new SqlParameter("id", id));
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read(); //setzt den Reader auf den ersten / nächsten DS
                User user = new User();
                user.ID = reader.GetString(0);
                user.Name = reader.GetString(1);
                user.LastName = reader.GetString(2);
                user.Mail = reader.GetString(3);
                return user;
            }
            else
            {
                return null;
            }   
        }//"Load()"




    }//"class User"
}//"namespace"
