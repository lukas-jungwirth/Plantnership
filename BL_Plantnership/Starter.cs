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

namespace BL_Plantnership
{
    // Die Klasse Main ist das Starterobjekt dieses Businessobjekts
    // Sie ist statisch, d.h. der Programmierer des PL muss kein Objekt erzeugen, sondern kann die Methoden
    // der Klasse direkt aufrufen, z.B. x = BOKunden.getKundenListe()
    // Dieses BO ist so konzipiert, dass der PL-Programmierer nie eine Klasse mit new instanzieren muss.
    public static class Starter
    {

        // Hilfsmethode, die eine Verbindung zur DB erzeugt und retourniert.
        internal static SqlConnection GetConnection()
        {
            try
            {
                List<string> dirs = new List<string>(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory).Split('\\'));
                dirs.RemoveAt(dirs.Count - 1);
                string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + String.Join(@"\", dirs) + @"\DB_Plantnership\Platnership.mdf;Integrated Security=True;Connect Timeout=30";
                SqlConnection conn = new SqlConnection(conString);
                conn.Open();
                return conn;
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
            //int checkUser = User.CheckUniqueUsername(username);
            //if (checkUser != 1) return checkUser;

            //register user
            if (User.register(username, password, name, lastname, mail)) return 1;
            else return -1;
        }

        //login function return ID of user
        public static string login(string username, string password)
        {
            return User.Login(username, password);
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


