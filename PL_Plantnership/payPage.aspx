<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="payPage.aspx.cs" Inherits="PL_Plantnership.payPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div class="wrapper">

            <h1>Rechnung</h1>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </p>
            <p>
                <asp:Label ID="lbl" runat="server" Text="Label"></asp:Label>
            </p>
            <p>
                <asp:Button ID="btnpay" runat="server" Text="Zahlen" />
            </p>




        </div>
        
    </form>
</body>
</html>
