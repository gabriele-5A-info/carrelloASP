using carrelloASP.Classi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace carrelloASP.Pubblica
{
    public partial class storico : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("../default.aspx");
            clsUsers user = (clsUsers)Session["user"];

            clsStoricoOrdini storico = new  clsStoricoOrdini(user.id);
            visualizzaStorico(storico.getOrdini());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if (Session["user"] == null)
                    Response.Redirect("../default.aspx");
            }
        }

        private void visualizzaStorico(List<clsStoricoOrdini> ordini)
        {
            // visualizzazione di tutti i prodotti acquistati dall'utente
            foreach (clsStoricoOrdini ordine in ordini)
            {
                clsProdotti prodotto = new clsProdotti().getProdotto(ordine.prodotto_id);

                Panel panel = new Panel();
                Panel panelBody = new Panel();

                Label lblNome = new Label();
                Label lblDescrizione = new Label();
                Label lblPrezzo = new Label();
                Image imgProdotto = new Image();
                Label lblQuantita = new Label();

                panel.CssClass = "panel panel-default";
                panelBody.CssClass = "panel-body";

                lblNome.Text = prodotto.nome;
                lblDescrizione.Text = prodotto.descrizione;
                lblPrezzo.Text = prodotto.prezzo;
                // imgProdotto.ImageUrl = prodotto.immagine;
                lblQuantita.Text = ordine.quantita.ToString();

                panelBody.Controls.Add(lblNome);
                panelBody.Controls.Add(lblDescrizione);
                panelBody.Controls.Add(lblPrezzo);
                panelBody.Controls.Add(imgProdotto);
                panelBody.Controls.Add(lblQuantita);

                panel.Controls.Add(panelBody);
                pnStorico.Controls.Add(panel);
            }
        }
    }
}