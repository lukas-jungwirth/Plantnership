using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Plantnership;

namespace PL_Plantnership
{
    public partial class PlantDetail : System.Web.UI.Page
    {
        string currentID;
        Plant currentPlant;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((User)Session["currentUser"] == null)
            {
                Response.Redirect("login.aspx");
            }

            if (!IsPostBack)
            //if page is rendered the first time
            {
                currentID = (string)Session["plantID"];
                currentPlant = Starter.getPlantByID(currentID);
                Session["plant"] = currentPlant;

                lblInfoVariety.Text = currentPlant.Variety;
                lblInfoAge.Text = currentPlant.Age;
                lblInfoDistrict.Text = currentPlant.District;

            }
            else
            {

                currentPlant = (Plant)Session["plant"];
                currentID = (string)Session["plantID"];
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void btnpay_Click(object sender, EventArgs e)
        {
            Response.Redirect("");
        }
    }
}