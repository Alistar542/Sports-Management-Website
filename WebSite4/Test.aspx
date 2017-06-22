<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="test11.css" rel="stylesheet" type="text/css"/>
    <style type="text/css">
        .auto-style1 {}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <ul>
        <li>
            <table>
                <tr>
            <td>
        <a href="Test.aspx">Home</a>
            </td>
            
                    <td>
                        <asp:TextBox class="textf" ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox CssClass="textf" ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Button" />
                    </td>
                </tr>
            </table>
            </li>
        </ul>
      
    </div>
    </form>
</body>
</html>
