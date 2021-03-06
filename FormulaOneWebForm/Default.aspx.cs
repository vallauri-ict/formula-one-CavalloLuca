﻿using FormulaOneDLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormulaOneWebForm
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // lo fa eseguire sempre TRANNE la prima volta, perchè al primo giro è false, poi diventa true
            // ispostback è sempre falsa la prima volta
            if (!Page.IsPostBack) 
            {
                // inizializzazioni che vengono eseguite solo la prima volta che carico la pagina
                // lblMessaggio.Text = "Digita username e password, poi clicca sul pulsante INVIA";
                //lblMessaggio.Text = "Premi il pulsante INVIA, apparirà la lista delle nazioni gestite.";
                DBtools db = new DBtools();
                cmbTables.DataSource = db.getTableName();
                cmbTables.DataBind();
                cmbTables.SelectedIndex = 0;
                dgvItems.DataSource = db.getTable(cmbTables.SelectedItem.ToString());
                dgvItems.DataBind();
            }
            else
            {
                // elaborazioni da eseguire tutte le volte che la pagina viene ricaricata
                // lblMessaggio.Text = "Benvenuto al signor " + txtUserName.Text;
                // riempire la lista nazioni
                //DBtools db=new DBtools();
                //dgvItems.DataSource = db.getTable(cmbTables.SelectedIndex.ToString());
                //dgvItems.DataBind();
                Getcountry("");
            }
        }

        protected void changeSelection(object sender, EventArgs e)
        {
            DBtools db = new DBtools();
            dgvItems.DataSource = db.caricaTables(cmbTables.SelectedItem.ToString());
            dgvItems.DataBind();
        }

        public void Getcountry(string isoCode="")
        {
            HttpWebRequest apiRequest = WebRequest.Create("http://localhost:44308/api/Country/" + isoCode + "") as HttpWebRequest;
            string apiResponse = "";
            try
            {
                using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    apiResponse = reader.ReadToEnd();
                    Country[] oCountry = Newtonsoft.Json.JsonConvert.DeserializeObject<Country[]>(apiResponse);
                    lblNazioni.DataSource = oCountry;
                    lblNazioni.DataBind();
                    lblNazioni.Visible = true;
                }
            }
            catch(System.Net.WebException ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}