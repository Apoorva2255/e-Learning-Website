<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.master" AutoEventWireup="true" CodeFile="frmAssignment.aspx.cs" Inherits="STD_frmAssignment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
    .style1
    {
        height: 29px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
<table width="100%">
<tr>
<td colspan="2">
Assignment
</td>
</tr>
<tr>
<td class="style1">
    Subject</td>
<td class="style1">
        <asp:DropDownList ID="ddlSubject" runat="server">
        </asp:DropDownList>
</td>
    <td class="style1">
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="ddlSubject" ErrorMessage="Subject is Required" 
            ForeColor="Red">*</asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td>
    Assignment</td>
<td>
        <asp:FileUpload ID="FileUpload1" runat="server" />
</td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="FileUpload1" ErrorMessage="Assignmrent is Required" 
            ForeColor="Red">*</asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td align="center" colspan="2">
    <asp:LinkButton ID="lnkupload" runat="server" onclick="lnkupload_Click">Submit</asp:LinkButton>
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
</td>
</tr>
<tr>
<td align="center" colspan="2">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
        CellPadding="4" ShowFooter="True" ShowHeaderWhenEmpty="True" Width="100%">
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <RowStyle BackColor="White" ForeColor="#003399" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SortedAscendingCellStyle BackColor="#EDF6F6" />
        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
        <SortedDescendingCellStyle BackColor="#D6DFDF" />
        <SortedDescendingHeaderStyle BackColor="#002876" />
        <Columns>
            <asp:TemplateField HeaderText="SL.">
                <ItemTemplate>
                    <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="RegNo" HeaderText="RegNO" />
            <asp:BoundField DataField="Subject" HeaderText="Subject" />
            <asp:BoundField DataField="Date" DataFormatString="{0:dd MMM yyyy}" 
                HeaderText="Submit Date" />
            <asp:TemplateField HeaderText="View Assignment">
                <ItemTemplate>
                   <%-- <asp:LinkButton ID="LinkButton1" runat="server" 
                        PostBackUrl='<%#Eval("Assignment") %>'>View</asp:LinkButton>--%>
                          <a href="../STDAssignment/<%#Eval("Assignment") %>" >view</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</td>
</tr>
</table>
</div>
</asp:Content>

