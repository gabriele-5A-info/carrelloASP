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
        protected override void OnInit(EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("../default.aspx");

            if (Session["prodotto_id"] == null)
                Response.Redirect("../default.aspx");

            caricaProdotto();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if (Session["user"] == null)
                    Response.Redirect("../default.aspx");

                if (Session["prodotto_id"] == null)
                    Response.Redirect("../default.aspx");
            }
        }

        private void caricaProdotto()
        {
            clsProdotti prodotto = new clsProdotti().getProdotto(Convert.ToInt32(Session["prodotto_id"]));
            clsUsers fornitore = new clsUsers().getUser(prodotto.fornitore_id);
            clsCategorie categoria = new clsCategorie().getCategoria(prodotto.categoria_id);

            Panel panel = new Panel();
            Panel panelBody = new Panel();

            Label lblNome = new Label();
            Label lblDescrizione = new Label();
            Label lblCategoria = new Label();
            Label lblFornitore = new Label();
            Label lblPrezzo = new Label();
            Image imgProdotto = new Image();
            Label lblQuantita = new Label();
            TextBox txtQuantita = new TextBox();

            Button btnAcquista = new Button();

            panel.CssClass = "panel panel-default";
            panelBody.CssClass = "panel-body";

            lblNome.CssClass = "text lbl-nome";
            lblDescrizione.CssClass = "text lbl-descrizione";
            lblCategoria.CssClass = "text lbl-categoria";
            lblFornitore.CssClass = "text lbl-fornitore";
            lblPrezzo.CssClass = "text lbl-prezzo";
            lblQuantita.CssClass = "text lbl-quantita";
            txtQuantita.CssClass = "input txt-quantita";

            btnAcquista.CssClass = "btn btn-acquista";

            imgProdotto.CssClass = "img-responsive";
            imgProdotto.Width = 250;
            imgProdotto.Height = 250;

            lblNome.Text = prodotto.nome;
            lblDescrizione.Text = prodotto.descrizione;
            lblCategoria.Text = categoria.nome;
            lblFornitore.Text = "Fornitore: " + fornitore.username;
            lblPrezzo.Text = prodotto.prezzo + "€";
            imgProdotto.ImageUrl = "../img/" + prodotto.immagine;
            lblQuantita.Text = "Quantità: ";
            txtQuantita.Text = "1";

            btnAcquista.Text = "Aggiungi al carrello";
            
            btnAcquista.Click += new EventHandler(btnAcquista_Click);
            btnAcquista.CommandArgument = prodotto.id.ToString();

            panelBody.Controls.Add(lblNome);
            panelBody.Controls.Add(lblDescrizione);
            panelBody.Controls.Add(lblCategoria);
            panelBody.Controls.Add(lblFornitore);
            panelBody.Controls.Add(lblPrezzo);
            panelBody.Controls.Add(imgProdotto);
            panelBody.Controls.Add(lblQuantita);
            panelBody.Controls.Add(txtQuantita);
            panelBody.Controls.Add(btnAcquista);
            panel.Controls.Add(panelBody);
            pnlProdotto.Controls.Add(panel);
        }

        protected void btnAcquista_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            clsProdotti prodotto = new clsProdotti(Convert.ToInt32(btn.CommandArgument)).getProdotto();
            prodotto.quantita -= Convert.ToInt32(((TextBox)((Button)sender).Parent.Controls[7]).Text);

            if(prodotto.quantita < 0)
            {
                lblErrore.Text = "Quantità non disponibile";
                lblErrore.ForeColor = System.Drawing.Color.Red;
                return;
            }

            prodotto.modifica();

            clsCarrelli carrello = new clsCarrelli(((clsUsers)Session["user"]).id);

            carrello.user_id = ((clsUsers)Session["user"]).id;
            carrello.quantita = Convert.ToInt32(((TextBox)((Button)sender).Parent.Controls[7]).Text);
            carrello.prodotto_id = Convert.ToInt32(btn.CommandArgument);

            if(carrello.inserisci())
            {
                lblErrore.Text = "Prodotto aggiunto al carrello";
                lblErrore.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblErrore.Text = "Errore nell'aggiunta al carrello";
                lblErrore.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}