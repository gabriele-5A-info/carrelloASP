<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="carrelloASP.Pubblica.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>admin</title>
    <script src="https://kit.fontawesome.com/083056627d.js" crossorigin="anonymous"></script>

    <link rel="stylesheet" type="text/css" href="../style.css" />
    <link rel="stylesheet" type="text/css" href="../CSS/admin.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <button class="btn btnBack" id="btnBack" onclick="return Redirect();"><i class="fas fa-arrow-left"></i></button>


            <div class="container-modifica">
                <asp:Label ID="Label13" runat="server" Text="Prodotto da modificare" CssClass="title-aggiungi"></asp:Label>
            
                <asp:DropDownList ID="ddlElementoModifica" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlElementoModifica_SelectedIndexChanged" OnTextChanged="ddlElementoModifica_SelectedIndexChanged" CssClass="ddl-elemento-modifica input">
                </asp:DropDownList>
           
                <asp:Label ID="Label7" runat="server" Text="Nome"></asp:Label>
            
                <asp:TextBox ID="txtNomeModifica" runat="server" CssClass="txt-nome-modifica input"></asp:TextBox>
            
                <asp:Label ID="Label8" runat="server" Text="Descrizione"></asp:Label>
            
                <asp:TextBox ID="txtDescrizioneModifica" runat="server" CssClass="txt-descrizione-modifica input"></asp:TextBox>
            
                <asp:Label ID="Label9" runat="server" Text="Prezzo"></asp:Label>
            
                <asp:TextBox ID="txtPrezzoModifica" runat="server" CssClass="txt-prezzo-modifica input"></asp:TextBox>
            
                <asp:Label ID="Label10" runat="server" Text="Quantità"></asp:Label>
            
                <asp:TextBox ID="txtQuantitaModifica" runat="server" CssClass="txt-quantita-modifica input"></asp:TextBox>
            
                <!-- upload immagine -->
                <asp:Label ID="Label5" runat="server" Text="Immagine"></asp:Label>
                <asp:FileUpload ID="fuImmagineModifica" runat="server" CssClass="fu-immagine-modifica input"/>
            
                <asp:DropDownList ID="ddlCategoriaModifica" runat="server" CssClass="ddl-categoria-modifica input">
                </asp:DropDownList>
            
                <asp:DropDownList ID="ddlFornitoreModifica" runat="server" AutoPostBack="True" CssClass="ddl-fornitore-modifica input">
                    <asp:ListItem>Seleziona Validita</asp:ListItem>
                    <asp:ListItem Value="1">Visualizzabile</asp:ListItem>
                    <asp:ListItem Value="0">Non visualizzabile</asp:ListItem>
                </asp:DropDownList>
            
                <asp:DropDownList ID="ddlValiditaModifica" runat="server" CssClass="ddl-validita-modifica input">
                    <asp:ListItem>Seleziona Validita</asp:ListItem>
                    <asp:ListItem Value="1">Visualizzabile</asp:ListItem>
                    <asp:ListItem Value="0">Non visualizzabile</asp:ListItem>
                </asp:DropDownList>
            
                <asp:Button ID="btnModifica" runat="server" OnClick="btnModifica_Click" Text="Modifica" CssClass="btn-modifica btn"/>
            
                <asp:Label ID="lblRisultatoModifica" runat="server" CssClass="lbl-risultato-modifica"></asp:Label>
            </div>

            
            <div class="container-aggiungi">
                <asp:Label ID="Label14" runat="server" Text="Aggiungi Categoria" CssClass="title-aggiungi"></asp:Label>
            
                <asp:TextBox ID="txtCategoriaAggiungi" runat="server" CssClass="txt-categoria-aggiungi input"></asp:TextBox>
            
                <asp:Button ID="btnAggiungi" runat="server" OnClick="btnAggiungi_Click" Text="Aggiungi" CssClass="btn-aggiungi btn"/>
            
                <asp:Label ID="lblRisultatoAggiungi" runat="server" CssClass="lbl-risultato-aggiungi"></asp:Label>
            </div>
            
            <div class="container-elimina">
                <asp:Label ID="Label15" runat="server" Text="Rimuovi Categoria" CssClass="title-elimina"></asp:Label>
            
                <asp:DropDownList ID="ddlCategoriaElimina" runat="server" CssClass="ddl-categoria-elimina input"></asp:DropDownList>
            
                <asp:Button ID="btnRimuovi" runat="server" OnClick="btnRimuovi_Click" Text="Rimuovi" CssClass="btn-rimuovi btn"/>
            
                <asp:Label ID="lblRisultatoRimuovi" runat="server" CssClass="lbl-risultato-rimuovi"></asp:Label>
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