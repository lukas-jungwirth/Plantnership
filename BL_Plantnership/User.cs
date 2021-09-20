using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BCryptNet = BCrypt.Net.BCrypt;


namespace BL_Plantnership
{
    public class User
    {
        private string _ID = "";
        private string _Username;
        private string _Name;
        private string _LastName;
        private string _Mail;
        //private DateTime currentDate = DateTime.Today;

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



        //CONSTRUCTOR
        internal User()
        {

        }

        //METHODS


        /*
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
        */

        public Plants getUserPlants()
        {
            return Plant.LoadAllFromUser(ID);
        }

        public Plants loadRentedPlants()
        {
            return Plant.LoadRentedFromUser(ID);
        }

        //check if user has purchased a specific tree
        public bool hasPurchased(Plant plant)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from [Purchase] where userID = @uid AND plantID = @plID", Starter.GetConnection());
                cmd.Parameters.Add(new SqlParameter("uid", ID));
                cmd.Parameters.Add(new SqlParameter("plID", plant.ID));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        //add purchase entry
        public bool purchasePlant(Plant plant, int aboType)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Purchase (plantID, userID, aboTyp) values (@pid, @uid, @atyp)", Starter.GetConnection());
                cmd.Parameters.Add(new SqlParameter("pid", plant.ID));
                cmd.Parameters.Add(new SqlParameter("uid", _ID));
                cmd.Parameters.Add(new SqlParameter("atyp", aboType));
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            

        }


        //STATIC METHODS

        private static User FillUserFromSQLDataReader(SqlDataReader reader)
        {
            User user = new User();
            user.ID = reader.GetString(0);
            user.Username = reader.GetString(1);
            user.Name = reader.GetString(2);
            user.LastName = reader.GetString(3);
            user.Mail = reader.GetString(4);
            return user;
        }


        internal static User Load(string userID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select ID, username, name, lastName, mail from [User] where ID = @uid", Starter.GetConnection());
                cmd.Parameters.Add(new SqlParameter("uid", userID));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return FillUserFromSQLDataReader(reader);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            
        }//"Load()"

        internal static User LoadLoginUser(string username, string password)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select ID, username, password, name, lastName, mail from [User] WHERE username = @user", Starter.GetConnection());
                cmd.Parameters.Add(new SqlParameter("user", username));
                SqlDataReader reader = cmd.ExecuteReader();
                
                string hash = "";
                while (reader.Read())
                {
                    User user = new User();
                    user.ID = reader.GetString(0);
                    user.Username = reader.GetString(1);
                    hash = reader.GetString(2);
                    user.Name = reader.GetString(3);
                    user.LastName = reader.GetString(4);
                    user.Mail = reader.GetString(5);

                    bool verified = BCryptNet.Verify(password, hash);
                    if (verified) return user;
                }
                return null;
               }
            catch
            {
                return null;
            }
        }//LoadLoginUser




    }//"class User"
}//"namespace"
