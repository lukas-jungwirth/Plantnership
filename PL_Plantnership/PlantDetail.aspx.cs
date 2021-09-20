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
        User currentUser;
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
                
                currentID = (string)Session["plantID"];
                currentPlant = Starter.getPlantByID(currentID);
                Session["plant"] = currentPlant;

                lblInfoVariety.Text = currentPlant.Variety;
                lblInfoAge.Text = currentPlant.Age;
                lblInfoDistrict.Text = currentPlant.District;
                lblAmountType1.Text = currentPlant.getAmountOfAbos(1).ToString();
                lblAmountType2.Text = currentPlant.getAmountOfAbos(2).ToString();
                radioBtnCat.SelectedIndex = 0;

                //check if plant is allready purchased
                if (currentUser.hasPurchased(currentPlant))
                {
                    btnBuy.Enabled = false;
                    radioBtnCat.Enabled = false;
                    lblBuyError.Text = "Sie sind bereits stolzer Abonnent dieser Pflanze!";
                }
            }
            else
            {

                currentPlant = (Plant)Session["plant"];
                currentUser = (User)Session["currentUser"];
                currentID = (string)Session["plantID"];
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void btnBuy_Click(object sender, ImageClickEventArgs e)
        {
            int index = radioBtnCat.SelectedIndex;
            //indx starts with 0 and abotype with 1
            int aboType = index++;
            bool success = currentUser.purchasePlant(currentPlant, aboType);
            if (success)
            {
                Response.Redirect("payPage.aspx");
            }
            else
            {
                lblBuyError.Text = "Kauf fehlgeschlagen!";
            }
            
        }
    }
}