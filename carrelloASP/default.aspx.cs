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
                adoNet.impostaConnessione("App_Data/carrelloASP.mdf");
            }

            if (Session["user"] != null)
            {
                clsUsers user = (clsUsers)Session["user"];
                lblBenvenuto.Text = "Benvenuto " + user.username;
            }
            else
                lblBenvenuto.Text = "Benvenuto ospite";

            showProdotti();
        }

        protected void btnAccediRegistrati_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pubblica/registrazione.aspx");
        }

        protected void btnFornitore_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pubblica/prodotti.aspx");
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pubblica/admin.aspx");
        }

        private void showProdotti()
        {
            List<clsProdotti> prodotti = new clsProdotti().elencoLista(false);

            foreach (clsProdotti prodotto in prodotti)
            {
                Panel panel = new Panel();
                panel.CssClass = "panel panel-default";

                Panel panelBody = new Panel();
                panelBody.CssClass = "panel-body";

                Image img = new Image();
                img.ImageUrl = "img/" + prodotto.immagine;
                img.CssClass = "img-responsive";
                img.Width = 150;
                img.Height = 150;

                Label lblNome = new Label();
                lblNome.Text = prodotto.nome;
                lblNome.CssClass = "text-primary";

                Label lblDescrizione = new Label();
                lblDescrizione.Text = prodotto.descrizione;
                lblDescrizione.CssClass = "text-info";

                Label lblPrezzo = new Label();
                lblPrezzo.Text = "Prezzo: " + prodotto.prezzo + " €";
                lblPrezzo.CssClass = "text-price";

                Label lblQuantita = new Label();
                lblQuantita.Text = "Quantità: " + prodotto.quantita;
                lblQuantita.CssClass = "text-quantita";

                Button btnAcquista = new Button();
                btnAcquista.Text = "Acquista";
                btnAcquista.CssClass = "btn btn-acquista";
                btnAcquista.Click += new EventHandler(btnAcquista_Click);
                btnAcquista.CommandArgument = prodotto.id.ToString();

                panelBody.Controls.Add(img);
                panelBody.Controls.Add(new LiteralControl("<br />"));
                panelBody.Controls.Add(lblNome);
                panelBody.Controls.Add(new LiteralControl("<br />"));
                panelBody.Controls.Add(lblDescrizione);
                panelBody.Controls.Add(new LiteralControl("<br />"));
                panelBody.Controls.Add(lblPrezzo);
                panelBody.Controls.Add(new LiteralControl("<br />"));
                panelBody.Controls.Add(lblQuantita);
                panelBody.Controls.Add(new LiteralControl("<br />"));
                panelBody.Controls.Add(btnAcquista);

                panel.Controls.Add(panelBody);

                pnlProdotti.Controls.Add(panel);
            }
        }

        private void btnAcquista_Click(object sender, EventArgs e)
        {
            Session["prodotto_id"] = ((Button)sender).CommandArgument;
            Response.Redirect("Pubblica/acquista.aspx");
        }

        protected void btnCarrello_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pubblica/carrello.aspx");
        }
    }
}