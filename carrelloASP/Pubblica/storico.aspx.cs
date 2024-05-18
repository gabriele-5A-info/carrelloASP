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
            foreach (clsStoricoOrdini ordine in ordini)
            {
                clsProdotti prodotto = new clsProdotti().getProdotto(ordine.prodotto_id);

                Panel panel = new Panel();
                Panel panelBody = new Panel();

                Panel panelInfo = new Panel();
                Label lblNome = new Label();
                Label lblDescrizione = new Label();
                Label lblPrezzo = new Label();
                Label lblQuantita = new Label();
                Label lblData = new Label();

                panel.CssClass = "panel panel-default";
                panelBody.CssClass = "panel-body";
                panelInfo.CssClass = "panel-info";

                lblNome.CssClass = "text lbl-nome";
                lblDescrizione.CssClass = "text lbl-descrizione";
                lblPrezzo.CssClass = "text lbl-prezzo";
                lblQuantita.CssClass = "text lbl-quantita";
                lblData.CssClass = "text lbl-data";

                Image img = new Image();
                img.ImageUrl = "../img/" + prodotto.immagine;
                img.CssClass = "img-responsive";
                img.Width = 250;
                img.Height = 250;

                lblNome.Text = prodotto.nome;
                lblDescrizione.Text = prodotto.descrizione;
                lblPrezzo.Text = prodotto.prezzo + "€";
                lblQuantita.Text = ordine.quantita.ToString() + " prodotti acquistati";
                lblData.Text = ordine.data.ToString();

                panelBody.Controls.Add(img);

                panelInfo.Controls.Add(lblNome);
                panelInfo.Controls.Add(lblDescrizione);
                panelInfo.Controls.Add(lblPrezzo);
                panelInfo.Controls.Add(lblQuantita);
                panelInfo.Controls.Add(lblData);

                panel.Controls.Add(panelBody);
                panelBody.Controls.Add(panelInfo);
                pnStorico.Controls.Add(panel);
            }
        }
    }
}