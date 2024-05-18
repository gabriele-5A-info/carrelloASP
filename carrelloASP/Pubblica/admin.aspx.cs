using carrelloASP.Classi;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace carrelloASP.Pubblica
{
    public partial class admin : System.Web.UI.Page
    {
        static clsUsers user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                user = (clsUsers)Session["user"];
                if (user == null || user.role != "admin")
                    Response.Redirect("../default.aspx");

                ddlCaricaCategorie();
                ddlCaricaFornitori();
                ddlCaricaElementi();
            }
        }

        private void ddlCaricaCategorie()
        {
            ddlCategoriaModifica.DataSource = new clsCategorie().elenco();
            ddlCategoriaModifica.DataTextField = "nome";
            ddlCategoriaModifica.DataValueField = "id";
            ddlCategoriaModifica.DataBind();
            ddlCategoriaModifica.Items.Insert(0, new ListItem("Seleziona una categoria", ""));

            ddlCategoriaElimina.DataSource = new clsCategorie().elenco();
            ddlCategoriaElimina.DataTextField = "nome";
            ddlCategoriaElimina.DataValueField = "id";
            ddlCategoriaElimina.DataBind();
            ddlCategoriaElimina.Items.Insert(0, new ListItem("Seleziona una categoria", ""));
        }

        private void ddlCaricaFornitori()
        {
            ddlFornitoreModifica.DataSource = new clsUsers().elencoFornitori();
            ddlFornitoreModifica.DataTextField = "email";
            ddlFornitoreModifica.DataValueField = "id";
            ddlFornitoreModifica.DataBind();
            ddlFornitoreModifica.Items.Insert(0, new ListItem("Seleziona un fornitore", ""));
        }

        private void ddlCaricaElementi()
        {
            ddlElementoModifica.DataSource = new clsProdotti().elenco(true);
            ddlElementoModifica.DataTextField = "nome";
            ddlElementoModifica.DataValueField = "id";
            ddlElementoModifica.DataBind();
            ddlElementoModifica.Items.Insert(0, new ListItem("Seleziona un prodotto", ""));
        }

        protected void ddlElementoModifica_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlElementoModifica.SelectedValue == string.Empty)
            {
                txtNomeModifica.Text = string.Empty;
                txtDescrizioneModifica.Text = string.Empty;
                txtPrezzoModifica.Text = string.Empty;
                txtQuantitaModifica.Text = string.Empty;
                fuImmagineModifica.Attributes.Clear();
                ddlValiditaModifica.SelectedValue = string.Empty;
                ddlCategoriaModifica.SelectedValue = string.Empty;
                return;
            }

            clsProdotti prodotto = new clsProdotti(Convert.ToInt32(ddlElementoModifica.SelectedValue)).getProdotto();

            txtNomeModifica.Text = prodotto.nome;
            txtDescrizioneModifica.Text = prodotto.descrizione;
            txtPrezzoModifica.Text = prodotto.prezzo.ToString(CultureInfo.InvariantCulture);
            txtQuantitaModifica.Text = prodotto.quantita.ToString();
            ddlCategoriaModifica.SelectedValue = prodotto.categoria_id.ToString();
            ddlFornitoreModifica.SelectedValue = prodotto.fornitore_id.ToString();

            if (prodotto.validita)
                ddlValiditaModifica.SelectedValue = "1";
            else
                ddlValiditaModifica.SelectedValue = "0";
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            if (ddlElementoModifica.SelectedValue == string.Empty)
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
                ddlFornitoreModifica.SelectedValue != string.Empty ? Convert.ToInt32(ddlFornitoreModifica.SelectedValue) : prodotto.fornitore_id,
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
            if (fuImmagineModifica.FileName != string.Empty)
                fuImmagineModifica.SaveAs(Server.MapPath("~/img/") + fuImmagineModifica.FileName);
        }

        protected void btnAggiungi_Click(object sender, EventArgs e)
        {
            if(txtCategoriaAggiungi.Text.Trim() == string.Empty)
            {
                lblRisultatoAggiungi.Text = "Inserire il nome della categoria";
                lblRisultatoAggiungi.ForeColor = System.Drawing.Color.Red;
                return;
            }

            clsCategorie categoria = new clsCategorie(txtCategoriaAggiungi.Text.Trim().Replace('\'', ' '));

            if (categoria.inserisci())
            {
                lblRisultatoAggiungi.Text = "Categoria aggiunta correttamente";
                lblRisultatoAggiungi.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblRisultatoAggiungi.Text = "Errore nell'aggiunta della categoria";
                lblRisultatoAggiungi.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnRimuovi_Click(object sender, EventArgs e)
        {
            if(ddlCategoriaElimina.SelectedValue == string.Empty)
            {
                lblRisultatoRimuovi.Text = "Selezionare una categoria da eliminare";
                lblRisultatoRimuovi.ForeColor = System.Drawing.Color.Red;
                return;
            }

            clsCategorie categoria = new clsCategorie(Convert.ToInt32(ddlCategoriaElimina.SelectedValue));

            if (categoria.elimina())
            {
                lblRisultatoRimuovi.Text = "Categoria eliminata correttamente";
                lblRisultatoRimuovi.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblRisultatoRimuovi.Text = "Errore nell'eliminazione della categoria";
                lblRisultatoRimuovi.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}