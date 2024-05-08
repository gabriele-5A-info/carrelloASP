<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prodotti.aspx.cs" Inherits="carrelloASP.Pubblica.prodotti" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Nome"></asp:Label>
            <br />
            <asp:TextBox ID="txtNomeAggiungi" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Descrizione"></asp:Label>
            <br />
            <asp:TextBox ID="txtDescrizioneAggiungi" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Prezzo"></asp:Label>
            <br />
            <asp:TextBox ID="txtPrezzoAggiungi" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Quantità"></asp:Label>
            <br />
            <asp:TextBox ID="txtQuantitaAggiungi" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="Label5" runat="server" Text="Immagine"></asp:Label>
            <br />
            <asp:TextBox ID="txtImmagineAggiungi" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Categoria"></asp:Label>
            <br />
            <asp:DropDownList ID="ddlCategoriaAggiungi" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnAggiungi" runat="server" OnClick="btnAggiungi_Click" Text="Aggiungi" />
            <br />
            <asp:Label ID="lblRisultatoAggiungi" runat="server"></asp:Label>

            <br />
            <br />
            <asp:Label ID="Label13" runat="server" Text="Prodotto da modificare"></asp:Label>

            <br />
            <asp:DropDownList ID="ddlElementoModifica" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlElementoModifica_SelectedIndexChanged" OnTextChanged="ddlElementoModifica_SelectedIndexChanged">
            </asp:DropDownList>
            <br />

            <asp:Label ID="Label7" runat="server" Text="Nome"></asp:Label>
            <br />
            <asp:TextBox ID="txtNomeModifica" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label8" runat="server" Text="Descrizione"></asp:Label>
            <br />
            <asp:TextBox ID="txtDescrizioneModifica" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label9" runat="server" Text="Prezzo"></asp:Label>
            <br />
            <asp:TextBox ID="txtPrezzoModifica" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label10" runat="server" Text="Quantità"></asp:Label>
            <br />
            <asp:TextBox ID="txtQuantitaModifica" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="Label11" runat="server" Text="Immagine"></asp:Label>
            <br />
            <asp:TextBox ID="txtImmagineModifica" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label12" runat="server" Text="Categoria"></asp:Label>
            <br />
            <asp:DropDownList ID="ddlCategoriaModifica" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:DropDownList ID="ddlValiditaModifica" runat="server">
                <asp:ListItem>Seleziona Validita</asp:ListItem>
                <asp:ListItem Value="1">Visualizzabile</asp:ListItem>
                <asp:ListItem Value="0">Non visualizzabile</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnModifica" runat="server" OnClick="btnModifica_Click" Text="Modifica" />
            <br />
            <asp:Label ID="lblRisultatoModifica" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
