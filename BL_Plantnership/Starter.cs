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
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
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
        static internal SqlConnection GetConnection()
        {

            // Hinweis: das @ am Anfang von Strings verhindert das Sonder- und Escapezeichen interpretiert werden.

            //Variante 1: DB File direkt angeben
            //Vorteil: Man spart sich das Registrieren der DB im SQL Manager
            //Nachteil: Pfad zur DB hardcoded - sollte besser in Web-Config gemacht werden

            //string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\lbschmiedl\Kundenverwaltung2014\DB\KundenDB4.mdf;Integrated Security=True;Connect Timeout=30";

            //Variante 2: wie oben, aber der Pfad wird aus dem absoluten App-Pfad und der relativen Position des DB-Files berechnet.
            List<string> dirs = new List<string>(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory).Split('\\'));
            dirs.RemoveAt(dirs.Count - 1); //letztes Verzeichnis entfernen
            string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + String.Join(@"\", dirs) + @"\DB\KundenDB4.mdf;Integrated Security=True;Connect Timeout=5";

            //Variante 3: DBFile mit SQL Server Manager Express im SQL-Server registrieren und den "Kurznamen aus dem SQL Manager angeben
            //Vorteil: nur ein logischer Name - Name und Pfad der DB kann verändert werden (SQL Manager)
            //Nachteil: App kann nicht mit Copy&Paste auf den Zielserver verschoben werden, da DB regstriert werden muss.
            //string conString = @"Data Source=localhost\SQLEXPRESS;Database=KundenDB4;Integrated Security=true;Integrated Security=True;Connect Timeout=30";

            // weitere Varianten:
            // man könnte den Conectionstring auch in eine externe Konfigurationsdatei schreioben und von dort auslesen...

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            return con;
        }//"GetConnection()"

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


