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
        private string _Sold;
        private string _AboPriceStd;
        private string _AboPriceHigh;

        //PROPERTIES
        public string ID
        {
            get { return _ID; }
            internal set { _ID = value; }
        }
        public string Owner
        {
            get { return _Owner; }
            set { _Owner = value; }
        }

        public string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }
        public string Variety
        {
            get { return _Variety; }
            set { _Variety = value; }
        }
        public string Age
        {
            get { return _Age; }
            set { _Age = value; }
        }
        public string District
        {
            get { return _District; }
            set { _District = value; }
        }
        public string Street
        {
            get { return _Street; }
            set { _Street = value; }
        }
        public string HouseNumber
        {
            get { return _HouseNumber; }
            set { _HouseNumber = value; }
        }
        public string Sold
        {
            get { return _Sold; }
            internal set { _Sold = value; }
        }
        public string AboPriceStd
        {
            get { return _AboPriceStd; }
            set { _AboPriceStd = value; }
        }
        public string AboPriceHigh
        {
            get { return _AboPriceHigh; }
            set { _AboPriceHigh = value; }
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
                string SQL = "insert into Plant (ID, owner, category, variety, age, district, street, houseNumber, sold) values (@id, @cat, @var, @age, @dis, @str, @num, @sld)";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Starter.GetConnection();
                //create unique guid
                _ID = Guid.NewGuid().ToString();

                cmd.Parameters.Add(new SqlParameter("id", _ID));
                cmd.Parameters.Add(new SqlParameter("owner", _Owner));
                cmd.Parameters.Add(new SqlParameter("cat", Category));
                cmd.Parameters.Add(new SqlParameter("var", Variety));
                cmd.Parameters.Add(new SqlParameter("age", Age));
                cmd.Parameters.Add(new SqlParameter("dis", District));
                cmd.Parameters.Add(new SqlParameter("str", Street));
                cmd.Parameters.Add(new SqlParameter("num", HouseNumber));
                cmd.Parameters.Add(new SqlParameter("sld", 0));

                //return number of applied records
                //if insert worked return should be 1
                return (cmd.ExecuteNonQuery() > 0); 
            }    
            else
            {
                //if there is an existing element UPDATE fields
                string SQL = "update Plant set category=@cat, variety=@var, age=@age, district=@dis, street=@str, houseNumber=@num  where ID = @id";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SQL;
                cmd.Connection = Starter.GetConnection();
                cmd.Parameters.Add(new SqlParameter("cat", Category));
                cmd.Parameters.Add(new SqlParameter("var", Variety));
                cmd.Parameters.Add(new SqlParameter("age", Age));
                cmd.Parameters.Add(new SqlParameter("dis", District));
                cmd.Parameters.Add(new SqlParameter("str", Street));
                cmd.Parameters.Add(new SqlParameter("num", HouseNumber));
                return (cmd.ExecuteNonQuery() > 0);
            }
        }//"Save()"




        //STATIC METHODS

        public static bool ChangePlantSellState(string plantID, bool sold)
        {
            SqlCommand cmd = new SqlCommand("update Plant set sold = @sld where ID = @id ", Starter.GetConnection());
            cmd.Parameters.Add(new SqlParameter("id", plantID));
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
            plant.Sold = reader.GetString(8);
            return plant;
        }

        // Laden eines Kundenobjekts - wird von BOMail.getKunde() aufgerufen
        internal static Plant Load(string plantID)
        {
            string SQL = "select id, owner, category, variety, age, district, street, houseNumber, sold from Plant where ID = @id and category = @cat";
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
                return null;
        }

        //loads all plant objects from a given category into a list of plant objects (if Plant.Sold is false)
        internal static Plants LoadAllFromCategory(string Category)
        {
         
            SqlCommand cmd = new SqlCommand("select id, owner, category, variety, age, district, street, houseNumber, sold from Kunden where category = @cat and sold = 0", Starter.GetConnection());
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

    }//"class"
}//"namespace"