<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registrazione.aspx.cs" Inherits="carrelloASP.Pubblica.registrazione" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
            <br />
            <asp:TextBox ID="txtEmailAccedi" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            <br />
            <asp:TextBox ID="txtPasswordAccedi" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnAccedi" runat="server" OnClick="btnAccedi_Click" Text="Accedi" />
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Username"></asp:Label>
            <br />
            <asp:TextBox ID="txtUsernameRegistrati" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
            <br />
            <asp:TextBox ID="txtPasswordRegistrati" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Email"></asp:Label>
            <br />
            <asp:TextBox ID="txtEmailRegistrati" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Ruolo"></asp:Label>
            <asp:RadioButtonList ID="rblRole" runat="server">
                <asp:ListItem Selected="True">user</asp:ListItem>
                <asp:ListItem>fornitore</asp:ListItem>
                <asp:ListItem>admin</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Button ID="btnRegistrati" runat="server" OnClick="btnRegistrati_Click" Text="Registrati" />
        </div>
    </form>
</body>
</html>
