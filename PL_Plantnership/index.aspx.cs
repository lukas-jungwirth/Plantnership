using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Plantnership;


namespace PL_Plantnership
{
    public partial class Test : System.Web.UI.Page
    {

        private User currentUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            if((User)Session["currentUser"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                currentUser = (User)Session["currentUser"];
                lblDisplayUsername.Text = currentUser.Username;
            }
            
        }


        protected void btnTreeMatch_Click(System.Object sender, System.EventArgs e)
        {
            //Baumauswahl wird angezeigt
        }

        protected void btnLogin_Click(System.Object sender, System.EventArgs e)
        {
            //Login seite lädt
            
        }

        protected void btnBaumVerwalten_Click(System.Object sender, System.EventArgs e)
        {

            //geht eh nur wenn user eingelogged
            Response.Redirect("Verwaltung.aspx");

        }

        protected void imgBtnApfel_Click(object sender, ImageClickEventArgs e)
        {
            Session["category"] = "Apfel";
            Response.Redirect("ObstBaumUnterKategorie.aspx");
        }

        protected void imgBtnBirne_Click(object sender, ImageClickEventArgs e)
        {
            Session["category"] = "Birne";
            Response.Redirect("ObstBaumUnterKategorie.aspx");
        }

        protected void imgBtnKirsche_Click(object sender, ImageClickEventArgs e)
        {
            Session["category"] = "Kirsche";
            Response.Redirect("ObstBaumUnterKategorie.aspx");
        }

        protected void imgBtnMarille_Click(object sender, ImageClickEventArgs e)
        {
            Session["category"] = "Marille";
            Response.Redirect("ObstBaumUnterKategorie.aspx");
        }

        protected void imgBtnPfirsich_Click(object sender, ImageClickEventArgs e)
        {
            Session["category"] = "Pfirsich";
            Response.Redirect("ObstBaumUnterKategorie.aspx");
        }

        protected void imgBtnZwetschke_Click(object sender, ImageClickEventArgs e)
        {
            Session["category"] = "Zwetschke";
            Response.Redirect("ObstBaumUnterKategorie.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}