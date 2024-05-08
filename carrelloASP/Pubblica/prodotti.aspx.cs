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
using System.Globalization;

namespace carrelloASP.Pubblica
{
    public partial class prodotti : System.Web.UI.Page
    {
        static clsUsers user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                user = (clsUsers)Session["user"];
                if (user == null)
                    Response.Redirect("../default.aspx");

                ddlCaricaCategorie();
                ddlCaricaElementiFornitore();
            }
        }

        protected void btnAggiungi_Click(object sender, EventArgs e)
        {
            if (txtNomeAggiungi.Text == string.Empty || txtDescrizioneAggiungi.Text == string.Empty || txtPrezzoAggiungi.Text == string.Empty || txtQuantitaAggiungi.Text == string.Empty || txtImmagineAggiungi.Text == string.Empty || ddlCategoriaAggiungi.SelectedValue == string.Empty)
            {
                lblRisultatoAggiungi.Text = "Compilare tutti i campi";
                return;
            }

            clsProdotti prodotto = new clsProdotti(
                txtNomeAggiungi.Text.Trim().Replace('\'', ' '),
                txtDescrizioneAggiungi.Text.Trim().Replace('\'', ' '),
                txtPrezzoModifica.Text,
                Convert.ToInt32(txtQuantitaAggiungi.Text),
                txtImmagineAggiungi.Text.Trim().Replace('\'', ' '),
                Convert.ToInt32(ddlCategoriaAggiungi.SelectedValue),
                Convert.ToInt32(user.id),
                true
            );

            if(prodotto.inserisci())
                lblRisultatoAggiungi.Text = "Prodotto inserito correttamente";
            else
                lblRisultatoAggiungi.Text = "Errore nell'inserimento del prodotto";
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            if(ddlElementoModifica.SelectedValue == string.Empty)
            {
                lblRisultatoModifica.Text = "Selezionare un prodotto da modificare";
                return;
            }

            clsProdotti prodotto = new clsProdotti(Convert.ToInt32(ddlElementoModifica.SelectedValue));
            prodotto = prodotto.getProdotto(prodotto.id);

            clsProdotti prodottoModifica = new clsProdotti(
                prodotto.id,
                txtNomeModifica.Text != string.Empty ? txtNomeModifica.Text.Trim().Replace('\'', ' ') : prodotto.nome,
                txtDescrizioneModifica.Text != string.Empty ? txtDescrizioneModifica.Text.Trim().Replace('\'', ' ') : prodotto.descrizione,
                txtPrezzoModifica.Text != string.Empty ? txtPrezzoModifica.Text : prodotto.prezzo.ToString(CultureInfo.InvariantCulture),
                txtQuantitaModifica.Text != string.Empty ? Convert.ToInt32(txtQuantitaModifica.Text) : prodotto.quantita,
                txtImmagineModifica.Text != string.Empty ? txtImmagineModifica.Text.Trim().Replace('\'', ' ') : prodotto.immagine,
                ddlCategoriaModifica.SelectedValue != string.Empty ? Convert.ToInt32(ddlCategoriaModifica.SelectedValue) : prodotto.categoria_id,
                user.id,
                ddlValiditaModifica.SelectedValue != string.Empty ? Convert.ToBoolean(Convert.ToInt32(ddlValiditaModifica.SelectedValue)) : prodotto.validita
            );

            if (prodottoModifica.modifica())
                lblRisultatoModifica.Text = "Prodotto modificato correttamente";
            else
                lblRisultatoModifica.Text = "Errore nella modifica del prodotto";
        }

        private void ddlCaricaCategorie()
        {
            ddlCategoriaAggiungi.DataSource = new clsCategorie().elenco();
            ddlCategoriaAggiungi.DataTextField = "nome";
            ddlCategoriaAggiungi.DataValueField = "id";
            ddlCategoriaAggiungi.DataBind();
            ddlCategoriaAggiungi.Items.Insert(0, new ListItem("Seleziona una categoria", ""));

            ddlCategoriaModifica.DataSource = new clsCategorie().elenco();
            ddlCategoriaModifica.DataTextField = "nome";
            ddlCategoriaModifica.DataValueField = "id";
            ddlCategoriaModifica.DataBind();
            ddlCategoriaModifica.Items.Insert(0, new ListItem("Seleziona una categoria", ""));
        }

        private void ddlCaricaElementiFornitore()
        {
            ddlElementoModifica.DataSource = new clsProdotti().elenco(user.id, true);
            ddlElementoModifica.DataTextField = "nome";
            ddlElementoModifica.DataValueField = "id";
            ddlElementoModifica.DataBind();
            ddlElementoModifica.Items.Insert(0, new ListItem("Seleziona un prodotto", ""));
        }

        protected void ddlElementoModifica_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlElementoModifica.SelectedValue == string.Empty)
            {
                txtNomeModifica.Text = string.Empty;
                txtDescrizioneModifica.Text = string.Empty;
                txtPrezzoModifica.Text = string.Empty;
                txtQuantitaModifica.Text = string.Empty;
                txtImmagineModifica.Text = string.Empty;
                ddlValiditaModifica.SelectedValue = string.Empty;
                ddlCategoriaModifica.SelectedValue = string.Empty;
                return;
            }

            clsProdotti prodotto = new clsProdotti(Convert.ToInt32(ddlElementoModifica.SelectedValue)).getProdotto();

            if (prodotto.validita)
                ddlValiditaModifica.SelectedValue = "1";
            else
                ddlValiditaModifica.SelectedValue = "0";
            ddlCategoriaModifica.SelectedValue = prodotto.categoria_id.ToString();
        }
    }
}