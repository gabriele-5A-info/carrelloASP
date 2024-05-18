<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="carrelloASP._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>carrello</title>
    <link href="style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container">
               <div class="header">
                    <h1 class="title">Carrello</h1>
                    <asp:Label ID="lblBenvenuto" runat="server" Text="Label" CssClass="lblBenvenuto"></asp:Label>            
                </div>

                <div class="container-btn">
                    <asp:Button ID="btnAccediRegistrati" runat="server" Text="accedi o registrati" OnClick="btnAccediRegistrati_Click" CssClass="btn btnRegistrati"/>        
                    <asp:Button ID="btnFornitore" runat="server" Text="pannello fornitore" OnClick="btnFornitore_Click" CssClass="btn btnFornitore"/>
                    <asp:Button ID="btnAdmin" runat="server" Text="pannello admin" OnClick="btnAdmin_Click" CssClass="btn btnAdmin"/>
                    <asp:Button ID="btnCarrello" runat="server" Text="carrello" OnClick="btnCarrello_Click" CssClass="btn btnCarrello"/>
                </div>

                <asp:Panel ID="pnlProdotti" runat="server" CssClass="container-card">
                </asp:Panel>
            </div>
        </div>
    </form>
</body>
</html>
