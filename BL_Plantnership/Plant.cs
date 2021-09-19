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
        private string _UserID;
        private string _Owner;
        private string _CategoryID;
        private string _CategoryName;
        private string _Variety;
        private string _Age;
        private string _District;
        private string _Street;
        private string _HouseNumber;
        //only for rented plants
        private string _AboType;
        private string _AboStart;
        private string _AboPrice;


        //PROPERTIES
        public string ID
        {
            get { return _ID; }
            internal set { _ID = value; }
        }
        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        public string Owner
        {
            get { return _Owner; }
            set { _Owner = value; }
        }
        public string CategoryID {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }
        public string CategoryName {
            get { return _CategoryName; }
            set { _CategoryName = value; }
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
        //only for rented trees
        public string Abotype
        {
            get { return _AboType; }
            set { _AboType = value; }
        }
        public string AboStart
        {
            get { return _AboStart; }
            set { _AboStart = value; }
        }
        public string AboPrice
        {
            get { return _AboPrice; }
            set { _AboPrice = value; }
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
                string SQL = "insert into Plant (ID, userID, categoryID, variety, age, district, street, houseNumber) values (@plID, @uID, @cat, @var, @age, @dis, @str, @num)";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Starter.GetConnection();
                //create unique guid
                _ID = Guid.NewGuid().ToString();

                cmd.Parameters.Add(new SqlParameter("plID", _ID));
                cmd.Parameters.Add(new SqlParameter("uID", UserID));
                cmd.Parameters.Add(new SqlParameter("cat", CategoryID));
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
                string SQL = "update Plant set categoryID=@cat, variety=@vari, age=@age, district=@dis, street=@stre, houseNumber=@numb  where ID = @plID";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Starter.GetConnection();
                cmd.Parameters.Add(new SqlParameter("plID", _ID));
                cmd.Parameters.Add(new SqlParameter("cat", CategoryID));
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

        internal static List<string> getEntryIdList(string category)
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




        // Hilfsfunktion für die beiden unteren Methoden
        private static Plant FillPlantFromSQLDataReader(SqlDataReader reader)
        {
            Plant plant = new Plant();
            plant.ID = reader.GetString(0);
            plant.UserID = reader.GetString(1);
            plant.Owner = reader.GetString(2);
            plant.CategoryID = reader.GetString(3);
            plant.CategoryName = reader.GetString(4);
            plant.Variety = reader.GetString(5);
            plant.Age = reader.GetString(6);
            plant.District = reader.GetString(7);
            plant.Street = reader.GetString(8);
            plant.HouseNumber = reader.GetString(9);
            return plant;
        }

        // Load Plant Object
        internal static Plant Load(string plantID)
        {
            string SQL = "select p.ID, p.userID, u.username, p.categoryID, c.categoryName, p.variety, p.age, p.district, p.street, p.houseNumber from [Plant] as p LEFT JOIN [Category] as c ON p.categoryID = c.categoryID LEFT JOIN [User] as u ON p.userID = u.ID  where p.ID = @plId";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Starter.GetConnection();
                cmd.Parameters.Add(new SqlParameter("plId", plantID));

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

        //loads all plant objects from a given category into a list of plant objects
        internal static Plants LoadAllFromCategory(string catID)
        {
         
            SqlCommand cmd = new SqlCommand("select p.ID, p.userID, u.username, p.categoryID, c.categoryName, p.variety, p.age, p.district, p.street, p.houseNumber from [Plant] as p LEFT JOIN [Category] as c ON p.categoryID = c.categoryID LEFT JOIN [User] as u ON p.userID = u.ID where p.categoryID = @cat", Starter.GetConnection());
            cmd.Parameters.Add(new SqlParameter("cat", catID));
            SqlDataReader reader = cmd.ExecuteReader();
            Plants allPlants = new Plants();
            while (reader.Read())
            {
                Plant plant = FillPlantFromSQLDataReader(reader);
                allPlants.Add(plant);
            }
            return allPlants;
        }

        internal static Plants LoadAllFromUser(string userID)
        {
            SqlCommand cmd = new SqlCommand("SELECT p.ID, p.userID, u.username, p.categoryID, c.categoryName, p.variety, p.age, p.district, p.street, p.houseNumber from [Plant] as p LEFT JOIN [Category] as c ON p.categoryID = c.categoryID LEFT JOIN [User] as u ON p.userID = u.ID where p.userID = @uID", Starter.GetConnection());
            cmd.Parameters.Add(new SqlParameter("uID", userID));
            SqlDataReader reader = cmd.ExecuteReader();
            Plants allPlants = new Plants();
            while (reader.Read())
            {
                Plant plant = FillPlantFromSQLDataReader(reader);
                allPlants.Add(plant);
            }
            return allPlants;
        }

        internal static Plants LoadRendtedPlants(string userID)
        {
            SqlCommand cmd = new SqlCommand("select pl.ID, u.username, pl.categoryID, c.categoryName, pl.variety, pl.age, pl.district, pl.street, pl.houseNumber, pu.aboType, pu.start, pu.price from Plant as pl LEFT JOIN [Purchase] as pu ON pl.userID = pu.userID  LEFT JOIN [Category] as c ON pl.categoryId = c.categoryID LEFT JOIN [User] as u ON pl.userID = u.ID where pl.userID = @uID", Starter.GetConnection());
            cmd.Parameters.Add(new SqlParameter("uID", userID));
            SqlDataReader reader = cmd.ExecuteReader();
            Plants allPlants = new Plants();
            while (reader.Read())
            {
                Plant plant = new Plant();
                plant.ID = reader.GetString(0);
                plant.Owner = reader.GetString(1);
                plant.CategoryID = reader.GetString(2);
                plant.CategoryName = reader.GetString(3);
                plant.Variety = reader.GetString(4);
                plant.Age = reader.GetString(5);
                plant.District = reader.GetString(6);
                plant.Street = reader.GetString(7);
                plant.HouseNumber = reader.GetString(8);
                plant.Abotype = reader.GetString(9);
                plant.AboStart = reader.GetString(10);
                plant.AboPrice = reader.GetString(11);
                allPlants.Add(plant);
            }
            return allPlants;
        }

    }//"class"
}//"namespace"