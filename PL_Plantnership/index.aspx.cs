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
        private Categories categoryList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if((User)Session["currentUser"] == null)
            {
                Response.Redirect("login.aspx");
            }

            if (!IsPostBack)
            {
                currentUser = (User)Session["currentUser"];
                categoryList = Starter.getAllCategories();
                lblDisplayUsername.Text = currentUser.Username;
                RepeaterCategory.DataSource = categoryList;
                RepeaterCategory.DataBind();
            }
            else
            {
                currentUser = (User)Session["currentUser"];
                categoryList = (Categories)Session["categoryList"];
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
            Session["category"] = "1";
            Response.Redirect("ObstBaumUnterKategorie.aspx");
        }

        protected void imgBtnBirne_Click(object sender, ImageClickEventArgs e)
        {
            Session["category"] = "2";
            Response.Redirect("ObstBaumUnterKategorie.aspx");
        }

        protected void imgBtnKirsche_Click(object sender, ImageClickEventArgs e)
        {
            Session["category"] = "3";
            Response.Redirect("ObstBaumUnterKategorie.aspx");
        }

        protected void imgBtnMarille_Click(object sender, ImageClickEventArgs e)
        {
            Session["category"] = "4";
            Response.Redirect("ObstBaumUnterKategorie.aspx");
        }

        protected void imgBtnPfirsich_Click(object sender, ImageClickEventArgs e)
        {
            Session["category"] = "5";
            Response.Redirect("ObstBaumUnterKategorie.aspx");
        }

        protected void imgBtnZwetschke_Click(object sender, ImageClickEventArgs e)
        {
            Session["category"] = "6";
            Response.Redirect("ObstBaumUnterKategorie.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void ShowCat_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "ShowCategory")
            {
                int catID = Convert.ToInt32(e.CommandArgument);
                Category currentCategory = Starter.getCategoryById(catID);
                Session["category"] = currentCategory;
                Response.Redirect("ObstBaumUnterKategorie.aspx");
            }
        }
    }
}