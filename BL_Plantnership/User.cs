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
        private string _Username;
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

        public string Username
        {
            get { return _Username; }
            set { _Username = value;  }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value;  }
        }
        public string LastName {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public string Mail {
            get { return _Mail; }
            set { _Mail = value; }
        }

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
                string SQL = "update Plant set name=@name, lastName=@lstName, mail=@mail where ID = @id";
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


        // Laden eines Kundenobjekts - wird von BOMail.getKunde() aufgerufen
        internal static User Load(string userID)
        {
            SqlCommand cmd = new SqlCommand("select ID, username, name, lastName, mail from [User] where ID = @uid", Starter.GetConnection());
            cmd.Parameters.Add(new SqlParameter("uid", userID));
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                User user = new User();
                while (reader.Read())
                {
                    user.ID = reader.GetString(0);
                    user.Username = reader.GetString(1);
                    user.Name = reader.GetString(2);
                    user.LastName = reader.GetString(3);
                    user.LastName = reader.GetString(3);
                    user.Mail = reader.GetString(4);
                }
                return user;
            }
            else
            {
                return null;
            }   
        }//"Load()"




    }//"class User"
}//"namespace"
