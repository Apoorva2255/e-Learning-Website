<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" MasterPageFile="~/RegMasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat=server >
    
    <div>
    
        <h6 style="font-size: x-large; text-align: left;">
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <strong><span class="style7">&nbsp;&nbsp; </span><span class="style14">REGISTRATION PAGE</span></strong><br />
            <asp:LinkButton runat="server" onclick="Unnamed1_Click">Login</asp:LinkButton>
        </h6>
    
        <table class="style1">
            <tr>
                <td class="style19">
                    User Name</td>
                <td class="style21">
                    <asp:TextBox ID="TextBoxUN" runat="server" style="font-family: Georgia" 
                        Width="180px" meta:resourcekey="TextBoxUNResource1"></asp:TextBox>
                </td>
                <td class="style20">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUN" runat="server"   ValidationGroup="s" 
                        ControlToValidate="TextBoxUN" ErrorMessage="User Name is Required" 
                        ForeColor="Red" meta:resourcekey="RequiredFieldValidatorUNResource1">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style19">
                    Email</td>
                <td class="style21">
                    <asp:TextBox ID="txtemail" runat="server" Width="180px" 
                        meta:resourcekey="TextBoxEmailResource1"></asp:TextBox>
                </td>
                <td class="style20">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server"   ValidationGroup="s" 
                        ControlToValidate="txtemail" ErrorMessage="E-mail is Required" 
                        ForeColor="Red" meta:resourcekey="RequiredFieldValidatorEmailResource1">*</asp:RequiredFieldValidator>
                    <br /> 
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"   ValidationGroup="s" 
                        ControlToValidate="txtemail" 
                        ErrorMessage="You must enter the valid E-mail ID" ForeColor="Red" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                        meta:resourcekey="RegularExpressionValidator1Resource1">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style19">
                    Gender</td>
                <td class="style21">
                    <asp:DropDownList ID="ddlgender" runat="server" Width="180px">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                        <asp:ListItem Value="F">Female</asp:ListItem>
                        <asp:ListItem Value="M">Male</asp:ListItem>
                        <asp:ListItem Value="T">Transgender</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style20">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorGender" runat="server" 
                        ControlToValidate="ddlgender" ErrorMessage="Gender is Required" 
                        ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style19">
                    Session</td>
                <td>
                    <asp:DropDownList ID="ddlsession" runat="server" 
                        Width="180px" >
                    </asp:DropDownList>
                </td>
                <td class="style20">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"   ValidationGroup="s" 
                        ControlToValidate="ddlsession" ErrorMessage="Session is Required" 
                        ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style19">
                    Semester</td>
                <td class="style21">
                    <asp:DropDownList ID="ddlsem" runat="server" Width="180px">
                    </asp:DropDownList>
                </td>
                <td class="style20">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"   ValidationGroup="s" 
                        ControlToValidate="ddlsem" ErrorMessage="Semester is Required" 
                        ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style22">
                    Courses</td>
                <td class="style23">
                    <asp:DropDownList ID="ddlclass" runat="server" Width="180px">
                    </asp:DropDownList>
                </td>
                <td class="style24">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"   ValidationGroup="s" 
                        ControlToValidate="ddlclass" ErrorMessage="Courses is Required" 
                        ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style19">
                    Father Name</td>
                <td class="style21">
                    <asp:TextBox ID="txtfnm" runat="server" Width="180px"></asp:TextBox>
                </td>
                <td class="style20">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorFN" runat="server"   ValidationGroup="s" 
                        ControlToValidate="txtfnm" ErrorMessage="Father's name is Required" 
                        ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    Mother Name</td>
                <td class="style18">
                    <asp:TextBox ID="txtmnm" runat="server" Width="180px"></asp:TextBox>
                </td>
                <td class="style16">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorMN" runat="server"  ValidationGroup="s"  
                        ControlToValidate="txtmnm" ErrorMessage="Mother's name is Required" 
                        ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style19">
                    DOB</td>
                <td class="style21">
                    <asp:TextBox ID="txtdob" runat="server"  Width="180px"></asp:TextBox>
                </td>
                <td class="style20">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDOB" runat="server"   ValidationGroup="s" 
                        ControlToValidate="txtdob" ErrorMessage="DOB is Required" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style19">
                    Permanent Address</td>
                <td class="style21">
                    <asp:TextBox ID="txtperadd" runat="server" Width="180px"></asp:TextBox>
                </td>
                <td class="style20">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorAdd" runat="server"   ValidationGroup="s" 
                        ControlToValidate="txtperadd" ErrorMessage="Address is Required" 
                        ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style19">
                    City</td>
                <td class="style21">
                    <asp:TextBox ID="txtcity" runat="server" Width="180px"></asp:TextBox>
                </td>
                <td class="style20">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCity" runat="server"   ValidationGroup="s" 
                        ControlToValidate="txtcity" ErrorMessage="City is Required" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style19">
                    Pincode</td>
                <td class="style21">
                    <asp:TextBox ID="txtpin" runat="server" Width="180px"></asp:TextBox>
                </td>
                <td class="style20">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPin" runat="server"   ValidationGroup="s" 
                        ErrorMessage="Pincode is Required" ForeColor="Red" 
                        ControlToValidate="txtpin">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style19">
                    Password</td>
                <td class="style21">
                    <asp:TextBox ID="txtpass" runat="server" TextMode="Password" Width="180px" 
                        meta:resourcekey="TextBoxPWResource1"></asp:TextBox>
                </td>
                <td class="style20">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPW" runat="server"  ValidationGroup="s"  
                        ControlToValidate="txtpass" ErrorMessage="Password is Required" 
                        ForeColor="Red" meta:resourcekey="RequiredFieldValidatorPWResource1">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style19">
                    Confirm Password</td>
                <td class="style21">
                    <asp:TextBox ID="TextBoxCPw" runat="server" TextMode="Password" Width="180px" 
                        meta:resourcekey="TextBoxCPwResource1"></asp:TextBox>
                </td>
                <td class="style20">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCPw" runat="server"   ValidationGroup="s" 
                        ControlToValidate="TextBoxCPw" ErrorMessage="Confirm Password is Required" 
                        ForeColor="Red" meta:resourcekey="RequiredFieldValidatorCPwResource1">*</asp:RequiredFieldValidator>
                    <br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server"   
                        ControlToCompare="txtpass" ControlToValidate="TextBoxCPw" 
                        ErrorMessage="Both Password must be same" ForeColor="Red" 
                        meta:resourcekey="CompareValidator1Resource1" ValidationGroup="s">*</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="style19">
                    Mobile No</td>
                <td class="style21">
                    <asp:TextBox ID="txtContactno" runat="server"></asp:TextBox>
                </td>
                <td class="style15">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style19">
                    &nbsp;</td>
                <td class="style17">
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" 
                        meta:resourcekey="Button1Resource1" style="margin-left: 0px" 
                        ValidationGroup="s" />
                    <input id="Reset1" type="reset" value="reset" /></td>
                <td class="style15">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9" colspan="3">
                    <asp:Label ID="lblmsg" runat="server" ForeColor="#993300"></asp:Label>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        ValidationGroup="s" />
                </td>
            </tr>
        </table>
    
    </div>
 </asp:Content>   
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
    .style7
    {
        font-size: xx-large;
        color: #000000;
    }
        .style9
        {
            text-align: center;
        }
        .style11
        {
            width: 164px;
            height: 50px;
            text-align: right;
        }
        .style14
        {
            font-size: xx-large;
            color: #CCFFFF;
            top: 60%;
        }
        .style15
        {
            width: 253px;
            text-align: center;
        }
        .style16
        {
            width: 253px;
            height: 50px;
            text-align: left;
        }
        .style17
        {
            width: 220px;
            text-align: center;
        }
        .style18
        {
            width: 220px;
            height: 50px;
            }
        .style19
        {
            text-align: right;
        }
        .style20
        {
            width: 253px;
            text-align: left;
        }
        .style21
        {
            width: 220px;
        }
        .style22
        {
            text-align: right;
            height: 29px;
        }
        .style23
        {
            width: 220px;
            height: 29px;
        }
        .style24
        {
            width: 253px;
            text-align: left;
            height: 29px;
        }
    </style>
    </asp:Content>    


