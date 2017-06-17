<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet2.css" type="text/css" rel="stylesheet" />
    <style type="text/css">


        .auto-style5 {
            height:22px;
        }
        .auto-style4 {
            height: 22px;
            text-align: right;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style6 {
            text-align: center;
        }
        .auto-style7 {
            width: 100%;
        }
        .auto-style8 {
            height: 30px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="div2" style="width:100%">
            <tr>
                <td style="text-align: center" class="auto-style1">
                    <asp:Label class="div1" ID="lbl_sports" runat="server" Text="Sports Management"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
        <table class="div3" style="width:100%">
            <tr>
                <td colspan="2" class="auto-style5">
                    &nbsp;&nbsp;
                    <asp:Label class="div5" ID="lbl_pro" runat="server" Text="Profile"></asp:Label>
                </td>
                <td colspan="2" class="auto-style4">
                    <asp:Button CssClass="but" ID="btn_chpass" runat="server" Text="Change My Password" OnClick="btn_chpass_Click" />
                    <asp:Button  ID="btn_logout"  runat="server"  Text="Logout" OnClick="btn_logout_Click" BackColor="#0066FF" Font-Names="Arial" ForeColor="White" Height="30px" Width="100px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;&nbsp;
                    <asp:Label class="prolbl" ID="lbl_name" runat="server" Text="Name"></asp:Label>
                </td>
                <td class="auto-style2" colspan="2">
                    <asp:Label class="prolbl" ID="lbl_nname" runat="server"></asp:Label>
                </td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td>
                    &nbsp;&nbsp;
                    <asp:Label class="prolbl" ID="lbl_dob" runat="server" Text="Date of birth"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:Label class="prolbl" ID="lbl_ndob" runat="server"></asp:Label>
                </td>
                <td rowspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;&nbsp;
                    <asp:Label class="prolbl" ID="lbl_gen" runat="server" Text="Gender"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:Label class="prolbl" ID="lbl_ngen" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;&nbsp;
                    <asp:Label class="prolbl" ID="lbl_evty" runat="server" Text="Co-ordinating event"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:Label CssClass="prolbl" ID="lbl_neyty" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6" colspan="4">
                    <asp:Button ID="btn_list" runat="server" OnClick="btn_list_Click" Text="Participant List" />
                </td>
            </tr>
        </table>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
            </asp:View>
            &nbsp;
            <br />
            <asp:View ID="View2" runat="server">
                <table class="auto-style7">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Enter the Existing Password"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_expass" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Enter the new password"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_npass" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Confirm Password"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_cpass" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">
                            <asp:Button ID="btn_cpass" runat="server" OnClick="btn_cpass_Click" Text="Change Password" />
                        </td>
                        <td class="auto-style8"></td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
            </asp:View>
            <br />
        </asp:MultiView>
        <br >
    </form>
    
</body>
</html>
