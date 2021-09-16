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
        string currentCategory;
        Plants allCategoryPlants;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((User)Session["currentUser"] == null)
            {
                Response.Redirect("login.aspx");
            }

            if (!IsPostBack)
            //if page is rendered the first time
            {
                currentCategory = (string)Session["category"];
                allCategoryPlants = Starter.getAllPlantsFromCategory(currentCategory);
                Session["allCategoryPlants"] = allCategoryPlants;

                repeaterPlantList.DataSource = allCategoryPlants;
                repeaterPlantList.DataBind();

            }
            else
            {

                allCategoryPlants = (Plants)Session["allCategoryPlants"];
                currentCategory = (string)Session["currentCategory"];
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
    }
}