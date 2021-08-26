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
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:Button ID="Button2" runat="server" Text="Button" />
        <asp:Button ID="Button3" runat="server" Text="Button" />
        <asp:Button ID="Button4" runat="server" Text="Button" />
        Hallo Lukas!<asp:Button ID="Button5" runat="server" Text="Button" />
        <asp:Button ID="Button6" runat="server" Text="Button" />
        <asp:CheckBox ID="CheckBox1" runat="server" />
        <br />
        Hier ist Magdalena<br />
        <asp:Button ID="Button7" runat="server" Text="Button" OnClick="Button7_Click" />
        <asp:Label ID="lblOutput" runat="server" Text="Hier kommt der text rein"></asp:Label>
    </form>
</body>
</html>
