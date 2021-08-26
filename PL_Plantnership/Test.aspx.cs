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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Starter starter = new Starter();
            int zahl = starter.test();
            lblOutput.Text = zahl.ToString();
        }
    }
}