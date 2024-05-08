using carrelloASP.Classi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace carrelloASP.Pubblica
{
    public partial class acquista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if (Session["user"] == null)
                    Response.Redirect("../default.aspx");

                if (Session["prodotto_id"] == null)
                    Response.Redirect("../default.aspx");

                caricaProdotto();
            }
        }

        private void caricaProdotto()
        {
            clsProdotti prodotto = new clsProdotti().getProdotto(Convert.ToInt32(Session["prodotto_id"]));

            Panel panel = new Panel();
            Panel panelBody = new Panel();

            Label lblNome = new Label();
            Label lblDescrizione = new Label();
            Label lblPrezzo = new Label();
            Image imgProdotto = new Image();
            TextBox txtQuantita = new TextBox();

            Button btnAcquista = new Button();

            panel.CssClass = "panel panel-default";
            panelBody.CssClass = "panel-body";

            lblNome.Text = prodotto.nome;
            lblDescrizione.Text = prodotto.descrizione;
            lblPrezzo.Text = prodotto.prezzo;
            imgProdotto.ImageUrl = prodotto.immagine;
            txtQuantita.Text = "1";

            btnAcquista.Text = "Acquista";

            panelBody.Controls.Add(lblNome);
            panelBody.Controls.Add(lblDescrizione);
            panelBody.Controls.Add(lblPrezzo);
            panelBody.Controls.Add(imgProdotto);
            panelBody.Controls.Add(txtQuantita);
            panelBody.Controls.Add(btnAcquista);
            panel.Controls.Add(panelBody);
            pnlProdotto.Controls.Add(panel);

            btnAcquista.Click += new EventHandler(btnAcquista_Click);
            btnAcquista.CommandArgument = prodotto.id.ToString();
        }

        protected void btnAcquista_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int prodotto_id = Convert.ToInt32(btn.CommandArgument);

            int quantita = Convert.ToInt32(((TextBox)((Button)sender).Parent.Controls[4]).Text);

            // clsCarrello carrello = new clsCarrello();

            // carrello.aggiungiProdotto(prodotto_id, quantita);

            Response.Redirect("carrello.aspx");
        }
    }
}