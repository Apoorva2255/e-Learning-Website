<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.master" AutoEventWireup="true" CodeFile="FrmConFrence.aspx.cs" Inherits="STD_ListOfAsignemnt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div align="center">
        <strong>Conference Details</strong>
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
             <strong>Date Of Conference   </strong><%#Eval("Date")%><br />
          <strong>Start Time   </strong><%#Eval("Time_from")%><br />
         
              <strong>End Time  </strong><%#Eval("Time_to")%><br />
              <strong>Url </strong>
              
            <asp:LinkButton runat="server" onclick="Unnamed1_Click" CommandArgument='<%#Eval("Url") %>' >LinkButton</asp:LinkButton> 
            
           
      
        </ItemTemplate>
    </asp:DataList>
</div>
</asp:Content>

