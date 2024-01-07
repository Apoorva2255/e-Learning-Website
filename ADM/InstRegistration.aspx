<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.master" AutoEventWireup="true" CodeFile="InstRegistration.aspx.cs" Inherits="InstRegistration" %>

<%@ Register assembly="RJS.Web.WebControl.PopCalendar" namespace="RJS.Web.WebControl" tagprefix="rjs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            font-size: xx-large;
        }
        .style3
        {
            text-align: right;
            }
        .style4
        {
        }
        .style5
        {
            width: 213px;
        }
        .style6
        {
            text-align: right;
            width: 340px;
            height: 30px;
        }
        .style7
        {
            width: 213px;
            height: 30px;
        }
        .style8
        {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p class="style2">
        Add Faculty Details</p>
    <table class="style1">
        <tr>
            <td class="style6">
                Name</td>
            <td class="style7">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
            <td class="style8">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" 
                    ErrorMessage="Name is Required" ForeColor="Red" SetFocusOnError="True" 
                    ValidationGroup="S">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Email</td>
            <td class="style5">
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ControlToValidate="txtEmail" 
                    ErrorMessage="Email is Required" ForeColor="Red" SetFocusOnError="True" 
                    ValidationGroup="S">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Contact number</td>
            <td class="style5">
                <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  ControlToValidate="txtMobile"
                    ErrorMessage="Number is Required" ForeColor="Red" SetFocusOnError="True" 
                    ValidationGroup="S">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" >
                DOJ</td>
            <td class="style5">
                <asp:TextBox ID="txtdoj" runat="server" ReadOnly="True"></asp:TextBox>
                <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="txtdoj" 
                    Format="dd mmm yyyy" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td  align="center" colspan="3">
                <asp:Label ID="lblmsg" runat="server" Font-Bold="True" ForeColor="#993300"></asp:Label>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    ValidationGroup="S" ShowMessageBox="True" />
                <asp:Button ID="Button1" runat="server" Text="Submit" Width="126px" 
                    onclick="Button1_Click" ValidationGroup="S" Height="29px" />
                </td>
        </tr>
        <tr>
            <td  align="center" colspan="3">
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                    GridLines="None" ShowFooter="True" Width="100%">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    <Columns>
                    <asp:TemplateField HeaderText="SL.">
                    
                    <ItemTemplate>
                    
                    <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </td>
        </tr>
        <tr>
            <td class="style4" align="center" colspan="3">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

