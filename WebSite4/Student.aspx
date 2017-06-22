<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Student.aspx.cs" Inherits="Student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="StyleSheet2.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .auto-style2 {
            height: 23px;
        }
        .auto-style4 {
            height: 22px;
            text-align: right;
        }
        .auto-style5 {
            height:22px;
        }
        .auto-style6 {
            text-align: left;
        }
        .auto-style7 {
            height:23px;
            text-align: center;
        }
        .auto-style8 {
            height: 23px;
            width: 335px;
        }
        .auto-style9 {
            width: 335px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="div2" style="width:100%">
            <tr>
                <td style="text-align: center">
                    <asp:Label class="div1" ID="lbl_sports" runat="server" Text="Sports Management"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="div3" style="width:100%">
            <tr>
                <td colspan="2">
                    &nbsp;&nbsp;
                    <asp:Label class="div5" ID="lbl_pro" runat="server" Text="profile"></asp:Label>
                </td>
                <td colspan="2" class="auto-style4">
                    <asp:Button ID="btn_logout" runat="server" style="text-align: center" Text="Logout" OnClick="btn_logout_Click" BackColor="#0066FF" Font-Names="Arial" ForeColor="White" Height="30px" Width="100px" />
                </td>
            </tr>
            <tr>
                <td colspan="4" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;&nbsp;
                    <asp:Label CssClass="prolbl" ID="lbl_name" runat="server" Text="Name"></asp:Label>
                </td>
                <td class="auto-style8" colspan="2">
                    <asp:Label class="prolbl" ID="lbl_nname" runat="server"></asp:Label>
                </td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td>
                    &nbsp;&nbsp;
                    <asp:Label class="prolbl" ID="lbl_dob" runat="server" Text="Date of birth"></asp:Label>
                </td>
                <td colspan="2" class="auto-style9">
                    <asp:Label CssClass="prolbl" ID="lbl_ndob" runat="server"></asp:Label>
                </td>
                <td rowspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;&nbsp;
                    <asp:Label class="prolbl" ID="lbl_gen" runat="server" Text="Gender"></asp:Label>
                </td>
                <td colspan="2" class="auto-style9">
                    <asp:Label CssClass="prolbl" ID="lbl_ngen" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td colspan="2" class="auto-style8"></td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style7" colspan="4">
                    <asp:Button ID="btn_event" runat="server" OnClick="btn_event_Click" Text="View My Events" CssClass="auto-style6" />
                    <br />
                </td>
            </tr>
        </table>
        <br />
        <br>
        <asp:MultiView ID="MultiView1" runat="server" OnActiveViewChanged="MultiView1_ActiveViewChanged">
            <asp:View ID="View2" runat="server">
                <table class="div3" style="width:100%">
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="lbl_event" runat="server" Text="Events"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>9am to 10am</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButtonList ID="rbl_9to10" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Long Jump</asp:ListItem>
                                <asp:ListItem>High Jump</asp:ListItem>
                                <asp:ListItem>Pole Vault</asp:ListItem>
                                <asp:ListItem>None</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>10am to 12pm</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButtonList ID="rbl_10to12" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Football</asp:ListItem>
                                <asp:ListItem>Cricket</asp:ListItem>
                                <asp:ListItem>Hockey</asp:ListItem>
                                <asp:ListItem>None</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">1pm to 2pm</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButtonList ID="rbl_1to2" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Badminton</asp:ListItem>
                                <asp:ListItem>Tennis</asp:ListItem>
                                <asp:ListItem>None</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>2pm to 3pm</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButtonList ID="rbl_2to3" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Carroms</asp:ListItem>
                                <asp:ListItem>Chess</asp:ListItem>
                                <asp:ListItem>Table Tennis</asp:ListItem>
                                <asp:ListItem>None</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btn_sub" runat="server" OnClick="btn_sub_Click" Text="Submit" />
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View1" runat="server">
                <table class="div3">
                    <tr>
                        <td>
                            <asp:Label ID="lbl_revent" runat="server" Text="You have registered for the following events"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">9am to 10am</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_r9to10" runat="server" Text="No Events"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>10am to 12pm</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_r10to12" runat="server">No Events</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>1pm to 2pm</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_r1to2" runat="server">No Events</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>2pm to 3pm</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_r2to3" runat="server">No Events</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
        <br />
    
    </div>
    </form>
</body>
</html>
