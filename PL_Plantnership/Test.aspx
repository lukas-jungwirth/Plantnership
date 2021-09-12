<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="PL_Plantnership.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Hallo Welt</div>
        Hallo Lukas!<br />
        Hier ist Magdalena<br />
        <asp:Button ID="Button7" runat="server" Text="Button" OnClick="Button7_Click" />
        <asp:Label ID="lblOutput" runat="server" Text="Hier kommt der text rein"></asp:Label>
        <br />
        super tolle arbeit leute
        <select id="selectSternzeichen">
            <option>Widder</option>
            <option>Waage</option>
            <option>Stier</option>
            <option>Skorpion</option>
            <option>Zwillinge</option>
            <option>Krebs</option>
            <option>Steinbock</option>
            <option>Löwe</option>
            <option>Wassermann</option>
            <option>Jungfrau</option>
            <option>Fische</option>
        </select>
        <select id="selectJz">
            <option>Frühling</option>
            <option>Sommer</option>
            <option>Herbst</option>
            <option>Winter</option>
        </select>

        <asp:Button ID="btnGetMyCategory" runat="server" OnClick="btnGetMyCategory_Click" Text="Berechne die perfekte Kategorie für mich" />

    </form>

</body>
</html>
