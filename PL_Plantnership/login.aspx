<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="PL_Plantnership.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link rel="Stylesheet" href="style.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="loginTitle">Herzlich Willkommen bei Plantnership!</h1>
            <div class="loginToggle">
                <asp:Button ID="btnLoginSite" runat="server" Text="Login" CssClass="loginActive loginSiteBtn" OnClick="btnLoginSite_Click" />
                <asp:Button ID="btnRegisterSite" runat="server" Text="Registrieren" CssClass="loginSiteBtn" OnClick="btnRegisterSite_Click"/>
            </div>
            <asp:MultiView ID="MultViewLogin" runat="server" ActiveViewIndex="0">
                <asp:View ID="viewLogin" runat="server">
                    <div class="loginWrapper">
                        <h2>Login</h2>
                        <div class="inputWrapper">
                            <asp:Label ID="lblLoginUsername" runat="server">Username</asp:Label>
                            <asp:TextBox ID="inputLoginUsername" runat="server"></asp:TextBox>
                        </div>
                        <div class="inputWrapper">
                            <asp:Label ID="lblLoginPassword" runat="server">Passwort</asp:Label>
                            <asp:TextBox ID="inputLoginPassword" runat="server"></asp:TextBox>
                        </div>
                        <asp:Label ID="lblFeedbackLogin" runat="server" Text=""></asp:Label>
                        <asp:Button ID="btnLogin" runat="server" Text="Einloggen" CssClass="button" OnClick="btnLogin_Click" />
                    </div>
                </asp:View>
                <asp:View ID="viewRegister" runat="server">
                    <div class="loginWrapper">
                        <h2>Login</h2>
                        <div class="inputWrapper">
                            <asp:Label ID="lblRegUsername" runat="server">Username</asp:Label>
                            <asp:TextBox ID="inputRegUsername" runat="server"></asp:TextBox>
                        </div>
                        <div class="inputWrapper">
                            <asp:Label ID="lblRegPassword" runat="server">Passwort</asp:Label>
                            <asp:TextBox ID="inputRegPassword" runat="server"></asp:TextBox>
                        </div>
                        <div class="inputWrapper">
                            <asp:Label ID="lblRegName" runat="server">Vorname</asp:Label>
                            <asp:TextBox ID="inputRegName" runat="server"></asp:TextBox>
                        </div>
                        <div class="inputWrapper">
                            <asp:Label ID="lblRegLstName" runat="server">Nachname</asp:Label>
                            <asp:TextBox ID="inputRegLstName" runat="server"></asp:TextBox>
                        </div>
                        <div class="inputWrapper">
                            <asp:Label ID="lblRegMail" runat="server">Mail</asp:Label>
                            <asp:TextBox ID="inputRegMail" runat="server"></asp:TextBox>
                        </div>


                        <asp:Label ID="lblFeedbackReg" runat="server" Text=""></asp:Label>
                        <asp:Button ID="btnReg" runat="server" Text="Registrieren" CssClass="button" OnClick="btnReg_Click" />
                    </div>
                </asp:View>
            </asp:MultiView>
        </div>
    </form>
</body>
</html>
