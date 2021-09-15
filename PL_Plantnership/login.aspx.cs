using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL_Plantnership
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoginSite_Click(object sender, EventArgs e)
        {
            MultViewLogin.ActiveViewIndex = 0;
            btnLoginSite.CssClass = "loginActive loginSiteBtn";
            btnRegisterSite.CssClass = "loginSiteBtn";
        }

        protected void btnRegisterSite_Click(object sender, EventArgs e)
        {
            MultViewLogin.ActiveViewIndex = 1;
            btnRegisterSite.CssClass = "loginActive loginSiteBtn";
            btnLoginSite.CssClass = "loginSiteBtn";
        }
    }
}