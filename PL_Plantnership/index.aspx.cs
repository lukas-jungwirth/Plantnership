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
            currentUser = (User)Session["currentUser"];
            lblDisplayUsername.Text = currentUser.Username;
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
            //wenn loggedin == true -> zur Bäume verwalten seite

            //wenn loggedin == false -> zur login seite
        }
    }
}