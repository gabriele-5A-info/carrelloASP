<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="carrelloASP._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnAccediRegistrati" runat="server" Text="accedi o registrati" OnClick="btnAccediRegistrati_Click" />
            <br />
            <asp:Label ID="lblBenvenuto" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnFornitore" runat="server" Text="pannello fornitore" OnClick="btnFornitore_Click" />
            <br />
            <br />
            <asp:Button ID="btnAdmin" runat="server" Text="pannello admin" OnClick="btnAdmin_Click" />
            <br />
            <br />
            <asp:Panel ID="pnlProdotti" runat="server">
            </asp:Panel>
        </div>
    </form>
</body>
</html>
