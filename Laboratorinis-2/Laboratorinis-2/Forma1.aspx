<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forma1.aspx.cs" Inherits="Laboratorinis_2.Forma1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="MinDistance_Label" runat="server" Text="Minimalus atstumas"></asp:Label>
            <br />
            <asp:TextBox ID="MinDistance_DataTextbox" runat="server"></asp:TextBox>
            <br />
            <br />
        </div>
        <div>
            <asp:Button ID="Data_UploadFromInternal" runat="server" Text="Įkelti iš App_Data" OnClick="Data_UploadFromInternal_Click" />
            <br />
            <br />
            <asp:Label ID="Data_Header" runat="server" Text="Pradiniai duomenys"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Data_Label1" runat="server" Text="Miestai"></asp:Label>
            <br />
            <asp:TextBox ID="Data_TextBox1" runat="server" TextMode="MultiLine" CssClass="auto-style1" Width="346px" Height="111px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Data_Label2" runat="server" Text="Keliai tarp miestų"></asp:Label>
            <br />
            <asp:TextBox ID="Data_TextBox2" runat="server" CssClass="auto-style1" TextMode="MultiLine" Width="346px" Height="111px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Data_CalculateButton" runat="server" Text="Vykdyti" OnClick="Data_CalculateButton_Click" />
            <br />
            <br />
        </div>
        <div>
            <asp:Label ID="Result_Label" runat="server" Text="Rezultatai"></asp:Label>
            <br />
            <asp:TextBox ID="Result_TextBox" runat="server"></asp:TextBox>
        </div>
    </form>
</body>
</html>
