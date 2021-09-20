using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Plantnership;

namespace PL_Plantnership
{
    public partial class ObstBaumUnterKategorie : System.Web.UI.Page
    {
        User currentUser;
        Category currentCategory;
        Plants allCategoryPlants; 
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            //if page is rendered the first time
            {
                if ((User)Session["currentUser"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                else
                {
                    currentUser = (User)Session["currentUser"];
                }

                currentCategory = (Category)Session["category"];
                allCategoryPlants = currentCategory.getAllPlants(currentUser);
                Session["allCategoryPlants"] = allCategoryPlants;

                repeaterPlantList.DataSource = allCategoryPlants;
                repeaterPlantList.DataBind();

            }
            else
            {

                allCategoryPlants = (Plants)Session["allCategoryPlants"];
                currentCategory = (Category)Session["category"];
                currentUser = (User)Session["currentUser"];
            }
        }

        protected void Detail_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "DetailClick")
            {
                Session["plantID"] = e.CommandArgument;
                Response.Redirect("PlantDetail.aspx");
            }
        }

        protected void btnBaumVerwalten_Click(object sender, EventArgs e)
        {
            //geht eh nur wenn user eingelogged
            Response.Redirect("Verwaltung.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
    
}