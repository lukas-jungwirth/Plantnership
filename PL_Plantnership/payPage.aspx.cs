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
                Plant currentPlant = (Plant)Session["plant"];

                
                lblInfoVariety.Text = currentPlant.Variety;
                lblInfoAge.Text = currentPlant.Age;
                lblInfoDistrict.Text = currentPlant.District;
                lblAboInfo.Text = (string)Session["aboType"];
                
            }
            else
            {

                //currentPlant = (Plant)Session["plant"];
                //currentID = (string)Session["plantID"];
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