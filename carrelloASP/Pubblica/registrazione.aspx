<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registrazione.aspx.cs" Inherits="carrelloASP.Pubblica.registrazione" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>registrazione</title>
    
    <script src="https://kit.fontawesome.com/083056627d.js" crossorigin="anonymous"></script>
    <link rel="stylesheet" type="text/css" href="../style.css" />
    <link rel="stylesheet" type="text/css" href="../CSS/registrazione.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn btnLogout" />
            <button class="btn btnBack" id="btnBack" onclick="return Redirect();"><i class="fas fa-arrow-left"></i></button>

            <div class="container" runat="server" id="divContainer">

                <div class="header">
                    <h1 class="title">Registrazione / Accesso</h1>
                    <asp:Label ID="lblErrore" runat="server" Text="" CssClass="lblErrore"></asp:Label>
                </div>

                <div class="form">
                    <div class="formLogin frm">
                        <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>
           
                       <asp:TextBox ID="txtEmailAccedi" runat="server" CssClass="input"></asp:TextBox>
           
                       <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
           
                       <asp:TextBox ID="txtPasswordAccedi" runat="server" CssClass="input"></asp:TextBox>
           
                       <asp:Button ID="btnAccedi" runat="server" OnClick="btnAccedi_Click" Text="Accedi" CssClass="btn btnLogin" />
                    </div>
 
                    <div class="formRegistrati frm">
                        <asp:Label ID="Label3" runat="server" Text="Username"></asp:Label>

                        <asp:TextBox ID="txtUsernameRegistrati" runat="server" CssClass="input"></asp:TextBox>

                        <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>

                        <asp:TextBox ID="txtPasswordRegistrati" runat="server" CssClass="input"></asp:TextBox>

                        <asp:Label ID="Label6" runat="server" Text="Email"></asp:Label>

                        <asp:TextBox ID="txtEmailRegistrati" runat="server" CssClass="input"></asp:TextBox>

                        <asp:Label ID="Label5" runat="server" Text="Ruolo"></asp:Label>
                        <asp:RadioButtonList ID="rblRole" runat="server" CssClass="rblRole">
                            <asp:ListItem Selected="True">user</asp:ListItem>
                            <asp:ListItem>fornitore</asp:ListItem>
                        </asp:RadioButtonList>

                        <asp:Button ID="btnRegistrati" runat="server" OnClick="btnRegistrati_Click" Text="Registrati" CssClass="btn btnRegistrati"/>
                    </div>
                </div>
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