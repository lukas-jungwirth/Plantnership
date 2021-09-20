<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Verwaltung.aspx.cs" Inherits="PL_Plantnership.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Verwaltung</title>
    <link rel="Stylesheet" href="style.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">

        <header>
            <div class="headerLeft">
                <asp:Button ID="btnHome" runat="server" Text="Startseite" OnClick="btnHome_Click" />
            </div>

            <div class="headerRight">
                <asp:Button ID="btnLogout" runat="server" Text="Logout" />
            </div>
        </header>


        <div class="settingContainer">

            <div class="myTreeToggle">
                <asp:Button ID="btnMyTreeSite" runat="server" Text="Meine Bäume" CssClass="loginActive loginSiteBtn" OnClick="btnMyTreeSite_Click" />
                <asp:Button ID="btnRentTreeSite" runat="server" Text="Gemietete Bäume" CssClass="loginSiteBtn" OnClick="btnRentTreeSite_Click" />
            </div>


            <div class="profilInfoWrapper">

                <h2 class="h2Profil">PROFIL</h2>

                <div class="profileRow">
                    <span>Name:</span><asp:Label ID="lblProfileUsername" runat="server" Text=""></asp:Label>
                </div>

                <div class="profileRow">
                    <span>Name:</span><asp:Label ID="lblProfileName" runat="server" Text=""></asp:Label>
                </div>

                <div class="profileRow">
                    <span>Nachname:</span><asp:Label ID="lblProfileLstName" runat="server" Text=""></asp:Label>
                </div>

                <div class="profileRow">
                    <span>Mail:</span><asp:Label ID="lblProfileMail" runat="server" Text=""></asp:Label>
                </div>

                <div class="profileRow">
                    <asp:Button ID="btnCreateNewPlant" runat="server" Text="Neuen Baum hinzufügen" CssClass="buttonEdit" OnClick="btnCreateNewPlant_Click" />
                </div>

            </div>
        </div>

        <div class="verwaltungFlex ">
            <asp:MultiView ID="MultiViewVerwaltung" runat="server" ActiveViewIndex="0">

                <asp:View ID="viewMyTrees" runat="server">
                    <div class="vierbaume">
                        <asp:Repeater ID="Repeater1" runat="server">

                            <ItemTemplate>
                                <div class="lblAlleDreiVerwaltung">



                                    <div class="flexBoxlisteBaumUnterkategorie2">
                                        <h2>Baumart</h2>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
                                    </div>

                                    <div class="flexBoxlisteBaumUnterkategorie2">
                                        <h2>Sorte</h2>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Variety") %>'></asp:Label>
                                    </div>

                                    <div class="flexBoxlisteBaumUnterkategorie2">
                                        <h2>Vermieterin</h2>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Owner") %>'></asp:Label>
                                    </div>



                                    <asp:Button ID="Button1" runat="server" Text="Details ändern" CssClass="buttonEdit" OnCommand="Edit_Click" CommandName="EditClick" CommandArgument='<%# Eval("ID") %>' />

                                </div>
                            </ItemTemplate>

                        </asp:Repeater>
                </asp:View>
        </div>
        <asp:View ID="viewRentedTrees" runat="server">
        </asp:View>
        </asp:MultiView>
        </div>
        
    </form>
</body>
</html>
