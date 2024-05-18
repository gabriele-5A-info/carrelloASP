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

namespace carrelloASP.Pubblica
{
    public partial class registrazione : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["user"] != null)
                {
                    divContainer.Visible = false;

                    btnLogout.Visible = true;
                }
                else
                {
                    divContainer.Visible = true;

                    btnLogout.Visible = false;
                }
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAccedi_Click(object sender, EventArgs e)
        {
            clsUsers user = new clsUsers(txtEmailAccedi.Text, txtPasswordAccedi.Text);
            Session["user"] = user.getUser();

            if (Session["user"] != null)
                Response.Redirect("../default.aspx");
            else
            {
                lblErrore.Text = "Errore: email o password errati";
            }
        }

        protected void btnRegistrati_Click(object sender, EventArgs e)
        {
            clsUsers user = new clsUsers(txtUsernameRegistrati.Text, txtPasswordRegistrati.Text, txtEmailRegistrati.Text, rblRole.SelectedValue);
            user.inserisci();
            Response.Redirect("../default.aspx");
        }

        protected void btnBack_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("../default.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("../default.aspx");
        }
    }
}