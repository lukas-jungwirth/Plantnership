<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="PL_Plantnership.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>PlantnerShip</title>
    <link rel="Stylesheet" href="style.css" type="text/css" />
</head>
<body>
   
    
       <h1>PlantnerSHIP</h1> 
    <form id="form1" runat="server">
        <br />
        <br />
        
        <asp:Button ID="btnTreeMatch" runat="server" OnClick="btnTreeMatch_Click" Text="Tree Match" />
        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
        <asp:Button ID="btnBaumVerwalten" runat="server" OnClick="btnBaumVerwalten_Click" Text="Meine Bäume verwalten" />
        </form>
    <br />
        <br />
      <asp:Image ID="Image1" runat="server" ImageUrl="~/pexels-photo-1632790.jpeg" />
    
   
</body>
</html>
