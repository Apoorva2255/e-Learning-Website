<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Courses.aspx.cs" Inherits="Courses" MasterPageFile="~/MainSite.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link rel="stylesheet" type="text/css" href="Styles/Site.css" />
    
 </asp:Content> 
 <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <div align="center">
    
    
        <asp:Panel runat="server" GroupingText="Add Course">
        <table class="style1">
        <tr>
            <td class="style2" style="text-align: right">
                Courses Name</td>
            <td>
                <asp:TextBox ID="txtCourse" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtCourse" ErrorMessage="Enter Course" ForeColor="#993300" 
                    SetFocusOnError="True" ValidationGroup="s">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" 
                    ValidationGroup="s" />
                <asp:Label ID="lblmsg" runat="server" ForeColor="#993300"></asp:Label>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="s" />
            </td>
        </tr>
        <tr>
            <td class="style2" style="text-align: right" colspan="2">
                <asp:GridView ID="GridView1" runat="server" Width="100%" BackColor="White" 
                    BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                    ShowFooter="True" AutoGenerateColumns="False">
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
                    
                  <asp:TemplateField HeaderText="Sl.">
                  
                  
                  <ItemTemplate>
                  
                  
                  <%#Container.DataItemIndex+1 %>
                  </ItemTemplate>
                  
                  </asp:TemplateField>
                    <asp:BoundField DataField="Course" HeaderText="Course" />
                    
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
        </asp:Panel>
    </div>
    
 </asp:Content>    