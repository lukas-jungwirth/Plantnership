using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using BCryptNet = BCrypt.Net.BCrypt;
using System.Security.Policy;

namespace BL_Plantnership
{

    public static class Starter
    {

        //creates connection to DB
        internal static SqlConnection GetConnection()
        {

            List<string> dirs = new List<string>(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory).Split('\\'));
            dirs.RemoveAt(dirs.Count - 1); //letztes Verzeichnis entfernen
            string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + String.Join(@"\", dirs) + @"\DB_Plantnership\Platnership.mdf; Integrated Security = True; Connect Timeout = 30";

            
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                return con;
            }
            catch
            {
                return null;
            }
           
        }//"GetConnection()"

        //register user
        //1 - success
        //0 - username existing
        //-1 - error        
        public static int register(string username, string password, string name, string lastname, string mail)
        {
            //check if not input field is empty
            if (username == "" || password == "" || name == "" || lastname == "" || mail == "") return -2;

            //check if username already exists
            int checkUser = CheckUniqueUsername(username);
            if (checkUser == 1) return 0;

            try
            {
                
                SqlCommand cmd = new SqlCommand("insert into [User] (ID, name , lastName , mail, username, password) values (@id, @name, @lstName, @mail, @user, @pw)", Starter.GetConnection());
                string ID = Guid.NewGuid().ToString();
                cmd.Parameters.Add(new SqlParameter("@id", ID));
                cmd.Parameters.Add(new SqlParameter("@user", username));
                cmd.Parameters.Add(new SqlParameter("@pw", hashPw(password)));
                cmd.Parameters.Add(new SqlParameter("@name", name));
                cmd.Parameters.Add(new SqlParameter("@lstName", lastname));
                cmd.Parameters.Add(new SqlParameter("@mail", mail));
                if (cmd.ExecuteNonQuery() > 0) return 1;
                return -1;
            }
            catch
            {
                return -1;
            }
        }

        public static int CheckUniqueUsername(string username)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * from [User] WHERE username = @user", Starter.GetConnection());
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

        internal static string hashPw(string pw)
        {
            string hashedPw = BCryptNet.HashPassword(pw);
            return hashedPw;
        }


        //login function return user object
        public static User Login(string username, string password)
        {
            return User.LoadLoginUser(username, password);
        }

        public static Categories getAllCategories()
        {
            return Category.LoadAllCategories();
        }

        public static Category getCategoryById(int categoryID)
        {
            return Category.Load(categoryID);
        }


        //Methode ladet ale Kunden aus der BD, verpackt diese in Kundenobjekte und liefert sie als Kundenliste zurück.

        public static Plants getPlantsByUsername(string username)
        {
            return Plant.LoadAllFromUser(username);
        }

        public static Plant getPlantByID(string plantID)
        {
            return Plant.Load(plantID);
        }

        //gibt ein neues leeres Kundenobjekt zum SPeichern neuer Kunden zurück
        public static Plant newPlant()
        {
            return new Plant();
        }


    }

}


