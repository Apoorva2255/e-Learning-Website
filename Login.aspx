<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat=server >
    <div class="style1">
    
       <strong style="font-size: xx-large">Login Page</strong></div>
    <table class="style2">
        <tr>
            <td class="style4">
                UserName</td>
            <td class="style5">
                <asp:TextBox ID="TxtUN" runat="server" Width="180px"></asp:TextBox>
            </td>
            <td class="style15">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TxtUN" ErrorMessage="Please enter Username" 
                    ForeColor="Red" style="font-size: large; font-weight: 700">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Password</td>
            <td class="style5">
                <asp:TextBox ID="TxtPass" runat="server" TextMode="Password" 
                    Width="180px"></asp:TextBox>
            </td>
            <td class="style15">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TxtPass" ErrorMessage="Please enter Password" 
                    ForeColor="Red" style="font-size: large; font-weight: 700">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style5">
                <asp:Button ID="BtnLogin" runat="server" onclick="Button_Login_Click" 
                    style="font-weight: 700; Font-Size: x-large" Text="Login" Width="171px" />
            </td>
            <td class="style15">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                </td>
            <td class="style6">
                <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Yellow" 
                    NavigateUrl="~/Registration.aspx">New User Register Here</asp:HyperLink>
                </td>
            <td class="style16">
                </td>
        </tr>
        </table>

</asp:Content>    

<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
    .style15
    {
        width: 9px;
    }
    .style16
    {
        color: White;
        width: 9px;
    }
</style>
</asp:Content>
    

