<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateConference.aspx.cs" Inherits="CreateConference" MasterPageFile="~/MainSite.master" %>
<%@ Register assembly="RJS.Web.WebControl.PopCalendar" namespace="RJS.Web.WebControl" tagprefix="rjs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link rel="stylesheet" type="text/css" href="Styles/Site.css" />
    
    <style type="text/css">
        .style1
        {
            width: 282px;
        }
        .style2
        {
            width: 134px;
        }
        .style3
        {
            width: 134px;
            height: 24px;
        }
        .style4
        {
            width: 282px;
            height: 24px;
        }
        .style5
        {
            height: 24px;
        }
        .style6
        {
            width: 134px;
            height: 29px;
        }
        .style7
        {
            width: 282px;
            height: 29px;
        }
        .style8
        {
            height: 29px;
        }
    </style>
    
 </asp:Content> 

 <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

   

        <div align="center">
            

            <table  width="100%">
        <tr>
                        <td align="left" class="style2" >
                            Session</td>
                        <td align="left" class="style1">
                            <asp:DropDownList ID="ddlsession" runat="server" Width="174px">
                            </asp:DropDownList>
                        </td>
                        <td align="left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="ddlsession" ErrorMessage="Session is Required" 
                                ForeColor="Red" ValidationGroup="s">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
    <tr>
            <td align="left" class="style2" >
                Class&nbsp;</td>
            <td align="left" class="style1">
                <asp:DropDownList ID="ddlclass" runat="server" Width="180px">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                    <asp:ListItem Value="1">Content</asp:ListItem>
                    <asp:ListItem Value="2">Confrence</asp:ListItem>
                   
                </asp:DropDownList>
            </td>
            <td align="left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="s"
                    ControlToValidate="ddlclass" ErrorMessage="Class is Required" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
                        <td align="left" class="style2" >
                            Semester</td>
                        <td align="left" class="style1">
                            <asp:DropDownList ID="ddlsem" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td align="left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  ValidationGroup="s"
                                ControlToValidate="ddlsem" ErrorMessage="Semester is Required" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
              
        <tr>
            <td align="left" class="style3" >
                Date</td>
            <td align="left" class="style4">
                <asp:TextBox ID="txtdate" runat="server" ></asp:TextBox>
                <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="txtdate" 
                    Format="dd mmm yyyy" />
            </td>
            <td align="left" class="style5">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  ValidationGroup="s"
                    ControlToValidate="txtdate" ErrorMessage="Time is Required" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style6" align="left">
                Title</td>
            <td align="left" class="style7"> 
                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
            </td>
            <td align="left" class="style8"> 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"  ValidationGroup="s"
                    ControlToValidate="txtTitle" ErrorMessage="Title is Required" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2" align="left">
                Time From</td>
            <td align="left" class="style1"> <asp:TextBox ID="txtTimeFrom" runat="server" ></asp:TextBox></asp:TextBox>
            </td>
            <td align="left"> 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"  ValidationGroup="s"
                    ControlToValidate="txtTimeFrom" ErrorMessage="Time from is Required" 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="left" class="style6" >
                Time To</td>
            <td align="left" class="style7">
                <asp:TextBox ID="txtTimeto" runat="server" ></asp:TextBox>
            </td>
            <td align="left" class="style8">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"  ValidationGroup="s"
                    ControlToValidate="txtTimeto" ErrorMessage="Time to is Required" 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        
        <tr>
            <td align="left" class="style2" >
                URL</td>
            <td align="left" class="style1">
                <asp:TextBox ID="txturl" runat="server"></asp:TextBox>
            </td>
            <td align="left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"  ValidationGroup="s"
                    ControlToValidate="txturl" ErrorMessage="URL is Required" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2" >
                &nbsp;</td>
            <td class="style1">
                <asp:Button ID="Button1" runat="server" Text="Submit" Width="149px" 
                    onclick="Button1_Click" style="margin-right: 4px" ValidationGroup="s" />
                            <asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="#993300"></asp:Label>
            </td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="s" />
            </td>
        </tr>
    </table>
           
        
        </div>
        <div>
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
             <strong>Date Of Conference   </strong><%#Eval("Date")%><br />
          <strong>Start Time   </strong><%#Eval("Time_from")%><br />
         
              <strong>End Time  </strong><%#Eval("Time_to")%><br />
              <strong>Url </strong>
              
            <asp:LinkButton runat="server" onclick="Unnamed1_Click" CommandArgument='<%#Eval("Url") %>' >Go Online</asp:LinkButton> 
            
           
      
        </ItemTemplate>
    </asp:DataList>
        </div>
    
    
 </asp:Content>  