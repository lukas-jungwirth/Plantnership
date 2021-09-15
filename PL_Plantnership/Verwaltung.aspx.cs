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
        protected void Page_Load(object sender, EventArgs e)
        {

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
    }
}