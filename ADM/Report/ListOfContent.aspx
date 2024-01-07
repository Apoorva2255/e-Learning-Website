<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.master" AutoEventWireup="true" CodeFile="ListOfContent.aspx.cs" Inherits="STD_ListOfAsignemnt" %>

<%@ Register assembly="RJS.Web.WebControl.PopCalendar" namespace="RJS.Web.WebControl" tagprefix="rjs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div>
<table width="100%">
<tr>
<td align="center" colspan="4">
<strong>Content Details</strong>
</td>
</tr>
<tr>
<td>From Date</td><td>
    <asp:TextBox ID="txtfrom" runat="server" ReadOnly="True"></asp:TextBox>
    <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="txtfrom" />
    </td>
<td>To Date</td><td>
    <asp:TextBox ID="txtTo" runat="server" ReadOnly="True"></asp:TextBox>
    <rjs:PopCalendar ID="PopCalendar2" runat="server" Control="txtTo" 
        Format="dd mmm yyyy" />
    </td>
</tr>

<tr>
<td align="center" colspan="4">
    <asp:LinkButton ID="lnkserach" runat="server" onclick="lnkserach_Click">Search</asp:LinkButton>
    </td>
</tr>

</table>
</div>
<div align="center">
        
<%--    <asp:DataList ID="DataList1" runat="server" BackColor="White" 
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" 
        onselectedindexchanged="DataList1_SelectedIndexChanged" RepeatColumns="3" 
        RepeatDirection="Horizontal" Width="100%">
        <AlternatingItemStyle BackColor="#F7F7F7" />
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <ItemStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
       
        <ItemTemplate>
        
          <strong>Title   </strong><%#Eval("Title")%><br />
         
           
     <strong>Assignment </strong>    <asp:LinkButton runat="server" PostBackUrl='<%#Eval("Upload") %>'>Download</asp:LinkButton>
        </ItemTemplate>
    </asp:DataList>--%>

    <asp:GridView runat="server" ID="gvData" CellPadding="4" ForeColor="#333333" 
            GridLines="None" ShowFooter="True" ShowHeaderWhenEmpty="True" Width="100%" 
            AutoGenerateColumns="False" EmptyDataText="Record Not Found">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
        <Columns>
          <asp:TemplateField HeaderText="SL.">
                <ItemTemplate>
                <%#Container.DataItemIndex+1 %>
                </ItemTemplate>
                </asp:TemplateField>
        <asp:BoundField DataField="Title" HeaderText="Title" />
        <asp:BoundField DataField="CreatedDate" DataFormatString='{0:dd MMM yyyy}' HeaderText="Date" />
        <asp:TemplateField HeaderText="Assignment">
        <ItemTemplate>
        <strong> </strong>    <asp:LinkButton runat="server" PostBackUrl='<%#Eval("Upload") %>'>Download</asp:LinkButton>
        </ItemTemplate>
        </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
</asp:Content>

