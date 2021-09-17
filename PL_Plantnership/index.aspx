﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="PL_Plantnership.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>PlantnerShip</title>
    <link rel="Stylesheet" href="style.css" type="text/css" />
</head>
<body>
   <form id="form2" runat="server">

    <header>
        <div class="headerLeft">
            <asp:Label ID="btnHome" runat="server" Text="">Startseite</asp:Label>
        </div>
        <div class="headerCenter">
                <p><span>Willkommen zurück </span><asp:Label ID="lblDisplayUsername" runat="server" Text=""></asp:Label></p>
        </div>
        <div class="headerRight">
                <asp:Button ID="btnBaumVerwalten" runat="server" OnClick="btnBaumVerwalten_Click" Text="Meine Bäume verwalten" />
                <asp:Button ID="btnLogout" runat="server" OnClick="btnBaumVerwalten_Click" Text="Logout" />
        </div>
    </header>

       <h1 class="headIndex">PlantnerSHIP</h1> 

        <h2 class="categoryTree">Baumkategorien</h2>
        

       <div class="treeCat">

        <asp:ImageButton ID="imgBtnApfel" runat="server" AlternateText="Apfelbaum" ImageUrl="~/Fotos/Apfelbaum-titelbild-für-artikel-1.jpg" height="300px" width="300px" OnClick="imgBtnApfel_Click"/>

        <asp:ImageButton ID="imgBtnBirne" runat="server" AlternateText="Birnbaum" ImageUrl="~/Fotos/Birnbaum-Martina-Berg-Fotoliaid188344.jpg" height="300px" width="300px"/>
        <asp:ImageButton ID="imgBtnKirsche" runat="server" AlternateText="Kirschbaum" ImageUrl="~/Fotos/Kirschbaum-Branko-Srot-Fotolia_161189688.jpg" height="300px" width="300px" />
       </div>

       <div class="treeCat">
        <asp:ImageButton ID="imgBtnMarille" runat="server" AlternateText="Marillenbaum" ImageUrl="~/Fotos/Marillen.jpg" height="300px" width="300px"/>
        <asp:ImageButton ID="imgBtnPfirsich" runat="server" AlternateText="Pfirsichbaum" ImageUrl="~/Fotos/1-pfirsichbaum-1176136976.jpg" height="300px" width="300px"/>
        <asp:ImageButton ID="imgBtnZwetschke" runat="server" AlternateText="Zwetschkenbaum" ImageUrl="~/Fotos/77c66506-3181-4091-bebc-80f84d71c4b4.jpg" height="300px" width="300px" />
           
       </div>

       

       <h2 class="categoryTree">Du suchst den Plantner fürs Leben?</h2>
       <h3>Finde mit unserem Match Finder die perfekte Pflanze für deine Bedürfnisse!</h3>


        <div class="treeMatchIndex">
            <div class="sternzeichenIndex">
            <asp:Label ID="lblSternzeichen" runat="server" Text="Klick auf ein Sternzeichen:"></asp:Label>
                
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            

            
            <asp:ListItem Value="widder">Widder</asp:ListItem>
            <asp:ListItem Value="stier">Stier</asp:ListItem>
            <asp:ListItem Value="zwillinge">Zwillinge</asp:ListItem>
            <asp:ListItem Value="krebs">Krebs</asp:ListItem>
            <asp:ListItem Value="löwe">Löwe</asp:ListItem>
            <asp:ListItem Value="jungfrau">Jungfrau</asp:ListItem>
        </asp:RadioButtonList>
                </div>


        <div class="jahreszeitenIndex">
            <asp:Label ID="lblJahreszeiten" runat="server" Text="Suche eine Jahreszeit aus:"></asp:Label>
            <asp:RadioButtonList ID="RadioButtonList2" runat="server">
                
                <asp:ListItem Value="frühling">Frühling</asp:ListItem>
                <asp:ListItem Value="sommer">Sommer</asp:ListItem>
                <asp:ListItem Value="herbst">Herbst</asp:ListItem>
                <asp:ListItem Value="winter">Winter</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <br />
        <br />
        </div>
       <div  class="btnTreeMatch">
       <asp:Button ID="btnTreeMatch" runat="server" OnClick="btnTreeMatch_Click" Text="Tree Match" />
        </div>

       <footer>
           Hello World! Du bis am Ende der Seite angekommen, scroll bitte wieder rauf!
       </footer>

           </form>
   
          
   
</body>
</html>
