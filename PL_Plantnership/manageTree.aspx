<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manageTree.aspx.cs" Inherits="PL_Plantnership.manageTree" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Baumverwaltung</title>
    <link rel="Stylesheet" href="style.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="manageWrapper">
            <h1>Baumverwaltung</h1>
            <h2>Baumdaten</h2>
            <div class="inputWrapper">
               <asp:Label ID="lblCategory" runat="server">Baumkategorie</asp:Label>
                <asp:RadioButtonList ID="radioBtnCat" runat="server" AutoPostBack="True" style="margin-right: 0px" Width="176px">
                    <asp:ListItem Value="Apfel"></asp:ListItem>
                    <asp:ListItem Value="Birne"></asp:ListItem>
                    <asp:ListItem Value="Kirsche"></asp:ListItem>
                    <asp:ListItem Value="Marille"></asp:ListItem>
                    <asp:ListItem Value="Zwetschke"></asp:ListItem>
                    <asp:ListItem Value="Pfirsich"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="inputWrapper">
               <asp:Label ID="lblVariety" runat="server">Sorte</asp:Label>
               <asp:TextBox ID="txtVariety" runat="server"></asp:TextBox>
           </div>
            <div class="inputWrapper">
               <asp:Label ID="lblAge" runat="server">Alter</asp:Label>
               <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
           </div>
            <h2>Standort</h2>
            <div class="inputWrapper">
               <asp:Label ID="lblDistrict" runat="server">Bezirk</asp:Label>
               <asp:TextBox ID="txtDistrict" runat="server"></asp:TextBox>
           </div>
            <div class="inputWrapper">
               <asp:Label ID="lblStreet" runat="server">Straße</asp:Label>
               <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox>
           </div>
            <div class="inputWrapper">
               <asp:Label ID="lblHouseNumb" runat="server">Hausnummer</asp:Label>
               <asp:TextBox ID="txtHouseNumb" runat="server"></asp:TextBox>
           </div>
            <div class="buttonWrapper">
                <asp:Button ID="btnManageSave" runat="server" Text="Speichern" CssClass="button" OnClick="btnManageSave_Click" />
                <asp:Button ID="btnManageDelete" runat="server" Text="Baum löschen" CssClass="button" OnClick="btnManageDelete_Click"/>
                <asp:Button ID="btnManageCancel" runat="server" Text="Abbrechen" CssClass="button" OnClick="btnManageCancel_Click"/>
            </div>
            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
