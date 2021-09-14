using BL_Plantnership;
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

        protected void btnLoginAktiv_Click(object sender, EventArgs e)
        {
            //check ob 'User in DB existiert, wenn ja Session starten
        }

        protected void btnRegistrieren_Click(object sender, EventArgs e)
        {
            //User in DB anlegen

            //Session mit User starten
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = inputUsername.Text;
            string pw = inputPassword.Text;
            string name = inputName.Text;
            string lastName = inputLastName.Text;
            string mail = inputLastName.Text;
            
            int feedback = Starter.register(username, pw, name, lastName, mail);
            string feedbackStr;
            if (feedback == 1) feedbackStr = "Erfolgreich";
            else if (feedback == 0) feedbackStr = "Username bereits vorhanden!";
            else feedbackStr = "Ein Fehler ist aufgetreten!";

            lblFeedbackRegister.Text = feedbackStr;
        }
    }
}