﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="PL_Plantnership.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
</head>
<body>
    <h1> Login </h1>
    <form id="form1" runat="server">
        <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
        <asp:TextBox ID="txtBoxName" runat="server"></asp:TextBox>
        <br />
        <div>
            <asp:Label ID="lblPW" runat="server" Text="Password"></asp:Label>
            :
            <asp:TextBox ID="txtBoxPW" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnLoginAktiv" runat="server" OnClick="btnLoginAktiv_Click" Text="Login" />
            <asp:Button ID="btnRegistrieren" runat="server" OnClick="btnRegistrieren_Click" Text="neu Registrieren" />
        </div>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
