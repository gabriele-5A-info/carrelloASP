using carrelloASP.Classi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace carrelloASP.Pubblica
{
    public partial class carrello : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("../default.aspx");
            clsUsers user = (clsUsers)Session["user"];

            clsCarrelli car = new clsCarrelli(user.id);
            List<clsCarrelli> carrelli = car.elenco();

            // visualizzazione dei prodotti nel carrello per l'acquisto dell'intero carrello
            elencoCarrello(carrelli);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["user"] == null)
                    Response.Redirect("../default.aspx");
                clsUsers user = (clsUsers)Session["user"];
            }
        }

        private void elencoCarrello(List<clsCarrelli> carrelli)
        {
            // visualizzazione di tutti i prodotti nel carrello per permettere all'utente di acquistarli tutti insieme
            foreach (clsCarrelli carrello in carrelli)
            {
                clsProdotti prodotto = new clsProdotti().getProdotto(carrello.prodotto_id);

                Panel panel = new Panel();
                Panel panelBody = new Panel();

                Label lblNome = new Label();
                Label lblDescrizione = new Label();
                Label lblPrezzo = new Label();
                Image imgProdotto = new Image();
                TextBox txtQuantita = new TextBox();

                panel.CssClass = "panel panel-default";
                panelBody.CssClass = "panel-body";

                lblNome.Text = prodotto.nome;
                lblDescrizione.Text = prodotto.descrizione;
                lblPrezzo.Text = prodotto.prezzo;
                // imgProdotto.ImageUrl = prodotto.immagine;
                txtQuantita.Text = carrello.quantita.ToString();

                panelBody.Controls.Add(lblNome);
                panelBody.Controls.Add(lblDescrizione);
                panelBody.Controls.Add(lblPrezzo);
                panelBody.Controls.Add(imgProdotto);
                panelBody.Controls.Add(txtQuantita);

                panel.Controls.Add(panelBody);

                pnCarrello.Controls.Add(panel);
            }

            Button btnAcquista = new Button();
            btnAcquista.Text = "Acquista";
            btnAcquista.Click += new EventHandler(btnAcquista_Click);

            pnCarrello.Controls.Add(btnAcquista);
        }

        protected void btnAcquista_Click(object sender, EventArgs e)
        {
            clsUsers user = (clsUsers)Session["user"];
            clsStoricoOrdini storico = new clsStoricoOrdini(user.id);
            clsCarrelli car = new clsCarrelli(user.id);
            
            storico.inserisci(car.elenco());
            car.acquista();

            Response.Redirect("storico.aspx");
        }
    }
}