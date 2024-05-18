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
                Panel panelInfo = new Panel();

                Label lblNome = new Label();
                Label lblDescrizione = new Label();
                Label lblPrezzo = new Label();
                Image imgProdotto = new Image();
                Label lblQuantita = new Label();

                Button btnRimuovi = new Button();

                panel.CssClass = "panel panel-default";
                panelBody.CssClass = "panel-body";
                panelInfo.CssClass = "panel-info";

                lblNome.Text = prodotto.nome;
                lblDescrizione.Text = prodotto.descrizione;
                lblPrezzo.Text = prodotto.prezzo;
                imgProdotto.ImageUrl = "../img/" + prodotto.immagine;
                lblQuantita.Text = carrello.quantita.ToString();

                lblNome.CssClass = "text lbl-nome";
                lblDescrizione.CssClass = "text lbl-descrizione";
                lblPrezzo.CssClass = "text lbl-prezzo";
                imgProdotto.CssClass = "img-responsive";
                imgProdotto.Width = 250;
                imgProdotto.Height = 250;
                lblQuantita.CssClass = "text lbl-quantita";

                panelBody.Controls.Add(imgProdotto);

                btnRimuovi.CssClass = "btn btn-rimuovi";
                btnRimuovi.Text = "Rimuovi";
                btnRimuovi.Click += new EventHandler(btnRimuovi_Click);
                btnRimuovi.CommandArgument = carrello.id.ToString();

                panelInfo.Controls.Add(lblNome);
                panelInfo.Controls.Add(lblDescrizione);
                panelInfo.Controls.Add(lblPrezzo);
                panelInfo.Controls.Add(lblQuantita);
                panelInfo.Controls.Add(btnRimuovi);

                panel.Controls.Add(panelBody);
                panel.Controls.Add(panelInfo);

                pnCarrello.Controls.Add(panel);
            }

            Button btnAcquista = new Button();
            btnAcquista.CssClass = "btn btn-acquista";
            btnAcquista.Text = "Acquista";
            btnAcquista.Click += new EventHandler(btnAcquista_Click);

            pnCarrello.Controls.Add(btnAcquista);
        }

        protected void btnRimuovi_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            clsUsers user = (clsUsers)Session["user"];
            clsCarrelli car = new clsCarrelli(user.id).getProdotto(Convert.ToInt32(id));
            clsProdotti prodotto = new clsCarrelli(user.id).getProdottoCarrello(Convert.ToInt32(id));

            car.rimuovi(Convert.ToInt32(id));

            prodotto.quantita += car.quantita;
            prodotto.modifica();

            Response.Redirect("carrello.aspx");
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

        protected void btnStorico_Click(object sender, EventArgs e)
        {
            Response.Redirect("storico.aspx");
        }
    }
}