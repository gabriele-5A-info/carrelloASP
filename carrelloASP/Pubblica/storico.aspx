<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="storico.aspx.cs" Inherits="carrelloASP.Pubblica.storico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>storico</title>

    <script src="https://kit.fontawesome.com/083056627d.js" crossorigin="anonymous"></script>

    <link rel="stylesheet" type="text/css" href="../style.css" />
    <link rel="stylesheet" type="text/css" href="../CSS/storico.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <button class="btn btnBack" id="btnBack" onclick="return Redirect();"><i class="fas fa-arrow-left"></i></button>

            <asp:Panel ID="pnStorico" runat="server" CssClass="pnStorico">
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