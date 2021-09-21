<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="payPage.aspx.cs" Inherits="PL_Plantnership.payPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <link rel="Stylesheet" href="style.css" type="text/css" />
    <title>Rechnung</title>
</head>
<body>
    <form id="form1" runat="server">


         <header>
            <div class="headerLeft">
                <asp:Button ID="btnHome" runat="server" Text="Startseite" OnClick="btnHome_Click" />
            </div>
            <div class="headerRight">
                <asp:Button ID="bntBaumVerwalten" runat="server" Text="Meine Bäume verwalten" OnClick="bntBaumVerwalten_Click" />
                <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
            </div>
        </header>

        <div class="rechnungsSite">
        <h1>Rechnung</h1>
          

                <span class="infoRow">
                    <span class="infoTitle">Sorte</span><asp:Label ID="lblInfoVariety" runat="server" Text=""></asp:Label>
                </span>
                <span class="infoRow">
                    <span class="infoTitle">Alter</span><asp:Label ID="lblInfoAge" runat="server" Text=""></asp:Label>
                </span>
                <span class="infoRow">
                    <span class="infoTitle">Bezirk</span><asp:Label ID="lblInfoDistrict" runat="server" Text=""></asp:Label>
                </span>
             <span class="infoRow">
                    <span class="infoTitle">Straße</span><asp:Label ID="lblStreet" runat="server" Text=""></asp:Label>
                </span>
             <span class="infoRow">
                    <span class="infoTitle">Hausnummer</span><asp:Label ID="lblHouseNumber" runat="server" Text=""></asp:Label>
                </span>
                <span class="infoRow">
                    <span class="infoTitle">Abo Info</span><asp:Label ID="lblAboInfo" runat="server" Text=""></asp:Label>
                </span>
            
                <p>Vielen Dank für Ihre Unterstützung. Wir hoffen, Sie haben eine/n PlantnerIn fürs Leben gefunden.</p>
                    <asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label>
            </div>
        
    </form>
</body>
</html>
