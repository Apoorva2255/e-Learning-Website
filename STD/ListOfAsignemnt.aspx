<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.master" AutoEventWireup="true" CodeFile="ListOfAsignemnt.aspx.cs" Inherits="STD_ListOfAsignemnt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div align="center">
        <strong>Assignemnt Details</strong>
    <asp:DataList ID="DataList1" runat="server" BackColor="White" 
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" 
        onselectedindexchanged="DataList1_SelectedIndexChanged" RepeatColumns="3" 
        RepeatDirection="Horizontal" Width="100%">
        <AlternatingItemStyle BackColor="#F7F7F7" />
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <ItemStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
       
        <ItemTemplate>
        
          <strong>Subject   </strong><%#Eval("Subject")%><br />
         <strong>Date   </strong><%#Eval("Date")%><br />          
           
     <strong>Assignment </strong>    <asp:LinkButton runat="server" PostBackUrl='<%#Eval("DocumentPath") %>'>Download</asp:LinkButton>
        </ItemTemplate>
    </asp:DataList>
</div>
</asp:Content>

