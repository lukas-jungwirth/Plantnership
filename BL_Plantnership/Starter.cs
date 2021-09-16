/// BOKunden: Businessobjekt zur Applikation PLWebKunden (C# ASP.Net Presentation Layer)
/// Demoapplikation in der LV "Web Programmierung 2"
/// Author: G. Schmiedl, FH St. Pölten
/// 
/// Dieses Projekt realisiert das BO nach dem Domain Model Pattern, wobei das Erzeugen von
/// Objekten nur durch die Verwendung von BO-Methoden erlaubt ist. 
///  cMain: Starterobjekt ist statisch - kann nicht instanziert werden - aber verwendet
///  BOKunde: bekommt man nur mit Hilfe von Methoden in cMain
///  BOKommentar: bekommt man nur von Methoden aus BOKunde

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
    // Die Klasse Main ist das Starterobjekt dieses Businessobjekts
    // Sie ist statisch, d.h. der Programmierer des PL muss kein Objekt erzeugen, sondern kann die Methoden
    // der Klasse direkt aufrufen, z.B. x = BOKunden.getKundenListe()
    // Dieses BO ist so konzipiert, dass der PL-Programmierer nie eine Klasse mit new instanzieren muss.
    public static class Starter
    {

        //creates connection to DB
        internal static SqlConnection GetConnection()
        {

            List<string> dirs = new List<string>(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory).Split('\\'));
            dirs.RemoveAt(dirs.Count - 1); //letztes Verzeichnis entfernen
            string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + String.Join(@"\", dirs) + @"\DB_Plantnership\Platnership.mdf;Integrated Security=True;Connect Timeout=30";
            
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
            //check if username already exists
            int checkUser = CheckUniqueUsername(username);
            if (checkUser != 1) return checkUser;

            try
            {
                
                SqlCommand cmd = new SqlCommand("insert into [User] (Id, name , lastName , mail, username, password) values (@id, @name, @lstName, @mail, @user, @pw)", Starter.GetConnection());
                string ID = Guid.NewGuid().ToString();
                cmd.Parameters.Add(new SqlParameter("id", ID));
                cmd.Parameters.Add(new SqlParameter("user", username));
                cmd.Parameters.Add(new SqlParameter("pw", hashPw(password)));
                cmd.Parameters.Add(new SqlParameter("name", name));
                cmd.Parameters.Add(new SqlParameter("lstName", lastname));
                cmd.Parameters.Add(new SqlParameter("mail", mail));
                if (cmd.ExecuteNonQuery() > 0) return 1;
                return -1;
            }
            catch
            {
                return -1;
            }

            //register user
            //if (User.register(username, password, name, lastname, mail)) return 1;
            //else return -1;
        }

        internal static int CheckUniqueUsername(string username)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * from [User] WHERE username = @user", Starter.GetConnection());
                cmd.Parameters.Add(new SqlParameter("user", username));
                SqlDataReader reader = cmd.ExecuteReader();
                int result = reader.HasRows ? 0 : 1;
                return result;
            }
            catch
            {
                return -1;
            }

        }

        public static string hashPw(string pw)
        {
            string hashedPw = BCryptNet.HashPassword(pw);
            return hashedPw;
        }

        //login function return ID of user
        public static string Login(string username, string password)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Id, password FROM [User] WHERE username = @user", Starter.GetConnection());
                cmd.Parameters.Add(new SqlParameter("user", username));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                string hash = "";
                string ID = "";
                    while (reader.Read())
                    {
                    ID = reader.GetString(0);
                    hash = reader.GetString(1);
                     }
                    
                    bool verified = BCryptNet.Verify(password, hash);
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


        public static User getUserByID(string userID)
        {
            return User.Load(userID);
        }

        //Methode ladet ale Kunden aus der BD, verpackt diese in Kundenobjekte und liefert sie als Kundenliste zurück.
        public static Plants getAllPlantsFromCategory(string category)
        {
            return Plant.LoadAllFromCategory(category);
        }

        public static Plants getPlantsByUsername(string username)
        {
            return Plant.LoadAllFromUser(username);
        }

        //Methode ladet einen Kundenrecord direkt aus der DB, speichert Werte in
        //BOKunde-Objekt und gibt initialisiertes Objekt zurück.
        public static Plant getPlantByID(string plantID)
        {
            return Plant.Load(plantID);
        }

        public static Plant getPlantMatch(string sternzeichen, string jahreszeit, bool plantForLife)
        {
            return Plant.LoadMatchingPlant(sternzeichen, jahreszeit, plantForLife);
        }

        //gibt ein neues leeres Kundenobjekt zum SPeichern neuer Kunden zurück
        public static Plant newPlant()
        {
            // ok, das erscheint jetzt eher komisch, hat aber den Vorteil, dass,
            // ich diese Methode im BL später noch erweitern kan ohne im PL
            // was zu ändern (zB Vorinitialisierung, oder ähnliches)
            // das gelcihe könnte ich in diesem Fall auch mit einem Konstruktor in
            // der Klasse BOKunde erreichen.
            return new Plant();
        }

        public static bool purchasePlant(string userID, string plantID, string aboType)
        {
            SqlCommand cmd = new SqlCommand("insert into Purchase (plantID, userID, aboType) values (@pid, @uid, @ytp)", GetConnection());
            cmd.Parameters.Add(new SqlParameter("pid", plantID));
            cmd.Parameters.Add(new SqlParameter("uid", userID));
            cmd.Parameters.Add(new SqlParameter("ytp", aboType));
            if(cmd.ExecuteNonQuery() > 0)
            {
                return (Plant.ChangePlantSellState(plantID, true));
                
            }
            else
            {
                return false;
            }
            
        }
    }

}


