<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="STD_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div align="right">
<table width="100%">
<tr>
<td align="center" colspan="4">
  </td>
</tr>
<tr>
<td valign="top">
  <strong>Assignment  Details</strong>
  <asp:DataList ID="DataList1" runat="server" BackColor="White" 
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" 
         RepeatColumns="3" 
        RepeatDirection="Horizontal" Width="100%">
        <AlternatingItemStyle BackColor="#F7F7F7" />
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <ItemStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
       
        <ItemTemplate>
        
          <strong>Session</strong> <%#Eval("SessionName")%><br />     
          <strong>Title</strong> <%#Eval("Subject")%><br />     
              <strong>SemName</strong> <%#Eval("SemName")%><br />     
           <strong>Courses Name</strong> <%#Eval("Courses_Name")%><br /> 
              <strong>Subject</strong> <%#Eval("Subject")%><br />
          <%--  <asp:LinkButton runat="server" PostBackUrl='<%#Eval("DocumentPath") %>'>View</asp:LinkButton>
--%>
            
    <a href="../Assignment/<%#Eval("DocumentPath") %>" >view</a>
  
        </ItemTemplate>
    </asp:DataList>
    
</td>
<td valign="top" align="center">
  <strong>Student Profile</strong>
    <asp:DetailsView runat="server" Height="50px" Width="100%" ID="DetailsView1" 
        BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" CellSpacing="2">
        <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
</asp:DetailsView></td>
</tr>
</table>
    
</div>
</asp:Content>


