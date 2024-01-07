<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.master" AutoEventWireup="true" CodeFile="frmListOfUsersaspx.aspx.cs" Inherits="ADM_Report_frmListOfUsersaspx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div align="center">
<strong>User Details</strong>


    <asp:GridView runat="server" BackColor="White" BorderColor="#3366CC"  ID="Gvdata"
        BorderStyle="None" BorderWidth="1px" CellPadding="4" ShowFooter="True" 
        Width="100%">
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <RowStyle BackColor="White" ForeColor="#003399" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SortedAscendingCellStyle BackColor="#EDF6F6" />
        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
        <SortedDescendingCellStyle BackColor="#D6DFDF" />
        <SortedDescendingHeaderStyle BackColor="#002876" />
    </asp:GridView>
</div>
</asp:Content>

