﻿using BL_Plantnership;
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

        protected void btnReg_Click(object sender, EventArgs e)
        {
            string user = inputRegUsername.Text;
            string pw = inputRegPassword.Text;
            string name = inputRegName.Text;
            string lstName = inputRegLstName.Text;
            string mail = inputRegMail.Text;
            int feedback = Starter.register(user, pw, name, lstName, mail);
            string feedbackStr;
            if (feedback == 1) {
                MultViewLogin.ActiveViewIndex = 0;
                btnLoginSite.CssClass = "loginActive loginSiteBtn";
                btnRegisterSite.CssClass = "loginSiteBtn";
                feedbackStr = "erfolgreich";
                lblFeedbackLogin.Text = "Registrierung war erfolgreich";
            }
            else if (feedback == 0) feedbackStr = "Benutzername bereits vorhanden";
            else feedbackStr = "Ein Fehler ist aufgetreten!";

            lblFeedbackReg.Text = feedbackStr;

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string loginUser = inputLoginUsername.Text;
            string loginPw = inputLoginPassword.Text;

            string feedback = Starter.Login(loginUser, loginPw);
            string dispFdbk;
            if (feedback == "error_db") dispFdbk = "Leider ist ein Fehler in der Datenbankverbindung aufgetreten!";
            else if (feedback == "error_user") dispFdbk = "Der eingegebene Username ist nicht vorhanden!";
            else if (feedback == "error_pw") dispFdbk = "Passwort falsch!";
            else
            {
                dispFdbk = "Login erfolgreich";
                // user to session
                Session["currentUser"] = Starter.getUserByID(feedback);
                Response.Redirect("index.aspx"); 
                
            }
            lblFeedbackLogin.Text = dispFdbk;
        }
    }
}