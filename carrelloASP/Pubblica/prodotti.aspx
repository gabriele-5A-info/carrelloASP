<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prodotti.aspx.cs" Inherits="carrelloASP.Pubblica.prodotti" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>pannello fornitore</title>
    <script src="https://kit.fontawesome.com/083056627d.js" crossorigin="anonymous"></script>

    <link rel="stylesheet" type="text/css" href="../style.css" />
    <link rel="stylesheet" type="text/css" href="../CSS/prodotti.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <button class="btn btnBack" id="btnBack" onclick="return Redirect();"><i class="fas fa-arrow-left"></i></button>

            <div class="container-aggiungi">
                <asp:Label ID="Label14" runat="server" Text="Aggiungi Prodotto" CssClass="title-aggiungi"></asp:Label>

                <asp:Label ID="Label1" runat="server" Text="Nome"></asp:Label>
                <asp:TextBox ID="txtNomeAggiungi" runat="server" CssClass="txtAggiungiNome input"></asp:TextBox>

                <asp:Label ID="Label2" runat="server" Text="Descrizione"></asp:Label>
                <asp:TextBox ID="txtDescrizioneAggiungi" runat="server" CssClass="txtAggiungiDescrizione input"></asp:TextBox>

                <asp:Label ID="Label3" runat="server" Text="Prezzo"></asp:Label>
                <asp:TextBox ID="txtPrezzoAggiungi" runat="server" CssClass="txtAggiungiPrezzo input"></asp:TextBox>

                <asp:Label ID="Label4" runat="server" Text="Quantità"></asp:Label>
                <asp:TextBox ID="txtQuantitaAggiungi" runat="server" CssClass="txtAggiungiQuantita input"></asp:TextBox>

                <!-- upload immagine -->
                <asp:Label ID="Label5" runat="server" Text="Immagine"></asp:Label>
                <asp:FileUpload ID="fuImmagineAggiungi" runat="server" CssClass="fuAggiungiImmagine input"/>

                <asp:Label ID="Label6" runat="server" Text="Categoria"></asp:Label>
                <asp:DropDownList ID="ddlCategoriaAggiungi" runat="server" CssClass="ddlAggiungiCategoria input"></asp:DropDownList>

                <asp:Button ID="btnAggiungi" runat="server" OnClick="btnAggiungi_Click" Text="Aggiungi" CssClass="btnAggiungi"/>

                <asp:Label ID="lblRisultatoAggiungi" runat="server" CssClass="lblRisultatoAggiungi"></asp:Label>
            </div>

            <div class="container-modifica">
                <asp:Label ID="Label15" runat="server" Text="Modifica Prodotto" CssClass="title-modifica"></asp:Label>              

                <asp:Label ID="Label13" runat="server" Text="Prodotto da modificare"></asp:Label>
                <asp:DropDownList ID="ddlElementoModifica" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlElementoModifica_SelectedIndexChanged" OnTextChanged="ddlElementoModifica_SelectedIndexChanged" CssClass="ddlElementoModifica input"></asp:DropDownList>

                <asp:Label ID="Label7" runat="server" Text="Nome"></asp:Label>
                <asp:TextBox ID="txtNomeModifica" runat="server" CssClass="txtModificaNome input"></asp:TextBox>

                <asp:Label ID="Label8" runat="server" Text="Descrizione"></asp:Label>
                <asp:TextBox ID="txtDescrizioneModifica" runat="server" CssClass="txtModificaDescrizione input"></asp:TextBox>

                <asp:Label ID="Label9" runat="server" Text="Prezzo"></asp:Label>
                <asp:TextBox ID="txtPrezzoModifica" runat="server" CssClass="txtModificaPrezzo input"></asp:TextBox>

                <asp:Label ID="Label10" runat="server" Text="Quantità"></asp:Label>
                <asp:TextBox ID="txtQuantitaModifica" runat="server" CssClass="txtModificaQuantita input"></asp:TextBox>

                <!-- upload immagine -->
                <asp:Label ID="Label11" runat="server" Text="Immagine"></asp:Label>
                <asp:FileUpload ID="fuImmagineModifica" runat="server" CssClass="fuModificaImmagine input"/>

                <asp:Label ID="Label12" runat="server" Text="Categoria"></asp:Label>
                <asp:DropDownList ID="ddlCategoriaModifica" runat="server" CssClass="ddlModificaCategoria input"></asp:DropDownList>

                <asp:DropDownList ID="ddlValiditaModifica" runat="server" CssClass="ddlModificaValidita input">
                    <asp:ListItem>Seleziona Validita</asp:ListItem>
                    <asp:ListItem Value="1">Visualizzabile</asp:ListItem>
                    <asp:ListItem Value="0">Non visualizzabile</asp:ListItem>
                </asp:DropDownList>

                <asp:Button ID="btnModifica" runat="server" OnClick="btnModifica_Click" Text="Modifica" CssClass="btnModifica"/>
                <asp:Label ID="lblRisultatoModifica" runat="server" CssClass="lblRisultatoModifica"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>

<script defer="">
    function Redirect() {
        console.log(window.location.origin);
        window.location.href = window.location.origin;
        return false;
    }
</script>
