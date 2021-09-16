<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ObstBaumUnterKategorie.aspx.cs" Inherits="PL_Plantnership.ObstBaumUnterKategorie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="Stylesheet" href="style.css" type="text/css" />    
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <header>
    
    <asp:Button ID="btnBaumVerwalten" runat="server"  Text="Meine Bäume verwalten" />
    <asp:Button ID="btnLoginIndex" runat="server"  Text="Login" />
    </header>

        <h3> Such dir einen Plantner für die Saison aus: </h3>
        <div>
            <asp:Repeater ID="repeaterPlantList" runat="server">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Variety") %>'></asp:Label>
                        <br />
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Owner") %>'></asp:Label>
                        <br />
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("District") %>'></asp:Label>
                        <asp:Button ID="btnDetails" runat="server" Text="Details anzeigen" cssClass="button" OnCommand="Detail_Click" CommandName="DetailClick" CommandArgument='<%# Eval("ID") %>'/>
                    </ItemTemplate>
                </asp:Repeater>
        </div>

    </form>
</body>
</html>
