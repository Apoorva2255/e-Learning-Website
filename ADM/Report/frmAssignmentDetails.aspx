<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.master" AutoEventWireup="true" CodeFile="frmAssignmentDetails.aspx.cs" Inherits="OPT_Report_frmAssignmentDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
        BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" 
        CellSpacing="1" EmptyDataText="Record Not Found" GridLines="None" 
        ShowFooter="True" ShowHeaderWhenEmpty="True" Width="100%" 
            AutoGenerateColumns="False">
        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#594B9C" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#33276A" />
        <Columns>
         <asp:TemplateField HeaderText="SL.">
                    <ItemTemplate>
                    <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                    </asp:TemplateField>

                        <asp:BoundField DataField="ID" HeaderText="RegNO" />
                      <asp:BoundField DataField="UserName" HeaderText="Name" />
                       <asp:BoundField DataField="FatherName" HeaderText="Father's Name" />
                        <asp:BoundField DataField="class" HeaderText="class" />
                        <asp:BoundField DataField="Subject" HeaderText="Subject" />
                          <asp:BoundField DataField="Semester" HeaderText="Semester" />
                         
                         
<asp:BoundField DataField="MobileNo" HeaderText="MobileNo" />
                        <asp:BoundField DataField="PermanentAddress" HeaderText="Address" />

                         <asp:BoundField DataField="IsAssignment" HeaderText="Is Assignment Submit" />
        <asp:TemplateField HeaderText="View Assignment">
                            <ItemTemplate>
                            
          <a href="../../STDAssignment/<%#Eval("Assignment") %>" >view</a>

                           
                                 </ItemTemplate>
                            </asp:TemplateField>

        </Columns>
    </asp:GridView>
</div>
</asp:Content>

