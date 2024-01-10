<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmaddContent.aspx.cs" Inherits="CreateConference" MasterPageFile="~/MainSite.master" %>
<%@ Register assembly="RJS.Web.WebControl.PopCalendar" namespace="RJS.Web.WebControl" tagprefix="rjs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link rel="stylesheet" type="text/css" href="Styles/Site.css" />
    
    <style type="text/css">
        .style1
        {
            height: 11px;
            font-weight: 700;
            text-align: center;
            font-size: x-large;
        }
        .style2
        {
            height: 33px;
        }
    .style3
    {
        width: 211px;
    }
    .style4
    {
        height: 33px;
        width: 211px;
    }
    .style5
    {
        width: 6px;
    }
    .style6
    {
        height: 33px;
        width: 6px;
    }
    </style>
    
 </asp:Content> 

 <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

   

        <div align="center">
            

            <table  width="100%">
        <tr>
                        <td align="left" class="style1" colspan="2" >
                            CONTENTS</td>
                        <td align="left" class="style1" >
                            &nbsp;</td>
                    </tr>
        <tr>
                        <td align="left" class="style3" >
                            Session</td>
                        <td align="left" class="style5">
                            <asp:DropDownList ID="ddlsession" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td align="left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="Session is Required" ControlToValidate="ddlsession" 
                                ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
    <tr>
            <td align="left" class="style3" >
                Class&nbsp;</td>
            <td align="left" class="style5">
                <asp:DropDownList ID="ddlclass" runat="server" Width="180px">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                    <asp:ListItem Value="1">Content</asp:ListItem>
                    <asp:ListItem Value="2">Confrence</asp:ListItem>
                   
                </asp:DropDownList>
            </td>
            <td align="left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="Class is Required" ControlToValidate="ddlclass" 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
                        <td align="left" class="style4" >
                            Semester</td>
                        <td align="left" class="style6">
                            <asp:DropDownList ID="ddlsem" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td align="left" class="style2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ErrorMessage="Semester is Required" ControlToValidate="ddlsem" 
                                ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>

        <tr>
                        <td align="left" class="style4" >
                            Title</td>
                        <td align="left" class="style6">
                            <asp:TextBox ID="txttitle" runat="server"></asp:TextBox>
                        </td>
                        <td align="left" class="style2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ErrorMessage="Title is Required" ControlToValidate="txttitle" 
                                ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>

        <tr>
                        <td align="left" class="style3" >
                            Content </td>
                        <td align="left" class="style5">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </td>
                        <td align="left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ErrorMessage="Content is Required" ControlToValidate="FileUpload1" 
                                ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>

        <tr>
            <td class="style3" >
                &nbsp;</td>
            <td style="text-align: left" class="style5">
                <asp:Button ID="Button1" runat="server" Text="Upload" Width="149px" 
                    onclick="Button1_Click" style="margin-right: 4px; text-align: right;" />
                            <asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="#993300"></asp:Label>
            </td>
            <td style="text-align: left">
                &nbsp;</td>
        </tr>
    </table>
           
        
        </div>
        <div>
            <asp:GridView runat="server" ID="gvdata" Width="100%" BackColor="White" 
                BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                AutoGenerateColumns="False">
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
           
                   <asp:BoundField DataField="Title"  HeaderText="Title " />
                    <asp:BoundField DataField="SemName" HeaderText="Semester" />
                                    <asp:BoundField DataField="Courses_Name" HeaderText="Class" />

                                     <asp:BoundField DataField="SessionName" HeaderText="Session" />

                                    
                                   
                                    <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                      <a href="../Content/<%#Eval("Upload") %>" >view</a>
                                       
                                       </ItemTemplate>
                                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        
        </div>
    
    
 </asp:Content>  