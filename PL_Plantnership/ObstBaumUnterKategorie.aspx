<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ObstBaumUnterKategorie.aspx.cs" Inherits="PL_Plantnership.ObstBaumUnterKategorie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="Stylesheet" href="style.css" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <header>
            <div class="headerLeft">
                <asp:Button ID="btnHome" runat="server" Text="Startseite" OnClick="btnHome_Click" />
            </div>
            <div class="headerRight">
                 <asp:Button ID="btnBaumVerwalten" runat="server" OnClick="btnBaumVerwalten_Click" Text="Meine Bäume verwalten" />
                <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" />
            </div>
        </header>

        &nbsp;<h3>Such dir einen Plantner für die Saison aus: </h3>

        <asp:Repeater ID="repeaterPlantList" runat="server">

            <ItemTemplate>

                <div class="lblunterkat">

                    <div class="lblAlleDrei">

                        <div class="flexBoxlisteBaumUnterkategorie1">
                            <h2>Sorte</h2>
                            <asp:Label CssClass="lbl1" ID="Label1" runat="server" Text='<%# Eval("Variety") %>'></asp:Label>
                        </div>

                        <div class="flexBoxlisteBaumUnterkategorie1">
                            <h2>VermieterIN</h2>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Owner") %>'></asp:Label>
                        </div>

                        <div class="flexBoxlisteBaumUnterkategorie1">
                            <h2>PLZ:</h2>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("District") %>'></asp:Label>
                        </div>

                    </div>


                    <asp:Button CssClass="btnUnterseite" ID="btnDetails" runat="server" Text="Details anzeigen" OnCommand="Detail_Click" CommandName="DetailClick" CommandArgument='<%# Eval("ID") %>' />


                </div>
            </ItemTemplate>

        </asp:Repeater>



    </form>

</body>
</html>
