<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" type="text/css" rel="stylesheet" />

    <style type="text/css">
        .auto-style1 {
            width: 30px;
            height: 49px;
        }
        .auto-style2 {
            width: 50px;
            height: 49px;
        }
    </style>

    </head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="div6">
            <tr>
                <td style="text-align: center">
                    <asp:Label  class="div9" ID="lbl_sports" runat="server" Text="Sports Management" ></asp:Label>
                </td>
            </tr>
        </table>
    
        <table class="div1">
            <tr>
                <td></td>
                <td  class="div8" colspan="5">
                    <asp:Label class="signinlbl" ID="lbl_signinhere" runat="server" Text="Sign In Here!"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="div2" rowspan="12"></td>
                <td class="div4">
                    <asp:Label class="div10" ID="lbl_srno" runat="server" Text="SR No."></asp:Label>
                </td>
                <td class="div3">
                    <asp:TextBox ID="txt_srno" runat="server"></asp:TextBox>
                </td>
                <td class="div4">
                    <asp:Label class="div10" ID="lbl_pass" runat="server" Text="Password"></asp:Label>
                </td>
                <td class="div3">
                    <asp:TextBox ID="txt_pass" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td class="div4">
                    <asp:Button ID="btn_in" runat="server" Text="Sign-In" OnClick="btn_in_Click" />
                </td>
            </tr>
            <tr>
                <td class="div5" colspan="5">
                    <br />
                    <br />
                    <asp:Label class="div10" ID="lbl_nota" runat="server" Text="Not a member already? Sign-Up here!"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="div10">
                    <asp:Label ID="lbl_cat" runat="server" Text="Category"></asp:Label>
                </td>
                <td class="div10" colspan="4">
                    <asp:RadioButtonList ID="rbl_cat" runat="server" OnSelectedIndexChanged="rbl_cat_SelectedIndexChanged" RepeatDirection="Horizontal" AutoPostBack="True">
                        <asp:ListItem>Admin</asp:ListItem>
                        <asp:ListItem>Student</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label class="div10" ID="lbl_name" runat="server" Text="Name"></asp:Label>
                </td>
                <td class="auto-style2" colspan="4">
                    <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" BackColor="Red" ControlToValidate="txt_name" ErrorMessage="Required Field" ForeColor="White" ValidationGroup="req"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label class="div10" ID="lbl_srnoup" runat="server" Text="Sr No."></asp:Label>
                </td>
                <td class="auto-style2" colspan="4">
                    <asp:TextBox ID="txt_srnoup" runat="server" OnTextChanged="txt_srnoup_TextChanged" TextMode="Number" CausesValidation="True" ValidationGroup="req"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" BackColor="Red" ControlToValidate="txt_srnoup" ErrorMessage="Required field" ForeColor="White" ValidationGroup="req"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="div4">
                    <asp:Label class="div10" ID="lbl_dob" runat="server" Text="Date Of Birth"></asp:Label>
                </td>
                <td class="div3" colspan="4">
                    <asp:TextBox ID="txt_dob" runat="server" OnTextChanged="txt_dob_TextChanged" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" BackColor="Red" ControlToValidate="txt_dob" ErrorMessage="Required Field" ForeColor="White" ValidationGroup="req"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="div4">
                    <asp:Label class="div10" ID="lbl_gen" runat="server" Text="Gender"></asp:Label>
                </td>
                <td class="div3" colspan="4">
                    <asp:RadioButtonList class="div10" ID="rbl_gen" runat="server" OnSelectedIndexChanged="rbl_gen_SelectedIndexChanged" RepeatDirection="Horizontal">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" BackColor="Red" ControlToValidate="rbl_gen" ErrorMessage="Required Field" ForeColor="White" ValidationGroup="req"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="div4">
                    <asp:Label class="div10" ID="lbl_passup" runat="server" Text="Password"></asp:Label>
                </td>
                <td class="div3" colspan="4">
                    <asp:TextBox ID="txt_passup" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" BackColor="Red" ControlToValidate="txt_passup" ErrorMessage="Required Field" ForeColor="White" ValidationGroup="req"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="div4">
                    <asp:Label class="div10" ID="lbl_con" runat="server" Text="Confirm Password"></asp:Label>
                </td>
                <td class="div3" colspan="4">
                    <asp:TextBox ID="txt_con" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" BackColor="Red" ControlToValidate="txt_con" ErrorMessage="Required Field" ForeColor="White" ValidationGroup="req"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="div4">
                    <asp:Label class="div10" ID="lbl_event" runat="server" Text="Event" Visible="False" ForeColor="White"></asp:Label>
                </td>
                <td class="div7" colspan="4">
                    <asp:DropDownList ID="ddl_event" runat="server" Visible="False" AutoPostBack="True" OnSelectedIndexChanged="ddl_event_SelectedIndexChanged">
                        <asp:ListItem Value="null">Select any event</asp:ListItem>
                        <asp:ListItem>Long Jump</asp:ListItem>
                        <asp:ListItem>Pole Vault</asp:ListItem>
                        <asp:ListItem>Football</asp:ListItem>
                        <asp:ListItem>Cricket</asp:ListItem>
                        <asp:ListItem>Hockey</asp:ListItem>
                        <asp:ListItem>Badminton</asp:ListItem>
                        <asp:ListItem>High Jump</asp:ListItem>
                        <asp:ListItem>Tennis</asp:ListItem>
                        <asp:ListItem>Carroms</asp:ListItem>
                        <asp:ListItem>Chess</asp:ListItem>
                        <asp:ListItem>Table Tennis</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="div4">
                    <asp:Label class="div10" ID="lbl_key" runat="server" Text="Security key" Visible="False" ForeColor="White"></asp:Label>
                </td>
                <td class="div7" colspan="4">
                    <asp:TextBox ID="txt_key" runat="server" TextMode="Password" Visible="False" OnTextChanged="txt_key_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="div7" colspan="5">
                    <asp:Button ID="btn_up" runat="server" Text="Sign-Up" OnClick="btn_up_Click" ValidationGroup="req" />
                    <asp:Button ID="btn_adup" runat="server" OnClick="btn_adup_Click" Text="Sign-Up" Visible="False" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
