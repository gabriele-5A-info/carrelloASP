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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAccedi_Click(object sender, EventArgs e)
        {
            users user = new users(txtEmailAccedi.Text, txtPasswordAccedi.Text);
            Session["user"] = user.getUser();
            Response.Redirect("../default.aspx");
        }

        protected void btnRegistrati_Click(object sender, EventArgs e)
        {
            users user = new users(txtUsernameRegistrati.Text, txtPasswordRegistrati.Text, txtEmailRegistrati.Text, rblRole.SelectedValue);
            user.inserisci();
            Response.Redirect("../default.aspx");
        }
    }
}