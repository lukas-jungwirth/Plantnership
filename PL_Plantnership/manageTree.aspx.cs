using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Plantnership;

namespace PL_Plantnership
{
    public partial class manageTree : System.Web.UI.Page
    {
        User currentUser;
        string currentID;
        Plant currentPlant;
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((User)Session["currentUser"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                currentUser = (User)Session["currentUser"];
            }

            if (!IsPostBack)
            {
                currentID = (string)Session["plantID"]; //wurde beim Aufruf übertragen
                if (currentID != "")
                {
                    //Objekt laden und Werte setzen
                    currentPlant = Starter.getPlantByID(currentID);
                    //if there is already a plant object with this id
                    if (currentPlant != null)
                    {
                        //kopiere die Properties des Objekts in die Felder der Maske
                        radioBtnCat.SelectedValue = currentPlant.Category;
                        txtVariety.Text = currentPlant.Variety;
                        txtAge.Text = currentPlant.Age;
                        txtDistrict.Text = currentPlant.District;
                        txtStreet.Text = currentPlant.Street;
                        txtHouseNumb.Text = currentPlant.HouseNumber;
                        Session["Plant"] = currentPlant;
                        btnManageDelete.Visible = true;
                    }
                    else
                    {
                        lblError.Text = "Leider konnten wir ihre Pflanze nicht finden. Gerne können Sie eine neue Pflanze anlegen!";
                        btnManageDelete.Visible = false;
                        Session["Plant"] = Starter.newPlant(); //new empty Plant
                    }
                }
                else
                {
                    //if id empty -> new plant
                    btnManageDelete.Visible = false;
                    currentPlant = Starter.newPlant();
                    Session["Plant"] = currentPlant;
                }
            }
            else
            {
                currentPlant = (Plant)Session["Plant"];
            }
                

        }

        protected void btnManageSave_Click(object sender, EventArgs e)
        {
            if (currentPlant != null)
            {
                //Feldwerte in das Objekt laden
                currentPlant.Category = radioBtnCat.SelectedValue;
                currentPlant.Variety = txtVariety.Text;
                currentPlant.Age = txtAge.Text;
                currentPlant.District = txtDistrict.Text;
                currentPlant.Street = txtStreet.Text;
                currentPlant.HouseNumber = txtHouseNumb.Text;
                currentPlant.Owner = currentUser.Username;
                if (currentPlant.Save())
                {
                    Response.Redirect("Verwaltung.aspx");
                }
                else
                {
                    lblError.Text = "Speichern fehlgeschlagen";
                }
            }
            else lblError.Text = "Pflanze existiert nicht mehr in DB!";
        }

        protected void btnManageDelete_Click(object sender, EventArgs e)
        {
            currentPlant = (Plant)Session["Plant"];
            if (currentPlant.Delete())
                Response.Redirect("Default.aspx");
            else
                lblError.Text = "Löschen nicht möglich";
        }

        protected void btnManageCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Verwaltung.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}