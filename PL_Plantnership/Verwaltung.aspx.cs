using BL_Plantnership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PL_Plantnership
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        User currentUser;
        Plants myTrees;
        Plants rentedTrees;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((User)Session["currentUser"] == null)
            {
                Response.Redirect("login.aspx");
            }


                if (!IsPostBack)
                //if page is rendered the first time
                {

                    currentUser = (User)Session["currentUser"];
                    myTrees = currentUser.getUserPlants();
                    
                    Repeater1.DataSource = myTrees;
                    Repeater1.DataBind();

                    rentedTrees = currentUser.loadRentedPlants();
                    RepeaterRented.DataSource = rentedTrees;
                    RepeaterRented.DataBind();

                    Session["myTrees"] = myTrees;
                    Session["rentedTrees"] = rentedTrees;

                    lblProfileUsername.Text = currentUser.Username;
                    lblProfileName.Text = currentUser.Name;
                    lblProfileLstName.Text = currentUser.LastName;
                    lblProfileMail.Text = currentUser.Mail;

                }
                else
                {

                    currentUser = (User)Session["currentUser"];
                    myTrees = (Plants)Session["myTrees"];
                    rentedTrees = (Plants)Session["rentedTrees"];
                    
                }
            
        }

        protected void btnMyTreeSite_Click(object sender, EventArgs e)
        {
            MultiViewVerwaltung.ActiveViewIndex = 0;
            btnMyTreeSite.CssClass = "loginActive loginSiteBtn";
            btnRentTreeSite.CssClass = "loginSiteBtn";
           
        }

        protected void btnRentTreeSite_Click(object sender, EventArgs e)
        {
            MultiViewVerwaltung.ActiveViewIndex = 1;
            btnRentTreeSite.CssClass = "loginActive loginSiteBtn";
            btnMyTreeSite.CssClass = "loginSiteBtn";
        }

        protected void btnCreateNewPlant_Click(object sender, EventArgs e)
        {
            //empty ID -> new plant object
            Session["plantID"] = "";
            Response.Redirect("manageTree.aspx");
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void Edit_Click(object sender, CommandEventArgs e)
        {
            if(e.CommandName == "EditClick")
            {
                Session["plantID"] = e.CommandArgument; 
                Response.Redirect("manageTree.aspx");
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

    }
}