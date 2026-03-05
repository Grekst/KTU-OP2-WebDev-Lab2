<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forma1.aspx.cs" Inherits="Laboratorinis_2.Forma1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Minimalus atstumas"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" LostFocus="LostFocus"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Įvesti"/>
            <br />
            <br />
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Duomenų failas"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            <br />
            <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
        </div>
    </form>
</body>
</html>
