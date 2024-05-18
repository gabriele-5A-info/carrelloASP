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
            if (txtNomeAggiungi.Text == string.Empty || txtDescrizioneAggiungi.Text == string.Empty || txtPrezzoAggiungi.Text == string.Empty || txtQuantitaAggiungi.Text == string.Empty || fuImmagineAggiungi.FileName == string.Empty || ddlCategoriaAggiungi.SelectedValue == string.Empty)
            {
                lblRisultatoAggiungi.Text = "Compilare tutti i campi";
                lblRisultatoAggiungi.ForeColor = System.Drawing.Color.Red;
                return;
            }

            clsProdotti prodotto = new clsProdotti(
                txtNomeAggiungi.Text.Trim().Replace('\'', ' '),
                txtDescrizioneAggiungi.Text.Trim().Replace('\'', ' '),
                txtPrezzoModifica.Text,
                Convert.ToInt32(txtQuantitaAggiungi.Text),
                fuImmagineAggiungi.FileName,
                Convert.ToInt32(ddlCategoriaAggiungi.SelectedValue),
                Convert.ToInt32(user.id),
                true
            );

            if (prodotto.inserisci())
            {
                lblRisultatoAggiungi.Text = "Prodotto inserito correttamente";
                lblRisultatoAggiungi.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblRisultatoAggiungi.Text = "Errore nell'inserimento del prodotto";
                lblRisultatoAggiungi.ForeColor = System.Drawing.Color.Red;
            }

            // caricamento immagine nella cartella img
            fuImmagineAggiungi.SaveAs(Server.MapPath("~/img/") + fuImmagineAggiungi.FileName);
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            if(ddlElementoModifica.SelectedValue == string.Empty)
            {
                lblRisultatoModifica.Text = "Selezionare un prodotto da modificare";
                lblRisultatoModifica.ForeColor = System.Drawing.Color.Red;
                return;
            }

            clsProdotti prodotto = new clsProdotti(Convert.ToInt32(ddlElementoModifica.SelectedValue));
            prodotto = prodotto.getProdotto(prodotto.id);
            string tempImg = prodotto.immagine;

            clsProdotti prodottoModifica = new clsProdotti(
                prodotto.id,
                txtNomeModifica.Text != string.Empty ? txtNomeModifica.Text.Trim().Replace('\'', ' ') : prodotto.nome,
                txtDescrizioneModifica.Text != string.Empty ? txtDescrizioneModifica.Text.Trim().Replace('\'', ' ') : prodotto.descrizione,
                txtPrezzoModifica.Text != string.Empty ? txtPrezzoModifica.Text : prodotto.prezzo.ToString(CultureInfo.InvariantCulture),
                txtQuantitaModifica.Text != string.Empty ? Convert.ToInt32(txtQuantitaModifica.Text) : prodotto.quantita,
                fuImmagineModifica.FileName != string.Empty ? fuImmagineModifica.FileName : prodotto.immagine,
                ddlCategoriaModifica.SelectedValue != string.Empty ? Convert.ToInt32(ddlCategoriaModifica.SelectedValue) : prodotto.categoria_id,
                user.id,
                ddlValiditaModifica.SelectedValue != string.Empty ? Convert.ToBoolean(Convert.ToInt32(ddlValiditaModifica.SelectedValue)) : prodotto.validita
            );

            if (prodottoModifica.modifica())
            {
                lblRisultatoModifica.Text = "Prodotto modificato correttamente";
                lblRisultatoModifica.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblRisultatoModifica.Text = "Errore nella modifica del prodotto";
                lblRisultatoModifica.ForeColor = System.Drawing.Color.Red;
            }

            // cancellazione immagine vecchia
            if (fuImmagineModifica.FileName != string.Empty)
                System.IO.File.Delete(Server.MapPath("~/img/") + tempImg);

            // caricamento immagine nella cartella img
            if(fuImmagineModifica.FileName != string.Empty)
                fuImmagineModifica.SaveAs(Server.MapPath("~/img/") + fuImmagineModifica.FileName);
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
                fuImmagineModifica.FileName.Replace(fuImmagineModifica.FileName, string.Empty);
                ddlValiditaModifica.SelectedValue = string.Empty;
                ddlCategoriaModifica.SelectedValue = string.Empty;
                return;
            }

            clsProdotti prodotto = new clsProdotti(Convert.ToInt32(ddlElementoModifica.SelectedValue)).getProdotto();

            txtNomeModifica.Text = prodotto.nome;
            txtDescrizioneModifica.Text = prodotto.descrizione;
            txtPrezzoModifica.Text = prodotto.prezzo.ToString(CultureInfo.InvariantCulture);
            txtQuantitaModifica.Text = prodotto.quantita.ToString();

            if (prodotto.validita)
                ddlValiditaModifica.SelectedValue = "1";
            else
                ddlValiditaModifica.SelectedValue = "0";
            ddlCategoriaModifica.SelectedValue = prodotto.categoria_id.ToString();
        }
    }
}