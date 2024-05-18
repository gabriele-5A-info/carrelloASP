<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="carrello.aspx.cs" Inherits="carrelloASP.Pubblica.carrello" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>carrello</title>

    <script src="https://kit.fontawesome.com/083056627d.js" crossorigin="anonymous"></script>

    <link rel="stylesheet" type="text/css" href="../style.css" />
    <link rel="stylesheet" type="text/css" href="../CSS/carrello.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:Button ID="btnLogout" runat="server" Text="Storico" CssClass="btn btnStorico" OnClick="btnStorico_Click" />
            <button class="btn btnBack" id="btnBack" onclick="return Redirect();"><i class="fas fa-arrow-left"></i></button>

            <asp:Panel ID="pnCarrello" runat="server" CssClass="pnCarrello">
            </asp:Panel>
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