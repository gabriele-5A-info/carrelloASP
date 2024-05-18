<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="acquista.aspx.cs" Inherits="carrelloASP.Pubblica.acquista" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>acquista</title>

    <script src="https://kit.fontawesome.com/083056627d.js" crossorigin="anonymous"></script>

    <link rel="stylesheet" type="text/css" href="../style.css" />
    <link rel="stylesheet" type="text/css" href="../CSS/acquista.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <button class="btn btnBack" id="btnBack" onclick="return Redirect();"><i class="fas fa-arrow-left"></i></button>

            <asp:Panel ID="pnlProdotto" runat="server" CssClass="pnlProdotto">
            </asp:Panel>

            <asp:Label ID="lblErrore" runat="server" CssClass="lblErrore"></asp:Label>
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
