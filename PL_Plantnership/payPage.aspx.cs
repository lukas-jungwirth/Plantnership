using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Plantnership;

namespace PL_Plantnership
{
    public partial class payPage : System.Web.UI.Page
    {
        Plant currentPlant;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((User)Session["currentUser"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else if((Plant)Session["plant"] == null)
            {
                Response.Redirect("index.aspx");
            }

            if (!IsPostBack)
            //if page is rendered the first time
            {
                currentPlant = (Plant)Session["plant"];
                int aboType = (int)Session["aboType"];
                
                lblInfoVariety.Text = currentPlant.Variety;
                lblInfoAge.Text = currentPlant.Age;
                lblInfoDistrict.Text = currentPlant.District;
                lblStreet.Text = currentPlant.Street;
                lblHouseNumber.Text = currentPlant.HouseNumber;
                lblAboInfo.Text = aboType.ToString();

                if (aboType == 0) lblDescription.Text = "Sie sind jetzt offizieller Supporter dieser Pflanze!";
                else lblDescription.Text = "Als offizieller Planter haben sie nun die Lizenz selbst die reifen Früchte ihrer Pflanze zu ernten. Nehmen sie dabei Rücksicht auf andere Plantner und beachten Sie, dass die Pflückerlaubnis nach dem Prinzip Wer zuerst kommt pflückt zuerst erfolgt!";




            }
            else
            {

                currentPlant = (Plant)Session["plant"];
            }
        }

        protected void btnpay_Click(object sender, EventArgs e)
        {

        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void bntBaumVerwalten_Click(object sender, EventArgs e)
        {
            Response.Redirect("Verwaltung.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("login.aspx");
        }
    }
}