<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="PL_Plantnership.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>PlantnerShip</title>
    <link rel="Stylesheet" href="style.css" type="text/css" />
</head>
<body>
    <form id="form2" runat="server">

        <header>
            <div class="headerLeft">
                <asp:Button ID="btnHome" runat="server" OnClick="btnHome_Click" Text="Startseite" />
            </div>
            <div class="headerCenter">
                <p>
                    <span>Willkommen zurück </span>
                   <asp:Label ID="lblDisplayUsername" runat="server" Text=""></asp:Label>
                </p>
            </div>
            <div class="headerRight">
                 <asp:Button ID="btnBaumVerwalten" runat="server" OnClick="btnBaumVerwalten_Click" Text="Meine Bäume verwalten" />
                <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" />
            </div>
        </header>

        <h1 class="headIndex">PlantnerSHIP</h1>

        <h2 class="categoryTree">Baumkategorien</h2>

        <div class="treeCat">
        <asp:Repeater ID="RepeaterCategory" runat="server">
           <ItemTemplate>
                <div class="category">
                    <h2><%# Eval("Name") %></h2>
                    <asp:ImageButton ID="imgCat" runat="server" ImageUrl='<%# Eval("ImageUrl") %>' Height="300px" Width="300px" OnCommand="ShowCat_Click" CommandName="ShowCategory" CommandArgument='<%# Eval("ID") %>' /> 
                </div>
            </ItemTemplate>

        </asp:Repeater>
        </div>



        <h2 class="categoryTree">Du suchst den Plantner fürs Leben?</h2>
        <p><strong>Find die perfekte Pflanze für deine Bedürfnisse!</strong></p>

        <footer>
            Hello World! Du bis am Ende der Seite angekommen, scroll bitte wieder rauf!
        </footer>

    </form>



</body>
</html>
