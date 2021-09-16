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

        string currentID;
        Plant currentPlant;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                currentID = (string)Session["ID"]; //wurde beim Aufruf übertragen
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
                currentPlant.Vorname = txtVorname.Text;
                currentPlant.Kundenstatus = ddStatus.SelectedValue;
                if (currentPlant.Save())
                    Response.Redirect("Default.aspx");
                else lblFehlermeldung.Text = "Speichern fehlgeschlagen";
            }
            else lblFehlermeldung.Text = "Kunde existiert nicht mehr in DB!";
        }

        protected void btnManageDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnManageCancel_Click(object sender, EventArgs e)
        {

        }
    }
}