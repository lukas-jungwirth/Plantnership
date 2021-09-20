using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BL_Plantnership
{
    public class Category
    {
        private int _ID;
        private string _Name;
        private string _AboPrice1;
        private string _AboPrice2;
        private string _ImageUrl;

        public int ID
        {
            get { return _ID; }
            internal set { _ID = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string AboPrice1
        {
            get { return _Name; }
            set { _AboPrice1 = value; }
        }
        public string AboPrice2
        {
            get { return _Name; }
            set { _AboPrice2 = value; }
        }
        public string ImageUrl
        {
            get { return _ImageUrl; }
            set { _ImageUrl = value; }
        }

        //CONSTRUCTOR
        internal Category()
        {

        }

        public Plants getAllPlants(User user)
        {
            return Plant.LoadAllFromCategory(ID, user);
        }

        //load all 
        internal static Categories LoadAllCategories()
        {

            SqlCommand cmd = new SqlCommand("select categoryID, categoryName, aboPrice1, aboPrice2, imageUrl from Category", Starter.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            Categories allCats = new Categories();
            while (reader.Read())
            {
                Category cat = new Category();
                cat.ID = reader.GetInt32(0);
                cat.Name = reader.GetString(1);
                cat.AboPrice1 = reader.GetString(2);
                cat.AboPrice2 = reader.GetString(3);
                cat.ImageUrl = reader.GetString(4);
                allCats.Add(cat);
            }
            return allCats;
        }

        //load by id
        internal static Category Load(int catID)
        {
          
                SqlCommand cmd = new SqlCommand("SELECT categoryID, categoryName, aboPrice1, aboPrice2, imageUrl from Category where categoryID = @catId", Starter.GetConnection());
                cmd.Parameters.Add(new SqlParameter("catId", catID));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Category cat = new Category();
                    while (reader.Read())
                    {
                        cat.ID = reader.GetInt32(0);
                        cat.Name = reader.GetString(1);
                        cat.AboPrice1 = reader.GetString(2);
                        cat.AboPrice2 = reader.GetString(3);
                        cat.ImageUrl = reader.GetString(4);
                    }
                    return cat;
                }
                else
                {
                    return null;
                }
          

        }//"Load()"



    }//end class
}//end namespace
