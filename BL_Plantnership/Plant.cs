using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL_Plantnership
{
    public class Plant
    {
        //init
        private string _ID = "";
        private string _Owner;
        private string _Category;
        private string _Variety;
        private string _Age;
        private string _District;
        private string _Street;
        private string _HouseNumber;
        private bool _Sold;

        //PROPERTIES
        public string ID
        {
            get { return _ID; }
            internal set { _ID = value; }
        }
        public string Owner {
            get { return _Owner; }
            set { _Owner = value; }
        }

        public string Category {
            get { return _Category; }
            set { _Category = value; }
        }

        public string Variety {
            get { return _Variety; }
            set { _Variety = value; }
        }

        public string Age {
            get { return _Age; }
            set { _Age = value; }
        }

        public string District {
            get { return _District; }
            set { _District = value; }
        }

        public string Street {
            get { return _Street; }
            set { _Street = value; }
        }

        public string HouseNumber {
            get { return _HouseNumber; }
            set { _HouseNumber = value; }
        }

        public bool Sold
        {
            get { return _Sold; }
            internal set { _Sold = value; }
        }


        //CONSTRUCTOR
        internal Plant()
        {

        }

        //METHODS

        // Den aktuellen Kunden aus der DB löschen
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
                string SQL = "insert into Plant (ID, owner, category, variety, age, district, street, houseNumber) values (@plID, @owner, @cat, @var, @age, @dis, @str, @num)";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Starter.GetConnection();
                //create unique guid
                _ID = Guid.NewGuid().ToString();

                cmd.Parameters.Add(new SqlParameter("plID", _ID));
                cmd.Parameters.Add(new SqlParameter("owner", Owner));
                cmd.Parameters.Add(new SqlParameter("cat", Category));
                cmd.Parameters.Add(new SqlParameter("var", Variety));
                cmd.Parameters.Add(new SqlParameter("age", Age));
                cmd.Parameters.Add(new SqlParameter("dis", District));
                cmd.Parameters.Add(new SqlParameter("str", Street));
                cmd.Parameters.Add(new SqlParameter("num", HouseNumber));

                //return number of applied records
                //if insert worked return should be 1
                return (cmd.ExecuteNonQuery() > 0); 
            }    
            else
            {
                //if there is an existing element UPDATE fields
                string SQL = "update Plant set category=@cat, variety=@vari, age=@age, district=@dis, street=@stre, houseNumber=@numb  where ID = @plID";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Starter.GetConnection();
                cmd.Parameters.Add(new SqlParameter("plID", _ID));
                cmd.Parameters.Add(new SqlParameter("cat", Category));
                cmd.Parameters.Add(new SqlParameter("vari", Variety));
                cmd.Parameters.Add(new SqlParameter("age", Age));
                cmd.Parameters.Add(new SqlParameter("dis", District));
                cmd.Parameters.Add(new SqlParameter("stre", Street));
                cmd.Parameters.Add(new SqlParameter("numb", HouseNumber));
                return (cmd.ExecuteNonQuery() > 0);
            }
        }//"Save()"




        //STATIC METHODS
        public static string getMatchCategory(string sternzeichen, string jahreszeit)
        {
            string sz = sternzeichen.ToLower();
            string jz = jahreszeit.ToLower();

            int cat = 0;
            if (sz == "widder" || sz == "waage") { cat = 1; }
            else if (sz == "stier" || sz == "skorpion") { cat = 2; }
            else if (sz == "zwillinge" || sz == "schütze") { cat = 3; }
            else if (sz == "krebs" || sz == "steinbock") { cat = 4; }
            else if (sz == "löwe" || sz == "wassermann") { cat = 5; }
            else if (sz == "jungfrau" || sz == "fische") { cat = 6; }

            if (jz == "frühling") {
                if (cat <= 5) cat += 1;
                else cat = 1;
            }
            else if (jz == "sommer") {
                if (cat <= 4) cat += 2;
                else if (cat == 5) cat = 1;
                else cat = 2;
            }
            else if (jz == "herbst") {
                if (cat >= 2) cat -= 1;
                else cat = 6;

            }
            else if (jz == "winter") {
                if (cat >= 3) cat -= 2;
                else if (cat == 2) cat = 6;
                else cat = 5;
                
            }

            string calculatedCat;
            switch (cat)
            {
                case 1:
                    calculatedCat = "apfel";
                    break;
                case 2:
                    calculatedCat = "birne";
                    break;
                case 3:
                    calculatedCat = "kirsche";
                    break;
                case 4:
                    calculatedCat = "marille";
                    break;
                case 5:
                    calculatedCat = "zwetschke";
                    break;
                default:
                    calculatedCat = "pfirsich";
                    break;
            }

            return calculatedCat;
        }

        public static List<string> getEntryIdList(string category)
        {
            string SQL = "select count(*) from Plant where category = @cat";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Starter.GetConnection();
                cmd.Parameters.Add(new SqlParameter("cat", category));

                List<string> results = new List<string>();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        results.Add((string)reader["ID"]);
                    }
                    return results;
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
         }

        internal static Plant LoadMatchingPlant(string sternzeichen, string jahreszeit, bool plantForLife)
        {
            string cat = getMatchCategory(sternzeichen, jahreszeit);
            List<string> categoryIds = getEntryIdList(cat);
            int amount = categoryIds.Count;
            Random rnd = new Random();
            int rndNumb = rnd.Next(1, amount);
            int numb = rndNumb;
            string id = categoryIds[numb];
            return Load(id);
        }


        public static bool ChangePlantSellState(string plantID, bool sold)
        {
            SqlCommand cmd = new SqlCommand("update Plant set sold = @sld where ID = @plID ", Starter.GetConnection());
            cmd.Parameters.Add(new SqlParameter("plID", plantID));
            cmd.Parameters.Add(new SqlParameter("sld", sold));
            return (cmd.ExecuteNonQuery() > 0);
        }//"ChangePlantSellState()"

        // Hilfsfunktion für die beiden unteren Methoden
        private static Plant FillPlantFromSQLDataReader(SqlDataReader reader)
        {
            Plant plant = new Plant();
            plant.ID = reader.GetString(0);
            plant.Owner = reader.GetString(1);
            plant.Category = reader.GetString(2);
            plant.Variety = reader.GetString(3);
            plant.Age = reader.GetString(4);
            plant.District = reader.GetString(5);
            plant.Street = reader.GetString(6);
            plant.HouseNumber = reader.GetString(7);
            plant.Sold = reader.GetBoolean(8);
            return plant;
        }

        // Laden eines Kundenobjekts - wird von BOMail.getKunde() aufgerufen
        internal static Plant Load(string plantID)
        {
            string SQL = "select ID, owner, category, variety, age, district, street, houseNumber, sold from Plant where ID = @id";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Starter.GetConnection();
                cmd.Parameters.Add(new SqlParameter("id", plantID));

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read(); //setzt den Reader auf den ersten / nächsten DS
                    return FillPlantFromSQLDataReader(reader);
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
              
        }

        //loads all plant objects from a given category into a list of plant objects (if Plant.Sold is false)
        internal static Plants LoadAllFromCategory(string Category)
        {
         
            SqlCommand cmd = new SqlCommand("select ID, owner, category, variety, age, district, street, houseNumber, sold from Plant where category = @cat and sold = 0", Starter.GetConnection());
            cmd.Parameters.Add(new SqlParameter("cat", Category));
            SqlDataReader reader = cmd.ExecuteReader();
            Plants allPlants = new Plants();
            while (reader.Read())
            {
                Plant plant = FillPlantFromSQLDataReader(reader);
                allPlants.Add(plant);
            }
            return allPlants;
        }

        internal static Plants LoadAllFromUser(string username)
        {
            SqlCommand cmd = new SqlCommand("select ID, owner, category, variety, age, district, street, houseNumber, sold from Plant where owner = @user", Starter.GetConnection());
            cmd.Parameters.Add(new SqlParameter("user", username));
            SqlDataReader reader = cmd.ExecuteReader();
            Plants allPlants = new Plants();
            while (reader.Read())
            {
                Plant plant = FillPlantFromSQLDataReader(reader);
                allPlants.Add(plant);
            }
            return allPlants;
        }

    }//"class"
}//"namespace"