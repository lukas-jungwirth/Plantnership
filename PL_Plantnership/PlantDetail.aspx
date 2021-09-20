<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlantDetail.aspx.cs" Inherits="PL_Plantnership.PlantDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="Stylesheet" href="style.css" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">

        <header>
            <div class="headerLeft">
                <asp:Button ID="btnHome" runat="server" Text="Startseite" OnClick="btnHome_Click" />
            </div>
            <div class="headerRight">
                <asp:Button ID="Button2" runat="server" Text="Meine Bäume verwalten" />
                <asp:Button ID="Button3" runat="server" Text="Logout" />
            </div>
        </header>


        <div class="detailContainer">
            <h1>
                <asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label>
            </h1>
            <div class="infoWrapper">
                <h2>Steckbrief</h2>
                <span class="infoRow">
                    <span class="infoTitle">Sorte</span><asp:Label ID="lblInfoVariety" runat="server" Text="Label"></asp:Label>
                </span>
                <span class="infoRow">
                    <span class="infoTitle">Alter</span><asp:Label ID="lblInfoAge" runat="server" Text="Label"></asp:Label>
                </span>
                <span class="Bezirk">
                    <span class="infoTitle">Bezirk</span><asp:Label ID="lblInfoDistrict" runat="server" Text="Label"></asp:Label>
                    <p>Genauere Standortinformationen können nach dem Kauf eingesehen werden.</p>
                </span>
            </div>
            <div class="aboWrapper">
                <h2>Abostufe wählen</h2>
                <div class="aboWrapper">
                    <table>
                        <tr>
                            <th>Supporter</th>
                            <th>Planter</th>
                        </tr>
                        <tr>
                            <td>Preis: $$€</td>
                            <td>Preis: $$€</td>
                        </tr>
                        <tr>
                            <td>Werde Supporter und untersütze deine Lieblingspflanzen um ihren Bedarf zu decken!</td>
                            <td>Bekomme zusätzlich die Möglichkeit die Früchte deiner Pflanze zu ernten</td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblAmountType1" runat="server" Text="0"></asp:Label><span> andere Personen haben auch dieses Abo gewählt.</span></td>
                            <td><asp:Label ID="lblAmountType2" runat="server" Text="0"></asp:Label><span> andere Personen haben auch dieses Abo gewählt.</span></td>
                        </tr> 
                    </table>
                </div>
                <asp:RadioButtonList ID="radioBtnCat" runat="server" AutoPostBack="True" Style="margin-right: 0px" Width="176px">
                    <asp:ListItem Value="1">Basic</asp:ListItem>
                    <asp:ListItem Value="2">Planter</asp:ListItem>
                </asp:RadioButtonList>
                <asp:ImageButton ID="btnBuy" runat="server" AlternateText="Kaufen" ImageUrl="~/Fotos/googlePay.png" Height="40px" OnClick="btnBuy_Click"/>
                <asp:Label ID="lblBuyError" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
