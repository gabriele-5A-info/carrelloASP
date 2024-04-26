using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// using specifiche
using System.Data;
using adoNetWebSQlServer;
using carrelloASP.Classi;

namespace carrelloASP
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // collegamento al db
                adoNet.impostaConnessione("App_Data/carrelloASP.mdf");
            }

            if (Session["user"] != null)
            {
                users user = (users)Session["user"];
                lblBenvenuto.Text = "Benvenuto " + user.username;
            }
            else
                lblBenvenuto.Text = "Benvenuto ospite";
        }

        protected void btnAccediRegistrati_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pubblica/registrazione.aspx");
        }
    }
}